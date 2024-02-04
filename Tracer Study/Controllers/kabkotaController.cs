using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PRG_4_API.Model;

namespace PRG_4_API.Controllers
{
    [Authorize]
    public class kabkotaController : Controller
    {
        private readonly kabkotaRepository _kabkotaRepository;
        ResponseModel response = new ResponseModel();

        public kabkotaController(IConfiguration configuration)
        {
            _kabkotaRepository = new kabkotaRepository(configuration);
        }

        [HttpGet("/GetAllKabKota", Name = "GetAllKabKota")]
        public IActionResult GetAllKabKota()
        {
            try
            {
                response.status = 200;
                response.message = "Success";
                response.data = _kabkotaRepository.getAllData();
            }
            catch (Exception ex)
            {
                response.status = 500;
                response.message = "Failed";
            }
            return Ok(response);
        }

        [HttpGet("/GetKabKota", Name = "GetKabKota")]
        public IActionResult GetKabKota(string kabkota_id)
        {
            try
            {
                response.status = 200;
                response.message = "Success";
                response.data = _kabkotaRepository.getData(kabkota_id);
            }
            catch (Exception ex)
            {
                response.status = 500;
                response.message = "Failed, " + ex;
            }
            return Ok(response);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
