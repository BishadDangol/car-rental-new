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
    public class VehicleRepository: Repository<Vehicle>, IVehicle
    {
        public readonly ApplicationDbContext _context;
        public VehicleRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
