using Hexagonal.Data;
using Hexagonal.Data.Bases;
using Hexagonal.Domain;

namespace Hexagonal.API.Modules;

/// <summary>
///     Persistence Extensions.
/// </summary>
public static class EntityRepositoryExtensions
{
    /// <summary>
    ///     Add Persistence dependencies varying on configuration.
    /// </summary>
    /// <param name="services"></param>
    public static IServiceCollection AddEntityRepository(this IServiceCollection services)
    {
        services.AddScoped<IBookRepository, BookRepository>();

        services.AddScoped<IRedisRepository<Book>, RedisRepository<Book>>();
        return services;
    }
}