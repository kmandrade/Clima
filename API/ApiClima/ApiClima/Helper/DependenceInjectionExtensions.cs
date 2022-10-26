using ApiClima.ClimateServices;
using ApiClima.Models;
using Domain.Entities;
using Domain.Repositories.Base;
using Domain.Repositories.Clima;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiClima.Helper
{
    public static class DependenceInjectionExtensions
    {
        public static IServiceCollection AddDependenceInjection(this IServiceCollection services)
        {
            services.AddScoped<IClimateRepository, ClimateRepository>();
            services.AddScoped<IClimateService, ClimateService>();

            return services;
        }
    }
}
