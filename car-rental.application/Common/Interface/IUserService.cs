using car_rental.domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace car_rental.application.Common.Interface
{
    public interface IUserService
    {
        string GetDocument(string id);

        Task<User> GetUser(string Id);

        Task<IEnumerable<User>> GetUserDetails();

        string GetUserName(string email);

        void LockUser(string Id);

        void UnlockUser(string Id);
    }
}
