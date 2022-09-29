using MCCWebAPI.Models;
using MCCWebAPI.Models.ViewModels;
using MCCWebAPI.Respositories.Data;
using MCCWebAPI.Respositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MCCWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        AccountRepository accountRepository;

        public AccountController(AccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        [HttpPost("login")]
        public IActionResult Login(Login login)
        {
            var data = accountRepository.Login(login);
            if (data == null)
            {
                return BadRequest(new { message = "Gagal login! Email atau password salah", StatusCode = 400 });
            }
            return Ok(new { message = "Berhasil login!", StatusCode = 200, data = data });
        } 

        //REGISTRASI BARU
        [HttpPost("register")]
        public IActionResult Registrasi(AccountViewModel accountViewModel)
        {
            var result = accountRepository.Register(accountViewModel);
            if (result > 0)
                return Ok(new { statusCode = 200, message = "Berhasil menambahkan data" });
            return BadRequest(new { statusCode = 400, message = "Gagal menambahkan data" });
        }

        [HttpPost("changePass")]
        public IActionResult Change(ChangePasswordViewModel changePasswordViewModel)
        {
            var result = accountRepository.Change(changePasswordViewModel);
            if (result > 0)
                return Ok(new { statusCode = 200, message = "Berhasil mengubah password" });
            return BadRequest(new { statusCode = 400, message = "Gagal mengubah password" });
        }

        [HttpPost("forgotPass")]
        public IActionResult Forgot(AccountViewModel accountViewModel)
        {
            var result = accountRepository.Forgot(accountViewModel);
            if (result > 0)
                return Ok(new { statusCode = 200, message = "Berhasil membuat ulang password" });
            return BadRequest(new { statusCode = 400, message = "Gagal membuat ulang password" });
        }
    }
}
