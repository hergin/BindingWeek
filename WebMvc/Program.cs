using WebMvc.Service;
using WebMvc.Data;
using Microsoft.EntityFrameworkCore;

namespace WebMvc;
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        // Add services to the container
        builder.Services.AddControllersWithViews();

        // Register the DbContext
        builder.Services.AddDbContext<MyTaskContext>(options =>
            options.UseSqlite(builder.Configuration.GetConnectionString("MyTasksConnection")));

        // Register Services
        builder.Services.AddScoped<ITaskService, TaskService>();

        var app = builder.Build();

        // Apply migrations
        using (var scope = app.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            DbInitializer.Initialize(services);
            var dbContext = services.GetRequiredService<MyTaskContext>();

            // Apply pending migrations
            dbContext.Database.Migrate();
        }

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseHttpsRedirection();
            app.UseExceptionHandler("/Home/Error");

            app.UseHsts();
        }

        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}
