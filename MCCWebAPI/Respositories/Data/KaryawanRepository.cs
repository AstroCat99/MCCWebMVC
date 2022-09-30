using MCCWebAPI.Context;
using MCCWebAPI.Models;
using MCCWebAPI.Models.ViewModels;
using MCCWebAPI.Respositories.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace MCCWebAPI.Respositories.Data
{
    public class KaryawanRepository 
    {
        MyContext myContext;

        public KaryawanRepository(MyContext myContext)
        {
            this.myContext = myContext;
        }

        public int Delete(int id)
        {
            var data = Get(id);
            myContext.Employees.Remove(data);
            var result = myContext.SaveChanges();
            return result;
        }

        public List<Employee> Get()
        {
            var data = myContext.Employees.Include(data => data.Jabatan).ToList();
            return data;
        }

        public Employee Get(int id)
        {
            var data = myContext.Employees.Find(id);
            return data;
        }

        public int Post(KaryawanViewModel karyawan)
        {
            myContext.Employees.Add(new Employee
            {
                Id = karyawan.Id,
                Telpon = karyawan.Telpon,
                JabatanId = karyawan.JabatanId
            });
            var result = myContext.SaveChanges();
            return result;
        }

        public int Put(KaryawanViewModel karyawan)
        {
            var data = myContext.Employees.Find(karyawan.Id);
            data.Telpon = karyawan.Telpon;
            data.JabatanId = karyawan.JabatanId;
            myContext.Employees.Update(data);
            var result = myContext.SaveChanges();
            return result;
        }

        
    }
}
