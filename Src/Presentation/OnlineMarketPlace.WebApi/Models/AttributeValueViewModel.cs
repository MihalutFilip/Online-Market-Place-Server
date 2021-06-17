using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMarketPlace.WebApi.Models
{
    public class AttributeValueViewModel
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public AttributeTypeViewModel AttributeType { get; set; }
        public int AttributeTypeId { get; set; }
    }
}
