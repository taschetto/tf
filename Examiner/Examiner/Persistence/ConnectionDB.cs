using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examiner.Persistence
{
    class ConnectionDB
    {
        public static SqlConnection CreateConnection()
        {
            var conexao =
                new SqlConnection(
                    @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Gabriel\Documents\GitHub\tf\Examiner\Examiner\supernova.mdf;Integrated Security=True;Context Connection=False");

            return conexao;
        }
    }
}
