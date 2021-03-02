using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuyBooks.Models
{
    public class SeedData
    {
        public static void EnsurePopulated (IApplicationBuilder application)
        {
            BuyBooksDbContext context = application.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<BuyBooksDbContext>();

            if(context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            //if there is not currently context this will seed the database with initial data
            if(!context.Libraries.Any())
            {
                context.Libraries.AddRange(

                    new Library
                    {
                        Title = "Les Miserables",
                        AuthorFirstName = "Victor",
                        AuthorLastName = "Hugo",
                        Publisher = "Signet",
                        ISBN = "978-0451419439",
                        Class = "Fiction",
                        Category = "Classic",
                        PageCount = 1488,
                        Price = 9.95m
                    },
                    new Library
                    {
                        Title = "Team of Rivals",
                        AuthorFirstName = "Doris Kearns",
                        AuthorLastName = "Goodwinn",
                        Publisher = "Simon & Schuster",
                        ISBN = "978-0743270755",
                        Class = "Non-Fiction",
                        Category = "Biography",
                        PageCount = 944,
                        Price = 14.58m
                    },
                    new Library
                    {
                        Title = "The Snowball",
                        AuthorFirstName = "Alice",
                        AuthorLastName = "Schroeder",
                        Publisher = "Bantam",
                        ISBN = "978-0553384611",
                        Class = "Non-Fiction",
                        Category = "Biography",
                        PageCount = 832,
                        Price = 21.54m
                    },
                    new Library
                    {
                        Title = "American Ulysses",
                        AuthorFirstName = "Ronald C.",
                        AuthorLastName = "White",
                        Publisher = "Random House",
                        ISBN = "978-0812981254",
                        Class = "Non-Fiction",
                        Category = "Biography",
                        PageCount = 864,
                        Price = 11.61m
                    },
                    new Library
                    {
                        Title = "Unbroken",
                        AuthorFirstName = "Laura",
                        AuthorLastName = "Hillenbrand",
                        Publisher = "Random House",
                        ISBN = "978-0812974492",
                        Class = "Non-Fiction",
                        Category = "Historical",
                        PageCount = 528,
                        Price = 13.33m
                    },
                    new Library
                    {
                        Title = "The Great Train Robbery",
                        AuthorFirstName = "Michael",
                        AuthorLastName = "Crichton",
                        Publisher = "Vintage",
                        ISBN = "978-0804171281",
                        Class = "Fiction",
                        Category = "Historical Fiction",
                        PageCount = 288,
                        Price = 15.95m
                    },
                    new Library
                    {
                        Title = "Deep Work",
                        AuthorFirstName = "Cal",
                        AuthorLastName = "Newport",
                        Publisher = "Grand Central Publishing",
                        ISBN = "978-1455586691",
                        Class = "Non-Fiction",
                        Category = "Self-Help",
                        PageCount = 304,
                        Price = 14.99m
                    },
                    new Library
                    {
                        Title = "It's Your Ship",
                        AuthorFirstName = "Michael",
                        AuthorLastName = "ABrashoff",
                        Publisher = "Grand Central Publishing",
                        ISBN = "978-1455523023",
                        Class = "Non-Fiction",
                        Category = "Self-Help",
                        PageCount = 240,
                        Price = 21.66m
                    },
                    new Library
                    {
                        Title = "The Virgin Way",
                        AuthorFirstName = "Richard",
                        AuthorLastName = "Branson",
                        Publisher = "Portfolio",
                        ISBN = "978-1591847984",
                        Class = "Non-Fiction",
                        Category = "Business",
                        PageCount = 400,
                        Price = 29.16m
                    },
                    new Library
                    {
                        Title = "Sycamore Row",
                        AuthorFirstName = "John",
                        AuthorLastName = "Grisham",
                        Publisher = "Bantam",
                        ISBN = "978-0553393613",
                        Class = "Fiction",
                        Category = "Thrillers",
                        PageCount = 642,
                        Price = 15.03m
                    },
                    new Library
                    {
                        Title = "Fahrenheit 451",
                        AuthorFirstName = "Ray",
                        AuthorLastName = "Bradbury",
                        Publisher = "Simon & Schuster",
                        ISBN = "978-0743247221",
                        Class = "Fiction",
                        Category = "Dystopian",
                        PageCount = 256,
                        Price = 8.29m
                    },
                    new Library
                    {
                        Title = "The 7 Habits of Highly Effective People",
                        AuthorFirstName = "Stephen R.",
                        AuthorLastName = "Covey",
                        Publisher = "Simon & Schuster",
                        ISBN = "978-1982137274",
                        Class = "Non-Fiction",
                        Category = "Self-Help",
                        PageCount = 464,
                        Price = 12.53m
                    },
                    new Library
                    {
                        Title = "Man's Search for Meaning",
                        AuthorFirstName = "Viktor E.",
                        AuthorLastName = "Frankl",
                        Publisher = " Beacon Press",
                        ISBN = "978-0807014271",
                        Class = "Non-Fiction",
                        Category = "Self-Help",
                        PageCount = 192,
                        Price = 8.39m
                    }

                );

                context.SaveChanges();
            }
        }
    }
}
