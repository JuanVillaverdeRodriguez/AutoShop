using Es.Udc.DotNet.ModelUtil.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Udc.DotNet.PracticaMaD.Model.DAOs.WorkshopDao
{
    public interface IWorkshopDaoEF : IGenericDao<Workshop, Int64>
    {
        //Devuelve un taller encontrado por nombre
        //Lanza InstanceNotFoundException cuando no se encuentra
        Workshop findWorkshopByName(string WorkshopName);
    }
}