using MCCWebAPI.Context;
using MCCWebAPI.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MCCWebAPI.Respositories.Data
{
    public class AccountRepository
    {
        MyContext myContext;

        public AccountRepository(MyContext myContext)
        {
            this.myContext = myContext;
        }

        public ResponseLogin Login(Login login)
        {
            var data = myContext.UserRoles.
                Include(data => data.User.Employee).
                Include(data => data.User).
                Include(data => data.Role).
                FirstOrDefault(
                x => x.User.Employee.Email.Equals(login.Email)
                &&
                x.User.Password.Equals(login.Password));

            if (data == null)
                return null;
            else if (data != null && !login.Password.Equals(data.User.Password))
                return null;

            return new ResponseLogin
            {
                Id = data.Id,
                Email = data.User.Employee.Email,
                FullName = data.User.Employee.FullName,
                Role = data.Role.Name

            };
        }
    }
}
