using System.Data.SqlClient;

namespace PRG_4_API.Model
{
    public class laporankuesionerRepository
    {
        private readonly string _connectionString;

        private readonly SqlConnection _connection;

        public laporankuesionerRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");

            _connection = new SqlConnection(_connectionString);
        }

        public List<laporankuesionerModel> getAllData()
        {
            List<laporankuesionerModel> laporankuesionerList = new List<laporankuesionerModel>();

            try
            {
                string query = "SELECT * FROM ts_laporanKuesioner";
                SqlCommand command = new SqlCommand(query, _connection);
                _connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    laporankuesionerModel laporankuesioner = new laporankuesionerModel
                    {
                        id_hasilKuesioner = reader["id_hasilKuesioner"].ToString(),
                        kode = reader["kode"].ToString(),
                        jawabanKuesioner = reader["jawabanKuesioner"].ToString(),
                        created_by = reader["created_by"].ToString(),
                        created_date = Convert.ToDateTime(reader["created_date"].ToString()),
                        modified_by = reader["modified_by"].ToString(),
                        modified_date = Convert.ToDateTime(reader["modified_date"].ToString()),
                    };
                    laporankuesionerList.Add(laporankuesioner);
                }
                reader.Close();
                _connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return laporankuesionerList;
        }

        public laporankuesionerModel getData(string id_hasilKuesioner)
        {
            laporankuesionerModel laporankuesionermodel = new laporankuesionerModel();
            try
            {
                string query = "SELECT * FROM ts_laporanKuesioner WHERE id_hasilKuesioner = @p1";
                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@p1", id_hasilKuesioner);
                _connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                reader.Read();

                laporankuesionermodel.id_hasilKuesioner = reader["id"].ToString();
                laporankuesionermodel.kode = reader["kode"].ToString();
                laporankuesionermodel.jawabanKuesioner = reader["jawabanKuesioner"].ToString();
                laporankuesionermodel.created_by = reader["created_by"].ToString();
                laporankuesionermodel.created_date = Convert.ToDateTime(reader["created_date"].ToString());
                laporankuesionermodel.modified_by = reader["modified_by"].ToString();
                laporankuesionermodel.modified_date = Convert.ToDateTime(reader["modified_date"].ToString());

                reader.Close();
                _connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return laporankuesionermodel;
        }
    }
}
