using WebMvc.Service;
using Microsoft.EntityFrameworkCore;
namespace WebMvc;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        using var db = new TaskDbContext();
        db.Add(new Infomation {Id = 0, Title = " ", Content = " ", dueDate = DateTime.Now});
        db.SaveChanges();

        // Add services to the container.
        builder.Services.AddControllersWithViews();
        builder.Services.AddSingleton<ITaskService, TaskService>();
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}
