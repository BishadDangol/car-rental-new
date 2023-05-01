using car_rental.domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace car_rental.application.DTOs
{
    public class CustomerRegisterDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string Email {  get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

    }
}
