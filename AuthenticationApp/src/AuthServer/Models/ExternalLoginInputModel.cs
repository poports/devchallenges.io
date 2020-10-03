using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AuthServer.Models
{
    public class ExternalLoginInputModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
