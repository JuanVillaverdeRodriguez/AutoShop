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
        Workshop findWorkshopByName(string WorkshopName);
    }
}