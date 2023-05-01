using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace car_rental.domain.Entities
{
    public class Document
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string DriverLicenseNumber { get; set; }
        public string CitizenPaperNumber { get; set; }
        public Guid CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }
    }
}
