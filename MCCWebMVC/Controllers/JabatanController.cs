using MCCWebMVC.Contexts;
using MCCWebMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace MCCWebMVC.Controllers
{
    public class JabatanController : Controller
    {
        MyContext myContext;

        public JabatanController(MyContext myContext)
        {
            this.myContext = myContext;
        }


        //READ
        public IActionResult Index()
        {
            var data = myContext.Jabatans.ToList();

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
        public IActionResult Create(Jabatan jabatan)
        {
            if (ModelState.IsValid)
            {
                myContext.Jabatans.Add(jabatan);
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
            var data = myContext.Jabatans.Where(x => x.Id == id).SingleOrDefault();
            return View(data);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Jabatan jabatan)
        {
            var data = myContext.Jabatans.FirstOrDefault(x => x.Id == id);

            if (data != null)
            {
                data.Name = jabatan.Name;
                data.Tunjangan = jabatan.Tunjangan;
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
            var data = myContext.Jabatans.Where(x => x.Id == id).SingleOrDefault();
            return View(data);
        }

        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, Gaji jabatan)
        {
            var data = myContext.Jabatans.FirstOrDefault(x => x.Id == id);
            if (data != null)
            {
                myContext.Jabatans.Remove(data);
                myContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
                return View();
        }

        //DETAILS
        public IActionResult Details(int id)
        {
            var data = myContext.Jabatans.Where(x => x.Id == id).SingleOrDefault();
            return View(data);
        }
    }
}
