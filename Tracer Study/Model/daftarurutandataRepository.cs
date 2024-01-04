using System.Data.SqlClient;

namespace PRG_4_API.Model
{
    public class daftarurutandataRepository
    {
        private readonly string _connectionString;

        private readonly SqlConnection _connection;

        public daftarurutandataRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");

            _connection = new SqlConnection(_connectionString);
        }

        public List<daftarurutandataModel> getAllData()
        {
            List<daftarurutandataModel> daftarurutandataList = new List<daftarurutandataModel>();
            
            try
            {
                string query = "SELECT * FROM ts_daftarUrutanData";
                SqlCommand command = new SqlCommand(query, _connection);
                _connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    daftarurutandataModel daftarurutandata = new daftarurutandataModel
                    {
                        id_daftarUrutanData = Convert.ToInt32(reader["id_daftarUrutanData"].ToString()),
                        kode = reader["kode"].ToString(),
                        alias = reader["alias"].ToString(),
                        id_detailJenisPeriode = Convert.ToInt32(reader["id_detailJenisPeriode"].ToString()),
                        created_by = reader["created_by"].ToString(),
                        created_date = Convert.ToDateTime(reader["created_date"].ToString()),
                        modified_by = reader["modified_by"].ToString(),
                        modified_date = Convert.ToDateTime(reader["modified_date"].ToString()),
                        status = reader["status"].ToString(),
                    };
                    daftarurutandataList.Add(daftarurutandata);
                }
                reader.Close();
                _connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return daftarurutandataList;
        }

        public daftarurutandataModel getData(int id_daftarUrutanData)
        {
            daftarurutandataModel daftarurutandatamodel = new daftarurutandataModel();
            try
            {
                string query = "SELECT * FROM ts_daftarUrutanData WHERE id_daftarUrutanData = @p1";
                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@p1", id_daftarUrutanData);
                _connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                reader.Read();

                daftarurutandatamodel.id_daftarUrutanData = Convert.ToInt32(reader["id_daftarUrutanData"].ToString());
                daftarurutandatamodel.kode = reader["kode"].ToString();
                daftarurutandatamodel.alias = reader["alias"].ToString();
                daftarurutandatamodel.id_detailJenisPeriode = Convert.ToInt32(reader["id_detailJenisPeriode"].ToString());
                daftarurutandatamodel.created_by = reader["created_by"].ToString();
                daftarurutandatamodel.created_date = Convert.ToDateTime(reader["created_date"].ToString());
                daftarurutandatamodel.modified_by = reader["modified_by"].ToString();
                daftarurutandatamodel.modified_date = Convert.ToDateTime(reader["modified_date"].ToString());
                daftarurutandatamodel.status = reader["status"].ToString();

                reader.Close();
                _connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return daftarurutandatamodel;
        }
    }
}
