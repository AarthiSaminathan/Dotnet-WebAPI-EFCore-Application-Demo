using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using myBooks.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myBooks.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using(var serviceScope=applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                if(!context.Books.Any())
                {
                    context.Books.AddRange(new Book()
                    {
                        Id = 1,
                        Title = "Introduction of C#",
                        Description = "C# Description",
                        Rate = 5
                    },
                    new Book()
                    {
                        Id = 2,
                        Title = "Introduction of Java",
                        Description = "Java Description",
                        Rate = 4
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
