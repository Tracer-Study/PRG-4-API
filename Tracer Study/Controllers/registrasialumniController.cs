using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PRG_4_API.Model;

namespace PRG_4_API.Controllers
{
    [Authorize]
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
        
        [HttpPut("/UpdateStatusDiterima", Name = "UpdateStatusDiterima")]
        public IActionResult UpdateStatusDiterima(int id, string namaAdmin)
        {
            try
            {
                response.status = 200;
                response.message = "Akun Alumni Diterima.";
                _registrasialumniRepository.updateStatusDiterima(id, namaAdmin);
            }
            catch (Exception ex)
            {
                response.status = 500;
                response.message = "Failed, " + ex;
            }
            return Ok(response);
        }
        [HttpPut("/UpdateStatusDitolak", Name = "UpdateStatusDitolak")]
        public IActionResult UpdateStatusDitolak(int id, string namaAdmin)
        {
            try
            {
                response.status = 200;
                response.message = "Akun Alumni Ditolak.";
                _registrasialumniRepository.updateStatusDitolak(id, namaAdmin);
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
