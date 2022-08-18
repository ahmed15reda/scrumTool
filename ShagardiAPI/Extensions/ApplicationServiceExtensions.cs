using Core.Interfaces;
using Infrastructure.IServices;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ShagardiAPI.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<ITFSUserRepository, TFSUserRepository>();
            services.AddScoped<ISquadRepository, SquadRepository>();
            services.AddScoped<ICryptography, Cryptography>();
            services.AddScoped<ISystemConfigsRepository, SystemConfigsRepository>();
            services.AddScoped<IAbsenceTypesRepository, AbsenceTypesRepository>();
            services.AddScoped<IEmployeeAbsenceRepository, EmployeeAbsenceRepository>();

            services.AddScoped<ITFSUserService, TFSUserService>();
            services.AddScoped<ISquadService, SquadService>();
            services.AddScoped<ISystemConfigsService, SystemConfigsService>();
            services.AddScoped<IAbsenceTypesService, AbsenceTypesService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ITokenService, TokenService>();


            return services;
        }
    }
}
