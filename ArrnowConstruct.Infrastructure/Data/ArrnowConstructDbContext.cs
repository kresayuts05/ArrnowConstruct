using ArrnowConstruct.Infrastructure.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ArrnowConstruct.Infrastructure.Data
{
    public class ArrnowConstructDbContext : IdentityDbContext<User>
    {
        public ArrnowConstructDbContext(DbContextOptions<ArrnowConstructDbContext> options)
            : base(options)
        {
        }

        public DbSet<City> Cities { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Constructor> Constructors { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostComment> PostComments { get; set; }
        public DbSet<PostLikes> PostsLikes { get; set; }
        public DbSet<PostImage> PostImages { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<ReviewComment> ReviewComments { get; set; }
        public DbSet<ReviewImage> ReviewImages { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Site> Sites { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {

            //builder.Entity<User>()
            //    .Property(u => u.UserName)
            //    .HasMaxLength(20)
            //    .IsRequired();

            //builder.Entity<User>()
            //    .Property(u => u.Email)
            //    .HasMaxLength(60)
            //    .IsRequired();

            builder.Entity<PostLikes>().HasKey(k => new
            {
                k.PostId,
                k.UserId,
            });
            base.OnModelCreating(builder);
        }
    }
}