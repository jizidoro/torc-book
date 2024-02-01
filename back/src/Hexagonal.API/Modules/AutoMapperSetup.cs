using Hexagonal.Application.Mappers;

namespace Hexagonal.API.Modules;

/// <summary>
///     AutoMapperSetup
/// </summary>
public static class AutoMapperSetup
{
    /// <summary>
    ///     AddAutoMapperSetup
    /// </summary>
    /// <param name="services"></param>
    public static void AddAutoMapperSetup(this IServiceCollection services)
    {
        if (services == null) throw new ArgumentNullException(nameof(services));

        services.AddAutoMapper(typeof(DomainToDtoMappingProfile),
            typeof(DtoToDomainMappingProfile));
    }
}