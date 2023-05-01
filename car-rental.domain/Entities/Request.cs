using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace car_rental.domain.Entities
{
    public class Request
    {
        public Guid Id { get; set; } = new Guid();
        //public string? UserID { get; set; }
        //[ForeignKey("UserID")]

        //public User User { get; set; }  
    }
}
