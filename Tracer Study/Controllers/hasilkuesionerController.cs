using Microsoft.AspNetCore.Mvc;
using PRG_4_API.Model;

namespace PRG_4_API.Controllers
{
    public class hasilkuesionerController : Controller
    {
        private readonly hasilkuesionerRepository _hasilkuesionerRepository;
        ResponseModel response = new ResponseModel();

        public hasilkuesionerController(IConfiguration configuration)
        {
            _hasilkuesionerRepository = new hasilkuesionerRepository(configuration);
        }

        [HttpGet("/GetAllHasilKuesioner", Name = "GetAllHasilKuesioner")]
        public IActionResult GetAllHasilKuesioner()
        {
            try
            {
                response.status = 200;
                response.message = "Success";
                response.data = _hasilkuesionerRepository.getAllData();
            }
            catch (Exception ex)
            {
                response.status = 500;
                response.message = "Failed";
            }
            return Ok(response);
        }

        [HttpGet("/GetHasilKuesioner", Name = "GetHasilKuesioner")]
        public IActionResult GetHasilKuesioner(int id_hasilKuesioner)
        {
            try
            {
                response.status = 200;
                response.message = "Success";
                response.data = _hasilkuesionerRepository.getData(id_hasilKuesioner);
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
