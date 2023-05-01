using car_rental.application.DTOs;
using car_rental.domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace car_rental.application.Common.Interface
{
    public interface IVehicle: IRepository<Vehicle>
    {
        //Task<List<VehicleRequestDTO>> GetAllVehiclesAsync();
        //Task<List<VehicleRequestDTO>> GetAllVehicles();
        //Task<ResponseDTO> AddVehicleDetails(VehicleRequestDTO vehicle);
    }
}
