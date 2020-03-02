using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Gol.Domain.Interfaces.Repositories;
using Gol.Domain.Interfaces.Services;
using Gol.Infra.Data.Context;
using Gol.Infra.Data.Repository;
using Gol.Service.Services;

namespace Gol.IoC.DependencyResource
{
    public static class DependencyResolver
    {
        public static void Resolve(IServiceCollection services, IConfiguration Configuration)
        {
            //services.AddDbContext<RHContext>(options =>
            //    options.UseSqlServer("",
            //        b => b.MigrationsAssembly("Gol.Api")
            //        .UseRowNumberForPaging()));


            services.AddDbContext<ContextDb>(options =>
            {
                options.UseInMemoryDatabase("GolDb");

            });

            services.AddScoped(typeof(IService<>), typeof(BaseService<>));
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));

            services.AddScoped<ITravelRepository, TravelRepository>();
            services.AddScoped<IAuthRepository, AuthRepository>();

            services.AddScoped<ITravelService, TravelService>();
            services.AddScoped<IAuthService, AuthService>();
        }
    }
}
