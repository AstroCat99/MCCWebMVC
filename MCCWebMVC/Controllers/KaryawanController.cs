using MCCWebMVC.Contexts;
using MCCWebMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
            var datas = myContext.Karyawans.Include(data => data.Jabatan).ToList();

            return View(datas);
        }

        //CREATE
        //get
        public IActionResult Create()
        {
            ViewBag.JabatanId = new SelectList(myContext.Jabatans, "Id", "Id");
            ViewBag.GajiId = new SelectList(myContext.Gajis, "Id", "Id");
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
            ViewBag.JabatanId = new SelectList(myContext.Jabatans, "Id", "Id", data.JabatanId);
            ViewBag.GajiId = new SelectList(myContext.Gajis, "Id", "Id", data.GajiId);
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
