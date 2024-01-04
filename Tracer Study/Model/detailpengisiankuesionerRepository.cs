using System.Data.SqlClient;

namespace PRG_4_API.Model
{
    public class detailpengisiankuesionerRepository
    {
        private readonly string _connectionString;

        private readonly SqlConnection _connection;

        public detailpengisiankuesionerRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");

            _connection = new SqlConnection(_connectionString);
        }

        public List<detailpengisiankuesionerModel> getAllData()
        {
            List<detailpengisiankuesionerModel> detailpengisiankuesionerList = new List<detailpengisiankuesionerModel>();

            try
            {
                string query = "SELECT * FROM ts_detailPengisianKuesioner";
                SqlCommand command = new SqlCommand(query, _connection);
                _connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    detailpengisiankuesionerModel detailpengisiankuesioner = new detailpengisiankuesionerModel
                    {
                        id = Convert.ToInt32(reader["id"].ToString()),
                        tahun_lulus = reader["tahun_lulus"].ToString(),
                        tahun_kuesioner = reader["tahun_kuesioner"].ToString(),
                        created_by = reader["created_by"].ToString(),
                        created_date = Convert.ToDateTime(reader["created_date"].ToString()),
                        modified_by = reader["modified_by"].ToString(),
                        modified_date = Convert.ToDateTime(reader["modified_date"].ToString()),
                        status = reader["status"].ToString(),
                    };
                    detailpengisiankuesionerList.Add(detailpengisiankuesioner);
                }
                reader.Close();
                _connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return detailpengisiankuesionerList;
        }

        public detailpengisiankuesionerModel getData(int id)
        {
            detailpengisiankuesionerModel detailpengisiankuesionermodel = new detailpengisiankuesionerModel();
            try
            {
                string query = "SELECT * FROM ts_detailPengisianKuesioner WHERE id = @p1";
                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@p1", id);
                _connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                reader.Read();

                detailpengisiankuesionermodel.id = Convert.ToInt32(reader["id"].ToString());
                detailpengisiankuesionermodel.tahun_lulus = reader["tahun_lulus"].ToString();
                detailpengisiankuesionermodel.tahun_kuesioner = reader["tahun_kuesioner"].ToString();
                detailpengisiankuesionermodel.created_by = reader["created_by"].ToString();
                detailpengisiankuesionermodel.created_date = Convert.ToDateTime(reader["created_date"].ToString());
                detailpengisiankuesionermodel.modified_by = reader["modified_by"].ToString();
                detailpengisiankuesionermodel.modified_date = Convert.ToDateTime(reader["modified_date"].ToString());
                detailpengisiankuesionermodel.status = reader["status"].ToString();

                reader.Close();
                _connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return detailpengisiankuesionermodel;
        }
    }
}
