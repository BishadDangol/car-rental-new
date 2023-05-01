using car_rental.application.Common.Interface;
using car_rental.domain.Entities;
using car_rental.infrastructure.Persistence;
using car_rental.infrastructure.Services;
using CarRentalSystem.Application.Common.Services;
using CarRentalSystem.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace car_rental.infrastructure.DI
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)), ServiceLifetime.Singleton
            );

            //        services.AddIdentity<IdentityUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
            //.AddEntityFrameworkStores<ApplicationDbContext>()
            //.AddDefaultUI()
            //.AddDefaultTokenProviders();
            services.AddIdentity<IdentityUser, IdentityRole>(options =>
          options.SignIn.RequireConfirmedAccount = true)
          .AddDefaultTokenProviders()
          .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(100);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
            HttpClient httpClient = new HttpClient();

            Uri baseAddress = httpClient.BaseAddress;

            services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(baseAddress.ToString()) });
            //services.AddScoped<UserManager<User>>();
            //services.AddScoped<SignInManager<User>>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IFileService, FileService>();
            services.AddTransient<IUserService, UserService>();


            //services.AddIdentityCore<IdentityUser>(options =>
            //{

            //}).AddEntityFrameworkStores<ApplicationDbContext>();

            //services.AddTransient<IVehicleDetails, VehicleDetails>();

            return services;

        }
    }
}
