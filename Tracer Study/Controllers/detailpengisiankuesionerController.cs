using Microsoft.AspNetCore.Mvc;
using PRG_4_API.Model;

namespace PRG_4_API.Controllers
{
    public class detailpengisiankuesionerController : Controller
    {
        private readonly detailpengisiankuesionerRepository _detailpengisiankuesionerRepository;
        ResponseModel response = new ResponseModel();

        public detailpengisiankuesionerController(IConfiguration configuration)
        {
            _detailpengisiankuesionerRepository = new detailpengisiankuesionerRepository(configuration);
        }

        [HttpGet("/GetAllDetailPengisianKuesioner", Name = "GetAllDetailPengisianKuesioner")]
        public IActionResult GetAllDetailPengisianKuesioner()
        {
            try
            {
                response.status = 200;
                response.message = "Success";
                response.data = _detailpengisiankuesionerRepository.getAllData();
            }
            catch (Exception ex)
            {
                response.status = 500;
                response.message = "Failed";
            }
            return Ok(response);
        }

        [HttpGet("/GetDetailPengisianKuesioner", Name = "GetDetailPengisianKuesioner")]
        public IActionResult GetDetailPengisianKuesioner(int id)
        {
            try
            {
                response.status = 200;
                response.message = "Success";
                response.data = _detailpengisiankuesionerRepository.getData(id);
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
