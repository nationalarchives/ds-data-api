using Microsoft.OpenApi.Models;
using NLog.Web;
using NLog;
using Repositories.FAInformationAsset;
using Repositories.InformationAsset;
using RepositoryContracts.FAInformationAsset;
using RepositoryContracts.InformationAsset;
using TNA.DataDefinitionObjects;
using TNA.RepositoryLibraries.MongoDB;
using ia_data_api.Helper;

var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
try
{
    WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

    var secrets = new Dictionary<string, string?>
    {
        { $"ConnectionStrings:IAConnection", Environment.GetEnvironmentVariable("IAConnection") },
        { $"ConnectionStrings:FAConnection", Environment.GetEnvironmentVariable("FAConnection") }
    };
    builder.Configuration.AddInMemoryCollection(secrets).Build();

    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo { Title = "IA data api", Version = "v1" }); });
    builder.Services.AddHealthChecks();

    builder.Services.AddAutoMapper(typeof(Program).Assembly);

    builder.Services.AddTransient<IRepository<IA>, Repository<IA>>();
    builder.Services.AddTransient<IRepository<FileAuthorityIA>, Repository<FileAuthorityIA>>();
    builder.Services.AddTransient<IInformationAssetContext, InformationAssetContext>();
    builder.Services.AddTransient<IFaInformationAssetContext, FaInformationAssetContext>();

    // Add NLoging to the container.
    builder.Logging.ClearProviders();
    builder.Logging.AddConsole();
    builder.Host.UseNLog();

    WebApplication app = builder.Build();
    app.ConfigureExceptionHandler(logger);

    app.UsePathBase(new PathString("/iadataapi"));
    app.MapHealthChecks("/iadataapi/healthz");

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    app.MapControllers();
    app.Run();
}
catch (Exception exception)
{
    // NLog: catch setup errors
    logger.Error(exception, "Stopped program because of exception");
    throw;
}
finally
{
    // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
    LogManager.Shutdown();
}