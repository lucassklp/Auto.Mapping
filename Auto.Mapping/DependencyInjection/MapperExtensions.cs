using Auto.Mapping.Mappers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Auto.Mapping.DependencyInjection
{
    public static class MapperExtensions
    {

        public static IServiceCollection AddAutoMapping(this IServiceCollection services)
        {
            services.AddTransient<IMapResolver, MapResolver>();
            return services;
        }


        public static IServiceCollection AddAutoMapper<TInput, TOutput>(this IServiceCollection services)
            where TInput: class
            where TOutput: class, new()
        {
            services.AddTransient(typeof(IMapper<TInput, TOutput>), typeof(AutoMapper<TInput, TOutput>));
            return services;
        }


        //public static IServiceCollection AddLightMapper<LightMapper<TInput, TOutput>>(this IServiceCollection services)
            
        //{
        //    services.AddTransient<IMapper<TInput, TOutput>, AutoMapper<TInput, TOutput>>();
        //    return services;
        //}
    }
}
