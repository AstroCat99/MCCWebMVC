using MCCWebMVC.Contexts;
using MCCWebMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace MCCWebMVC.Controllers
{
    public class KaryawanController : Controller
    {
        MyContext myContext;

        public KaryawanController(MyContext myContext)
        {
            this.myContext = myContext;
        }

        public IActionResult Index()
        {
            var data = myContext.Karyawans.ToList();

            return View(data);
        }

        //CREATE
        //get
        public IActionResult Create()
        {
            return View();
        }

        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Karyawan karyawan)
        {
            if (ModelState.IsValid)
            {
                myContext.Karyawans.Add(karyawan);
                var result = myContext.SaveChanges();
                if (result > 0)
                    return RedirectToAction("Index");
            }
            return View();
        }

        //UPDATE
        //GET
        public IActionResult Edit(int id)
        {
            var data = myContext.Karyawans.Where(x => x.Id == id).SingleOrDefault();
            return View(data);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Karyawan karyawan)
        {
            var data = myContext.Karyawans.FirstOrDefault(x => x.Id == id);

            if (data != null)
            {
                data.Name = karyawan.Name;
                data.Ktp = karyawan.Ktp;
                data.Telpon = karyawan.Telpon;
                data.JabatanId = karyawan.JabatanId;
                data.GajiId = karyawan.GajiId;
                myContext.SaveChanges();

                return RedirectToAction("Index");
            }
            else
                return View();
        }

        //DELETE
        //get
        public IActionResult Delete(int id)
        {
            var data = myContext.Karyawans.Where(x => x.Id == id).SingleOrDefault();
            return View(data);
        }

        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, Gaji karyawan)
        {
            var data = myContext.Karyawans.FirstOrDefault(x => x.Id == id);
            if (data != null)
            {
                myContext.Karyawans.Remove(data);
                myContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
                return View();
        }

        //DETAILS
        public IActionResult Details(int id)
        {
            var data = myContext.Karyawans.Where(x => x.Id == id).SingleOrDefault();
            return View(data);
        }
    }
}
