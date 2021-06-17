using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OnlineMarketPlace.Domain
{
    public class ProductType : Entity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public ICollection<Product> Products { get; set; }
        public ICollection<AttributeType> AttributeTypes { get; set; }
    }
}
