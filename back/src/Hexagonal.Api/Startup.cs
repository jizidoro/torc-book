using hexagonal.API.Modules;
using hexagonal.API.Modules.Common;
using hexagonal.API.Modules.Common.FeatureFlags;
using hexagonal.API.Modules.Common.Swagger;

namespace hexagonal.API;

/// <summary>
///     Startup.
/// </summary>
public sealed class Startup
{
    /// <summary>
    ///     Startup constructor.
    /// </summary>
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    private IConfiguration Configuration { get; }

    /// <summary>
    ///     Configure dependencies from application.
    /// </summary>
    public void ConfigureServices(IServiceCollection services)
    {
        services
            .AddFeatureFlags(Configuration)
            .AddSqlServer(Configuration)
            .AddEntityRepository()
            .AddAuthentication(Configuration)
            .AddVersioning()
            .AddSwagger()
            .AddUseCases()
            .AddCustomControllers()
            .AddCustomCors()
            .AddProxy();

        services.AddAutoMapperSetup();
        services.AddLogging();


        //services.AddSingleton<IRabbitMqConnection>(sp =>
        //{
        //    var factory = new ConnectionFactory
        //    {
        //        HostName = Configuration["RabbitMQ:HostName"],
        //        UserName = Configuration["RabbitMQ:UserName"],
        //        Password = Configuration["RabbitMQ:Password"]
        //    };

        //    return new RabbitMqConnection(factory);
        //});

        //services.AddHostedService<BookConsumerService>();
    }

    /// <summary>
    ///     Configure http request pipeline.
    /// </summary>
    public void Configure(
        IApplicationBuilder app,
        IWebHostEnvironment env,
        IApiVersionDescriptionProvider provider)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/api/V1/CustomError")
                .UseHsts();
        }

        app
            .UseProxy(Configuration)
            .UseCustomCors()
            .UseRouting()
            .UseVersionedSwagger(provider, Configuration)
            .UseAuthentication()
            .UseAuthorization()
            .UseSerilogRequestLogging()
            .UseEndpoints(endpoints => { endpoints.MapControllers(); });
    }
}