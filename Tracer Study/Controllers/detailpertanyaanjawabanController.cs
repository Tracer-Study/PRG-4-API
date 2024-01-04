using Microsoft.AspNetCore.Mvc;
using PRG_4_API.Model;

namespace PRG_4_API.Controllers
{
    public class detailpertanyaanjawabanController : Controller
    {
        private readonly detailpertanyaanjawabanRepository _detailpertanyaanjawabanRepository;
        ResponseModel response = new ResponseModel();

        public detailpertanyaanjawabanController(IConfiguration configuration)
        {
            _detailpertanyaanjawabanRepository = new detailpertanyaanjawabanRepository(configuration);
        }

        [HttpGet("/GetAllDetailPertanyaanJawaban", Name = "GetAllDetailPertanyaanJawaban")]
        public IActionResult GetAllDetailPertanyaanJawaban()
        {
            try
            {
                response.status = 200;
                response.message = "Success";
                response.data = _detailpertanyaanjawabanRepository.getAllData();
            }
            catch (Exception ex)
            {
                response.status = 500;
                response.message = "Failed";
            }
            return Ok(response);
        }

        [HttpGet("/GetDetailPertanyaanJawaban", Name = "GetDetailPertanyaanJawaban")]
        public IActionResult GetDetailPertanyaanJawaban(int id_detailPertanyaanJawaban)
        {
            try
            {
                response.status = 200;
                response.message = "Success";
                response.data = _detailpertanyaanjawabanRepository.getData(id_detailPertanyaanJawaban);
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
