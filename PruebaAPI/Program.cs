using DataAccess;
using Logic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

var ConfigurationConnectionString = builder.Configuration.GetConnectionString("DB");
builder.Services.AddDbContext<UsuarioDB>(options =>
    options.UseMySql(ConfigurationConnectionString,
                      ServerVersion.AutoDetect(ConfigurationConnectionString)),
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
builder.Services.AddScoped<UsuarioDA>();

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
