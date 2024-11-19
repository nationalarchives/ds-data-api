using Microsoft.OpenApi.Models;
using NLog;
using NLog.Web;
using Repositories.SarInfo;
using RepositoryContracts.SarInfo;
using sar_data_api.Helper;
using TNA.DataDefinitionObjects;
using TNA.RepositoryLibraries.MongoDB;

var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
try
{
    WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

    var secrets = new Dictionary<string, string?>
    {
        { $"ConnectionStrings:SarConnection", Environment.GetEnvironmentVariable("SarConnection") }
    };
    builder.Configuration.AddInMemoryCollection(secrets).Build();

    builder.Services.AddControllers();

    builder.Services.AddTransient<IRepository<Sar>, Repository<Sar>>();
    builder.Services.AddTransient<ISarContext, SarContext>();

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo { Title = "Sar data api", Version = "v1" }); });

    builder.Services.AddAutoMapper(typeof(Program).Assembly);

    // Add NLoging to the container.
    builder.Logging.ClearProviders();
    builder.Logging.AddConsole();
    builder.Host.UseNLog();

    builder.Services.AddHealthChecks();

    WebApplication app = builder.Build();
    app.ConfigureExceptionHandler(logger);

    app.UsePathBase(new PathString("/sardataapi"));
    app.MapHealthChecks("/sardataapi/healthz");

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
    NLog.LogManager.Shutdown();
}