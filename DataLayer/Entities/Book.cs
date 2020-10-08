using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Entities
{
    public class Book
    {
        public int BookId { get; set; }     //PK
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PublishedOn { get; set; }
        public string Publisher { get; set; }
        [Column(TypeName = "decimal(8,2")]
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public bool SoftDeleted { get; set; }
        //Convention til at skabe one-to-many relation mellem en bog og mange reviews (Navigation Relation)
        public ICollection<Review> Reviews { get; set; }
        //Convention til at skabe one-to-zero-or-one relation mellem priceoffer og book. (Navigation Relation)
        public PriceOffer PriceOffer { get; set; }
        //Convention til at skabe many-to-many relation mellem Book og Author for at lave BookAuthor klassen. (Navigation Relation)
        public List<BookAuthor> BookAuthors { get; set; }

    }
}
