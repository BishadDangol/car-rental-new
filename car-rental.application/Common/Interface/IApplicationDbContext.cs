using car_rental.domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace car_rental.application.Common.Interface
{
    public interface IApplicationDbContext
    {
        DbSet<Vehicle> Vehicle { get; set; }
        DbSet<Request> Request { get; set; }
        DbSet<Customer> Customer { get; set; }
        DbSet<Staff> Staff { get; set; }
        DbSet<User> User { get; set; }
        DbSet<Document> Document {get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
