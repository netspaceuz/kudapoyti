using Serilog;

namespace kudapoyti.api.Configurations;

public static class LoggetConfiguration
{
    public static void Configuration(this WebApplicationBuilder builder)
    {
        builder.Host.UseSerilog((hotingContext, loggerConfiguration) =>
            loggerConfiguration.ReadFrom.Configuration(hotingContext.Configuration));
    }
}
