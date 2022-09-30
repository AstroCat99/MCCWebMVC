using MCCWebAPI.Context;
using MCCWebAPI.Models;
using MCCWebAPI.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
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
            var same = false;
            var data = myContext.UserRoles.
                Include(data => data.User.Employee).
                Include(data => data.User).
                Include(data => data.Role).
                FirstOrDefault(
                x => x.User.Employee.Email.Equals(login.Email));

            if (data == null)
                return null;
            else if (data != null)
                same = ValidatePassword(login.Password,data.User.Password);
            else
                return null;

            return new ResponseLogin
            {
                Id = data.Id,
                Email = data.User.Employee.Email,
                FullName = data.User.Employee.FullName,
                Role = data.Role.Name,
                JabatanId = data.User.Employee.JabatanId
            };
        }

        public int Register(AccountViewModel accountViewModel) 
        {
            var result = 0;
            Employee pegawai = new Employee
            {
                Id = 0,
                FullName = accountViewModel.FullName,
                Email = accountViewModel.Email,
                Telpon = "0",
                JabatanId = 1
            };
            myContext.Employees.Add(pegawai);
            var pegawaiSaved = myContext.SaveChanges();
            if (pegawaiSaved > 0)
            {
                var dataPegawai = myContext.Employees.
                FirstOrDefault(
                x => x.FullName.Equals(pegawai.FullName)
                &&
                x.Email.Equals(pegawai.Email));

                Gaji gaji = new Gaji
                {
                    Id = dataPegawai.Id,
                    Pokok = 0,
                    Bank = "Default",
                    Rekening = "0"
                };

                User user = new User
                {
                    Id = dataPegawai.Id,
                    Password = HashPassword(accountViewModel.Password)
                };
                myContext.Users.Add(user);
                var userSaved = myContext.SaveChanges();
                if (userSaved > 0)
                {
                    var dataUser = myContext.Users.
                    FirstOrDefault(
                    x => x.Id.Equals(pegawai.Id));
                    UserRole userRole = new UserRole
                    {
                        Id = 0,
                        UserId = dataUser.Id,
                        RoleId = 2
                    };
                    myContext.UserRoles.Add(userRole);
                    var userRoleSaved = myContext.SaveChanges();
                    result = 1;
                }
            }
            return result;
        }

        private static string GetRandomSalt()
        {
            return BCrypt.Net.BCrypt.GenerateSalt(12);
        }

        private static string HashPassword(string password)
        { 
            return BCrypt.Net.BCrypt.HashPassword(password,GetRandomSalt());
        }

        private static bool ValidatePassword(string password, string correctHash)
        {
            return BCrypt.Net.BCrypt.Verify(password,correctHash);
        }

        public int Change(ChangePasswordViewModel changePasswordViewModel)
        {
            var same = false;
            var result = 0;
            var data = myContext.UserRoles.
                Include(data => data.User.Employee).
                Include(data => data.User).
                FirstOrDefault(
                x => x.User.Employee.Email.Equals(changePasswordViewModel.Email));

            if (data == null)
                return result;
            else if (data != null)
                same = ValidatePassword(changePasswordViewModel.OldPassword, data.User.Password);
            else
                return result;

            if (same == true)
            {
                var newData = myContext.Users.Find(data.User.Id);
                newData.Password = HashPassword(changePasswordViewModel.NewPassword);
                myContext.Users.Update(newData);
                result = myContext.SaveChanges();
                return result;
            }
            else 
            {
                return result;
            }
        }

        public int Forgot(AccountViewModel accountViewModel)
        {
            var same = false;
            var result = 0;
            var data = myContext.UserRoles.
                Include(data => data.User.Employee).
                Include(data => data.User).
                FirstOrDefault(
                x => x.User.Employee.FullName.Equals(accountViewModel.FullName)
                &&
                x.User.Employee.Email.Equals(accountViewModel.Email));

            if (data == null)
                return result;
            else if (data != null)
            {
                var newData = myContext.Users.Find(data.User.Id);
                newData.Password = HashPassword(accountViewModel.Password);
                myContext.Users.Update(newData);
                result = myContext.SaveChanges();
                return result;
            }
            else
                return result;
        }
    }
}
