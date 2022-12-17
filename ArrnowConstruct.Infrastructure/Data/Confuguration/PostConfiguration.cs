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
    internal class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasData(CreatePosts());
        }

        internal static List<Post> CreatePosts()
        {
            List<Post> posts = new List<Post>();

            posts.Add(new Post()
            {
                Id = 1,
                Description = "My description is very short, but meaningful",
                ShortContent = "The short content is even shorter",
                Title = "The best post",
                SiteId = 2,
                Image = new List<Image>()
            }) ;

            return posts;
        }
    }
}
