namespace Examiner.Business
{
  using System;
  using System.Collections.Generic;
  using Examiner.Persistence;

  public class ExaminerFacade
  {
    private static ExaminerFacade instance = null;

    public static ExaminerFacade Instance
    {
      get
      {
        if (instance == null)
        {
          instance = new ExaminerFacade();
        }

        return instance;
      }
    }

    public List<T> GetAll<T>()
    {
      switch (typeof(T).Name)
      {
        case @"Exam":
          return ExamDB.Instance.GetAll() as List<T>;

        case @"Category":
          return CategoryDB.Instance.GetAll() as List<T>;

        case @"Question":
          return QuestionDB.Instance.GetAll() as List<T>;

        default:
          throw new InvalidOperationException();
      }
    }
  }
}
