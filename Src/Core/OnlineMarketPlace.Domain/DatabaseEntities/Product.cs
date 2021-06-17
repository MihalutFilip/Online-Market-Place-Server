using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OnlineMarketPlace.Domain
{
    public class Product : Entity
    {
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public byte[] ImageBase64 { get; set; }

        public User User { get; set; }
        public int UserId { get; set; }

        public ProductType ProductType { get; set; }
        public int ProductTypeId { get; set; }

        public ICollection<AttributeValue> AttributeValues { get; set; }
    }
}
