using Mapster;
using System.Reflection;

namespace OrderEats.API
{
    public static class MappingConfig
    {
        public static void Configure()
        {
            // Allow nested mapping
            TypeAdapterConfig.GlobalSettings.Default.PreserveReference(true);

            // Explicit mapping for all destination member fields
            TypeAdapterConfig.GlobalSettings.RequireDestinationMemberSource = true;

            // Load mapping configuration from IRegister implementations.
            TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetExecutingAssembly());

            // Validate mapping profiles
            TypeAdapterConfig.GlobalSettings.Compile();
        }
    }
}
