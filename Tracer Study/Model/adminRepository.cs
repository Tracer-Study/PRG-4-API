using System.Data.SqlClient;

namespace PRG_4_API.Model
{
    public class adminRepository
    {
        private readonly string _connectionString;

        private readonly SqlConnection _connection;

        public adminRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");

            _connection = new SqlConnection(_connectionString);
        }

        public List<adminModel> getAllData()
        { 
            List<adminModel> adminList = new List<adminModel>();

            try
            {
                string query = "SELECT * FROM ts_admin";
                SqlCommand command = new SqlCommand(query, _connection);
                _connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    adminModel admin = new adminModel
                    {
                        id_admin = reader["id_admin"].ToString(),
                        nama = reader["nama"].ToString(),
                        jenis_kelamin = reader["jenis_kelamin"].ToString(),
                        email = reader["email"].ToString(),
                        username = reader["username"].ToString(),
                        password = reader["password"].ToString()
                    };
                    adminList.Add(admin);
                }
                reader.Close();
                _connection.Close();
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
            return adminList;
        }

        public adminModel getData(string id_admin)
        {
            adminModel adminmodel = new adminModel();
            try
            {
                string query = "SELECT * FROM ts_admin WHERE id_admin = @p1";
                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@p1", id_admin);
                _connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                reader.Read();

                adminmodel.id_admin = reader["id_admin"].ToString();
                adminmodel.nama = reader["nama"].ToString();
                adminmodel.jenis_kelamin = reader["jenis_kelamin"].ToString();
                adminmodel.email = reader["email"].ToString();
                adminmodel.username = reader["username"].ToString();
                adminmodel.password = reader["password"].ToString();

                reader.Close();
                _connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return adminmodel;
        }
    }
}
