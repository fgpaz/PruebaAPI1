namespace PruebaAPI
{
    public class Startup { }
    //{
    //    public Startup(
    //        IWebHostEnvironment env)//IConfiguration configuration)
    //    {
    //        //Configuration = configuration;
    //        var builder = new ConfigurationBuilder()
    //            .SetBasePath(env.ContentRootPath)
    //            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    //            .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
    //            .AddEnvironmentVariables();

    //        Configuration = builder.Build();
    //    }

    //    public IConfiguration Configuration { get; }

    //    // This method gets called by the runtime. Use this method to add services to the container.
    //    public void ConfigureServices(IServiceCollection services)
    //    {
    //        services.AddDbContext<TodoDB>(options =>
    //              options.UseMySQL(
    //                  Configuration.GetConnectionString("TodoDB"),
    //                  ServerVersion.AutoDetect(connectionString: Configuration.GetConnectionString("TodoDB"))),
    //              ServiceLifetime.Scoped);

    //        //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

    //        services.AddControllersWithViews();

    //        services.AddSwaggerGen(c =>
    //        {
    //            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Snoop Tracking", Version = "v1" });
    //        });

    //        services.AddSingleton<MailAccess>();
    //        services.AddSingleton<MailLogic>();

    //        services.AddSingleton<ProjectClient>();

    //        services.AddTransient<AsignacionesAccess>();
    //        services.AddTransient<CargasAccess>();
    //        services.AddTransient<CargasHistoricasAccess>();
    //        services.AddTransient<ProyectosAccess>();
    //        services.AddTransient<RecursosAccess>();

    //        services.AddTransient<AsignacionesLogic>();
    //        services.AddTransient<CargasLogic>();
    //        services.AddTransient<DevLogic>();
    //        services.AddTransient<ProyectosLogic>();
    //        services.AddTransient<RecursosLogic>();
    //        services.AddTransient<TogglLogic>();

    //        services.AddTransient<AsignacionesService>();
    //        services.AddTransient<CargasService>();
    //        services.AddTransient<DevService>();
    //        services.AddTransient<ProyectosService>();
    //        services.AddTransient<RecursosService>();
    //        services.AddTransient<TogglService>();
    //    }

    //    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    //    public void Configure(IApplicationBuilder app)
    //    {
    //        app.UseDeveloperExceptionPage();

    //        app.UseHttpsRedirection();
    //        app.UseRouting();
    //        app.UseEndpoints(endpoints =>
    //        {
    //            endpoints.MapControllers();
    //        });

    //        app.UseSwagger();
    //        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "IRAM_Sipo_Cotizaciones v1"));
    //    }


}
