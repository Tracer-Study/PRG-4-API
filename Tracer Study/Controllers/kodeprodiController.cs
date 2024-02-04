using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PRG_4_API.Model;

namespace PRG_4_API.Controllers
{
    [Authorize]
    public class kodeprodiController : Controller
    {
        private readonly kodeprodiRepository _kodeprodiRepository;
        ResponseModel response = new ResponseModel();

        public kodeprodiController(IConfiguration configuration)
        {
            _kodeprodiRepository = new kodeprodiRepository(configuration);
        }

        [HttpGet("/GetAllKodeProdi", Name = "GetAllKodeProdi")]
        public IActionResult GetAllKodeProdi()
        {
            try
            {
                response.status = 200;
                response.message = "Success";
                response.data = _kodeprodiRepository.getAllData();
            }
            catch (Exception ex)
            {
                response.status = 500;
                response.message = "Failed";
            }
            return Ok(response);
        }

        [HttpGet("/GetKodeProdi", Name = "GetKodeProdi")]
        public IActionResult GetKodeProdi(int id)
        {
            try
            {
                response.status = 200;
                response.message = "Success";
                response.data = _kodeprodiRepository.getData(id);
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
