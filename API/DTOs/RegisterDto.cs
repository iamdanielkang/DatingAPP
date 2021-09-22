using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class RegisterDTO
    {
        // Validation for username and password to prevent empty strings
        [Required] public string Username { get; set; }
        [Required] public string Password { get; set; }
    }
}