using Es.Udc.DotNet.ModelUtil.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Udc.DotNet.PracticaMaD.Model.DAOs.CardDao
{
    public interface ICardDaoEF : IGenericDao<Card, Int64>
    {
        //Devuelve una lista con las tarjetas pertencientes a un usuario dado.
        //Devuelve lista vacía si no encuentra ninguna.
        List<Card> findCardsByUsuarioId(long usuarioId);

    }
}
