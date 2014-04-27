using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System;
using AutoMapper;
using Microsoft.Ajax.Utilities;
using Vnsf.WebHost.Infrastructure.Tasks;

namespace Vnsf.WebHost.Infrastructure.Mapping
{
    public static class AutoMapperBootstrapper
    {
        private static Type[] types;
        static AutoMapperBootstrapper()
        {
            types = Assembly.GetExecutingAssembly().GetExportedTypes();
        }

        public static void Init()
        {
            //types = Assembly.GetExecutingAssembly().GetExportedTypes();

            LoadStandardMappings(types);
            LoadCustomMappings(types);
            Mapper.AssertConfigurationIsValid();
        }

        public static void RunInit()
        {
            //var types = Assembly.GetExecutingAssembly().GetExportedTypes();
            RunInitTask(types);
        }

        private static void RunInitTask(Type[] types)
        {
            var startups = (from t in types
                            from i in t.GetInterfaces()
                            where typeof(IRunAtInit).IsAssignableFrom(t)
                            && !t.IsAbstract && !t.IsInterface
                            select (IRunAtInit)Activator.CreateInstance(t)).ToArray();
            foreach (var task in startups)
            {
                task.Execute();
            }

        }

        private static void LoadCustomMappings(Type[] types)
        {
            var maps = (from t in types
                        from i in t.GetInterfaces()
                        where typeof(IHaveCustomMapping).IsAssignableFrom(t)
                        && !t.IsAbstract && !t.IsInterface
                        select (IHaveCustomMapping)Activator.CreateInstance(t)).ToArray();


            foreach (var map in maps)
            {
                map.CreateMapping(Mapper.Configuration);
            }
        }

        private static void LoadStandardMappings(IEnumerable<Type> types)
        {
            var maps = (from t in types
                        from i in t.GetInterfaces()
                        where i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>) && !t.IsAbstract && !t.IsInterface
                        select new
                               {
                                   Source = i.GetGenericArguments()[0],
                                   Destination = t
                               }).ToArray();

            foreach (var map in maps)
            {
                Mapper.CreateMap(map.Source, map.Destination);
            }
        }
    }
}