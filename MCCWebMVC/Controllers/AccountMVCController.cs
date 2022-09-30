using MCCWebAPI.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;
using MCCWebMVC.Models.ViewModel;

namespace MCCWebMVC.Controllers
{
    public class AccountMVCController : Controller
    {
        HttpClient HttpClient;
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Login login)
        {
            string address = "https://localhost:5001/api/Account/Login";
            HttpClient = new HttpClient
            {
                BaseAddress = new Uri(address)
            };

            StringContent content = new StringContent(JsonConvert.SerializeObject(login), Encoding.UTF8, "application/json");
            var result = HttpClient.PostAsync(address, content).Result;
            if (result.IsSuccessStatusCode)
            {
                var data = JsonConvert.DeserializeObject<ResponseClient>(await result.Content.ReadAsStringAsync());
                HttpContext.Session.SetString("Role", data.Data.Role);
                HttpContext.Session.SetString("Id", Convert.ToString(data.Data.Id));
                HttpContext.Session.SetString("JabatanId", Convert.ToString(data.Data.JabatanId));
                var Role = HttpContext.Session.GetString("Role");
                if(Role == "Admin")
                    return RedirectToAction("Index", "Gaji");
                else
                {
                    var Id = HttpContext.Session.GetString("Id");
                    return RedirectToAction("EditByEmployee", "Employee", new { id = Id });
                }
                    
            }
            return View();
        }

        public IActionResult Registrasi()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registrasi(AccountViewModel accountViewModel)
        {
            string address = "https://localhost:5001/api/Account/Register";
            HttpClient = new HttpClient
            {
                BaseAddress = new Uri(address)
            };

            StringContent content = new StringContent(JsonConvert.SerializeObject(accountViewModel), Encoding.UTF8, "application/json");
            var result = HttpClient.PostAsync(address, content).Result;
            if (result.IsSuccessStatusCode)
            {
                var data = JsonConvert.DeserializeObject<ResponseClient>(await result.Content.ReadAsStringAsync());
                HttpContext.Session.SetString("Role", "Unauthorized");
                return RedirectToAction("Login", "AccountMVC");
            }
            return View();
        }

        public IActionResult ForgotPass()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPass(AccountViewModel accountViewModel)
        {
            string address = "https://localhost:5001/api/Account/forgotPass";
            HttpClient = new HttpClient
            {
                BaseAddress = new Uri(address)
            };

            StringContent content = new StringContent(JsonConvert.SerializeObject(accountViewModel), Encoding.UTF8, "application/json");
            var result = HttpClient.PostAsync(address, content).Result;
            if (result.IsSuccessStatusCode)
            {
                var data = JsonConvert.DeserializeObject<ResponseClient>(await result.Content.ReadAsStringAsync());
                HttpContext.Session.SetString("Role", "Unauthorized");
                return RedirectToAction("Login", "AccountMVC");
            }
            return View();
        }

        public IActionResult ChangePass()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePass(ChangePasswordViewModel changePasswordViewModel)
        {
            string address = "https://localhost:5001/api/Account/changePass";
            HttpClient = new HttpClient
            {
                BaseAddress = new Uri(address)
            };

            StringContent content = new StringContent(JsonConvert.SerializeObject(changePasswordViewModel), Encoding.UTF8, "application/json");
            var result = HttpClient.PostAsync(address, content).Result;
            if (result.IsSuccessStatusCode)
            {
                var data = JsonConvert.DeserializeObject<ResponseClient>(await result.Content.ReadAsStringAsync());
                HttpContext.Session.SetString("Role", "Unauthorized");
                return RedirectToAction("Login", "AccountMVC");
            }
            return View();
        }
    }
}
