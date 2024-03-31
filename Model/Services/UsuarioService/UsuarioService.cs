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

        public UserProfileDetails FindUserProfileDetails(long userProfileId)
        {
            throw new NotImplementedException();
        }

        public string GetUserName(long usrId)
        {
            throw new NotImplementedException();
        }

        public SignInResult SignIn(string loginName, string password)
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

                SignInResult signInResult = new SignInResult(user.user_name, user.user_surname, user.email, user.workshopId, user.language);

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

        public void UpdateUserProfileDetails(long userId, UserProfileDetails userProfileDetails)
        {
            try
            {
                Usuario user =
                UsuarioDao.Find(userId);

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

        //Probablemente no hace falta implementarla
        public bool UserExists(string loginName)
        {
            throw new NotImplementedException();
        }

        public void CreateCard(long cardNumber, long userId, string type, int csv, DateTime expirationDate)
        {
            bool flagDefault = true;

            try
            {
                //Si no existe, lanzará una excepcion
                List<Card> cards = CardDao.findCardsByUsuarioId(userId);

                try
                {
                    Card card = CardDao.Find(cardNumber);

                } catch (Exception)
                {
                    flagDefault = false;
                    throw new DuplicateInstanceException(cards, "La tarjeta ya existe");

                }
                

                //throw new DuplicateInstanceException(user, "El usuario {user} ya existe");

            }
            catch (Exception)
            {
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

        public void DeleteCard(long cardNumber, long userId)
        {
            try
            {
                Card card = CardDao.Find(cardNumber);

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
                            throw new Exception("No hay mas tarjetas");
                        }
                    }
                }
            }
            catch
            {
                throw new Exception("La tarjeta no existe");
            }
        }
        public List<Card> GetAllCards()
        {
            return CardDao.GetAllElements();
    }
    }

    

}
