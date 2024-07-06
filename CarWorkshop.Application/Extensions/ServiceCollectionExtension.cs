using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarWorkshop.Application.CarWorkshop;
using CarWorkshop.Application.Mapping;
using CarWorkshop.Application.Service;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace CarWorkshop.Application.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped<ICarWorkshopService, CarWorkshopService>();      //description: Add CarWorkshopService to the services container

            services.AddAutoMapper(typeof(CarWorkshopMappingProfile));          //add automapper to the services container

            //add validators 
            services.AddValidatorsFromAssemblyContaining<CarWorkshopDtoValidator>()
                .AddFluentValidationAutoValidation() //
                .AddFluentValidationClientsideAdapters();
        }

    }

}
