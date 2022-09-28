using MCCWebAPI.Context;
using MCCWebAPI.Models;
using MCCWebAPI.Respositories.Interface;
using System.Collections.Generic;
using System.Linq;

namespace MCCWebAPI.Respositories.Data
{
    public class GajiRepository : IGajiRepository
    {
        MyContext myContext;

        public GajiRepository(MyContext myContext)
        {
            this.myContext = myContext;
        }

        public int Delete(int id)
        {
            var data = Get(id);
            myContext.Gajis.Remove(data);
            var result = myContext.SaveChanges();
            return result;
        }

        public List<Gaji> Get()
        {
            var data = myContext.Gajis.ToList();
            return data;
        }

        public Gaji Get(int id)
        {
            var data = myContext.Gajis.Find(id);
            return data;
        }

        public int Post(Gaji gaji)
        {
            myContext.Gajis.Add(gaji);
            var result = myContext.SaveChanges();
            return result; 
        }

        public int Put(Gaji gaji)
        {
            var data = Get(gaji.Id);
            data.Pokok = gaji.Pokok;
            data.Tunjangan = gaji.Tunjangan;
            data.Akomodasi = gaji.Akomodasi;
            data.Bank = gaji.Bank;
            data.Rekening = gaji.Rekening;
            myContext.Gajis.Update(data);
            var result = myContext.SaveChanges();
            return result;
        }
    }
}
