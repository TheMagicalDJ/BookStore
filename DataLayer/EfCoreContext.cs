using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    public class EfCoreContext : DbContext
    {

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<PriceOffer> PriceOffers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            {
                //Fluent API one-to-many relation, mellem en book og mange reviews.
                //modelBuilder.Entity<Review>()
                //    .HasOne<Book>(s => s.Book)
                //    .WithMany(g => g.Reviews)
                //    .HasForeignKey(s => s.BookId);

                //Fluent API one-to-zero-or-one relation, mellem en book og et priceoffer. 
                modelBuilder.Entity<PriceOffer>()
                    .HasOne<Book>(s => s.Book)
                    .WithOne(g => g.PriceOffer)
                    .HasForeignKey<PriceOffer>(k => k.BlogForeignKey);

                //Fluent API many-to-many relation, for at skabe BookAuthor klassen ved at joine Book og Author klasserne.. 
                modelBuilder.Entity<BookAuthor>()
                    .HasKey(t => new { t.BookId, t.AuthorId });

                modelBuilder.Entity<BookAuthor>()
                    .HasOne(pt => pt.Book)
                    .WithMany(p => p.BookAuthors)
                    .HasForeignKey(pt => pt.BookId);

                modelBuilder.Entity<BookAuthor>()
                    .HasOne(pt => pt.Author)
                    .WithMany(t => t.BookAuthors)
                    .HasForeignKey(pt => pt.AuthorId);


                //Implementering af data til BookStoreDb
                modelBuilder.Entity<Book>().HasData(
                new Book { BookId = 1, Title = "Refactoring", Description = "Improving the design of existing code", Price = 40 },
                new Book { BookId = 2, Title = "Patterns of Enterprise Application Architecture", Description = "Written in direct response to the stiff challenges", Price = 53 },
                new Book { BookId = 3, Title = "Domain - Driven Design", Description = "Linking business needs to software design", Price = 56},
                new Book { BookId = 4, Title = "Quantum Networking", Description = "Entangled quantum networking provides faster-than - light data communications", Price = 220});

                modelBuilder.Entity<Author>().HasData(
                new Author { AuthorId = 1, Name = "Martin Fowler" },
                new Author { AuthorId = 2, Name = "Eric Evans" },
                new Author { AuthorId = 3, Name = "Future Person" });
                
                modelBuilder.Entity<BookAuthor>().HasData(
                new BookAuthor { BookId = 1, AuthorId = 1 },
                new BookAuthor { BookId = 1, AuthorId = 2 },
                new BookAuthor { BookId = 2, AuthorId = 1 },
                new BookAuthor { BookId = 3, AuthorId = 2 },
                new BookAuthor { BookId = 4, AuthorId = 3 });
                
                modelBuilder.Entity<Review>().HasData(
                new Review { ReviewId = 1, BookId = 1, Comment = "Great book", NumStars = 3 },
                new Review { ReviewId = 2, BookId = 1, Comment = "Boringbook", NumStars = 1 });

            }
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = (localdb)\\mssqllocaldb; Database = BookStoreDb; Trusted_Connection = True; ")
            .EnableSensitiveDataLogging(true)
            .UseLoggerFactory(new ServiceCollection()
            .AddLogging(builder => builder.AddConsole()
                .AddFilter(DbLoggerCategory.Database.Command.Name, LogLevel.Information))
                .BuildServiceProvider().GetService<ILoggerFactory>());
        }
    }
}
