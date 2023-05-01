using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace car_rental.domain.Entities
{
    public class Customer
    {
        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        //public string PhoneNumer { get; set; }
        //public string UserName { get; set; }
        //public string Password { get; set; }
        //public string Email { get; set; }
        public Guid Id { get; set; } = Guid.NewGuid();
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User AppUser { get; set; }
    }
}
