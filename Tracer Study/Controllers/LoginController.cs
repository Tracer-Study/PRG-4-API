using PRG_4_API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using PRG_4_API.Model;
using System.Security.Cryptography;

namespace PRG_4_API.Controllers
{

    [Route("api/token")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        public IConfiguration _configuration;
        private readonly LoginViewRepository _loginViewRepository;
        ResponseModel response = new ResponseModel();
        public LoginController(IConfiguration config)
        {
            _configuration = config;
            _loginViewRepository = new LoginViewRepository(config);
        }

        [HttpPost("submit")]
        public IActionResult Login([FromBody] LoginViewModel _userData)
        {
            if (_userData != null && _userData.Username != null && _userData.Password != null)
            {
                try
                {
                    response.data = _loginViewRepository.getJwtToken(_userData.Username, _userData.Password);
                    if (response.data == "Nama Pengguna atau Kata Sandi tidak ditemukan") {
                        response.status = 210;
                        response.message = "Nama Pengguna atau Kata Sandi tidak ditemukan.";
                    } else if (response.data == "Login Gagal") {
                        response.status = 220;
                        response.message = "Terjadi Kesalahan saat Login.";
                    } else {
                        response.status = 200;
                        response.message = "Berhasil Login.";
                    }
                }
                catch (Exception ex)
                {
                    response.status = 500;
                    response.message = "Failed : " + ex.Message;
                }
                return Ok(response);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}