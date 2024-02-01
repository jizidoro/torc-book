using Hexagonal.API.Modules.Common.FeatureFlags;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Hexagonal.API.Modules.Common.Swagger;

/// <summary>
///     Swagger Extensions.
/// </summary>
public static class SwaggerExtensions
{
    /// <summary>
    ///     Add Swagger Configuration dependencies.
    /// </summary>
    /// <param name="services"></param>
    public static IServiceCollection AddSwagger(this IServiceCollection services)
    {
        var featureManager = services
            .BuildServiceProvider()
            .GetRequiredService<IFeatureManager>();

        var isEnabled = featureManager
            .IsEnabledAsync(nameof(CustomFeature.Swagger))
            .ConfigureAwait(false)
            .GetAwaiter()
            .GetResult();

        if (isEnabled)
        {
            services
                .AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>()
                .AddSwaggerGen();
        }

        return services;
    }

    /// <summary>
    ///     Add Swagger dependencies.
    /// </summary>
    /// <param name="app"></param>
    /// <param name="provider"></param>
    /// <param name="configuration"></param>
    public static IApplicationBuilder UseVersionedSwagger(
        this IApplicationBuilder app,
        IApiVersionDescriptionProvider provider,
        IConfiguration configuration)
    {
        app.UseSwagger();
        app.UseSwaggerUI(
            options =>
            {
                foreach (var description in provider.ApiVersionDescriptions)
                {
                    string swaggerEndpoint;

                    var basePath = configuration["ASPNETCORE_BASEPATH"];

                    if (!string.IsNullOrEmpty(basePath))
                    {
                        swaggerEndpoint =
                            $"{basePath}/swagger/{description.GroupName}/swagger.json";
                    }
                    else
                    {
                        swaggerEndpoint = $"/swagger/{description.GroupName}/swagger.json";
                    }

                    options.SwaggerEndpoint(swaggerEndpoint,
                        description.GroupName.ToUpperInvariant());
                }
            });

        return app;
    }
}