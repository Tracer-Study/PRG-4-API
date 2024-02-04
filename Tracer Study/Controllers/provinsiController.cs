using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PRG_4_API.Model;

namespace PRG_4_API.Controllers
{
    [Authorize]
    public class provinsiController : Controller
    {
        private readonly provinsiRepository _provinsiRepository;
        ResponseModel response = new ResponseModel();

        public provinsiController(IConfiguration configuration)
        {
            _provinsiRepository = new provinsiRepository(configuration);
        }

        [HttpGet("/GetAllProvinsi", Name = "GetAllProvinsi")]
        public IActionResult GetAllProvinsi()
        {
            try
            {
                response.status = 200;
                response.message = "Success";
                response.data = _provinsiRepository.getAllData();
            }
            catch (Exception ex)
            {
                response.status = 500;
                response.message = "Failed";
            }
            return Ok(response);
        }

        [HttpGet("/GetProvinsi", Name = "GetProvinsi")]
        public IActionResult GetProvinsi(string provinsi_id)
        {
            try
            {
                response.status = 200;
                response.message = "Success";
                response.data = _provinsiRepository.getData(provinsi_id);
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
