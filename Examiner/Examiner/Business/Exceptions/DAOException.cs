using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examiner.Business.Exceptions
{
  public class DAOException : Exception
  {
    public DAOException(Exception e)
    {
      this.BaseException = e;
    }

    public Exception BaseException { get; set; }
  }
}
