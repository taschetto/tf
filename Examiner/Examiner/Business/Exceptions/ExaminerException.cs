namespace Examiner.Business.Exceptions
{
    using System;
    class ExaminerException : Exception
    {
        public ExaminerException(Exception e)
        {
            this.BaseException = e;
        }
        public Exception BaseException { get; set; }
    }
}
