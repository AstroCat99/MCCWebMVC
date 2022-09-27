using MCCWebAPI.Context;
using MCCWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace MCCWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GajiController : ControllerBase
    {
        MyContext myContext;

        public GajiController(MyContext myContext)
        {
            this.myContext = myContext;
        }

        //READ
        [HttpGet]
        public IActionResult Get()
        {
            var data = myContext.Gajis.ToList();
            if (data.Count == 0)
                return Ok(new { message = "sukses mengambil data", statusCode = 200, data = "null" });
            return Ok(new { message = "sukses mengambil data", statusCode = 200, data = data });
        }

        [HttpPost("{id}")]
        public IActionResult Get(int id)
        {
            var data = myContext.Gajis.Find(id);
            if (data == null)
                return Ok(new { message = "sukses mengambil data", statusCode = 200, data = "null" });
            return Ok(new { message = "sukses mengambil data", statusCode = 200, data = data });
        }

        //UPDATE
        [HttpPut]
        public IActionResult Put(Gaji gaji)
        {
            var data = myContext.Gajis.Find(gaji.Id);
            data.Pokok = gaji.Pokok;
            data.Tunjangan = gaji.Tunjangan;
            data.Akomodasi = gaji.Akomodasi;
            data.Bank = gaji.Bank;
            data.Rekening = gaji.Rekening;
            myContext.Gajis.Update(data);
            var result = myContext.SaveChanges();
            if (result > 0)
                return Ok(new { statusCode = 200, message = "Berhasil mengupdate data" });
            return BadRequest(new { statusCode = 400, message = "Gagal mengupdate data" });
        }

        //CREATE 
        [HttpPost]
        public IActionResult Post(Gaji gaji)
        {
            myContext.Gajis.Add(gaji);
            var result = myContext.SaveChanges();
            if (result > 0)
                return Ok(new { statusCode = 200, message = "Berhasil menambahkan data" });
            return BadRequest(new { statusCode = 400, message = "Gagal menambahkan data" });
        }

        //DELETE
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var data = myContext.Gajis.Find(id);
            myContext.Gajis.Remove(data);
            var result = myContext.SaveChanges();
            if (result > 0)
                return Ok(new { statusCode = 200, message = "Berhasil menghapus data" });
            return BadRequest(new { statusCode = 400, message = "Gagal menghapus data" });
        }
    }
}
