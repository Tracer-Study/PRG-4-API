﻿using Microsoft.AspNetCore.Mvc;
using PRG_4_API.Model;

namespace PRG_4_API.Controllers
{
    public class viewDashboardController : Controller
    {
        private readonly viewDashboardRepository _registrasialumniRepository;
        ResponseModel response = new ResponseModel();
        public viewDashboardController(IConfiguration configuration)
        {
            _registrasialumniRepository = new viewDashboardRepository(configuration);
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
                response.data = _registrasialumniRepository.getIsiKuesioner(year);
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
        [HttpGet("/GetJumlahIsiKuesionerByProdi", Name = "GetJumlahIsiKuesionerByProdi")]
        public IActionResult GetJumlahIsiKuesionerByProdi(int year)
        {
            try
            {
                response.status = 200;
                response.message = "Success";
                response.data = _registrasialumniRepository.getIsiKuesionerByProdi(year);
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
                response.data = _registrasialumniRepository.getPengisianKuesionerByProdi(year,prodi);
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