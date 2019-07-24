using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeBook
{
    public static class AutoMapperConfig
    {
        public static IMapperConfigurationExpression AddAdminMapping(
       this IMapperConfigurationExpression configurationExpression)
        {
            configurationExpression.CreateMap<Entities.Recipe, Models.RecipeViewModel>()
             .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src
             => src.Category.Name));

            return configurationExpression;
        }
    }
}
