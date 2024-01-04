using System.Data.SqlClient;

namespace PRG_4_API.Model
{
    public class jawabankuesionerRepository
    {
        private readonly string _connectionString;

        private readonly SqlConnection _connection;

        public jawabankuesionerRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");

            _connection = new SqlConnection(_connectionString);
        }

        public List<jawabankuesionerModel> getAllData()
        {
            List<jawabankuesionerModel> jawabankuesionerList = new List<jawabankuesionerModel>();

            try
            {
                string query = "SELECT * FROM ts_jawabanKuesioner";
                SqlCommand command = new SqlCommand(query, _connection);
                _connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    jawabankuesionerModel jawabankuesioner = new jawabankuesionerModel
                    {
                        id_jawabanKuesioner = reader["id_jawabanKuesioner"].ToString(),
                        id_pku = reader["id_pku"].ToString(),
                        deskripsiJawaban = reader["deskripsiJawaban"].ToString(),
                        kode = reader["kode"].ToString(),
                        nilaiJawaban = reader["nilaiJawaban"].ToString(),
                        textbox = reader["textbox"].ToString(),
                        created_by = reader["created_by"].ToString(),
                        created_date = Convert.ToDateTime(reader["created_date"].ToString()),
                        modified_by = reader["modified_by"].ToString(),
                        modified_date = Convert.ToDateTime(reader["modified_date"].ToString()),
                        status = reader["status"].ToString(),
                    };
                    jawabankuesionerList.Add(jawabankuesioner);
                }
                reader.Close();
                _connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return jawabankuesionerList;
        }

        public jawabankuesionerModel getData(int id_jawabanKuesioner)
        {
            jawabankuesionerModel jawabankuesionermodel = new jawabankuesionerModel();
            try
            {
                string query = "SELECT * FROM ts_jawabanKuesioner WHERE id_jawabanKuesioner = @p1";
                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@p1", id_jawabanKuesioner);
                _connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                reader.Read();

                jawabankuesionermodel.id_jawabanKuesioner = reader["id_jawabanKuesioner"].ToString();
                jawabankuesionermodel.id_pku = reader["id_pku"].ToString();
                jawabankuesionermodel.deskripsiJawaban = reader["deskripsiJawaban"].ToString();
                jawabankuesionermodel.kode = reader["kode"].ToString();
                jawabankuesionermodel.nilaiJawaban = reader["nilaiJawaban"].ToString();
                jawabankuesionermodel.textbox = reader["textbox"].ToString();
                jawabankuesionermodel.created_by = reader["created_by"].ToString();
                jawabankuesionermodel.created_date = Convert.ToDateTime(reader["created_date"].ToString());
                jawabankuesionermodel.modified_by = reader["modified_by"].ToString();
                jawabankuesionermodel.modified_date = Convert.ToDateTime(reader["modified_date"].ToString());
                jawabankuesionermodel.status = reader["status"].ToString();

                reader.Close();
                _connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return jawabankuesionermodel;
        }
    }
}
