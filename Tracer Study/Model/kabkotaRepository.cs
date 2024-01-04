using System.Data.SqlClient;

namespace PRG_4_API.Model
{
    public class kabkotaRepository
    {
        private readonly string _connectionString;

        private readonly SqlConnection _connection;

        public kabkotaRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");

            _connection = new SqlConnection(_connectionString);
        }

        public List<kabkotaModel> getAllData()
        {
            List<kabkotaModel> kabkotaList = new List<kabkotaModel>();

            try
            {
                string query = "SELECT * FROM ts_kabKota";
                SqlCommand command = new SqlCommand(query, _connection);
                _connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    kabkotaModel kabkota = new kabkotaModel
                    {
                        kabkota_id = reader["kabkota_id"].ToString(),
                        kabkota_deskripsi = reader["kabkota_deskripsi"].ToString(),
                        kabkota_provinsi_id = reader["kabkota_provinsi_id"].ToString(),
                    };
                    kabkotaList.Add(kabkota);
                }
                reader.Close();
                _connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return kabkotaList;
        }

        public kabkotaModel getData(string kabkota_id)
        {
            kabkotaModel kabkotamodel = new kabkotaModel();
            try
            {
                string query = "SELECT * FROM ts_kabKota WHERE kabkota_id = @p1";
                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@p1", kabkota_id);
                _connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                reader.Read();

                kabkotamodel.kabkota_id = reader["kabkota_id"].ToString();
                kabkotamodel.kabkota_deskripsi = reader["kabkota_deskripsi"].ToString();
                kabkotamodel.kabkota_provinsi_id = reader["kabkota_provinsi_id"].ToString();

                reader.Close();
                _connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return kabkotamodel;
        }
    }
}
