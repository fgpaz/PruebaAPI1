using DataAccess;
using Logic;
using Microsoft.EntityFrameworkCore;
using PruebaAPI;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
builder.Host.ConfigureLogging((hostingContext, logging) =>
                {
                    logging.ClearProviders()
                        .AddSerilog(new LoggerConfiguration()
                            .ReadFrom.Configuration(hostingContext.Configuration, "Logging")
                            .Enrich.FromLogContext()
                            //.Enrich.WithThreadId()
                            //.Enrich.WithProcessId()
                            //.Enrich.WithMachineName()
                            //.WriteTo
                            //.FastConsole(new FastConsoleSinkOptions { UseJson = false })
                            .WriteTo
                            .File("events_log.log", rollingInterval: RollingInterval.Day, retainedFileCountLimit: 14)
                            .CreateLogger()
                            );
                });

string connectionString = builder.Configuration.GetConnectionString("DB");
builder.Services.AddDbContext<ContextDB>(options =>
    options.UseMySql(connectionString,
                      ServerVersion.AutoDetect(connectionString)),
                    ServiceLifetime.Scoped);

//Para conectar con DB en memoria
//builder.Services.AddDbContext<TodoContext>(opt =>
//    opt.UseInMemoryDatabase("TodoList"));

// Add services to the container
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<UsuarioLogic>();
builder.Services.AddScoped<UsuarioCRUD>();
builder.Services.AddSingleton<LoggerService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapGet("/", () => "Hello World!");
app.UseSwaggerUI();

app.Run();
