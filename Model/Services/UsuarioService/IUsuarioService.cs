using Es.Udc.DotNet.PracticaMaD.Model.DAOs.UsuarioDao;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Es.Udc.DotNet.ModelUtil.Transactions;

namespace Es.Udc.DotNet.PracticaMaD.Model.Services.UsuarioService
{
    public interface IUsuarioService
    {
        [Inject]
        IUsuarioDaoEF UsuarioDao { get; set; }

        //-------------------------------------------------------------------
        // ----------------------Registro de usuario-------------------------
        //-------------------------------------------------------------------


        [Transactional]
        long RegisterUsuario(String loginName, String clearPassword, UserProfileDetails userProfileDetails);

        //-------------------------------------------------------------------
        // ----------------------Autenticacion y salida ---------------------
        //-------------------------------------------------------------------

        [Transactional]
        LoginResult Login(String loginName, String password,
            Boolean passwordIsEncrypted);

        [Transactional]
        UserProfileDetails FindUserProfileDetails(long userProfileId);

        [Transactional]
        void UpdateUserProfileDetails(long userProfileId,
            UserProfileDetails userProfileDetails);

        [Transactional]
        void RegisterWorkshop(long workshopId, int postalCode, String location, String workshopName);

        [Transactional]
        string GetUserName(long usrId);

        [Transactional]
        void UpdateCard(long cardNumber, long userProfileId, String type, int csv, DateTime endDate);

        void ChangePassword(long userProfileId, String oldClearPassword,
            String newClearPassword);

        bool UserExists(string loginName);

        

       

    }
}
