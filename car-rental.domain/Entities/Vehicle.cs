using car_rental.domain.Shared;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace car_rental.domain.Entities
{
    public class Vehicle : BaseEntity
    {
        public Guid Id { get; set; } = new Guid();
        //prop
        public string Name { get; set; }
        public string Color { get; set; }
        public string Brand { get; set; }
        public int Rate { get; set; }
        public bool IsAvailable { get; set; }
        public string? Description { get; set; }

        public string? VehicleImage { get; set; }
        [NotMapped]
        public IFormFile? PhotoUrl { get; set; }

    }
}
