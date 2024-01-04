using System.Data.SqlClient;

namespace PRG_4_API.Model
{
    public class detailjenisperiodeRepository
    {
        private readonly string _connectionString;

        private readonly SqlConnection _connection;

        public detailjenisperiodeRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");

            _connection = new SqlConnection(_connectionString);
        }

        public List<detailjenisperiodeModel> getAllData()
        {
            List<detailjenisperiodeModel> detailjenisperiodeList = new List<detailjenisperiodeModel>();

            try
            {
                string query = "SELECT * FROM ts_detailJenisPeriode";
                SqlCommand command = new SqlCommand(query, _connection);
                _connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    detailjenisperiodeModel detailjenisperiode = new detailjenisperiodeModel
                    {
                        id_detailPeriode = Convert.ToInt32(reader["id_detailPeriode"].ToString()),
                        jenis_kuesioner = reader["jenis_kuesioner"].ToString(),
                        periode = Convert.ToInt32(reader["periode"].ToString()),
                        created_by = reader["created_by"].ToString(),
                        created_date = Convert.ToDateTime(reader["created_date"].ToString()),
                        modified_by = reader["modified_by"].ToString(),
                        modified_date = Convert.ToDateTime(reader["modified_date"].ToString()),
                        status = reader["status"].ToString(),
                    };
                    detailjenisperiodeList.Add(detailjenisperiode);
                }
                reader.Close();
                _connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return detailjenisperiodeList;
        }

        public detailjenisperiodeModel getData(int id_detailPeriode)
        {
            detailjenisperiodeModel detailjenisperiodemodel = new detailjenisperiodeModel();
            try
            {
                string query = "SELECT * FROM ts_detailJenisPeriode WHERE id_detailPeriode = @p1";
                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@p1", id_detailPeriode);
                _connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                reader.Read();

                detailjenisperiodemodel.id_detailPeriode = Convert.ToInt32(reader["id_detailPeriode"].ToString());
                detailjenisperiodemodel.jenis_kuesioner = reader["jenis_kuesioner"].ToString();
                detailjenisperiodemodel.periode = Convert.ToInt32(reader["periode"].ToString());
                detailjenisperiodemodel.created_by = reader["created_by"].ToString();
                detailjenisperiodemodel.created_date = Convert.ToDateTime(reader["created_date"].ToString());
                detailjenisperiodemodel.modified_by = reader["modified_by"].ToString();
                detailjenisperiodemodel.modified_date = Convert.ToDateTime(reader["modified_date"].ToString());
                detailjenisperiodemodel.status = reader["status"].ToString();

                reader.Close();
                _connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return detailjenisperiodemodel;
        }
    }
}
