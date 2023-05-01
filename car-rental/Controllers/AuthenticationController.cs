using car_rental.application.Common.Interface;
using car_rental.application.DTOs;
using car_rental.domain.Entities;
using CarRentalSystem.Application.Common.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace car_rental.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IUserService _userService;
        private readonly IFileService _fileService;
        private readonly IUnitOfWork _unitOfWork;

        public AuthenticationController(UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            SignInManager<IdentityUser> signInManager,
            IUserService userService,
            IUnitOfWork unitOfWork,
            IFileService fileService
        )
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _unitOfWork = unitOfWork;
            _userService = userService;
            _fileService = fileService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Register()
        {
            //ViewData["ReturnUrl"] = returnUrl;

            var register = new CustomerRegisterDTO();

            return View(register);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(CustomerRegisterDTO model)
        {
            var userInDb = await _userManager.FindByEmailAsync(model.Email);

            if (userInDb == null)
            {
                var user = new User
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    UserName= model.Email,
                    EmailConfirmed = true,

                };
                var result = await _userManager.CreateAsync(user, model.Password);
                await _userManager.AddToRoleAsync(user, "Customer");
                var customer = new Customer();

                if (result.Succeeded)
                {
                    customer.UserId = user.Id;
                     _unitOfWork.Customer.Add(customer);
                    await _unitOfWork.SaveChangesAsync();
                }
            }
            return RedirectToAction("Landing", "Home");
        }

        //Staff Reg 
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterStaff()
        {
            //ViewData["ReturnUrl"] = returnUrl;

            var register = new StaffRegisterDTO();

            return View(register);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterStaff(StaffRegisterDTO model)
        {
            var userInDb = await _userManager.FindByEmailAsync(model.Email);

            if (userInDb == null)
            {
                var user = new User
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    UserName = model.Email,
                    EmailConfirmed = true,

                };
                var result = await _userManager.CreateAsync(user, model.Password);
                await _userManager.AddToRoleAsync(user, "Staff");
                var staff = new Staff();

                if (result.Succeeded)
                {
                    staff.UserId = user.Id;
                    _unitOfWork.Staff.Add(staff);
                    await _unitOfWork.SaveChangesAsync();
                }
            }
            return RedirectToAction("AdminDashboard", "Home");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string returnurl = null)
        {
            ViewData["ReturnUrl"] = returnurl;

            var login = new UserLoginRequestDTO();

            return View(login);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserLoginRequestDTO model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            returnUrl ??= Url.Content("~/");

            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: true);

            if (result.Succeeded)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                var roles = await _userManager.GetRolesAsync(user);
              
                return LocalRedirect(returnUrl);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return View(model);
            }
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Landing","Home");
        }









        //[HttpGet]
        //public IActionResult Profile()
        //{
        //    ProfileDTO model = new ProfileDTO();
        //    var claimsIdentity = (ClaimsIdentity)User.Identity;
        //    var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
        //    var user = new string(claim.Value);
        //    var customer = _unitOfWork.Customer.GetFirstOrDefault(x => x.UserId == user);
        //    var documentName = _userService.GetDocument(user);
        //    if (documentName != "")
        //    {
        //        model.ExistingDocumentName = documentName;
        //    }

        //    return View(model);
        //}

        //[Authorize]
        //[HttpPost]
        //public IActionResult Profile(ProfileDTO model)
        //{
        //    var claimsIdentity = (ClaimsIdentity)User.Identity;
        //    var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
        //    var user = new string(claim.Value);
        //    var customer = _unitOfWork.Customer.GetFirstOrDefault(x => x.UserId == user);
        //    var documentName = _userService.GetDocument(user);
        //    Document document = new Document();

        //    if (documentName == "")
        //    {

        //        if (model.DocumentUrl != null)
        //        {
        //            var result = _fileService.SaveImage(model.DocumentUrl);
        //            if (result.Item1 == 1)
        //            {
        //                document.DocumentName = result.Item2;
        //                document.CustomerId = customer.Id;
        //            }
        //            document.DocumentType = model.DocumentType;
        //            _unitOfWork.Document.Add(document);
        //            _unitOfWork.SaveChangesAsync();

        //        }

        //    }




        //[HttpGet]
        //public IActionResult ChangePassword()
        //{
        //    ChangePasswordDTO model = new ChangePasswordDTO();


        //    return View(model);
        //}
        //[HttpPost]
        //public async Task<IActionResult> ChangePassword(ChangePasswordDTO model)
        //{
        //    var user = await _userManager.GetUserAsync(User);
        //    var changePasswordResult = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
        //    if (!changePasswordResult.Succeeded)
        //    {
        //        foreach (var error in changePasswordResult.Errors)
        //        {
        //            //ModelState.AddModelError(string.Empty, error.Description);
        //            var errormessage = error.Description;
        //        }
        //    }

        //    await _signInManager.RefreshSignInAsync(user);
        //    return RedirectToAction("Index", "Home");

        //}






        //    return RedirectToAction("Index", "Home");

        //}
        //[HttpGet]
        //[AllowAnonymous]
        //public IActionResult RentHistory()
        //{
        //    var claimsIdentity = (ClaimsIdentity)User.Identity;
        //    var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
        //    var user = new string(claim.Value);
        //    var customer = _unitOfWork.Customer.GetFirstOrDefault(x => x.UserId == user);
        //    var rental = _unitOfWork.Rental.GetAll().Where(x => x.CustomerId == customer.Id);

        //    return View(rental);
        //}

    }
}
