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
    internal class PostImageConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasData(AddImageToPost());
         }

        private List<Post> AddImageToPost()
        {
            var posts = PostConfiguration.CreatePosts();
            var image =( List<Image>)ImageComfiguration.CreateImages();

            posts[0].Image.Add(image[0]);

            return posts;
        }
    }
}
