using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TheBuzzerBeater.DataAccess.Data;
using TheBuzzerBeater.DataAccess.Repository.IRepository;
using TheBuzzerBeater.Models;

namespace TheBuzzerBeater.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Category obj)
        {
            _db.Categories.Update(obj);
        }
        public Category GetCategoryByName(string categoryName, bool includeProducts = false, bool includeSubcategories = false)
        {
            var query = _db.Categories.AsQueryable();

            if (includeProducts)
            {
                query = query.Include(u => u.Products);
            }

            if (includeSubcategories)
            {
                query = query.Include(u => u.Subcategories)
                    .ThenInclude(s => s.Products);
            }

            return query.FirstOrDefault(u => u.Name == categoryName);
        }
        public IEnumerable<Category> GetCategories()
        {
            return _db.Categories.ToList();
        }
    }
}
