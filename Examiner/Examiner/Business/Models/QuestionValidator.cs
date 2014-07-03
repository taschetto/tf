
namespace Examiner.Business.Models
{
    using System;

    class QuestionValidator
    {
        private static QuestionValidator _validatorQuestion = null;

        public static QuestionValidator GetValidador()
        {
            if (_validatorQuestion == null)
            {
                _validatorQuestion = new QuestionValidator();
            }
            return _validatorQuestion;
        }

        public bool ValidQuestionContent(String val)
        {
            if (string.IsNullOrEmpty(val) || val.Length >= 200)
            {
                return false;
            }
            return true;
        }

        public bool ValidFeedback(String val)
        {
            if (string.IsNullOrEmpty(val) || val.Length >= 200)
            {
                return false;
            }
            return true;
        }

        public bool ValidRightAlternative(int val)
        {
            if ((val >4 || val < 0))
            {
                return false;
            }
            return true;
        }

        public bool ValidAlternative(String val)
        {
            if (string.IsNullOrEmpty(val))
            {
                return false;
            }
            return true;
        }

    }
}
