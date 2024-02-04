using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PRG_4_API.Model;

namespace PRG_4_API.Controllers
{
    [Authorize]
    public class jawabankuesionerController : Controller
    {
        private readonly jawabankuesionerRepository _jawabankuesionerRepository;
        ResponseModel response = new ResponseModel();

        public jawabankuesionerController(IConfiguration configuration)
        {
            _jawabankuesionerRepository = new jawabankuesionerRepository(configuration);
        }

        [HttpGet("/GetAllJawabanKuesioner", Name = "GetAllJawabanKuesioner")]
        public IActionResult GetAllJawabanKuesioner()
        {
            try
            {
                response.status = 200;
                response.message = "Success";
                response.data = _jawabankuesionerRepository.getAllData();
            }
            catch (Exception ex)
            {
                response.status = 500;
                response.message = "Failed";
            }
            return Ok(response);
        }

        [HttpGet("/GetJawabanKuesioner", Name = "GetJawabanKuesioner")]
        public IActionResult GetJawabanKuesioner(int id_jawabanKuesioner)
        {
            try
            {
                response.status = 200;
                response.message = "Success";
                response.data = _jawabankuesionerRepository.getData(id_jawabanKuesioner);
            }
            catch (Exception ex)
            {
                response.status = 500;
                response.message = "Failed, " + ex;
            }
            return Ok(response);
        }
        [HttpGet("/GetJawabanKuesionerByPertanyaan", Name = "GetJawabanKuesionerByPertanyaan")]
        public IActionResult GetJawabanKuesionerByPertanyaan(string id_pku)
        {
            try
            {
                response.status = 200;
                response.message = "Success";
                response.data = _jawabankuesionerRepository.getDataByPertanyaan(id_pku);
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
