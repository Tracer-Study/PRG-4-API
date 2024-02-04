using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PRG_4_API.Model;

namespace PRG_4_API.Controllers
{
    [Authorize]
    public class detailjenisperiodeController : Controller
    {
        private readonly detailjenisperiodeRepository _detailjenisperiodeRepository;
        ResponseModel response = new ResponseModel();

        public detailjenisperiodeController(IConfiguration configuration)
        {
            _detailjenisperiodeRepository = new detailjenisperiodeRepository(configuration);
        }

        [HttpGet("/GetAllDetailJenisPeriode", Name = "GetAllDetailJenisPeriode")]
        public IActionResult GetAllDetailJenisPeriode()
        {
            try
            {
                response.status = 200;
                response.message = "Success";
                response.data = _detailjenisperiodeRepository.getAllData();
            }
            catch (Exception ex)
            {
                response.status = 500;
                response.message = "Failed";
            }
            return Ok(response);
        }

        [HttpGet("/GetDetailJenisPeriode", Name = "GetDetailJenisPeriode")]
        public IActionResult GetDetailJenisPeriode(int id_detailPeriode)
        {
            try
            {
                response.status = 200;
                response.message = "Success";
                response.data = _detailjenisperiodeRepository.getData(id_detailPeriode);
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
