using MCCWebAPI.Models.ViewModels;
using MCCWebAPI.Respositories.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MCCWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CutiLiburController : ControllerBase
    {
        CutiLiburRepository cutiLiburRepository;

        public CutiLiburController(CutiLiburRepository cutiLiburRepository)
        {
            this.cutiLiburRepository = cutiLiburRepository;
        }

        //REGISTRASI BARU
        [HttpPost("newSelfReport")]
        public IActionResult NewSelfReport(CutiLiburViewModel cutiLiburViewModel)
        {
            var result = cutiLiburRepository.NewSelfReport(cutiLiburViewModel);
            if (result > 0)
                return Ok(new { statusCode = 200, message = "Berhasil menambahkan data" });
            return BadRequest(new { statusCode = 400, message = "Gagal menambahkan data" });
        }

        //REGISTRASI BARU
        [HttpPost("approveSelfReport")]
        public IActionResult ApproveSelfReport(CutiLiburViewModel cutiLiburViewModel)
        {
            var result = cutiLiburRepository.ApproveSelfReport(cutiLiburViewModel);
            if (result > 0)
                return Ok(new { statusCode = 200, message = "Berhasil mengubah data" });
            return BadRequest(new { statusCode = 400, message = "Gagal mengubah data" });
        }
    }
}
