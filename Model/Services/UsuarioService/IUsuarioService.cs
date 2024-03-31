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

namespace Es.Udc.DotNet.PracticaMaD.Model.Services.UsuarioService
{
    public interface IUsuarioService
    {
        [Inject]
        IUsuarioDaoEF UsuarioDao { get; set; }

        [Inject]
        IWorkshopDaoEF WorkshopDao { get; set; }

        [Inject]
        ICardDaoEF CardDao { get; set;  }

        //-------------------------------------------------------------------
        // ----------------------Registro de usuario-------------------------
        //-------------------------------------------------------------------


        [Transactional]
        long RegisterUsuario(String loginName, String clearPassword, UserProfileDetails userProfileDetails);

        //-------------------------------------------------------------------
        // ----------------------Autenticacion y salida ---------------------
        //-------------------------------------------------------------------

        [Transactional]
        UserProfileDetails SignIn(String loginName, String password);

        [Transactional]
        UserProfileDetails FindUsuarioDetails(long userId);

        [Transactional]
        void UpdateUsuarioDetails(long userProfileId,
            UserProfileDetails userProfileDetails);

        [Transactional]
        long RegisterWorkshop(int postalCode, String location, String workshopName);

        [Transactional]
        string GetUserName(long usrId);

        [Transactional]
        void CreateCard(long cardNumber, long userProfileId, String type, int csv, DateTime expirationDate);

        [Transactional]
        void DeleteCard(long cardNumber, long userId);

        [Transactional]
        List<Card> GetAllCards();

        void ChangePassword(long userProfileId, String oldClearPassword,
            String newClearPassword);

        

       

    }
}
