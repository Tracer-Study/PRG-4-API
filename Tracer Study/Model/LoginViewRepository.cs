using Microsoft.IdentityModel.Tokens;
using PRG_4_API.Models;
using System.Data;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace PRG_4_API.Model
{
    public class LoginViewRepository
    {
        private readonly string _connectionString;

        private readonly SqlConnection _connection;

        public IConfiguration _configuration;
        public LoginViewRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            _configuration = configuration;
            _connection = new SqlConnection(_connectionString);
        }


        public string getJwtToken(string username, string password)
        {
            
            string role;

            if (username == "" || password == "")
            {
                return ("Nama Pengguna dan Kata Sandi tidak boleh kosong");
            }
            else
            {
                try
                {
                    _connection.Open();

                    SqlCommand command = new SqlCommand("ts_LoginAdmin", _connection);
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", EncryptPassword(password, "030518"));
                    command.CommandType = CommandType.StoredProcedure;

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        role = "Admin";

                        var claims = new[] {
                            new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                            new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                            new Claim("id_admin", reader["id_admin"].ToString()),
                            new Claim("nama", reader["nama"].ToString()),
                            new Claim("email", reader["email"].ToString()),
                            new Claim("username", reader["username"].ToString()),
                            new Claim("role", role)
                        };

                        reader.Close();
                        _connection.Close();


                        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

                        var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                        var token = new JwtSecurityToken(
                            _configuration["Jwt:Issuer"],
                            _configuration["Jwt:Audience"],
                            claims,
                            expires: DateTime.UtcNow.AddHours(1),
                            signingCredentials: signIn);
                        return new JwtSecurityTokenHandler().WriteToken(token);
                    }
                    else
                    {
                        reader.Close();

                        SqlCommand cmd = new SqlCommand("ts_LoginAlumni", _connection);
                        cmd.Parameters.AddWithValue("@username", ﻿username);
                        cmd.Parameters.AddWithValue("@password", EncryptPassword(password, "030518"));
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlDataReader read = cmd.ExecuteReader();

                        if (read.Read())
                        {
                            string status = read["status"].ToString();

                            role = "Alumni";

                            var claims = new[] {
                                new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                                new Claim("id", read["id"].ToString()),
                                new Claim("nim", read["nim"].ToString()),
                                new Claim("nik", read["nik"].ToString()),
                                new Claim("npwp", read["email"].ToString()),
                                new Claim("nama", read["nama"].ToString()),
                                new Claim("alamat", read["alamat"].ToString()),
                                new Claim("tanggal_lahir", read["tanggal_lahir"].ToString()),
                                new Claim("tahun_lulus", read["tahun_lulus"].ToString()),
                                new Claim("email", read["email"].ToString()),
                                new Claim("telepon", read["telepon"].ToString()),
                                new Claim("id_kodeProdi", read["id_kodeProdi"].ToString()),
                                new Claim("role", role),
                                new Claim("status", status)
                            };
                            read.Close();
                            _connection.Close();

                            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

                            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                            var token = new JwtSecurityToken(
                                _configuration["Jwt:Issuer"],
                                _configuration["Jwt:Audience"],
                                claims,
                                expires: DateTime.UtcNow.AddHours(1),
                                signingCredentials: signIn);
                            return new JwtSecurityTokenHandler().WriteToken(token);
                        }
                        else
                        {
                            return "Nama Pengguna atau Kata Sandi tidak ditemukan";
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                return "Login Gagal";
            }
        }

        public string EncryptPassword(string password, string key)
        {
            string plainText = "";
            using (MD5 md5Hash = MD5.Create())
            {
                plainText = GetMd5Hash(md5Hash, password + key);
            }

            plainText = Base64Encode(plainText);
            for (int i = 1; i <= 10; i++)
            {
                plainText = Scramble(plainText);
            }

            return plainText;
        }

        private static string GetMd5Hash(MD5 md5Hash, string input)
        {
            byte[] array = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < array.Length; i++)
            {
                stringBuilder.Append(array[i].ToString("x2"));
            }

            return stringBuilder.ToString();
        }

        private static string Base64Encode(string plainText)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(bytes);
        }

        private static string Base64Decode(string base64EncodedData)
        {
            byte[] bytes = Convert.FromBase64String(base64EncodedData);
            return Encoding.UTF8.GetString(bytes);
        }

        private string Scramble(string param)
        {
            string text = "";
            string text2 = "";
            string text3 = "";
            for (int i = 0; i < param.Length; i++)
            {
                if (isEven(i))
                {
                    text2 += param[i];
                }
                else
                {
                    text3 += param[i];
                }
            }

            return text2 + text3;
        }

        private bool isEven(int bilangan)
        {
            if (bilangan % 2 == 0)
            {
                return true;
            }

            return false;
        }
    }
}
