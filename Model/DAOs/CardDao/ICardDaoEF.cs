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
        List<Card> findCardsByUsuarioId(long usuarioId);

    }
}
