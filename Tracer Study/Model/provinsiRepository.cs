using System.Data.SqlClient;

namespace PRG_4_API.Model
{
    public class provinsiRepository
    {
        private readonly string _connectionString;

        private readonly SqlConnection _connection;

        public provinsiRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");

            _connection = new SqlConnection(_connectionString);
        }

        public List<provinsiModel> getAllData()
        {
            List<provinsiModel> provinsiList = new List<provinsiModel>();

            try
            {
                string query = "SELECT * FROM ts_provinsi";
                SqlCommand command = new SqlCommand(query, _connection);
                _connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    provinsiModel provinsi = new provinsiModel
                    {
                        provinsi_id = reader["provinsi_id"].ToString(),
                        provinsi_deskripsi = reader["provinsi_deskripsi"].ToString(),
                    };
                    provinsiList.Add(provinsi);
                }
                reader.Close();
                _connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return provinsiList;
        }

        public provinsiModel getData(string provinsi_id)
        {
            provinsiModel provinsimodel = new provinsiModel();
            try
            {
                string query = "SELECT * FROM ts_provinsi WHERE provinsi_id = @p1";
                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@p1", provinsi_id);
                _connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                reader.Read();

                provinsimodel.provinsi_id = reader["provinsi_id"].ToString();
                provinsimodel.provinsi_deskripsi = reader["provinsi_deskripsi"].ToString();

                reader.Close();
                _connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return provinsimodel;
        }
    }
}
