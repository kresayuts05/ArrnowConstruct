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
    internal class SiteConfiguration : IEntityTypeConfiguration<Site>
    {
        public void Configure(EntityTypeBuilder<Site> builder)
        {
            builder.HasData(CreateSites());
        }

        private List<Site> CreateSites()
        {
            List<Site> sites = new List<Site>();
            var categories = CategoryConfiguration.CreateCategories();

            sites.Add(new Site()
            {
                Id = 1,
                RoomsCount = 3,
                Area = 70,
                FromDate = DateTime.UtcNow.AddDays(1),
                ToDate = DateTime.UtcNow.AddDays(3),
                Price = 2000,
                Status = "InProcess",
                ClientId = 1,
                ConstructorId = 1,
                RoomsTypes = new List<Category>() { categories[3], categories[5] }
            });

            sites.Add(new Site()
            {
                Id = 2,
                RoomsCount = 3,
                Area = 70,
                FromDate = DateTime.UtcNow.AddDays(1),
                ToDate = DateTime.UtcNow.AddDays(3),
                Price = 2000,
                Status = "Finished",
                ClientId = 1,
                ConstructorId = 1,
                RoomsTypes = new List<Category>() { categories[2], categories[6] }
            });

            return sites;
        }
    }
}
