using Microsoft.AspNetCore.Mvc;
using PRG_4_API.Model;

namespace PRG_4_API.Controllers
{
    public class adminController : Controller
    {
        private readonly adminRepository _adminRepository;
        ResponseModel response = new ResponseModel();

        public adminController(IConfiguration configuration)
        {
            _adminRepository = new adminRepository(configuration);
        }

        [HttpGet("/GetAllAdmin", Name = "GetAllAdmin")]
        public IActionResult GetAllAdmin()
        {
            try
            {
                response.status = 200;
                response.message = "Success";
                response.data = _adminRepository.getAllData();
            }
            catch (Exception ex)
            {
                response.status = 500;
                response.message = "Failed";
            }
            return Ok(response);
        }

        [HttpGet("/GetAdmin", Name = "GetAdmin")]
        public IActionResult GetAdmin(string id_admin)
        {
            try
            {
                response.status = 200;
                response.message = "Success";
                response.data = _adminRepository.getData(id_admin);
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
