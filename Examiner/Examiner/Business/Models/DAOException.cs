using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examiner.Business.Models
{
    class DAOException : Exception
    {
        public DAOException(string message) : base(message)
        {
        }
    }

    
}
