﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace car_rental.domain.Entities
{
    public class User : IdentityUser
    {
        public String? FirstName { get; set; }
        public String? LastName { get; set; }
        //public string Username { get; set; }
        //[EmailAddress]
        //public string Email { get; set; }

        //public string Password { get; set; }


        //public string? Name { get; set; }

        //public string? Address { get; set; }

        //public string? Phone { get; set; }

    }
}
