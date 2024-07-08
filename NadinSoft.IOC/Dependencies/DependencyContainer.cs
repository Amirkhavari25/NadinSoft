using Microsoft.Extensions.DependencyInjection;
using NadinSoft.Application.Services.Implements;
using NadinSoft.Application.Services.Interfaces;
using NadinSoft.Data.Repository;
using NadinSoft.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NadinSoft.IOC.Dependencies
{
    public static class DependencyContainer
    {
        public static IServiceCollection ServicesDependencies(this IServiceCollection service)
        {
            service.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            service.AddScoped<IProductRepository, ProductRepository>();
            service.AddScoped<IProductService, ProductServieces>();
            return service;
        }
    }
}
