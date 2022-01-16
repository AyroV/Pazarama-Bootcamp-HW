using BootcampHW.Entity;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BootcampHW.Data
{
    public class MockData
    {
        public static void Mock(IApplicationBuilder app)
        {
            var scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetService<BookContext>();
            context.Database.Migrate();

            var categories = new List<Category>() 
            {
                new Category 
                {
                    Name="Gizem",
                    Books = new List<Book>()
                    {
                        new Book {
                            Title="The Lincoln Highway",
                            Author = "Amor Towles",
                            Description="The bestselling author of A Gentleman in Moscow and Rules of Civility and master of absorbing, sophisticated fiction returns with a stylish and propulsive novel set in 1950s America",
                            ImageUrl="1.jpg"
                        },
                        new Book {
                            Title="Crying in H Mart",
                            Author = "Michelle Zauner",
                            Description="From the indie rockstar of Japanese Breakfast fame, and author of the viral 2018 New Yorker essay that shares the title of this book, an unflinching, powerful memoir about growing up Korean American, losing her mother, and forging her own identity.",
                            ImageUrl="2.jpg"
                        },

                    }
                },
                new Category {Name="Macera"},
                new Category {Name="Romantik"},
                new Category {Name="Savaş"},
                new Category {Name="Bilim Kurgu"}
            };

            var books = new List<Book>()
            {
                new Book {
                    Title="The Plot",
                    Author = "Jean Hanff Korelitz",
                    Description="Hailed as 'breathtakingly suspenseful,' Jean Hanff Korelitz’s The Plot is a propulsive read about a story too good not to steal, and the writer who steals it.",
                    ImageUrl="3.jpg",
                    Categories = new List<Category>() {categories[0], new Category() {Name="Yeni Kategori"}, categories[1] }
                },
                new Book {
                    Title="How the Word Is Passed",
                    Author = "Clint Smith",
                    Description="The Atlantic writer drafts a history of slavery in this country unlike anything you’ve read before",
                    ImageUrl="4.jpg",
                    Categories = new List<Category>() {categories[0],categories[2] }
                },
                new Book {
                    Title="The Four Winds",
                    Author = "Kristin Hannah",
                    Description="From the number-one bestselling author of The Nightingale and The Great Alone comes a powerful American epic about love and heroism and hope, set during the Great Depression, a time when the country was in crisis and at war with itself, when millions were out of work and even the land seemed to have turned against them.",
                    ImageUrl="5.jpg",
                    Categories = new List<Category>() {categories[1], categories[3] }
                },
                    new Book {
                    Title="Empire of Pain",
                    Author = "Patrick Radden Keefe",
                    Description="A grand, devastating portrait of three generations of the Sackler family, famed for their philanthropy, whose fortune was built by Valium and whose reputation was destroyed by OxyContin. From the prize-winning and bestselling author of Say Nothing",
                    ImageUrl="6.jpg",
                    Categories = new List<Category>() {categories[0], categories[1] }
                },
                new Book {
                    Title="Harlem Shuffle",
                    Author = "Colson Whitehead",
                    Description="From the two-time Pulitzer Prize-winning author of The Underground Railroad and The Nickel Boys, a gloriously entertaining novel of heists, shakedowns, and rip-offs set in Harlem in the 1960s.",
                    ImageUrl="7.jpg",
                    Categories = new List<Category>() {categories[2], categories[4] }
                },
                new Book {
                    Title="Great Circle",
                    Author = "Maggie Shipstead",
                    Description="The unforgettable story of a daredevil female aviator determined to chart her own course in life, at any cost—Great Circle “soars and dips with dizzying flair ... an expansive story that covers more than a century and seems to encapsulate the whole wide world",
                    ImageUrl="8.jpg",
                    Categories = new List<Category>() {categories[1], categories[2] }
                }
            };

            if (!context.Database.GetPendingMigrations().Any())
            {
                if (!context.Categories.Any())
                    context.Categories.AddRange(categories);

                if (!context.Books.Any())
                    context.Books.AddRange(books);


                context.SaveChanges();
            }
        }
    }
}
