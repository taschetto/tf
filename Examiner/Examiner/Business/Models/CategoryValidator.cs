

namespace Examiner.Business.Models
{
    using System;
    class CategoryValidator
    {
        private static CategoryValidator _validatorCategory = null;

        public static CategoryValidator GetValidator()
        {
            if (_validatorCategory == null)
            {
                _validatorCategory = new CategoryValidator();
            }
            return (_validatorCategory);
        }

        public bool ValidName(String  name)
        {
            // Validação boba do tamanho do nome da categoria, mas existe um limite  de 200
            if (name.Length >= 200 || string.IsNullOrEmpty(name))
            {
                return false;
            }
            return true;
        }

        public bool ValidDescription(String des)
        {
            if (des.Length >= 200)
            {
                return false;
            }
            return true;
        }
    }
}
