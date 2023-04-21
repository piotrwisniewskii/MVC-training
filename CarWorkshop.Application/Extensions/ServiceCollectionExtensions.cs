using AutoMapper;
using CarWorkshop.Application.ApplicationUser;
using CarWorkshop.Application.CarWorkshop.Commands.CreateCarWorkshop;
using CarWorkshop.Application.Mappings;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CarWorkshop.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(typeof(CreateCarWorkshopCommand));

            services.AddScoped(privder => new MapperConfiguration(cfg =>
            {
                var scope = privder.CreateScope();
                var userContext = scope.ServiceProvider.GetRequiredService<IUserContext>();
                cfg.AddProfile(new CarWorkshopMappingProfile(userContext));
            }).CreateMapper()
            );

            services.AddScoped<IUserContext,UserContext>();
            services.AddValidatorsFromAssemblyContaining<CreateCarWorkshopCommandVallidator>()
                    .AddFluentValidationAutoValidation()
                    .AddFluentValidationClientsideAdapters();

        }
    }
}
