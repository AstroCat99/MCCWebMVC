using MCCWebAPI.Context;
using MCCWebAPI.Models;
using MCCWebAPI.Respositories.Interface;
using System.Collections.Generic;
using System.Linq;

namespace MCCWebAPI.Respositories.Data
{
    public class JabatanRepository : IJabatanRepository
    {
        MyContext myContext;

        public JabatanRepository(MyContext myContext)
        {
            this.myContext = myContext;
        }

        public int Delete(int id)
        {
            var data = Get(id);
            myContext.Jabatans.Remove(data);
            var result = myContext.SaveChanges();
            return result;
        }

        public List<Jabatan> Get()
        {
            var data = myContext.Jabatans.ToList();
            return data;
        }

        public Jabatan Get(int id)
        {
            var data = myContext.Jabatans.Find(id);
            return data;
        }

        public int Post(Jabatan jabatan)
        {
            myContext.Jabatans.Add(jabatan);
            var result = myContext.SaveChanges();
            return result;
        }

        public int Put(Jabatan jabatan)
        {
            var data = Get(jabatan.Id);
            data.Name = jabatan.Name;
            data.Tunjangan = jabatan.Tunjangan;
            myContext.Jabatans.Update(data);
            var result = myContext.SaveChanges();
            return result;
        }
    }
}
