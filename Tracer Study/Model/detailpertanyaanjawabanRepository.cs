using System.Data.SqlClient;

namespace PRG_4_API.Model
{
    public class detailpertanyaanjawabanRepository
    {
        private readonly string _connectionString;

        private readonly SqlConnection _connection;

        public detailpertanyaanjawabanRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");

            _connection = new SqlConnection(_connectionString);
        }

        public List<detailpertanyaanjawabanModel> getAllData()
        {
            List<detailpertanyaanjawabanModel> detailpertanyaanjawabanList = new List<detailpertanyaanjawabanModel>();

            try
            {
                string query = "SELECT * FROM ts_detailPertanyaanJawaban";
                SqlCommand command = new SqlCommand(query, _connection);
                _connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    detailpertanyaanjawabanModel detailpertanyaanjawaban = new detailpertanyaanjawabanModel
                    {
                        id_detailPertanyaanJawaban = Convert.ToInt32(reader["id_detailPertanyaanJawaban"].ToString()),
                        id_jawabanKuesioner = reader["id_jawabanKuesioner"].ToString(),
                        id_pku_answer = reader["id_pku_answer"].ToString(),
                        created_by = reader["created_by"].ToString(),
                        created_date = Convert.ToDateTime(reader["created_date"].ToString()),
                        modified_by = reader["modified_by"].ToString(),
                        modified_date = Convert.ToDateTime(reader["modified_date"].ToString()),
                        status = reader["status"].ToString(),
                    };
                    detailpertanyaanjawabanList.Add(detailpertanyaanjawaban);
                }
                reader.Close();
                _connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return detailpertanyaanjawabanList;
        }

        public detailpertanyaanjawabanModel getData(int id_detailPertanyaanJawaban)
        {
            detailpertanyaanjawabanModel detailpertanyaanjawabanmodel = new detailpertanyaanjawabanModel();
            try
            {
                string query = "SELECT * FROM ts_detailPertanyaanJawaban WHERE id_detailPertanyaanJawaban = @p1";
                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@p1", id_detailPertanyaanJawaban);
                _connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                reader.Read();

                detailpertanyaanjawabanmodel.id_detailPertanyaanJawaban = Convert.ToInt32(reader["id_detailPertanyaanJawaban"].ToString());
                detailpertanyaanjawabanmodel.id_jawabanKuesioner = reader["id_jawabanKuesioner"].ToString();
                detailpertanyaanjawabanmodel.id_pku_answer = reader["id_pku_answer"].ToString();
                detailpertanyaanjawabanmodel.created_by = reader["created_by"].ToString();
                detailpertanyaanjawabanmodel.created_date = Convert.ToDateTime(reader["created_date"].ToString());
                detailpertanyaanjawabanmodel.modified_by = reader["modified_by"].ToString();
                detailpertanyaanjawabanmodel.modified_date = Convert.ToDateTime(reader["modified_date"].ToString());
                detailpertanyaanjawabanmodel.status = reader["status"].ToString();

                reader.Close();
                _connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return detailpertanyaanjawabanmodel;
        }
    }
}
