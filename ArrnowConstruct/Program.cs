using ArrnowConstruct.Extensions;
using ArrnowConstruct.Infrastructure.Data;
using ArrnowConstruct.Infrastructure.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using dotenv.net;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

        builder.Services.AddDbContext<ArrnowConstructDbContext>(options =>
            options.UseSqlServer(connectionString));
        builder.Services.AddDatabaseDeveloperPageExceptionFilter();

        builder.Services.AddDefaultIdentity<User>(options =>
        {
            options.SignIn.RequireConfirmedAccount = false;
            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = false;
        })
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<ArrnowConstructDbContext>();
        builder.Services.AddControllersWithViews();

        builder.Services.ConfigureApplicationCookie(options =>
        {
            options.LoginPath = "/User/Login";
            options.LogoutPath = "/User/Logout";
        });

        //builder.Services.AddAuthorization(options =>
        //{
        //    options.AddPolicy("MyPolicy", policy =>
        //    {
        //        policy.RequireRole("Admin");
        //        policy.RequireClaim("EmployeeNumber");
        //    });
        //});

        builder.Services.AddApplicationServices();
        ConfigureCloudaryService(builder.Services, builder.Configuration);

        builder.Services.AddResponseCaching();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            //app.UseMigrationsEndPoint();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapRazorPages();
            endpoints.MapControllerRoute(
              name: "default",
              pattern: "{controller=Home}/{action=Index}/{id?}"
            );

            endpoints.MapControllerRoute(
              name: "areas",
              pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
            );
        });

        app.UseResponseCaching();

        app.Run();
    }

    //Cloudinary api
    private static void ConfigureCloudaryService(IServiceCollection services, IConfiguration configuration)
    {
        var cloudName = configuration.GetValue<string>("AccountSettings:CloudName");
        var apiKey = configuration.GetValue<string>("AccountSettings:ApiKey");
        var apiSecret = configuration.GetValue<string>("AccountSettings:ApiSecret");

        if (new[] { cloudName, apiKey, apiSecret }.Any(string.IsNullOrWhiteSpace))
        {
            throw new ArgumentException("Please specify your Cloudinary account Information");
        }

        services.AddSingleton(new Cloudinary(new Account(cloudName, apiKey, apiSecret)));
    }
}