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


namespace Es.Udc.DotNet.PracticaMaD.Model.DAOs.WorkshopDao
{
    public class WorkshopDaoEF : GenericDaoEntityFramework<Workshop, Int64>, IWorkshopDaoEF
    {
        //Constructor
        public WorkshopDaoEF() { }

        Workshop wshop = null;

        Usuario IWorkshopDaoEF.findWorkshopByName(string name)
        {
            DbSet<Workshop> workshop = Context.Set<Workshop>();

            var result = from wshop in workshop where wshop.workshop_name == name select wshop;

            wshop = result.FirstOrDefault();
            if (wshop == null)
                throw new ModelUtil.Exceptions.InstanceNotFoundException(wshop, "No existe el taller {wshop}");

            return wshop;
        }
    }
}