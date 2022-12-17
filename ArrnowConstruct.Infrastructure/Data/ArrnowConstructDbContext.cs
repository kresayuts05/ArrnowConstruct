using ArrnowConstruct.Infrastructure.Data.Confuguration;
using ArrnowConstruct.Infrastructure.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ArrnowConstruct.Infrastructure.Data
{
    public class ArrnowConstructDbContext : IdentityDbContext<User>
    {
        private bool seedDb;

        public ArrnowConstructDbContext(DbContextOptions<ArrnowConstructDbContext> options, bool seed = true)
            : base(options)
        {
            if (this.Database.IsRelational())
            {
                this.Database.Migrate();
            }
            else
            {
                this.Database.EnsureCreated();
            }

            seedDb = seed;
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Constructor> Constructors { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Site> Sites { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Image> Image { get; set; }
        //in plural form

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<User>()
                .Property(u => u.UserName)
                .HasMaxLength(20)
                .IsRequired();

            builder.Entity<User>()
                .Property(u => u.Email)
                .HasMaxLength(60)
                .IsRequired();

            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new ClientConfiguration());
            builder.ApplyConfiguration(new ConstructorConfiguration());
            builder.ApplyConfiguration(new CategoryConfiguration());
            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new UsersRolesConifiguration());

            //builder.ApplyConfiguration(new RequestConfiguration());
            //builder.ApplyConfiguration(new SiteConfiguration());
            ////builder.ApplyConfiguration(new PostConfiguration());
            ////builder.ApplyConfiguration(new ImageComfiguration());
            ////builder.ApplyConfiguration(new PostImageConfiguration());

            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }
    }
}