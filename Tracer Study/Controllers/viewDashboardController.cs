using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PRG_4_API.Model;

namespace PRG_4_API.Controllers
{
    [Authorize]
    public class viewDashboardController : Controller
    {
        private readonly viewDashboardRepository _viewRepository;
        private readonly registrasialumniRepository _registrasialumniRepository;

        ResponseModel response = new ResponseModel();
        public viewDashboardController(IConfiguration configuration)
        {
            _viewRepository = new viewDashboardRepository(configuration);
            _registrasialumniRepository = new registrasialumniRepository(configuration);
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("/GetJumlahIsiKuesioner", Name = "GetJumlahIsiKuesioner")]
        public IActionResult GetJumlahIsiKuesioner(int year)
        {
            try
            {
                response.status = 200;
                response.message = "Success";
                response.data = _viewRepository.getIsiKuesioner(year);
            }
            catch (Exception ex)
            {
                response.status = 500;
                response.message = "Failed + " + ex.Message;
            }
            return Ok(response);
        }
        [HttpGet("/GetAllRegistrasiAlumniByStatus", Name = "GetAllRegistrasiAlumniByStatus")]
        public IActionResult GetAllRegistrasiAlumniByStatus(int year)
        {
            try
            {
                response.status = 200;
                response.message = "Success";
                response.data = _viewRepository.getAllDataByStatus(year);
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
                response.data = _viewRepository.getAllDataByYears(year);
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
                response.data = _viewRepository.getAllDataByProdi(year);
            }
            catch (Exception ex)
            {
                response.status = 500;
                response.message = "Failed";
            }
            return Ok(response);
        }
        [HttpGet("/GetJumlahIsiKuesionerByProdi", Name = "GetJumlahIsiKuesionerByProdi")]
        public IActionResult GetJumlahIsiKuesionerByProdi(int year)
        {
            try
            {
                response.status = 200;
                response.message = "Success";
                response.data = _viewRepository.getIsiKuesionerByProdi(year);
            }
            catch (Exception ex)
            {
                response.status = 500;
                response.message = "Failed";
            }
            return Ok(response);
        }
        [HttpGet("/GetPengisianKuesionerByProdi", Name = "GetPengisianKuesionerByProdi")]
        public IActionResult GetPengisianKuesionerByProdi(int year,int prodi)
        {
            try
            {
                response.status = 200;
                response.message = "Success";
                response.data = _viewRepository.getPengisianKuesionerByProdi(year,prodi);
            }
            catch (Exception ex)
            {
                response.status = 500;
                response.message = "Failed";
            }
            return Ok(response);
        }
        [HttpGet("/GetPengisianKuesionerByYear", Name = "GetPengisianKuesionerByYear")]
        public IActionResult GetPengisianKuesionerByYear(int year)
        {
            try
            {
                response.status = 200;
                response.message = "Success";
                response.data = _viewRepository.getPengisianKuesionerByYear(year);
            }
            catch (Exception ex)
            {
                response.status = 500;
                response.message = "Failed";
            }
            return Ok(response);
        }
        [HttpGet("/GetDataRegistrasiAlumniBelumVerifikasi", Name = "GetDataRegistrasiAlumniBelumVerifikasi")]
        public IActionResult GetDataRegistrasiAlumniBelumVerifikasi()
        {
            try
            {
                response.status = 200;
                response.message = "Success";
                response.data = _registrasialumniRepository.getDataRegistrasiAlumniBelumVerifikasi();
            }
            catch (Exception ex)
            {
                response.status = 500;
                response.message = "Failed";
            }
            return Ok(response);
        }
        [HttpGet("/GetDataPengisianKuesionerAlumni", Name = "GetDataPengisianKuesionerAlumni")]
        public IActionResult GetDataPengisianKuesionerAlumni(string nim)
        {
            try
            {
                response.status = 200;
                response.message = "Success";
                response.data = _viewRepository.getDetailPengisianKuesionerAlumni(nim);
            }
            catch (Exception ex)
            {
                response.status = 500;
                response.message = "Failed";
            }
            return Ok(response);
        }
        [HttpGet("/GetDataAkunBelumVerifikasi", Name = "GetDataAkunBelumVerifikasi")]
        public IActionResult GetDataAkunBelumVerifikasi(int year)
        {
            try
            {
                response.status = 200;
                response.message = "Success";
                response.data = _viewRepository.getDetailAkunBelumVerifikasi(year);
            }
            catch (Exception ex)
            {
                response.status = 500;
                response.message = "Failed";
            }
            return Ok(response);
        }
        [HttpGet("/GetJenisKuesioner", Name = "GetJenisKuesioner")]
        public IActionResult GetJenisKuesioner()
        {
            try
            {
                response.status = 200;
                response.message = "Success";
                response.data = _viewRepository.getJenisKuesioner();
            }
            catch (Exception ex)
            {
                response.status = 500;
                response.message = "Failed";
            }
            return Ok(response);
        }
        [HttpGet("/GetJenisPertanyaan", Name = "GetJenisPertanyaan")]
        public IActionResult GetJenisPertanyaan()
        {
            try
            {
                response.status = 200;
                response.message = "Success";
                response.data = _viewRepository.getJenisPertanyaan();
            }
            catch (Exception ex)
            {
                response.status = 500;
                response.message = "Failed";
            }
            return Ok(response);
        }
    }
}
