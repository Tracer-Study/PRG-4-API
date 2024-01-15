using Microsoft.AspNetCore.Mvc;
using PRG_4_API.Model;

namespace PRG_4_API.Controllers
{
    public class registrasialumniController : Controller
    {
        private readonly registrasialumniRepository _registrasialumniRepository;
        ResponseModel response = new ResponseModel();

        public registrasialumniController(IConfiguration configuration)
        {
            _registrasialumniRepository = new registrasialumniRepository(configuration);
        }

        [HttpGet("/GetAllRegistrasiAlumni", Name = "GetAllRegistrasiAlumni")]
        public IActionResult GetAllRegistrasiAlumni()
        {
            try
            {
                response.status = 200;
                response.message = "Success";
                response.data = _registrasialumniRepository.getAllData();
            }
            catch (Exception ex)
            {
                response.status = 500;
                response.message = "Failed";
            }
            return Ok(response);
        }

        [HttpGet("/GetAllRegistrasiAlumniByYears", Name = "GetAllRegistrasiAlumniByYears")]
        public IActionResult GetAllRegistrasiAlumniByYears(int year)
        {
            try
            {
                response.status = 200;
                response.message = "Success";
                response.data = _registrasialumniRepository.getAllDataByYears(year);
            }
            catch (Exception ex)
            {
                response.status = 500;
                response.message = "Failed";
            }
            return Ok(response);
        }
        [HttpGet("/GetAllRegistrasiAlumniByProdi", Name = "GetAllRegistrasiAlumniByProdi")]
        public IActionResult GetAllRegistrasiAlumniByProdi(int year)
        {
            try
            {
                response.status = 200;
                response.message = "Success";
                response.data = _registrasialumniRepository.getAllDataByProdi(year);
            }
            catch (Exception ex)
            {
                response.status = 500;
                response.message = "Failed";
            }
            return Ok(response);
        }
        [HttpGet("/GetAllRegistrasiAlumniByStatus", Name = "GetAllRegistrasiAlumniByStatus")]
        public IActionResult GetAllRegistrasiAlumniByStatus()
        {
            try
            {
                response.status = 200;
                response.message = "Success";
                response.data = _registrasialumniRepository.getAllDataByStatus();
            }
            catch (Exception ex)
            {
                response.status = 500;
                response.message = "Failed";
            }
            return Ok(response);
        }

        [HttpGet("/GetRegistrasiAlumni", Name = "GetRegistrasiAlumni")]
        public IActionResult GetRegistrasiAlumni(int id)
        {
            try
            {
                response.status = 200;
                response.message = "Success";
                response.data = _registrasialumniRepository.getData(id);
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
