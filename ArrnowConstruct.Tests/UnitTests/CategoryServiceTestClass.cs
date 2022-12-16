using ArrnowConstruct.Core.Contarcts;
using ArrnowConstruct.Core.Models.Category;
using ArrnowConstruct.Core.Services;
using ArrnowConstruct.Infrastructure.Data.Common;
using ArrnowConstruct.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrnowConstruct.Tests.UnitTests
{

    [TestFixture]
    public class CategoryServiceTestClass : UnitTestsBase
    {
        private IRepository repo;
        private ICategoryService categoryService;

        [SetUp]
        public async Task Setup()
        {
            this.repo = new Repository(this.context);
            this.categoryService = new CategoryService(repo);
        }

        [Test]
        public async Task AllCategoriesShouldReturnCorrectCollection()
        {
            var dbCategories = await repo.All<Category>()
                .ToListAsync();

            var allCategories = (List<CategoryModel>)await categoryService.AllCategories();

            Assert.AreEqual(dbCategories.Count, allCategories.Count);
            Assert.AreEqual(dbCategories[1].Id, allCategories[1].Id);
        }

        [Test]
        public async Task AllCategoriesNamesIdShouldReturnCorrectCollection()
        {
            var dbCategories = await repo.All<Category>()
                .Select(c => c.Name)
                .ToListAsync();

            var allNames = (List<string>)await categoryService.AllCategoriesNames();

            Assert.AreEqual(dbCategories.Count, allNames.Count);
            Assert.AreEqual(dbCategories[1], allNames[1]);
        }

        [Test]
        [TestCase(new[] { 1, 2, 3 })]
        [TestCase(new[] { 1,  3, 5, 7 })]
        [TestCase(new[] { 1})]
        public async Task CategoriesByIdsNamesIdShouldReturnCorrectCollection(int[] ids)
        {
            var dbCategories = await repo.All<Category>()
                .Where(c => ids.Contains(c.Id))
                .ToListAsync();

            var allNames = (List<Category>)await categoryService.CategoriesById(ids.ToList());

            Assert.AreEqual(dbCategories.Count, allNames.Count);
            Assert.AreEqual(dbCategories, allNames);
        }
    }
}
