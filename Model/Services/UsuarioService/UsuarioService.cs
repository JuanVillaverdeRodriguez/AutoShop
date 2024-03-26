using Es.Udc.DotNet.PracticaMaD.Model.DAOs.UsuarioDao;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Es.Udc.DotNet.ModelUtil.Transactions;
using System.Management.Instrumentation;
using Es.Udc.DotNet.ModelUtil.Exceptions;

namespace Es.Udc.DotNet.PracticaMaD.Model.Services.UsuarioService
{
    public class UsuarioService : IUsuarioService
    {
        public UsuarioService() {}

        [Inject]
        public IUsuarioDaoEF UsuarioDao { get; set; }


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

        public LoginResult Login(string loginName, string password, bool passwordIsEncrypted)
        {
            throw new NotImplementedException();
        }
        public void RegisterWorkshop(long workshopId, int postalCode, string location, string workshopName)
        {
            throw new NotImplementedException();
        }

        public void UpdateCard(long cardNumber, long userProfileId, string type, int csv, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public void UpdateUserProfileDetails(long userProfileId, UserProfileDetails userProfileDetails)
        {
            throw new NotImplementedException();
        }

        public bool UserExists(string loginName)
        {
            throw new NotImplementedException();
        }
    }   
}
