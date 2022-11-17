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
    internal class ConstructorConfiguration : IEntityTypeConfiguration<Constructor>
    {
        public void Configure(EntityTypeBuilder<Constructor> builder)
        {
            builder.HasData(new Constructor()
            {
                Id = 1,
                UserId = "7125d323-7567-4f56-b27e-6b7044014a37",
                Salary = 1500
            });
        }
    }
}
