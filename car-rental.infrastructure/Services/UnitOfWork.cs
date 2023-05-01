using car_rental.application.Common.Interface;
using car_rental.domain.Entities;
//using car_rental.infrastructure.Migrations;
using car_rental.infrastructure.Persistence;
using car_rental.infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace car_rental.infrastructure.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;
        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            Vehicle = new VehicleRepository(_dbContext);
            Customer = new CustomerRepository(_dbContext);
            Staff = new StaffRepository(_dbContext);
            Document = new DocumentRepository(_dbContext);
            Offer = new OfferRepository(_dbContext);
        }
        public IVehicle Vehicle { get; set; }
        public IUser User { get; set; }
        public ICustomer Customer { get; set; }
        public IStaff Staff { get; set; }
        public IDocument Document { get; set; }

        public IOffer Offer { get; set; }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync(); 
        }
    }
}
