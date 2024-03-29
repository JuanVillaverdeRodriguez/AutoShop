﻿using Es.Udc.DotNet.PracticaMaD.Model.DAOs.UsuarioDao;
using Es.Udc.DotNet.PracticaMaD.Model.DAOs.WorkshopDao;
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

        //-------------------------------------------------------------------
        // ----------------------Registro de usuario-------------------------
        //-------------------------------------------------------------------


        [Transactional]
        long RegisterUsuario(String loginName, String clearPassword, UserProfileDetails userProfileDetails);

        //-------------------------------------------------------------------
        // ----------------------Autenticacion y salida ---------------------
        //-------------------------------------------------------------------

        [Transactional]
        SignInResult SignIn(String loginName, String password);

        [Transactional]
        UserProfileDetails FindUserProfileDetails(long userProfileId);

        [Transactional]
        void UpdateUserProfileDetails(long userProfileId,
            UserProfileDetails userProfileDetails);

        [Transactional]
        long RegisterWorkshop(int postalCode, String location, String workshopName);

        [Transactional]
        string GetUserName(long usrId);

        [Transactional]
        void UpdateCard(long cardNumber, long userProfileId, String type, int csv, DateTime endDate);

        void ChangePassword(long userProfileId, String oldClearPassword,
            String newClearPassword);

        bool UserExists(string loginName);

        

       

    }
}
