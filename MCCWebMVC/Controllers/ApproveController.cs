using MCCWebAPI.Models.ViewModels;
using MCCWebMVC.Context;
using MCCWebMVC.Models.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MCCWebMVC.Controllers
{
    public class ApproveController : Controller
    {
        HttpClient HttpClient;
        MyContext myContext;

        public ApproveController(MyContext myContext)
        {
            this.myContext = myContext;
        }


        //READ
        public IActionResult Index()
        {
            //var data = myContext.Gajis.ToList();

            //return View(data);
            var role = HttpContext.Session.GetString("Role");
            if (role == null)
                role = "Guest";
            if (role.Equals("Admin"))
            {
                var data = myContext.CutiLiburs.Include(data => data.Employee).
                    ToList().Where(data => data.Status.Equals("Belum Approve"));
                if (data != null)
                    return View(data);
            }
            return RedirectToAction("Unauthorized", "ErrorPage");
        }

        public IActionResult ApproveSelfReport(int id) {
                var data = myContext.CutiLiburs.
                    FirstOrDefault(
                    x => x.Id.Equals(id));

                if (data == null)
                    return null;
                else
                return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> ApproveSelfReport(CutiLiburViewModel cutiLiburViewModel)
        {
            string address = "https://localhost:5001/api/CutiLibur/ApproveSelfReport";
            HttpClient = new HttpClient
            {
                BaseAddress = new Uri(address)
            };

            StringContent content = new StringContent(JsonConvert.SerializeObject(cutiLiburViewModel), Encoding.UTF8, "application/json");
            var result = HttpClient.PostAsync(address, content).Result;
            if (result.IsSuccessStatusCode)
            {
                //var data = JsonConvert.DeserializeObject<ResponseClient>(await result.Content.ReadAsStringAsync());
                //HttpContext.Session.SetString("Role", "Unauthorized");
                return RedirectToAction("Index", "Approve");
            }
            return View();
        }

    }
}
