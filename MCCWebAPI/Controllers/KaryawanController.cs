using MCCWebAPI.Context;
using MCCWebAPI.Models;
using MCCWebAPI.Models.ViewModels;
using MCCWebAPI.Respositories.Data;
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
        KaryawanRepository karyawanRepository;

        public KaryawanController(KaryawanRepository karyawanRepository)
        {
            this.karyawanRepository = karyawanRepository;
        }

        //READ
        [HttpGet]
        public IActionResult Get()
        {
            var data = karyawanRepository.Get();
            if (data.Count == 0)
                return Ok(new { message = "sukses mengambil data", statusCode = 200, data = "null" });
            return Ok(new { message = "sukses mengambil data", statusCode = 200, data = data });
        }

        [HttpPost("{id}")]
        public IActionResult Get(int id)
        {
            var data = karyawanRepository.Get(id); 
            if (data == null)
                return Ok(new { message = "sukses mengambil data", statusCode = 200, data = "null" });
            return Ok(new { message = "sukses mengambil data", statusCode = 200, data = data });
        }

        //UPDATE
        [HttpPut]
        public IActionResult Put(KaryawanViewModel karyawan)
        {
            var result = karyawanRepository.Put(karyawan);
            if (result > 0)
                return Ok(new { statusCode = 200, message = "Berhasil mengupdate data" });
            return BadRequest(new { statusCode = 400, message = "Gagal mengupdate data" });
        }

        //CREATE 
        [HttpPost]
        public IActionResult Post(KaryawanViewModel karyawan)
        {
            var result = karyawanRepository.Post(karyawan);
            if (result > 0)
                return Ok(new { statusCode = 200, message = "Berhasil menambahkan data" });
            return BadRequest(new { statusCode = 400, message = "Gagal menambahkan data" });
        }

        //DELETE
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = karyawanRepository.Delete(id);
            if (result > 0)
                return Ok(new { statusCode = 200, message = "Berhasil menghapus data" });
            return BadRequest(new { statusCode = 400, message = "Gagal menghapus data" });
        }
    }
}
