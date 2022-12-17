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
    internal class RequestConfiguration : IEntityTypeConfiguration<Request>
    {
        public void Configure(EntityTypeBuilder<Request> builder)
        {
            builder.HasData(CreateRequests());
        }

        private List<Request> CreateRequests()
        {
            List<Request> requests = new List<Request>();
            var categories = CategoryConfiguration.CreateCategories();

            requests.Add(new Request
            {
                Id = 1,
                RoomsCount = 2,
                Area = 30,
                RequiredDate = DateTime.UtcNow,
                Budget = 2000,
                Status = "Waiting",
                ClientId = 1,
                ConstructorId = 1,
                RoomsTypes = new List<Category>() { categories[0], categories[1]},
                IsActive = true
            });

            requests.Add(new Request
            {
                Id = 2,
                RoomsCount = 3,
                Area = 70,
                RequiredDate = DateTime.UtcNow,
                Budget = 2000,
                Status = "Confirmed",
                ClientId = 1,
                ConstructorId = 1,
                RoomsTypes = new List<Category>() { categories[3], categories[5] },
                IsActive = false
            });

            requests.Add(new Request
            {
                Id = 3,
                RoomsCount = 3,
                Area = 70,
                RequiredDate = DateTime.UtcNow,
                Budget = 2000,
                Status = "Confirmed",
                ClientId = 1,
                ConstructorId = 1,
                RoomsTypes = new List<Category>() { categories[2], categories[6] },
                IsActive = false
            });

            return requests;
        }
    }

}