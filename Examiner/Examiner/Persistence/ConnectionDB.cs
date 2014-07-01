using System.Data.SqlClient;


namespace Examiner.Persistence
{
  using System.Configuration;
  using System.Data;

  public class ConnectionDB
  {
    private SqlConnection connection = null;

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

        if (this.connection == null)
        {
          var connectionString = ConfigurationManager.ConnectionStrings["Examiner"];
          connection = connectionString != null ? new SqlConnection(connectionString.ConnectionString) : null;
        }

        return connection;
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