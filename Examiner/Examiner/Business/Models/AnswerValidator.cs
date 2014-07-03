namespace Examiner.Business.Models
{
    class AnswerValidator
    {
        private static AnswerValidator _answerValidator = null;

        public static AnswerValidator GetValidator()
        {
            if (_answerValidator == null)
            {
                _answerValidator = new AnswerValidator();
            }
            return _answerValidator;
        }

        public bool ValidAlternative(int val)
        {
            if (val > 4 || val < 0)
            {
                return false;
            }
            return true;
        }      
    }
}
