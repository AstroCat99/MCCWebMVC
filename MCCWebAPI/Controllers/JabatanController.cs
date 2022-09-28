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
    public class JabatanController : ControllerBase
    {
        JabatanRepository jabatanRepository;

        public JabatanController(JabatanRepository jabatanRepository)
        {
            this.jabatanRepository = jabatanRepository;
        }

        //READ
        [HttpGet]
        public IActionResult Get()
        {
            var data = jabatanRepository.Get();
            if (data.Count == 0)
                return Ok(new { message = "sukses mengambil data", statusCode = 200, data = "null" });
            return Ok(new { message = "sukses mengambil data", statusCode = 200, data = data });
        }

        [HttpPost("{id}")]
        public IActionResult Get(int id)
        {
            var data = jabatanRepository.Get(id);
            if (data == null)
                return Ok(new { message = "sukses mengambil data", statusCode = 200, data = "null" });
            return Ok(new { message = "sukses mengambil data", statusCode = 200, data = data });
        }

        //UPDATE
        [HttpPut]
        public IActionResult Put(Jabatan jabatan)
        {
            var result = jabatanRepository.Put(jabatan);
            if (result > 0)
                return Ok(new { statusCode = 200, message = "Berhasil mengupdate data" });
            return BadRequest(new { statusCode = 400, message = "Gagal mengupdate data" });
        }

        //CREATE 
        [HttpPost]
        public IActionResult Post(Jabatan jabatan)
        {
            var result = jabatanRepository.Post(jabatan);
            if (result > 0)
                return Ok(new { statusCode = 200, message = "Berhasil menambahkan data" });
            return BadRequest(new { statusCode = 400, message = "Gagal menambahkan data" });
        }

        //DELETE
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = jabatanRepository.Delete(id);
            if (result > 0)
                return Ok(new { statusCode = 200, message = "Berhasil menghapus data" });
            return BadRequest(new { statusCode = 400, message = "Gagal menghapus data" });
        }
    }
}
