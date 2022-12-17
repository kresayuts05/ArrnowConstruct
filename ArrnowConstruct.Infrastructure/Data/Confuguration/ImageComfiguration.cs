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
    internal class ImageComfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.HasData(CreateImages());
        }

        internal static List<Image> CreateImages()
        {
            List<Image> images = new List<Image>();

            images.Add(new Image()
            {
                Id = 1,
                UrlPath = "",
                IsActive = true,
                PostId = 1
            });

            return images;
        }
    }
}
