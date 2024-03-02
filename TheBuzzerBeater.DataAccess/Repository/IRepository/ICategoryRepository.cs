using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBuzzerBeater.Models;

namespace TheBuzzerBeater.DataAccess.Repository.IRepository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        void Update(Category obj);
        Category GetCategoryByName(string categoryName, bool includeProducts = false, bool includeSubcategories = false);
        IEnumerable<Category> GetCategories();
    }
}
