using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace car_rental.application.DTOs
{
    public class OfferDTO
    {
        public Guid Id { get; set; } = new Guid();
        //prop
        public string OfferName { get; set; }
       
        public string OfferDesc { get; set; }
       

    }
}
