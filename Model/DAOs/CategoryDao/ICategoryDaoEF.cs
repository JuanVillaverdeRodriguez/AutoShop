using Es.Udc.DotNet.ModelUtil.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Udc.DotNet.PracticaMaD.Model.DAOs.CategoryDao
{
    public interface ICategoryDaoEF : IGenericDao<Category, Int64>
    {
        //devuelve la categoría encontrada segun el id de categoría
        //devuelve InstanceNotFoundException si no encuentra la categoría
        Category findCategoryById(long categoryId);

    }
}
