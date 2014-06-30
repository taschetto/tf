using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examiner.Business.Models
{
    class DAOExcepton : Exception
    {
        public DAOExcepton(string message) : base(message)
        {
        }
    }

    
}
