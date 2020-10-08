using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entities
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }

        //Convention for at skabe many-to-many relation
        public List<BookAuthor> BookAuthors { get; set; }

    }
}
