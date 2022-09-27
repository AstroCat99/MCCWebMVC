using MCCWebAPI.Context;
using MCCWebAPI.Models;
using MCCWebAPI.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MCCWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KaryawanController : ControllerBase
    {
        MyContext myContext;

        public KaryawanController(MyContext myContext)
        {
            this.myContext = myContext;
        }

        //READ
        [HttpGet]
        public IActionResult Get()
        {
            var data = myContext.Karyawans.Include(data => data.Jabatan).Include(data => data.Gaji).ToList();
            if (data.Count == 0)
                return Ok(new { message = "sukses mengambil data", statusCode = 200, data = "null" });
            return Ok(new { message = "sukses mengambil data", statusCode = 200, data = data });
        }

        [HttpPost("{id}")]
        public IActionResult Get(int id)
        {
            var data = myContext.Karyawans.Find(id);
            if (data == null)
                return Ok(new { message = "sukses mengambil data", statusCode = 200, data = "null" });
            return Ok(new { message = "sukses mengambil data", statusCode = 200, data = data });
        }

        //UPDATE
        [HttpPut]
        public IActionResult Put(KaryawanViewModel karyawan)
        {
            var data = myContext.Karyawans.Find(karyawan.Id);
            data.Name = karyawan.Name;
            data.Ktp = karyawan.Ktp;
            data.Telpon = karyawan.Telpon;
            data.JabatanId = karyawan.JabatanId;
            data.GajiId = karyawan.GajiId;
            myContext.Karyawans.Update(data);
            var result = myContext.SaveChanges();
            if (result > 0)
                return Ok(new { statusCode = 200, message = "Berhasil mengupdate data" });
            return BadRequest(new { statusCode = 400, message = "Gagal mengupdate data" });
        }

        //CREATE 
        [HttpPost]
        public IActionResult Post(KaryawanViewModel karyawan)
        {
            //myContext.Karyawans.Add(karyawan);
            myContext.Karyawans.Add(new Karyawan
            {
                Id = karyawan.Id,
                Name = karyawan.Name,
                Ktp = karyawan.Ktp,
                JabatanId = karyawan.JabatanId,
                GajiId = karyawan.GajiId
            });
            var result = myContext.SaveChanges();
            if (result > 0)
                return Ok(new { statusCode = 200, message = "Berhasil menambahkan data" });
            return BadRequest(new { statusCode = 400, message = "Gagal menambahkan data" });
        }

        //DELETE
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var data = myContext.Karyawans.Find(id);
            myContext.Karyawans.Remove(data);
            var result = myContext.SaveChanges();
            if (result > 0)
                return Ok(new { statusCode = 200, message = "Berhasil menghapus data" });
            return BadRequest(new { statusCode = 400, message = "Gagal menghapus data" });
        }
    }
}
