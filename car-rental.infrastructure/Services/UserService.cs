using car_rental.application.Common.Interface;
using car_rental.domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace car_rental.infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public string GetDocument(string id)
        {
            var customer = _unitOfWork.Customer.GetFirstOrDefault(x => x.UserId == id);
            var document = _unitOfWork.Document.GetFirstOrDefault(x => x.CustomerId == customer.Id);
            if (document != null)
            {
                return document.DriverLicenseNumber;
            }
            else
            {
                return "";
            }
        }

        public Task<User> GetUser(string Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetUserDetails()
        {
            throw new NotImplementedException();
        }

        public string GetUserName(string email)
        {
            throw new NotImplementedException();
        }

        public void LockUser(string Id)
        {
            throw new NotImplementedException();
        }

        public void UnlockUser(string Id)
        {
            throw new NotImplementedException();
        }
    }
}
