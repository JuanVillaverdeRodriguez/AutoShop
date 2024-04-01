using Es.Udc.DotNet.PracticaMaD.Model.DAOs.UsuarioDao;
using Es.Udc.DotNet.PracticaMaD.Model.DAOs.WorkshopDao;
using Es.Udc.DotNet.PracticaMaD.Model.DAOs.CardDao;
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
        public long RegisterUsuario(string alias, string password, UserProfileDetails userProfileDetails)
        {
            //Comprobar si el usuario ya existe
                //Si el usuario ya existe lanzar excepcion
                //Si el usuario no existe seguir
            //Añadir al usuario a la base de datos

            try {
                //Si no existe, lanzará una excepcion
                Usuario user = UsuarioDao.findUsuarioByAlias(alias);

                //Si existe lanza DuplicateInstanceException
                throw new DuplicateInstanceException(user, "El usuario {user} ya existe");

            }
            catch (ModelUtil.Exceptions.InstanceNotFoundException) {

                Usuario newUser = new Usuario();

                newUser.alias = alias;
                newUser.password = password;
                newUser.user_name = userProfileDetails.user_name;
                newUser.user_surname = userProfileDetails.user_surname;
                newUser.email = userProfileDetails.email;
                newUser.workshopId = userProfileDetails.workshopId;
                newUser.language = userProfileDetails.language;

                //Se Crea el nuevo usuario en la BD
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
        public UserProfileDetails SignIn(string alias, string password)
        {
                
            // Si el usuario existe, se hace el login
            // Si el usuario no existe, se lanza excepcion

            try
            {
                Usuario user = UsuarioDao.findUsuarioByAlias(alias);

                if (!password.Equals(user.password))
                {
                    throw new MistakenPasswordException(alias);
                }

                UserProfileDetails signInResult = new UserProfileDetails(user.user_name, user.user_surname, user.email, user.language, user.workshopId);

                return signInResult;
            }
            catch (Exception e)
            {
                throw new MistakenCredentialsException(alias, e);
            }

        }

        [Transactional]
        public long RegisterWorkshop(int postalCode, string location, string workshopName)
        {
            //Comprobar si el taller ya existe
                //Si el taller ya existe lanzar excepcion
                //Si el taller no existe seguir
            //Añadir el taller a la base de datos

            try {
                //Si no existe, lanzará una excepcion
                Workshop wshop = WorkshopDao.findWorkshopByName(workshopName);

                //Si el taller ya existe lanza DuplicateInstanceException
                throw new DuplicateInstanceException(wshop, "El taller {wshop} ya existe");

            }
            catch (ModelUtil.Exceptions.InstanceNotFoundException) {

                Workshop newWshop = new Workshop();

                newWshop.Country = location;
                newWshop.postal_code = postalCode;
                newWshop.workshop_name = workshopName;

                WorkshopDao.Create(newWshop);

                //Se crea el nuevo taller en la BD
                return newWshop.workshopId;
            }
        }

        [Transactional]
        public void UpdateUsuarioDetails(long userId, UserProfileDetails userProfileDetails)
        {
            try
            {
                //lanza una excepcion si el usuario no existe
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
                //Lanza excepción si no se encuentra tarjeta
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

                //se crea la nueva tarjeta
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
