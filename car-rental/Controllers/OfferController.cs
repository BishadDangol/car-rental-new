using car_rental.application.Common.Interface;
using car_rental.application.DTOs;
using car_rental.domain.Entities;
using CarRentalSystem.Application.Common.Services;
using Microsoft.AspNetCore.Mvc;

namespace car_rental.Controllers
{
    public class OfferController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileService _fileService;
        private readonly IUserService _userService;
        public OfferController(IUnitOfWork unitOfWork, IFileService fileService, IUserService userService)
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
        public IActionResult AdminDisplayOffer()
        {
            List<Offer> offerList = _unitOfWork.Offer.GetAll();
            return View(offerList);
        }

        [HttpGet]
        public IActionResult DisplayOffer()
        {
            List<Offer> offerList = _unitOfWork.Offer.GetAll();
            return View(offerList);
        }

        [HttpGet]
        public IActionResult AddOffer()
        {
            Offer offer = new Offer();
            return View(offer);
        }
        [HttpPost]
        public IActionResult AddOffer(OfferDTO model)
        {


            Offer offer = new Offer();

            offer.OfferName = model.OfferName;
            offer.OfferDesc = model.OfferDesc;
           



            _unitOfWork.Offer.Add(offer);
            _unitOfWork.SaveChangesAsync();

            return RedirectToAction("AdminDashboard", "Home");
        }
    }
}
