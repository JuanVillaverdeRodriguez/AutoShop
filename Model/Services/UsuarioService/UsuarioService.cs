using Es.Udc.DotNet.PracticaMaD.Model.DAOs.UsuarioDao;
using Es.Udc.DotNet.PracticaMaD.Model.DAOs.WorkshopDao;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Es.Udc.DotNet.ModelUtil.Transactions;
using System.Management.Instrumentation;
using Es.Udc.DotNet.ModelUtil.Exceptions;
using Es.Udc.DotNet.PracticaMaD.Model.Services.Exceptions;
using Es.Udc.DotNet.PracticaMaD.Model.DAOs.CardDao;

namespace Es.Udc.DotNet.PracticaMaD.Model.Services.UsuarioService
{
    public class UsuarioService : IUsuarioService
    {
        public UsuarioService() {}

        [Inject]
        public IUsuarioDaoEF UsuarioDao { get; set; }

        [Inject]
        public IWorkshopDaoEF WorkshopDao { get; set; }

        [Inject]
        public ICardDaoEF CardDao { get; set; }


        [Transactional]
        public long RegisterUsuario(string loginName, string clearPassword, UserProfileDetails userProfileDetails)
        {
            // 1) Comprobar si el usuario ya existe
                // 1.1) Si el usuario ya existe lanzar excepcion
                // 1.2) Si el usuario no existe seguir
            // 2) Añadir al usuario a la base de datos

            try {
                //Si no existe, lanzará una excepcion
                Usuario user = UsuarioDao.findUsuarioByAlias(loginName);

                //Cambiar por una excepcion más precisa
                throw new DuplicateInstanceException(user, "El usuario {user} ya existe");

            }
            catch (ModelUtil.Exceptions.InstanceNotFoundException) {
                // Deberiamos poner la contraseña encriptada
                //String passwordEncrypted = PasswordEncrypter.Crypt(clearPassword);

                Usuario newUser = new Usuario();

                newUser.alias = loginName;
                newUser.password = clearPassword; // Poner contraseña encriptada
                newUser.user_name = userProfileDetails.user_name;
                newUser.user_surname = userProfileDetails.user_surname;
                newUser.email = userProfileDetails.email;
                newUser.workshopId = userProfileDetails.workshopId;
                newUser.language = userProfileDetails.language;

                UsuarioDao.Create(newUser);

                return newUser.userId;
            }
        }

        public void ChangePassword(long userProfileId, string oldClearPassword, string newClearPassword)
        {
            throw new NotImplementedException();
        }

        [Transactional]
        public UserProfileDetails FindUsuarioDetails(long userId)
        {
            try
            {
                Usuario user =
                UsuarioDao.Find(userId);

                UserProfileDetails details = new UserProfileDetails(user.user_name, user.user_surname, user.email, user.language, user.workshopId);
                return details;

            }
            catch (Exception)
            {
                throw new ModelUtil.Exceptions.InstanceNotFoundException(userId, "no existe el usuario");
            }
        }

        public string GetUserName(long usrId)
        {
            throw new NotImplementedException();
        }

        [Transactional]
        public UserProfileDetails SignIn(string loginName, string password)
        {
                
            // Si el usuario existe, se hace el login
            // Si el usuario no existe, se lanza excepcion

            try
            {
                Usuario user = UsuarioDao.findUsuarioByAlias(loginName);

                if (!password.Equals(user.password))
                {
                    throw new MistakenPasswordException(loginName);
                }

                UserProfileDetails signInResult = new UserProfileDetails(user.user_name, user.user_surname, user.email, user.language, user.workshopId);

                return signInResult;
            }
            catch (Exception e)
            {
                // Cambiar por excepcion general, obtener la excepcion interior para saber el error:
                // Posibles fallos : De red, de acceso a bd, de contraseña o usuario incorrecto (MistakenCredentialsException)
                throw new MistakenCredentialsException(loginName, e);
            }

        }

        [Transactional]
        public long RegisterWorkshop(int postalCode, string location, string workshopName)
        {
            // 1) Comprobar si el taller ya existe
                // 1.1) Si el taller ya existe lanzar excepcion
                // 1.2) Si el taller no existe seguir
            // 2) Añadir el taller a la base de datos

            try {
                //Si no existe, lanzará una excepcion
                Workshop wshop = WorkshopDao.findWorkshopByName(workshopName);

                //Cambiar por una excepcion más precisa
                throw new DuplicateInstanceException(wshop, "El taller {wshop} ya existe");

            }
            catch (ModelUtil.Exceptions.InstanceNotFoundException) {

                Workshop newWshop = new Workshop();

                newWshop.Country = location;
                newWshop.postal_code = postalCode;
                newWshop.workshop_name = workshopName;

                WorkshopDao.Create(newWshop);

                return newWshop.workshopId;
            }
        }

        [Transactional]
        public void UpdateUsuarioDetails(long userId, UserProfileDetails userProfileDetails)
        {
            try
            {
                Usuario user = UsuarioDao.Find(userId);

                user.user_name = userProfileDetails.user_name;
                user.user_surname = userProfileDetails.user_surname;
                user.email = userProfileDetails.email;
                user.language = userProfileDetails.language;

                UsuarioDao.Update(user);

            }catch (Exception)
            {
                throw new ModelUtil.Exceptions.InstanceNotFoundException(userId, "no existe el usuario");
            }
        }

        [Transactional]
        public void CreateCard(long cardNumber, long userId, string type, int csv, DateTime expirationDate)
        {
            bool flagDefault = false;
            try
            {
                Card card = CardDao.Find(cardNumber);
                throw new DuplicateInstanceException(card, "La tarjeta ya existe");
            }
            catch (ModelUtil.Exceptions.InstanceNotFoundException)
            {
                List<Card> cards = CardDao.findCardsByUsuarioId(userId);

                if (!cards.Any())
                    flagDefault = true;

                Card newCard = new Card();
                newCard.card_number = cardNumber;
                newCard.csv = csv;
                newCard.expiration_date = expirationDate;
                newCard.type = type;
                newCard.userId = userId;

                newCard.defaultCard = flagDefault;

                CardDao.Create(newCard);
            }
        }

        [Transactional]
        public void DeleteCard(long cardNumber, long userId)
        {
            Card card = new Card();
            try
            {
                card = CardDao.Find(cardNumber);

                if (card.userId == userId)
                {
                    CardDao.Remove(cardNumber);

                    if (card.defaultCard)
                    {
                        try
                        {
                            List<Card> cards = CardDao.findCardsByUsuarioId(userId);
                            Card firstCard = cards.First();
                            firstCard.defaultCard = true;
                            CardDao.Update(firstCard);
                        }
                        catch (Exception)
                        {
                            throw new ModelUtil.Exceptions.InstanceNotFoundException(card, "No hay mas tarjetas");
                        }
                    }
                }
            }
            catch
            {
                throw new ModelUtil.Exceptions.InstanceNotFoundException(card, "La tarjeta no existe");
            }
        }
        public List<Card> GetAllCards()
        {
            return CardDao.GetAllElements();
    }
    }

    

}
