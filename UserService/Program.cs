using UserService;
using Serilog;

IHost host = Host.CreateDefaultBuilder(args)
    .UseWindowsService()
    .ConfigureServices(services =>
    {
        services.AddHostedService<User>();
    }).UseSerilog()
    .Build();

var configsetting = new ConfigurationBuilder().
    AddJsonFile("appsettings.json").Build();
 
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .MinimumLevel.Override("microsoft", Serilog.Events.LogEventLevel.Warning)
    .Enrich.FromLogContext()
    .WriteTo.File(configsetting["Logging:Logpath"])
    .CreateLogger();
host.Run();