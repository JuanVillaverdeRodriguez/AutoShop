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
using Es.Udc.DotNet.PracticaMaD.Model.Services.PurchaseService;

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

        //Registra un nuevo usuario
        //Lanza DuplicateInstanceException si el usuario ya existe
        [Transactional]
        long RegisterUsuario(String alias, String password, UserProfileDetails userProfileDetails);

        //Logea al usuario
        //Si los campos fallan (error de contraseña) Lanza un MistakenCredentialsException
        [Transactional]
        SignInResult SignIn(String alias, String password);

        //Busca los detalles de usuario dado su userId
        //Devuelve InstanceNotFoundException si no existe el usuario
        [Transactional]
        UserProfileDetails FindUsuarioDetails(long userId);

        //Modifica los la información basica de un usuario
        //Lanza InstanceNotFoundException si no existe el usuario
        [Transactional]
        void UpdateUsuarioDetails(long userProfileId, UserProfileDetails userProfileDetails);

        //Registra un nuevo taller
        //Lanza DuplicateInstanceException si el taller ya existía
        [Transactional]
        long RegisterWorkshop(int postalCode, String workshopName);

        //Crea una nueva tarjeta para un usuario
        //Si el usuario ya tiene tarjetas y alguna de ellas por defecto, crea una tarjeta que no esté por defecto
        //Si el usuario no tiene más tarjetas antes de crear la nueva, crea una tarjeta por defecto
        //Lanza DuplicateInstanceException si la tarjeta ya existe
        [Transactional]
        void CreateCard(long cardNumber, long userId, String type, int csv, DateTime expirationDate);

        //Elimina una tarjeta y, en caso de que el usuario tuviese más tarjetas pone la primera por defecto
        //Lanza InstanceNotFoundException si la tarjeta no existe
        //Lanza InstanceNotFoundException si el usuario no tiene ninguna tarjeta
        [Transactional]
        void DeleteCard(long cardNumber, long userId);
        
        //Devuelve una lista con todas las tarjetas
        [Transactional]
        List<CardInfoResult> findUsuarioCards(long usuarioId);

        /*No implementadas, lanzan NotImplementedException*/
        [Transactional]
        string GetUserName(long usrId);

        void ChangePassword(long userProfileId, String oldClearPassword, String newClearPassword);

        

       

    }
}
