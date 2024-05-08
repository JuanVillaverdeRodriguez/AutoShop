using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using System.Management.Instrumentation;
using Es.Udc.DotNet.ModelUtil.Exceptions;
using Es.Udc.DotNet.ModelUtil.Dao;

namespace Es.Udc.DotNet.PracticaMaD.Model.DAOs.CategoryDao
{
    public class CategoryDaoEF : GenericDaoEntityFramework<Category, Int64>, ICategoryDaoEF
    {

        public CategoryDaoEF() { }

        Category cat = null;
        public Category findCategoryById(long categoryId)
        {
            DbSet<Category> category = Context.Set<Category>();

            var result = (from cat in category where cat.categoryId == categoryId select cat);

            cat = result.FirstOrDefault();
            if (cat == null)
                throw new ModelUtil.Exceptions.InstanceNotFoundException(cat, "No existe una categoría asociada {categoryId}");

            return cat;
        }

        public String findFatherCategoryByCategoryName(string categoryname)
        {
            DbSet<Category> category = Context.Set<Category>();

            var result = (from cat in category where cat.fatherId != null && cat.categoryName == categoryname select cat);

            cat = result.FirstOrDefault();
            if (cat == null)
                return "";

            long fatherid = (long) cat.fatherId;
            return this.Find(fatherid).categoryName;
        }
    }
}
