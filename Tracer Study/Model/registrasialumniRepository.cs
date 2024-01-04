using System.Data.SqlClient;

namespace PRG_4_API.Model
{
    public class registrasialumniRepository
    {
        private readonly string _connectionString;

        private readonly SqlConnection _connection;

        public registrasialumniRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");

            _connection = new SqlConnection(_connectionString);
        }

        public List<registrasialumniModel> getAllData()
        {
            List<registrasialumniModel> registrasialumniList = new List<registrasialumniModel>();

            try
            {
                string query = "SELECT * FROM ts_registrasiAlumni";
                SqlCommand command = new SqlCommand(query, _connection);
                _connection.Open();

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

        public registrasialumniModel getData(int id)
        {
            registrasialumniModel registrasialumnimodel = new registrasialumniModel();
            try
            {
                string query = "SELECT * FROM ts_registrasiAlumni WHERE id = @p1";
                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@p1", id);
                _connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                reader.Read();

                registrasialumnimodel.id = Convert.ToInt32(reader["id"].ToString());
                registrasialumnimodel.nim = reader["deskripsiPertanyaan"].ToString();
                registrasialumnimodel.nik = reader["jenis"].ToString();
                registrasialumnimodel.npwp = reader["kode"].ToString();
                registrasialumnimodel.nama = reader["pertanyaan_utama"].ToString();
                registrasialumnimodel.alamat = reader["pertanyaan_utama"].ToString();
                registrasialumnimodel.tanggal_lahir = Convert.ToDateTime(reader["tanggal_lahir"].ToString());
                registrasialumnimodel.tahun_lulus = reader["pertanyaan_utama"].ToString();
                registrasialumnimodel.email = reader["pertanyaan_utama"].ToString();
                registrasialumnimodel.password = reader["pertanyaan_utama"].ToString();
                registrasialumnimodel.status = reader["pertanyaan_utama"].ToString();
                registrasialumnimodel.telepon = reader["pertanyaan_utama"].ToString();
                registrasialumnimodel.created_by = reader["created_by"].ToString();
                registrasialumnimodel.created_date = Convert.ToDateTime(reader["created_date"].ToString());
                registrasialumnimodel.modified_by = reader["modified_by"].ToString();
                registrasialumnimodel.modified_date = Convert.ToDateTime(reader["modified_date"].ToString());
                registrasialumnimodel.id_kodeProdi = Convert.ToInt32(reader["id_kodeProdi"].ToString());

                reader.Close();
                _connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return registrasialumnimodel;
        }
    }
}
