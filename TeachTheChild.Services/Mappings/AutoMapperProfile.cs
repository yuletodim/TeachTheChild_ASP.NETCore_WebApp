namespace TeachTheChild.Services.Mappings
{
    using AutoMapper;
    using System.Linq;
    using System.Reflection;
    using System;
    using System.Collections.Generic;

    //public class AutoMapperProfile : Profile
    //{
    //    public AutoMapperProfile(params Assembly[] assemblies)
    //    {
    //        var exportedTypes = assemblies
    //            .SelectMany(a => a.GetExportedTypes())
    //            .Where(t => t.IsClass && !t.IsAbstract);

    //        this.LoadMappings(exportedTypes);
    //        this.LoadCustomMappings(exportedTypes);
    //    }

    //    private void LoadMappings(IEnumerable<Type> types)
    //    {
    //        foreach (var type in types)
    //        {
    //            type
    //                .GetInterfaces()
    //                .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>))
    //                .Select(i => i.GetGenericArguments().First())
    //                .ToList()
    //                .ForEach(source => this.CreateMap(source, type));
    //        }
    //    }

    //    private void LoadCustomMappings(IEnumerable<Type> types)
    //    {
    //        types
    //            .Where(t => typeof(IHaveCustomMappings).IsAssignableFrom(t))
    //            .Select(t => (IHaveCustomMappings)Activator.CreateInstance(t))
    //            .ToList()
    //            .ForEach(mapping => mapping.ApplyCustomMappings(this));
    //    }
    //}
}
