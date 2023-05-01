using car_rental.application.Common.Interface;
using car_rental.application.DTOs;
using car_rental.domain.Entities;
using CarRentalSystem.Application.Common.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace car_rental.Controllers
{
    public class VehicleController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileService _fileService;
        private readonly IUserService _userService;
        public VehicleController(IUnitOfWork unitOfWork, IFileService fileService, IUserService userService)
        {
            _unitOfWork = unitOfWork;
            _fileService = fileService;
            _userService = userService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AdminDisplayVehicle()
        {
            //List<Vehicle> vehicleList = _unitOfWork.Vehicle.GetAllAsync().toList;
            List<Vehicle> vehicleList = _unitOfWork.Vehicle.GetAll();
            return View(vehicleList);
        }

        [HttpGet]
        public IActionResult DisplayVehicle()
        {
            //List<Vehicle> vehicleList = _unitOfWork.Vehicle.GetAllAsync().toList;
            List<Vehicle> vehicleList = _unitOfWork.Vehicle.GetAll();
            return View(vehicleList);
        }

        [HttpGet]
        public IActionResult AddVehicle()
        {
            Vehicle vehicle = new Vehicle();
            return View(vehicle);
        }
        [HttpPost]
        public IActionResult AddVehicle(VehicleRequestDTO model)
        {
            //_unitOfWork.Vehicle.Add(vehicle);
            //_unitOfWork.SaveChangesAsync();
            //return RedirectToAction("Index", "Home");

            Vehicle vehicle = new Vehicle();

            //if (model.PhotoUrl != null)
            if (model.PhotoUrl != null && model.PhotoUrl.Length > 0)
            {
                var result = _fileService.SaveImage(model.PhotoUrl);
                if (result.Item1 == 1)
                {
                    vehicle.VehicleImage = result.Item2;
                }

            }

            vehicle.Name = model.Name;
            vehicle.Description = model.Description;
            vehicle.Color = model.Color;
            vehicle.Brand = model.Brand;
            vehicle.Rate = model.Rate;

            _unitOfWork.Vehicle.Add(vehicle);
            _unitOfWork.SaveChangesAsync();

            return RedirectToAction("AdminDashboard", "Home");
        }





        //[HttpGet]
        //public IActionResult DisplayVehicleAdmin()
        //{

        //    List<Vehicle> vehicleList = _unitOfWork.Vehicle.GetAll().Where(x => x.IsAvailable == true).ToList();

        //    return View(vehicleList);
        //}
        //[HttpGet]
        //public async Task<IActionResult> Rent(Guid id)
        //{
        //    var claimsIdentity = (ClaimsIdentity)User.Identity;
        //    var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
        //    var user = new string(claim.Value);
        //    var customer = _unitOfWork.Customer.GetFirstOrDefault(x => x.UserId == user);
        //    var document = _userService.GetDocument(user);
        //    RentVehicleDTO model = new RentVehicleDTO();

        //    if (document != "")
        //    {
        //        model.DocumentExists = true;
        //        model.DocumentName = document;
        //    }
        //    model.Vehicle = _unitOfWork.Vehicle.Get(id);
        //    model.Vehicleid = id;
        //    model.CustomerId = customer.Id;
        //    return View(model);

        //}
        //[HttpPost]
        //public IActionResult Rent(RentVehicleDTO model)
        //{

        //    Rental rental = new Rental()
        //    {
        //        VehicleId = model.Vehicleid,
        //        CustomerId = model.CustomerId,
        //        RequestedDate = model.RequestedDate,
        //    };
        //    Document document = new Document();
        //    _unitOfWork.Vehicle.Update(model.Vehicleid);
        //    if (model.DocumentUrl != null)
        //    {
        //        var result = _fileService.SaveImage(model.DocumentUrl);
        //        if (result.Item1 == 1)
        //        {
        //            document.DocumentName = result.Item2;
        //        }
        //        document.DocumentType = model.DocumentType;
        //        document.CustomerId = model.CustomerId;
        //        _unitOfWork.Document.Add(document);


        //    }
        //    _unitOfWork.Rental.Add(rental);
        //    _unitOfWork.SaveChangesAsync();
        //    return RedirectToAction("Index", "Home");


        //}
    }
}
