namespace GovUkDesignSystemDotNetDemo;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();

        var app = builder.Build();

        app.UseStaticFiles();

        app.UseRouting();

        app.MapControllers();

        app.Run();
    }
}
