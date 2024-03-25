using Es.Udc.DotNet.ModelUtil.Dao;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;

namespace Es.Udc.DotNet.PracticaMaD.Model.DAOs.UsuarioDao
{
    public class UsuarioDaoEF : GenericDaoEntityFramework<Usuario, Int64>, IUsuarioDaoEF
    {
        //Constructor
        public UsuarioDaoEF() {}

        DbSet<Usuario> usuario = Context.Set<Usuario>();

        Usuario IUsuarioDaoEF.findAllUsers()
        {
            var result = from user in usuario where user.user_name == "User3" select user;

            return result;
        }
    }
}
