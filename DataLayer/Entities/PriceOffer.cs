using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Entities
{
    public class PriceOffer
    {
        public int PriceOfferId { get; set; }
        [Column(TypeName = "decimal(8,2")]
        public decimal NewPrice { get; set; } 
        public string PromotionalText { get; set; }
        //Convention til at skabe one-to-zero-or-one relationship mellem priceoffer og book. (Navigation Relation)
        public int? BlogForeignKey { get; set; }    
        public Book Book { get; set; }
    }
}
