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
    public class AccountController : Controller
    {
        HttpClient HttpClient;
        string address;

        public AccountController()
        {
            this.address = "https://localhost:44378/api/Account/";
            HttpClient = new HttpClient
            {
                BaseAddress = new Uri(address)
            };
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Login login)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(login), Encoding.UTF8, "application/json");
            var result = HttpClient.PostAsync(address, content).Result;
            if (result.IsSuccessStatusCode)
            {
                var data = JsonConvert.DeserializeObject<ResponseClient>(await result.Content.ReadAsStringAsync());
                HttpContext.Session.SetString("Role", data.Data.Role);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }


    }
}
