using System;
using Microsoft.Extensions.Configuration;

namespace ModernArchitectureShop.TyeConfiguration
{
    public static class TyeExtensions
    {
        public static bool IsTyeEnabled(this IConfiguration configuration)
            => configuration.GetValue<bool>("IsTyeEnabled");

        public static Uri GetServiceUri(this IConfiguration configuration, ServiceConfig serviceConfig)
        {
            return configuration.IsTyeEnabled()
                           ? configuration.GetServiceUri(serviceConfig.ServiceName)
                           : new Uri(serviceConfig.ServiceUrl);
        }
    }
}
