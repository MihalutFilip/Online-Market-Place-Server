using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OnlineMarketPlace.Domain
{
    public class AttributeType : Entity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public DataType DataType { get; set; }

        public ProductType ProductType { get; set; }
        public int ProductTypeId { get; set; }

        public ICollection<AttributeValue> AttributeValues { get; set; }
    }
}
