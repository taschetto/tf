namespace Examiner.Business
{
  using System;
  using System.Collections.Generic;
  using Examiner.Persistence;
  using Examiner.Business.Models;

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

    public bool Add<T>(T t)
    {
      switch (typeof(T).Name)
      {
      case @"Exam":
        return ExamDB.Instance.Add(t as Exam);

      case @"Category":
        return CategoryDB.Instance.Add(t as Category);

      case @"Question":
        return QuestionDB.Instance.Add(t as Question);

      default:
        throw new InvalidOperationException();
      }
    }

    public bool Update<T>(T t)
    {
      switch (typeof(T).Name)
      {
      case @"Exam":
        return ExamDB.Instance.Update(t as Exam);

      case @"Category":
        return CategoryDB.Instance.Update(t as Category);

      case @"Question":
        return QuestionDB.Instance.Update(t as Question);

      default:
        throw new InvalidOperationException();
      }
    }
    public bool Delete<T>(T t)
    {
      switch (typeof(T).Name)
      {
      case @"Exam":
        return ExamDB.Instance.Delete(t as Exam);

      case @"Category":
        return CategoryDB.Instance.Delete(t as Category);

      case @"Question":
        return QuestionDB.Instance.Delete(t as Question);

      default:
        throw new InvalidOperationException();
      }
    }
  }
}
