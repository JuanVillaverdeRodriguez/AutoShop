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
        //Encuentra a un usuario y lo devuelve dado un alias
        //puede lanzar excepción InstanceNotFoundException si no encuentra al usuario
        Usuario findUsuarioByAlias(string loginName);
    }
}
