using ArrnowConstruct.Core.Models.Category;
using ArrnowConstruct.Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrnowConstruct.Core.Contarcts
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryModel>> AllCategories();

        Task<IEnumerable<string>> AllCategoriesNames();

        Task<IEnumerable<Category>> CategoriesById(List<int> ids);
    }
}
