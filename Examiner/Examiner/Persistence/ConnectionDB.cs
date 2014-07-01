using System.Data.SqlClient;


namespace Examiner.Persistence
{
  using System.Configuration;
  using System.Data;

  public class ConnectionDB
  {
    private static ConnectionDB instance = null;

    private ConnectionDB() { }

    public static ConnectionDB Instance
    {
      get
      {
        if (instance == null)
        {
          instance = new ConnectionDB();
        }
     
        return instance;
      }
    }

    public SqlConnection Connection
    {
      get
      {
        return new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Persistence\DB\supernova.mdf;Integrated Security=True");
      }
    }

    public DataTable ExecuteQuery(string sql)
    {
      using (var connection = this.Connection)
      {
        var command = new SqlCommand()
        {
          CommandType = CommandType.Text,
          CommandText = sql,
          Connection = connection
        };

        connection.Open();
        SqlDataReader reader = command.ExecuteReader();
        var dataTable = new DataTable();
        dataTable.Load(reader);
        return dataTable;
      }
    }

    public int ExecuteNonQuery(string sql)
    {
      using (var connection = this.Connection)
      {
        var command = new SqlCommand()
        {
          CommandType = CommandType.Text,
          CommandText = sql,
          Connection = connection
        };

        command.Connection.Open();
        int rowsAffected = command.ExecuteNonQuery();

        return rowsAffected;
      }
    }
  }
}