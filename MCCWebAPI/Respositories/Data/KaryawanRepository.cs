using MCCWebAPI.Context;
using MCCWebAPI.Models;
using MCCWebAPI.Models.ViewModels;
using MCCWebAPI.Respositories.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace MCCWebAPI.Respositories.Data
{
    public class KaryawanRepository : IKaryawanRepository
    {
        MyContext myContext;

        public KaryawanRepository(MyContext myContext)
        {
            this.myContext = myContext;
        }

        public int Delete(int id)
        {
            var data = Get(id);
            myContext.Karyawans.Remove(data);
            var result = myContext.SaveChanges();
            return result;
        }

        public List<EmployeeData> Get()
        {
            var data = myContext.Karyawans.Include(data => data.Jabatan).Include(data => data.Gaji).ToList();
            return data;
        }

        public EmployeeData Get(int id)
        {
            var data = myContext.Karyawans.Find(id);
            return data;
        }

        public int Post(KaryawanViewModel karyawan)
        {
            myContext.Karyawans.Add(new EmployeeData
            {
                Id = karyawan.Id,
                Name = karyawan.Name,
                Ktp = karyawan.Ktp,
                JabatanId = karyawan.JabatanId,
                GajiId = karyawan.GajiId
            });
            var result = myContext.SaveChanges();
            return result;
        }

        public int Put(KaryawanViewModel karyawan)
        {
            var data = myContext.Karyawans.Find(karyawan.Id);
            data.Name = karyawan.Name;
            data.Ktp = karyawan.Ktp;
            data.Telpon = karyawan.Telpon;
            data.JabatanId = karyawan.JabatanId;
            data.GajiId = karyawan.GajiId;
            myContext.Karyawans.Update(data);
            var result = myContext.SaveChanges();
            return result;
        }

        
    }
}
