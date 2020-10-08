using Microsoft.EntityFrameworkCore;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using DataLayer.Entities;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            EagerLoadingA1();
            //EagerLoadingA2();
            //ExplicitLoadingB1();
            //ExplicitLoadingB2();
        }

        #region Eager Loading A1
        private static void EagerLoadingA1()
        {
            using (var context = new EfCoreContext())
            {
                var books = context.Books
                    .Include(book => book.BookAuthors).ThenInclude(bookauthor => bookauthor.Author)

                    .Include(book => book.Reviews);


                foreach (var book in books)
                {
                    Console.WriteLine($"BookId: {book.BookId} - Title: {book.Title} - Price: {book.Price} -");
                    foreach (var author in book.BookAuthors)
                    {
                        Console.WriteLine($"Author: {author.Author.Name}");
                        foreach (var review in book.Reviews)
                        {
                            Console.WriteLine($"Stars: - {review.NumStars} - Comment: {review.Comment}");
                        }
                    }
                }
            }
        }

        #endregion

        #region Eager Loading A2
        private static void EagerLoadingA2()
        {
            using (EfCoreContext context = new EfCoreContext())
            {
                var books = context.Books
                    .Include(book => book.BookAuthors)
                    .ThenInclude(bookAuthor => bookAuthor.Author)
                    .ToList();
                AllBooksA2(books);
            }
        }
        static void AllBooksA2(IEnumerable<Book> books)
        {
            foreach (var book in books)
            {
                Console.WriteLine($"BookId: {book.BookId} - Title: {book.Title} - Price: {book.Price} -");
                foreach (var author in book.BookAuthors)
                {
                    Console.WriteLine($"Author: {author.Author.Name}");
                    //foreach (var review in book.Reviews)
                    //{
                    //    Console.WriteLine($"Stars: - {review.NumStars} - Comment: {review.Comment}");
                    //}
                }
            }

        }
        #endregion

        #region Explicit Loading B1
        static void ExcplicitLoadingB1()
        {

        }
        #endregion
    }
}
