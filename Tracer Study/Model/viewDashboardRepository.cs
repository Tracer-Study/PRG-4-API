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
        public List<yearCount> getAllDataByStatus(int year)
        {
            List<yearCount> registrasialumniList = new List<yearCount>();

            try
            {
                _connection.Open();

                SqlCommand command = new SqlCommand("ts_getCountRegistrasiAlumniByYear", _connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@year", year);

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
        public List<jumlahIsiKuesionerProdiAll> getPengisianKuesionerByYear(int year)
        {
            List<jumlahIsiKuesionerProdiAll> registrasialumniList = new List<jumlahIsiKuesionerProdiAll>();

            try
            {
                _connection.Open();

                SqlCommand command = new SqlCommand("ts_getPengisianKuesionerByYear", _connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@year", year);

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
        public List<detailpengisiankuesionerAlumni> getDetailPengisianKuesionerAlumni(string nim)
        {
            List<detailpengisiankuesionerAlumni> isiKuesionerAlumni = new List<detailpengisiankuesionerAlumni>();

            try
            {
                _connection.Open();

                SqlCommand command = new SqlCommand("ts_getDataDetailPengisianKuesionerAlumni", _connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@query", nim);

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    detailpengisiankuesionerAlumni registrasialumni = new detailpengisiankuesionerAlumni
                    {
                        nim = reader["nim"].ToString(),
                        nama = reader["nama"].ToString(),
                        id_hasilKuesioner = reader["id_hasilKuesioner"].ToString(),
                        id_detailPeriode = reader["id_detailPeriode"].ToString(),
                        jenis_periode = reader["jenis_periode"].ToString(),
                        id_pku = reader["id_pku"].ToString(),
                        kode = reader["kode"].ToString(),
                        deskripsiPertanyaan = reader["deskripsiPertanyaan"].ToString(),
                        jawabanKuesioner = reader["jawabanKuesioner"].ToString(),
                    };
                    isiKuesionerAlumni.Add(registrasialumni);
                }
                reader.Close();
                _connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return isiKuesionerAlumni;
        }
        
        public List<registrasialumniModel> getDetailAkunBelumVerifikasi(int year)
        {
            List<registrasialumniModel> isiKuesionerAlumni = new List<registrasialumniModel>();

            try
            {
                _connection.Open();

                SqlCommand command = new SqlCommand("ts_getDataRegistrasiAlumniBelumVerifikasiByYear", _connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue ("@year", year);

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    registrasialumniModel registrasialumni = new registrasialumniModel
                    {
                        id = Convert.ToInt32(reader["id"].ToString()),
                        nim = reader["nim"].ToString(),
                        nik = reader["nik"].ToString(),
                        npwp = reader["npwp"].ToString(),
                        nama = reader["nama"].ToString(),
                        alamat = reader["alamat"].ToString(),
                        tanggal_lahir = Convert.ToDateTime(reader["tanggal_lahir"].ToString()),
                        tahun_lulus = reader["tahun_lulus"].ToString(),
                        email = reader["email"].ToString(),
                        password = reader["password"].ToString(),
                        status = reader["status"].ToString(),
                        telepon = reader["telepon"].ToString(),
                        created_by = reader["created_by"].ToString(),
                        created_date = Convert.ToDateTime(reader["created_date"].ToString()),
                        modified_by = reader["modified_by"].ToString(),
                        modified_date = Convert.ToDateTime(reader["modified_date"].ToString()),
                        id_kodeProdi = Convert.ToInt32(reader["id_kodeProdi"].ToString()),
                    };
                    isiKuesionerAlumni.Add(registrasialumni);
                }
                reader.Close();
                _connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return isiKuesionerAlumni;
        }
        
    }
}
