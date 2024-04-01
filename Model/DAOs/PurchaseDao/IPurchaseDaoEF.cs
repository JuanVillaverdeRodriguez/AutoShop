using Es.Udc.DotNet.ModelUtil.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Udc.DotNet.PracticaMaD.Model.DAOs.PurchaseDao
{
    public interface IPurchaseDaoEF : IGenericDao<Purchase, Int64>
    {
        //Devuelve la lista de pedidos realizados por un usuario
        //Devuelve lista vacía si no ha realizado ningún pedido
        List<Purchase> GetPurchases(long usuarioId);

        //Devuelve el id de purchase más alto encontrado en la tabla
        long GetMaxPurchaseId();

        Purchase GetPurchaseByPK(long purchaseId, long productId);
    }
}
