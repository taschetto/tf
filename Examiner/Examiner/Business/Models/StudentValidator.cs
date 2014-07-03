namespace Examiner.Business.Models
{
    using System;
    class StudentValidator
    {
        private static StudentValidator _validator = null;

        public static StudentValidator GetValidator()
        {
            if (_validator == null)
            {
                _validator = new StudentValidator();
            }
            return _validator;
        }

        public bool ValidName(String name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return false;
            }
            return true;
        }

        public bool ValidEmail(String email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return false;
            }
            return true;
        }

        public bool ValidPassword(String pass)
        {
            if (string.IsNullOrEmpty(pass))
            {
                return false;
            }
            return true;
        }

        public bool ValidRegistration(String reg)
        {
            if (string.IsNullOrEmpty(reg))
            {
                return false;
            }
            return true;
        }

    }
}
