using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entities
{
    public class BookAuthor
    {
        public int BookId { get; set; }
        public int AuthorId { get; set; }
        public byte Order { get; set; }

        //Convention til at skabe many-to-many relationship. (Navigation Relation)
        public Book Book { get; set; }
        public Author Author { get; set; }

    }
}
