namespace TeachTheChild.Web.Mappings
{
    using System.Linq;
    using System;
    using System.Collections.Generic;
    using AutoMapper;

    using TeachTheChild.Common.Mappings;
    using TeachTheChild.Web.Infrastructure.Constants;

    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            var assemblies = AppDomain
                .CurrentDomain
                .GetAssemblies()
                .Where(a => a.GetName().Name.Contains(WebConstants.AppDomainName));


            var exportedTypes = assemblies
                .SelectMany(a => a.GetExportedTypes())
                .Where(t => t.IsClass && !t.IsAbstract);

            this.LoadMappings(exportedTypes);
            this.LoadReverseMappings(exportedTypes);
            this.LoadCustomMappings(exportedTypes);
        }

        private void LoadMappings(IEnumerable<Type> types)
        {
            foreach (var type in types)
            {
                type
                    .GetInterfaces()
                    .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>))
                    .Select(i => i.GetGenericArguments().First())
                    .ToList()
                    .ForEach(source => this.CreateMap(source, type));
            }
        }

        private void LoadReverseMappings(IEnumerable<Type> types)
        {
            foreach (var type in types)
            {
                type
                    .GetInterfaces()
                    .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapTo<>))
                    .Select(i => i.GetGenericArguments().First())
                    .ToList()
                    .ForEach(destination => this.CreateMap(type, destination));
            }
        }

        private void LoadCustomMappings(IEnumerable<Type> types)
        {
            types
                .Where(t => typeof(IHaveCustomMappings).IsAssignableFrom(t))
                .Select(t => (IHaveCustomMappings)Activator.CreateInstance(t))
                .ToList()
                .ForEach(mapping => mapping.ApplyCustomMappings(this));
        }
    }
}
