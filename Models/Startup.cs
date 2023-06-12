using Microsoft.EntityFrameworkCore;

// ...

public class Startup
{
    private readonly IConfiguration _configuration;

    public Startup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllersWithViews();

        // Définition de AccueilController comme page d'accueil



        _ = services.AddDbContext<VoitureExpressContext>(options =>
            options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")));
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseEndpoints(endpoints =>
        {
            _ = endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Accueil}/{action=Index}/{id?}");
        });
    }
}




