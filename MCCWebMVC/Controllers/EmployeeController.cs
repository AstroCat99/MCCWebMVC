using MCCWebMVC.Context;
using MCCWebMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace MCCWebMVC.Controllers
{
    public class EmployeeController : Controller
    {
        MyContext myContext;

        public EmployeeController(MyContext myContext)
        {
            this.myContext = myContext;
        }


        //READ
        public IActionResult Index()
        {
            //var data = myContext.Employees.ToList();

            //return View(data);
            var role = HttpContext.Session.GetString("Role");
            if (role == null)
                role = "Guest";
            if (role.Equals("Admin"))
            {
                var data = myContext.Employees.Include(data => data.Jabatan).ToList();
                if (data != null)
                    return View(data);
            }
            return RedirectToAction("Unauthorized", "ErrorPage"); 
        }
        //CREATE
        //get
        public IActionResult Create()
        {
            ViewBag.JabatanId = new SelectList(myContext.Jabatans, "Id", "Id");
            return View();
        }

        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                ViewBag.JabatanId = new SelectList(myContext.Jabatans, "Id", "Id",employee.JabatanId);
                myContext.Employees.Add(employee);
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
            var data = myContext.Employees.Where(x => x.Id == id).SingleOrDefault();
            ViewBag.JabatanId = new SelectList(myContext.Jabatans, "Id", "Id");
            return View(data);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Employee employee)
        {
            var data = myContext.Employees.FirstOrDefault(x => x.Id == id);

            ViewBag.JabatanId = new SelectList(myContext.Jabatans, "Id", "Id", employee.JabatanId);

            if (data != null)
            {
                data.FullName = employee.FullName;
                data.Email = employee.Email;
                data.Telpon = employee.Telpon;
                data.JabatanId = employee.JabatanId;
                myContext.SaveChanges();

                return RedirectToAction("Index");
            }
            else
                return View();
        }

        //UPDATE
        //GET
        public IActionResult EditByEmployee(int id)
        {

            //var data = myContext.Employees.Where(x => x.Id == id).SingleOrDefault();
            //ViewBag.JabatanId = new SelectList(myContext.Jabatans, "Id", "Id");
            //return View(data);

            var role = Convert.ToInt32(HttpContext.Session.GetString("Id"));
            if (id > 0)
            {
                var data = myContext.Employees.Where(x => x.Id == id).SingleOrDefault();
                if (data != null)
                    return View(data);
            }
            else
            {
                var data1 = myContext.Employees.Where(x => x.Id == role).SingleOrDefault();
                if (data1 != null)
                    return View(data1);
            }
            
            return RedirectToAction("Unauthorized", "ErrorPage");
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditByEmployee(int id, Employee employee)
        {
            var data = myContext.Employees.FirstOrDefault(x => x.Id == id);

            var jabatanId = HttpContext.Session.GetString("JabatanId");

            if (data != null)
            {
                data.FullName = employee.FullName;
                data.Email = employee.Email;
                data.Telpon = employee.Telpon;
                data.JabatanId = Convert.ToInt32(jabatanId);
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
            var data = myContext.Employees.Where(x => x.Id == id).SingleOrDefault();
            return View(data);
        }

        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, Employee employee)
        {
            var data = myContext.Employees.FirstOrDefault(x => x.Id == id);
            if (data != null)
            {
                myContext.Employees.Remove(data);
                myContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
                return View();
        }

        //DETAILS
        public IActionResult Details(int id)
        {
            var data = myContext.Employees.Where(x => x.Id == id).SingleOrDefault();
            return View(data);
        }
    }
}
