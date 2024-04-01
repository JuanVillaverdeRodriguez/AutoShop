using Es.Udc.DotNet.ModelUtil.Dao;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using System.Management.Instrumentation;
using Es.Udc.DotNet.ModelUtil.Exceptions;

namespace Es.Udc.DotNet.PracticaMaD.Model.DAOs.CardDao
{
    public class CardDaoEF : GenericDaoEntityFramework<Card, Int64>, ICardDaoEF
    {

        public CardDaoEF() { }

        List<Card> ICardDaoEF.findCardsByUsuarioId(long usuarioId)
        {
            DbSet<Card> card = Context.Set<Card>();

            List<Card> result = (from crd in card where crd.userId == usuarioId select crd).ToList();

            return result;
        }
    }
}
