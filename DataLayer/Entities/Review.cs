using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entities
{
    public class Review
    {
        public int ReviewId { get; set; }
        public string VoterName { get; set; }
        public int NumStars { get; set; }
        public string Comment { get; set; }
        //Conventions til at skabe one-to-many relationship mellem en bog og mange reviews (Navigation Relation)
        public int BookId { get; set; }     //FK
        public Book Book { get; set;}
    }
}
