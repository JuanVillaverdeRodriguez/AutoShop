using Es.Udc.DotNet.ModelUtil.Dao;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using System.Management.Instrumentation;

namespace Es.Udc.DotNet.PracticaMaD.Model.DAOs.UsuarioDao
{
    public class UsuarioDaoEF : GenericDaoEntityFramework<Usuario, Int64>, IUsuarioDaoEF
    {
        //Constructor
        public UsuarioDaoEF() {}

        Usuario user = null;

        Usuario IUsuarioDaoEF.findUsuarioByAlias(string alias)
        {
            DbSet<Usuario> usuario = Context.Set<Usuario>();

            var result = from user in usuario where user.alias == alias select user;

            Console.WriteLine($"Usuario encontrado: {alias}");
            user = result.FirstOrDefault();
            if (user == null)
                //TODO: Utilizar una excepcion dedicada
                throw new Exception();

            return user;
        }
    }
}
