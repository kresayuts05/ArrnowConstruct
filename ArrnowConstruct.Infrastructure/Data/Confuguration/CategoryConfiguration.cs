using ArrnowConstruct.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrnowConstruct.Infrastructure.Data.Confuguration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(CreateCategories());
        }

        internal static List<Category> CreateCategories()
        {
            var categories = new List<Category>();

            var category = new Category()
            {
                Id = 1,
                Name = "Kitchen"
            };

            categories.Add(category);

            category = new Category()
            {
                Id = 2,
                Name = "Bathroom"
            };

            categories.Add(category);

            category = new Category()
            {
                Id = 3,
                Name = "Bedroom"
            };

            categories.Add(category);
            category = new Category()
            {
                Id = 4,
                Name = "LivingRoom"
            };

            categories.Add(category);

            category = new Category()
            {
                Id = 5,
                Name = "DiningRoom"
            };

            categories.Add(category);

            category = new Category()
            {
                Id = 6,
                Name = "Hall"
            };

            categories.Add(category);

            category = new Category()
            {
                Id = 7,
                Name = "Office"
            };

            categories.Add(category);


            category = new Category()
            {
                Id = 8,
                Name = "GameRoom"
            };

            categories.Add(category);

            category = new Category()
            {
                Id = 9,
                Name = "Pantry"
            };

            categories.Add(category);

            category = new Category()
            {
                Id = 10,
                Name = "Toilet"
            };

            categories.Add(category);

            category = new Category()
            {
                Id = 11,
                Name ="UtilityRoom"
            };

            categories.Add(category);

            category = new Category()
            {
                Id = 12,
                Name = "SpareRoom"
            };


            categories.Add(category);

            category = new Category()
            {
                Id = 13,
                Name = "Cellar"
            };


            categories.Add(category);

            category = new Category()
            {
                Id = 14,
                Name = "Attic"
            };


            categories.Add(category);
            return categories;
        }
    }
}
