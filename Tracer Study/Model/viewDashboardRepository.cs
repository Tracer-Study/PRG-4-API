using System.Data;
using System.Data.SqlClient;

namespace PRG_4_API.Model
{
    public class viewDashboardRepository
    {
        private readonly string _connectionString;

        private readonly SqlConnection _connection;

        public viewDashboardRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");

            _connection = new SqlConnection(_connectionString);
        }
        public List<jumlahIsiKuesioner> getIsiKuesioner(int year)
        {
            List<jumlahIsiKuesioner> registrasialumniList = new List<jumlahIsiKuesioner>();

            try
            {
                _connection.Open();

                SqlCommand command = new SqlCommand("ts_getCountJumlahIsiKuesionerBerdasarkanTahun", _connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@year", year);

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    jumlahIsiKuesioner registrasialumni = new jumlahIsiKuesioner
                    {
                        sudah_isi = Convert.ToInt32(reader["jumlah_sudah_isi"].ToString()),
                        belum_isi = Convert.ToInt32(reader["jumlah_belum_isi"].ToString())
                    };
                    registrasialumniList.Add(registrasialumni);
                }
                reader.Close();
                _connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return registrasialumniList;
        }
        public List<yearCount> getAllDataByStatus()
        {
            List<yearCount> registrasialumniList = new List<yearCount>();

            try
            {
                _connection.Open();

                SqlCommand command = new SqlCommand("ts_getCountRegistrasiAlumniBerdasarkanStatus", _connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    yearCount registrasialumni = new yearCount
                    {
                        value = reader["status"].ToString(),
                        count = Convert.ToInt32(reader["hitung"].ToString()),
                    };
                    registrasialumniList.Add(registrasialumni);
                }
                reader.Close();
                _connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return registrasialumniList;
        }
        public List<yearCount> getAllDataByYears(int year)
        {
            List<yearCount> registrasialumniList = new List<yearCount>();

            try
            {
                _connection.Open();

                SqlCommand command = new SqlCommand(
                    "ts_getCountRegistrasiAlumniBerdasarkanTahunTerakhir",
                    _connection
                );
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@SelectedYear", year);

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    yearCount registrasialumni = new yearCount
                    {
                        value = reader["tahun_lulus"].ToString(),
                        count = Convert.ToInt32(reader["hitung"].ToString()),
                    };
                    registrasialumniList.Add(registrasialumni);
                }
                reader.Close();
                _connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return registrasialumniList;
        }

        public List<yearCount> getAllDataByProdi(int year)
        {
            List<yearCount> registrasialumniList = new List<yearCount>();

            try
            {
                _connection.Open();

                SqlCommand command = new SqlCommand("ts_getCountRegistrasiAlumniBerdasarkanProdi", _connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@year", year);

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    yearCount registrasialumni = new yearCount
                    {
                        value = reader["id"].ToString(),
                        valueName = reader["nama_prodi"].ToString(),
                        count = Convert.ToInt32(reader["hitung"].ToString()),
                    };
                    registrasialumniList.Add(registrasialumni);
                }
                reader.Close();
                _connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return registrasialumniList;
        }
        public List<jumlahIsiKuesionerProdi> getIsiKuesionerByProdi(int year)
        {
            List<jumlahIsiKuesionerProdi> registrasialumniList = new List<jumlahIsiKuesionerProdi>();

            try
            {
                _connection.Open();

                SqlCommand command = new SqlCommand("ts_getCountJumlahIsiKuesionerBerdasarkanProdi", _connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@year", year);

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    jumlahIsiKuesionerProdi registrasialumni = new jumlahIsiKuesionerProdi
                    {
                        id_prodi = Convert.ToInt32(reader["id_prodi"].ToString()),
                        nama_prodi = reader["nama_prodi"].ToString(),
                        belum_isi = Convert.ToInt32(reader["jumlah_belum_isi"].ToString()),
                        sudah_isi = Convert.ToInt32(reader["jumlah_sudah_isi"].ToString()),
                    };
                    registrasialumniList.Add(registrasialumni);
                }
                reader.Close();
                _connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return registrasialumniList;
        }
        public List<jumlahIsiKuesionerProdiAll> getPengisianKuesionerByProdi(int year, int prodi)
        {
            List<jumlahIsiKuesionerProdiAll> registrasialumniList = new List<jumlahIsiKuesionerProdiAll>();

            try
            {
                _connection.Open();

                SqlCommand command = new SqlCommand("ts_getPengisianKuesionerByProdi", _connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@year", year);
                command.Parameters.AddWithValue("@prodi", prodi);

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    jumlahIsiKuesionerProdiAll registrasialumni = new jumlahIsiKuesionerProdiAll
                    {
                        nim = reader["nim"].ToString(),
                        nama = reader["nama"].ToString(),
                        nama_prodi = reader["nama_prodi"].ToString(),
                        periode = reader["periode_diisi"].ToString(),
                        status = reader["status"].ToString(),
                    };
                    registrasialumniList.Add(registrasialumni);
                }
                reader.Close();
                _connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return registrasialumniList;
        }
        
    }
}
