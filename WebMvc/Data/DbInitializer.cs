using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace WebMvc.Data
{
    public static class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MyTaskContext(
                serviceProvider.GetRequiredService<DbContextOptions<MyTaskContext>>()))
            {
                // Skip seeding if data already exists
                //if (context.Tasks.Any())
                //{
                   // return; 
                //}

                context.Tasks.AddRange(
                    new MyTaskModel
                    {
                        Title = "420 Assignment",
                        Content = "Complete the 420 Create Task assignment",
                        DueDate = DateTime.Now.AddDays(3)
                    },
                    new MyTaskModel
                    {
                        Title = "Spring Break",
                        Content = "Plan the spring break 24. Where to visit?",
                        DueDate = DateTime.Now.AddDays(5)
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
