using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examiner.Business.Models
{
    class ExamValidator
    {
        private static ExamValidator _examValidator = null;

        public static ExamValidator GetValidator()
        {
            if (_examValidator == null)
            {
                _examValidator = new ExamValidator();
            }
            return _examValidator;
        }

        public bool ValidCount(int val)
        {
            if (val < 1)
            {
                return false;
            }
            return true;
        }

        public bool ValidOpen(char val)
        {
            if (val == 1 || val == 0)
            {
                return true;
            }
            return false;
        }


        //Bolar uma lógica de verificação para o código
        public bool ValidAccessCode(String val)
        {
            return true;
        }


    }
}
