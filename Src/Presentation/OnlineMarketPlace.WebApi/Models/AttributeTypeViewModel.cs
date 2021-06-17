using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineMarketPlace.Domain;

namespace OnlineMarketPlace.WebApi.Models
{
    public class AttributeTypeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DataType DataType { get; set; }
    }
}
