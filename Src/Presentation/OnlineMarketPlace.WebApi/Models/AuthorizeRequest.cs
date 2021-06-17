using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.ViewModels
{
    public class AuthorizeRequest
    {
        [Required]
        public string Email { set; get; }

        [Required]
        public string Password { set; get; }
    }
}
