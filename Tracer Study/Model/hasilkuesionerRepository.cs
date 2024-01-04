using System.Data.SqlClient;

namespace PRG_4_API.Model
{
    public class hasilkuesionerRepository
    {
        private readonly string _connectionString;

        private readonly SqlConnection _connection;

        public hasilkuesionerRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");

            _connection = new SqlConnection(_connectionString);
        }

        public List<hasilkuesionerModel> getAllData()
        {
            List<hasilkuesionerModel> hasilkuesionerList = new List<hasilkuesionerModel>();

            try
            {
                string query = "SELECT * FROM ts_hasilKuesioner";
                SqlCommand command = new SqlCommand(query, _connection);
                _connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    hasilkuesionerModel hasilkuesioner = new hasilkuesionerModel
                    {
                        id_hasilKuesioner = reader["id_hasilKuesioner"].ToString(),
                        nim = reader["nim"].ToString(),
                        id_detail_periode = Convert.ToInt32(reader["id_detail_periode"].ToString()),
                        tanggal_pengisian = Convert.ToDateTime(reader["tanggal_pengisian"].ToString()), //?
                        created_by = reader["created_by"].ToString(),
                        created_date = Convert.ToDateTime(reader["created_date"].ToString()),
                        modified_by = reader["modified_by"].ToString(),
                        modified_date = Convert.ToDateTime(reader["modified_date"].ToString()),
                    };
                    hasilkuesionerList.Add(hasilkuesioner);
                }
                reader.Close();
                _connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return hasilkuesionerList;
        }

        public hasilkuesionerModel getData(int id_hasilKuesioner)
        {
            hasilkuesionerModel hasilkuesionermodel = new hasilkuesionerModel();
            try
            {
                string query = "SELECT * FROM ts_hasilKuesioner WHERE id_hasilKuesioner = @p1";
                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@p1", id_hasilKuesioner);
                _connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                reader.Read();

                hasilkuesionermodel.id_hasilKuesioner = reader["id_hasilKuesioner"].ToString();
                hasilkuesionermodel.nim = reader["nim"].ToString();
                hasilkuesionermodel.id_detail_periode = Convert.ToInt32(reader["id_detail_periode"].ToString());
                hasilkuesionermodel.tanggal_pengisian = Convert.ToDateTime(reader["created_date"].ToString()); //?
                hasilkuesionermodel.created_by = reader["created_by"].ToString();
                hasilkuesionermodel.created_date = Convert.ToDateTime(reader["created_date"].ToString());
                hasilkuesionermodel.modified_by = reader["modified_by"].ToString();
                hasilkuesionermodel.modified_date = Convert.ToDateTime(reader["modified_date"].ToString());

                reader.Close();
                _connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return hasilkuesionermodel;
        }
    }
}
