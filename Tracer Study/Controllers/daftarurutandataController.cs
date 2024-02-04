using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PRG_4_API.Model;

namespace PRG_4_API.Controllers
{
    [Authorize]
    public class daftarurutandataController : Controller
    {
        private readonly daftarurutandataRepository _daftarurutandataRepository;
        ResponseModel response = new ResponseModel();

        public daftarurutandataController(IConfiguration configuration)
        {
            _daftarurutandataRepository = new daftarurutandataRepository(configuration);
        }

        [HttpGet("/GetAllDaftarUrutanData", Name = "GetAllDaftarUrutanData")]
        public IActionResult GetAllDaftarUrutanData()
        {
            try
            {
                response.status = 200;
                response.message = "Success";
                response.data = _daftarurutandataRepository.getAllData();
            }
            catch (Exception ex)
            {
                response.status = 500;
                response.message = "Failed";
            }
            return Ok(response);
        }

        [HttpGet("/GetDaftarUrutanData", Name = "GetDaftarUrutanData")]
        public IActionResult GetDaftarUrutanData(int id_daftarUrutanData)
        {
            try
            {
                response.status = 200;
                response.message = "Success";
                response.data = _daftarurutandataRepository.getData(id_daftarUrutanData);
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
