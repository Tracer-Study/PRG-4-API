using Microsoft.AspNetCore.Mvc;
using PRG_4_API.Model;

namespace PRG_4_API.Controllers
{
    public class laporankuesionerController : Controller
    {
        private readonly laporankuesionerRepository _laporankuesionerRepository;
        ResponseModel response = new ResponseModel();

        public laporankuesionerController(IConfiguration configuration)
        {
            _laporankuesionerRepository = new laporankuesionerRepository(configuration);
        }

        [HttpGet("/GetAllLaporanKuesioner", Name = "GetAllLaporanKuesioner")]
        public IActionResult GetAllLaporanKuesioner()
        {
            try
            {
                response.status = 200;
                response.message = "Success";
                response.data = _laporankuesionerRepository.getAllData();
            }
            catch (Exception ex)
            {
                response.status = 500;
                response.message = "Failed";
            }
            return Ok(response);
        }

        [HttpGet("/GetLaporanKuesioner", Name = "GetLaporanKuesioner")]
        public IActionResult GetLaporanKuesioner(string id_hasilKuesioner)
        {
            try
            {
                response.status = 200;
                response.message = "Success";
                response.data = _laporankuesionerRepository.getData(id_hasilKuesioner);
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
