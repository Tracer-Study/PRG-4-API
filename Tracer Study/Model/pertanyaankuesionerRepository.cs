﻿using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;

namespace PRG_4_API.Model
{
    public class pertanyaankuesionerRepository
    {
        private readonly string _connectionString;

        private readonly SqlConnection _connection;

        public pertanyaankuesionerRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");

            _connection = new SqlConnection(_connectionString);
        }

        public List<pertanyaankuesionerJoin> getAllData()
        {
            List<pertanyaankuesionerJoin> pertanyaankuesionerList = new List<pertanyaankuesionerJoin>();

            try
            {
                string query = "SELECT pk.id_pku, pk.deskripsiPertanyaan, pk.jenis, pk.kode, pk.id_detailPeriode, " +
                    "CONCAT(jp.jenis_kuesioner, ' - ', jp.periode) AS jenisPeriode, pk.pertanyaan_utama, pk.no_urutan, pk.status " +
                    "FROM ts_pertanyaanKuesioner pk JOIN ts_detailJenisPeriode jp ON pk.id_detailPeriode = jp.id_detailPeriode " +
                    "ORDER BY pk.id_detailPeriode ASC";
                SqlCommand command = new SqlCommand(query, _connection);
                _connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    pertanyaankuesionerJoin pertanyaankuesioner = new pertanyaankuesionerJoin
                    {
                        id_pku = reader["id_pku"].ToString(),
                        deskripsiPertanyaan = reader["deskripsiPertanyaan"].ToString(),
                        jenis = reader["jenis"].ToString(),
                        kode = reader["kode"].ToString(),
                        id_detailPeriode = Convert.ToInt32(reader["id_detailPeriode"].ToString()),
                        jenisPeriode = reader["jenisPeriode"].ToString(),
                        pertanyaan_utama = reader["pertanyaan_utama"].ToString(),
                        no_urutan = Convert.ToInt32(reader["no_urutan"].ToString()),
                        status = reader["status"].ToString(),
                    };
                    pertanyaankuesionerList.Add(pertanyaankuesioner);
                }
                reader.Close();
                _connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return pertanyaankuesionerList;
        }

        public pertanyaankuesionerModel getData(string id_pku)
        {
            pertanyaankuesionerModel pertanyaankuesionermodel = new pertanyaankuesionerModel();
            try
            {
                string query = "SELECT * FROM ts_pertanyaanKuesioner WHERE id_pku = @p1";
                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@p1", id_pku);
                _connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                reader.Read();

                pertanyaankuesionermodel.id_pku = reader["id_pku"].ToString();
                pertanyaankuesionermodel.deskripsiPertanyaan = reader["deskripsiPertanyaan"].ToString();
                pertanyaankuesionermodel.jenis = reader["jenis"].ToString();
                pertanyaankuesionermodel.kode = reader["kode"].ToString();
                pertanyaankuesionermodel.id_detailPeriode = Convert.ToInt32(reader["id_detailPeriode"].ToString());
                pertanyaankuesionermodel.pertanyaan_utama = reader["pertanyaan_utama"].ToString();
                pertanyaankuesionermodel.no_urutan = Convert.ToInt32(reader["no_urutan"].ToString());
                pertanyaankuesionermodel.created_by = reader["created_by"].ToString();
                pertanyaankuesionermodel.created_date = Convert.ToDateTime(reader["created_date"].ToString());
                pertanyaankuesionermodel.modified_by = reader["modified_by"].ToString();
                pertanyaankuesionermodel.modified_date = Convert.ToDateTime(reader["modified_date"].ToString());
                pertanyaankuesionermodel.status = reader["status"].ToString();

                reader.Close();
                _connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return pertanyaankuesionermodel;
        }
        public List<hasilPertanyaanModel> getHasilPertanyaan(string id_pku)
        {
            List<hasilPertanyaanModel> pertanyaankuesionermodel = new List<hasilPertanyaanModel>();
            try
            {
                string query = "ts_getHasilPertanyaan";
                SqlCommand command = new SqlCommand(query, _connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@query", id_pku);
                _connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    hasilPertanyaanModel pertanyaankuesioner = new hasilPertanyaanModel
                    {
                        id_pku = reader["id_pku"].ToString(),
                        deskripsiPertanyaan = reader["deskripsiPertanyaan"].ToString(),
                        kode = reader["kode"].ToString(),
                        jawabanKuesioner = reader["jawabanKuesioner"].ToString(),
                        jumlahKoresponden = Convert.ToInt32(reader["jumlahKoresponden"].ToString())
                    };
                    pertanyaankuesionermodel.Add(pertanyaankuesioner);
                }
                
                reader.Close();
                _connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return pertanyaankuesionermodel;
        }
        public List<hasilPertanyaanModel> getHasilPertanyaanTable(string id_pku)
        {
            List<hasilPertanyaanModel> pertanyaankuesionermodel = new List<hasilPertanyaanModel>();
            try
            {
                string query = "ts_getHasilPertanyaanTable";
                SqlCommand command = new SqlCommand(query, _connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@query", id_pku);
                _connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    hasilPertanyaanModel pertanyaankuesioner = new hasilPertanyaanModel
                    {
                        id_pku = reader["id_pku"].ToString(),
                        deskripsiPertanyaan = reader["deskripsiPertanyaan"].ToString(),
                        kode = reader["kode"].ToString(),
                        jawabanKuesioner = reader["jawabanKuesioner"].ToString(),
                        jumlahKoresponden = 0
                    };
                    pertanyaankuesionermodel.Add(pertanyaankuesioner);
                }
                
                reader.Close();
                _connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return pertanyaankuesionermodel;
        }
    }
}
