using MCCWebAPI.Models.ViewModels;
using MCCWebMVC.Models.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System;

namespace MCCWebMVC.Controllers
{
    public class SelfReportController : Controller
    {
        HttpClient HttpClient;

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CutiLiburViewModel cutiLiburViewModel)
        {
            string address = "https://localhost:5001/api/CutiLibur/NewSelfReport";
            HttpClient = new HttpClient
            {
                BaseAddress = new Uri(address)
            };

            var Id = Convert.ToInt32(HttpContext.Session.GetString("Id"));
            CutiLiburViewModel data = new CutiLiburViewModel
            {
                EmployeeId = Id,
                Bulan = cutiLiburViewModel.Bulan,
                Cuti = cutiLiburViewModel.Cuti,
                Libur = cutiLiburViewModel.Libur,
                Status = "Belum Approve"
            };

            StringContent content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            var result = HttpClient.PostAsync(address, content).Result;
            if (result.IsSuccessStatusCode)
            {
                //var data = JsonConvert.DeserializeObject<ResponseClient>(await result.Content.ReadAsStringAsync());
                //HttpContext.Session.SetString("Role", "Unauthorized");
                return RedirectToAction("Berhasil", "SelfReport");
            }
            return View();
        }

        public IActionResult Berhasil()
        {
            return View();
        }
    }
}
