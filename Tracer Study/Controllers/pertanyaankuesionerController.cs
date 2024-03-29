﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PRG_4_API.Model;

namespace PRG_4_API.Controllers
{
    [Authorize]
    public class pertanyaankuesionerController : Controller
    {
        private readonly pertanyaankuesionerRepository _pertanyaankuesionerRepository;
        ResponseModel response = new ResponseModel();

        public pertanyaankuesionerController(IConfiguration configuration)
        {
            _pertanyaankuesionerRepository = new pertanyaankuesionerRepository(configuration);
        }

        [HttpGet("/GetAllPertanyaanKuesioner", Name = "GetAllPertanyaanKuesioner")]
        public IActionResult GetAllPertanyaanKuesioner()
        {
            try
            {
                response.status = 200;
                response.message = "Success";
                response.data = _pertanyaankuesionerRepository.getAllData();
            }
            catch (Exception ex)
            {
                response.status = 500;
                response.message = "Failed";
            }
            return Ok(response);
        }

        [HttpGet("/GetPertanyaanKuesioner", Name = "GetPertanyaanKuesioner")]
        public IActionResult GetPertanyaanKuesioner(string id_pku)
        {
            try
            {
                response.status = 200;
                response.message = "Success";
                response.data = _pertanyaankuesionerRepository.getData(id_pku);
            }
            catch (Exception ex)
            {
                response.status = 500;
                response.message = "Failed, " + ex;
            }
            return Ok(response);
        }
        [HttpGet("/GetHasilPertanyaanKuesioner", Name = "GetHasilPertanyaanKuesioner")]
        public IActionResult GetHasilPertanyaanKuesioner(string id_pku)
        {
            try
            {
                response.status = 200;
                response.message = "Success";
                response.data = _pertanyaankuesionerRepository.getHasilPertanyaan(id_pku);
            }
            catch (Exception ex)
            {
                response.status = 500;
                response.message = "Failed, " + ex;
            }
            return Ok(response);
        }
        [HttpGet("/GetHasilPertanyaanKuesionerTable", Name = "GetHasilPertanyaanKuesionerTable")]
        public IActionResult GetHasilPertanyaanKuesionerTable(string id_pku)
        {
            try
            {
                response.status = 200;
                response.message = "Success";
                response.data = _pertanyaankuesionerRepository.getHasilPertanyaanTable(id_pku);
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
