using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarWorkshop.Application.Mapping;
//using CarWorkshop.Application.Service;
using FluentValidation;
using FluentValidation.AspNetCore;
using CarWorkshop.Application.CarWorkshop.Commands.CreateCarWorkshop;
using MediatR;

namespace CarWorkshop.Application.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            //services.AddScoped<ICarWorkshopService, CarWorkshopService>();      //description: Add CarWorkshopService to the services container
            services.AddMediatR(typeof(CreateCarWorkshopCommand));

            services.AddAutoMapper(typeof(CarWorkshopMappingProfile));          //add automapper to the services container

            //add validators 
            services.AddValidatorsFromAssemblyContaining<CreateCarWorkshopCommandValidator>()
                .AddFluentValidationAutoValidation() //
                .AddFluentValidationClientsideAdapters();
        }

    }

}
