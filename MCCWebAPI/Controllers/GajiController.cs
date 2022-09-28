using MCCWebAPI.Context;
using MCCWebAPI.Models;
using MCCWebAPI.Respositories.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace MCCWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GajiController : ControllerBase
    {
        GajiRepository gajiRepository;

        public GajiController(GajiRepository gajiRepository)
        {
            this.gajiRepository = gajiRepository;
        }

        //READ
        [HttpGet]
        public IActionResult Get()
        {
            var data = gajiRepository.Get();
            if (data.Count == 0)
                return Ok(new { message = "sukses mengambil data", statusCode = 200, data = "null" });
            return Ok(new { message = "sukses mengambil data", statusCode = 200, data = data });
        }

        [HttpPost("{id}")]
        public IActionResult Get(int id)
        {
            var data = gajiRepository.Get(id);
            if (data == null)
                return Ok(new { message = "sukses mengambil data", statusCode = 200, data = "null" });
            return Ok(new { message = "sukses mengambil data", statusCode = 200, data = data });
        }

        //UPDATE
        [HttpPut]
        public IActionResult Put(Gaji gaji)
        {
            var result = gajiRepository.Put(gaji);
            if (result > 0)
                return Ok(new { statusCode = 200, message = "Berhasil mengupdate data" });
            return BadRequest(new { statusCode = 400, message = "Gagal mengupdate data" });
        }

        //CREATE 
        [HttpPost]
        public IActionResult Post(Gaji gaji)
        {
            var result = gajiRepository.Post(gaji);
            if (result > 0)
                return Ok(new { statusCode = 200, message = "Berhasil menambahkan data" });
            return BadRequest(new { statusCode = 400, message = "Gagal menambahkan data" });
        }

        //DELETE
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = gajiRepository.Delete(id);
            if (result > 0)
                return Ok(new { statusCode = 200, message = "Berhasil menghapus data" });
            return BadRequest(new { statusCode = 400, message = "Gagal menghapus data" });
        }
    }
}
