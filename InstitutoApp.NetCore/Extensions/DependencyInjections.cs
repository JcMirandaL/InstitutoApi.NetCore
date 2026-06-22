using InstitutoApp.Common.Interfaces;
using InstitutoApp.Data;
using InstitutoApp.DTOs.CursoDTOs;
using InstitutoApp.DTOs.EstudianteDTOs;
using InstitutoApp.Repository;
using InstitutoApp.Services;
using InstitutoApp.Services.Mapping;
using Microsoft.EntityFrameworkCore;


namespace InstitutoApp.Api.Extensions
{
    public static class DependencyInjections
    {

        public static IServiceCollection AddAplicationServices(
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            //base datos dbContext
            //el applicationDbContex es el contexto de la base de datos que se va a usar
            //para acceder a la base de datos, y se le pasa la configuracion del string de conexion
            services.AddDbContext<ApplicationDbContex>(options =>
            {
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"));
            });


            //refrencia al autoMapper(injeccion de dependencia)
            //mappingProfile.cs donde se definen los mapeos entre los DTOs y las entidades
            services.AddAutoMapper(fg => { }, typeof(MappingProfile));


            //inyecciones de dependencia de services
            //defino las inyeccion de dependencias
            services.AddScoped<IGenericService<EstudianteResponseDTO, EstudianteCreatedDTO, EstudianteUpdateDTO>, EstdianteService>();
            services.AddScoped<IGenericService<CursoResponseDTO, CursoCreatedDTO, CursoUpdateDTO>, CursoService>();



            //inyecciones de dependencia de repository
            services.AddScoped<EstdianteRepository>();
            services.AddScoped<CursoRepository>();


            return services;
        }
    }
}
