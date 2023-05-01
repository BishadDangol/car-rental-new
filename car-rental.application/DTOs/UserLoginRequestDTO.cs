using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace car_rental.application.DTOs
{
    public class UserLoginRequestDTO
    {
        [Required(ErrorMessage = "User Name is required")]
        public string Username { get; set; }
        public string Email { get; set; }
        public bool RememberMe { get; set; }



        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
