using DataAccess;
using Logic;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

var Configuration = builder.Configuration;
builder.Services.AddDbContext<TodoDB>(options =>
    options.UseMySql(Configuration.GetConnectionString("TodoDB"),
                      ServerVersion.AutoDetect(Configuration.GetConnectionString("TodoDB"))),
                  ServiceLifetime.Scoped);
//Para conectar con DB en memoria
//builder.Services.AddDbContext<TodoContext>(opt =>
//    opt.UseInMemoryDatabase("TodoList"));

// Add services to the container
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<TodoLogic>();
builder.Services.AddScoped<TodoDataAccess>();

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

app.Run();
