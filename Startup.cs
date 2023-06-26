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
        _ = services.AddAuthentication(options =>
        {

        })
            .AddCookie(options =>
            {

            });

        // Ajouter les services d'autorisation
        services.AddAuthorization(options =>
        {
            // Définir les politiques d'autorisation
            options.AddPolicy("AdministratorOnly", policy =>
            {
                policy.RequireRole("Administrator");
            });
        });

        services.AddDbContext<VoitureExpressContext>(options =>
            options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")));
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseRouting();

        // Activer le middleware d'authentification
        app.UseAuthentication();

        // Activer le middleware d'autorisation
        _ = app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            endpoints.MapControllerRoute(
                name: "reparation",
                pattern: "Reparation/{action}/{id?}",
                defaults: new { controller = "Reparation" });

            endpoints.MapControllerRoute(
                name: "createrereparationvoiture",
                pattern: "Reparation/CreateReparationVoiture",
                defaults: new { controller = "Reparation", action = "CreateReparationVoiture" });
        });

    }
}    


