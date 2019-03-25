
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Insurance.Domain.Entities.Common;
using Insurance.Infra.Data;
using Insurance.Infraestructure.Data;
using Microsoft.Practices.Unity;

namespace Insurance.Startup
{
    public static class DependencyResolver
    {
        public static void Resolve(UnityContainer container)
        {
            RegisterTypes(container);
        }

        public static IEnumerable<Type> GetEntities<T>(Assembly assemblies)
        {
            return assemblies.ExportedTypes.Where(y => y.BaseType == typeof(T));
        }

        public static void RegisterInterfaces(IUnityContainer container, List<Assembly> assemblies)
        {
            assemblies.FirstOrDefault(x => x.FullName.Contains("Business"))?.ExportedTypes.Where(t => t.IsClass).ToList().ForEach(_class =>
            {
                var _interface = assemblies.FirstOrDefault(x => x.FullName.Contains("Domain"))
                    ?.ExportedTypes.FirstOrDefault(c => c.IsInterface && _class.GetInterfaces().Contains(c));
                if (_interface != null) container.RegisterType(_interface, _class, new HierarchicalLifetimeManager());
            });

            assemblies.FirstOrDefault(x => x.FullName.Contains("Infra"))?.ExportedTypes.Where(t => t.IsClass).ToList().ForEach(_class =>
            {
                var _interface = assemblies.FirstOrDefault(x => x.FullName.Contains("Domain"))
                    ?.ExportedTypes.FirstOrDefault(c => c.IsInterface && _class.GetInterfaces().Contains(c));
                if (_interface != null) container.RegisterType(_interface, _class, new HierarchicalLifetimeManager());
            });
        }

        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<AppDataContext, AppDataContext>(new HierarchicalLifetimeManager());

            var myAssemblies =
                AppDomain.CurrentDomain.GetAssemblies()
                    .Where(a => a.FullName.StartsWith("Insurance")).ToList();

            container.RegisterTypes(
                GetEntities<EntityBase>(myAssemblies.FirstOrDefault(x => x.FullName.Contains("Domain"))),
                WithMappings.FromMatchingInterface,
                WithName.Default,
                WithLifetime.Hierarchical);

            RegisterInterfaces(container, myAssemblies.Where(
                x => x.FullName.Contains("Domain") || x.FullName.Contains("Business") || x.FullName.Contains("Infra")).ToList());
        }
    }
}
