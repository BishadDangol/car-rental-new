using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace car_rental.application.Common.Interface
{
    public interface IUnitOfWork
    {
        IVehicle Vehicle { get; set; }
        IUser User { get; set; }
        ICustomer Customer { get; set; }
        IStaff Staff { get; set; }
        IDocument Document { get; set; }
        IOffer Offer { get; set; }

        Task<int> SaveChangesAsync();
    }
}
