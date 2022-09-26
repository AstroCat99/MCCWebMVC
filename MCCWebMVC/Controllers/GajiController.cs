﻿using MCCWebMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Data.SqlClient;
using MCCWebMVC.Contexts;
using System.Linq;

namespace MCCWebMVC.Controllers
{
    public class GajiController : Controller
    {
        MyContext myContext;

        public GajiController(MyContext myContext)
        {
            this.myContext = myContext;
        }


        //READ
        public IActionResult Index()
        {
            var data = myContext.Gajis.ToList();

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
        public IActionResult Create(Gaji gaji)
        {
            if (ModelState.IsValid)
            {
                myContext.Gajis.Add(gaji);
                var result = myContext.SaveChanges();
                if(result > 0)
                    return RedirectToAction("Index");
            }
            return View();
        }

        //UPDATE
        //GET
        public IActionResult Edit(int id)
        {
            var data = myContext.Gajis.Where(x => x.Id == id).SingleOrDefault();
            return View(data);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Gaji gaji)
        {
            var data = myContext.Gajis.FirstOrDefault(x => x.Id == id);

            if (data != null)
            {
                data.Pokok = gaji.Pokok;
                data.Tunjangan = gaji.Tunjangan;
                data.Akomodasi = gaji.Akomodasi;
                data.Bank = gaji.Bank;
                data.Rekening = gaji.Rekening;
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
            var data = myContext.Gajis.Where(x => x.Id == id).SingleOrDefault();
            return View(data);
        }

        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, Gaji gaji)
        {
            var data = myContext.Gajis.FirstOrDefault(x => x.Id == id);
            if (data != null)
            {
                myContext.Gajis.Remove(data);
                myContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
                return View();
        }

        //DETAILS
        public IActionResult Details(int id)
        {
            var data = myContext.Gajis.Where(x => x.Id == id).SingleOrDefault();
            return View(data);
        }

    }
}
