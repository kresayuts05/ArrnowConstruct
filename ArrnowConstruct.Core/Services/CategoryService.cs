using ArrnowConstruct.Core.Contarcts;
using ArrnowConstruct.Core.Models.Category;
using ArrnowConstruct.Infrastructure.Data.Common;
using ArrnowConstruct.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrnowConstruct.Core.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository repo;

        public CategoryService(IRepository _repo)
        {
            repo = _repo;
        }


        public async Task<IEnumerable<CategoryModel>> AllCategories()
        {
            return await repo.AllReadonly<Category>()
                 .Select(c => new CategoryModel()
                 {
                     Id = c.Id,
                     Name = c.Name
                 })
                 .ToListAsync();
        }

        public async Task<IEnumerable<string>> AllCategoriesNames()
        {
            return await repo.AllReadonly<Category>()
              .Select(c => c.Name)
              .Distinct()
              .ToListAsync();
        }

        public async Task<IEnumerable<Category>> CategoriesById(List<int> ids)
        {
            return await repo.All<Category>()
                 .Where(c => ids.Contains(c.Id))
                 .ToListAsync();
        }
    }
}
