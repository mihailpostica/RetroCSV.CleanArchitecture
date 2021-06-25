using System;
using System.Linq;
using System.Reflection;
using AutoMapper;

namespace RetroCSV.Core.Mappings
{
    public class MappingProfile:Profile
    {   //applies all the mappings that were made using by implementing the IMapFrom<T> interface
        public MappingProfile()
        {
            ApplyMappingsFromAssembly(Assembly.GetExecutingAssembly());
        }

        private void ApplyMappingsFromAssembly(Assembly assembly)
        {   
            //get the generic IMapFrom types
            var types = assembly.GetExportedTypes().Where(t => t.GetInterfaces().Any(i =>
                i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>))).ToList();
            
            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type);
                //since it's a generic interface "`1" should be added to the interface name.
                var methodInfo = type.GetMethod("Mapping") ?? type.GetInterface("IMapFrom`1")?.GetMethod("Mapping");
                methodInfo?.Invoke(instance, new object[] {this});
            }
        }
    }
}