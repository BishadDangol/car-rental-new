using car_rental.application.Common.Interface;
using car_rental.domain.Entities;
using car_rental.infrastructure.Persistence;
using car_rental.infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace car_rental.infrastructure.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomer
    {
        private readonly ApplicationDbContext _context;
        public CustomerRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public Guid GetCustomerId(string id)
        {
            var customer = _context.Customer.FirstOrDefault(x => x.UserId == id);
            return customer.Id;
        }
    }
}
