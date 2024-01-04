using System.Data.SqlClient;

namespace PRG_4_API.Model
{
    public class kodeprodiRepository
    {
        private readonly string _connectionString;

        private readonly SqlConnection _connection;

        public kodeprodiRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");

            _connection = new SqlConnection(_connectionString);
        }

        public List<kodeprodiModel> getAllData()
        {
            List<kodeprodiModel> kodeprodiList = new List<kodeprodiModel>();

            try
            {
                string query = "SELECT * FROM ts_kodeProdi";
                SqlCommand command = new SqlCommand(query, _connection);
                _connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    kodeprodiModel kodeprodi = new kodeprodiModel
                    {
                        id = Convert.ToInt32(reader["id"].ToString()),
                        kode_pt = reader["kode_pt"].ToString(),
                        nama_prodi = reader["nama_prodi"].ToString(),
                        kode_prodi = reader["kode_prodi"].ToString(),
                        created_by = reader["created_by"].ToString(),
                        created_date = Convert.ToDateTime(reader["created_date"].ToString()),
                        modified_by = reader["modified_by"].ToString(),
                        modified_date = Convert.ToDateTime(reader["modified_date"].ToString()),
                        status = reader["status"].ToString(),
                    };
                    kodeprodiList.Add(kodeprodi);
                }
                reader.Close();
                _connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return kodeprodiList;
        }

        public kodeprodiModel getData(int id)
        {
            kodeprodiModel kodeprodimodel = new kodeprodiModel();
            try
            {
                string query = "SELECT * FROM ts_kodeProdi WHERE id = @p1";
                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@p1", id);
                _connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                reader.Read();

                kodeprodimodel.id = Convert.ToInt32(reader["id"].ToString());
                kodeprodimodel.kode_pt = reader["kode_pt"].ToString();
                kodeprodimodel.nama_prodi = reader["nama_prodi"].ToString();
                kodeprodimodel.kode_prodi = reader["kode_prodi"].ToString();
                kodeprodimodel.created_by = reader["created_by"].ToString();
                kodeprodimodel.created_date = Convert.ToDateTime(reader["created_date"].ToString());
                kodeprodimodel.modified_by = reader["modified_by"].ToString();
                kodeprodimodel.modified_date = Convert.ToDateTime(reader["modified_date"].ToString());
                kodeprodimodel.status = reader["status"].ToString();

                reader.Close();
                _connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return kodeprodimodel;
        }
    }
}
