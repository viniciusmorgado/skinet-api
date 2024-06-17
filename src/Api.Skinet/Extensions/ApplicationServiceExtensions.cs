using Api.Skinet.Errors;
using Domain.Skinet.Interfaces;
using Infrastructure.Skinet.Data;
using Infrastructure.Skinet.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Skinet.Extensions;

public static class ApplicationServiceExtensions
{
    public static IServiceCollection AddApplicationServices( this IServiceCollection services
                                                           , IConfiguration configuration )
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddDbContext<StoreContext>(opt =>
        {
            opt.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
        });
        // services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        services.Configure<ApiBehaviorOptions>(options => 
        {
            options.InvalidModelStateResponseFactory = actionContext => 
            {
                var errors = actionContext.ModelState.Where(e => e.Value.Errors.Count > 0)
                                                     .SelectMany(x => x.Value.Errors)
                                                     .Select(x => x.ErrorMessage)
                                                     .ToArray();

                var errorResponse = new ApiValidationErrorResponse
                {
                    Errors = errors
                };

                return new BadRequestObjectResult(errorResponse);
            };
        });
        
        return services;
    }
}
