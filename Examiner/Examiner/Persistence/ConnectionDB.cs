using System.Data.SqlClient;


namespace Examiner.Persistence
{
  using System.Configuration;
  class ConnectionDB
  {
    public static SqlConnection CreateConnection()
    {
      var connectionString = ConfigurationManager.ConnectionStrings["Examiner"];
      var connection = connectionString != null ? new SqlConnection(connectionString.ConnectionString) : null;
      return connection;
    }
  }
}