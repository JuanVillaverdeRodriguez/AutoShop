using Es.Udc.DotNet.ModelUtil.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Udc.DotNet.PracticaMaD.Model.DAOs.UsuarioDao
{
    public interface IUsuarioDaoEF : IGenericDao<Usuario, Int64>
    {
        Usuario findAllUsers();
    }
}
