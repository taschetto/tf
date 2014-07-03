namespace Examiner.Business
{
  using System;
  using System.Linq;
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

    public T GetById<T>(int id)
      where T : BaseModel
    {
      switch (typeof(T).Name)
      {
      case @"Exam":
        return ExamDB.Instance.GetById(id) as T;

      case @"Category":
        return CategoryDB.Instance.GetById(id) as T;

      case @"Question":
        return QuestionDB.Instance.GetById(id) as T;

      case @"Student":
        return StudentDB.Instance.GetById(id) as T;

      case @"StudentExam":
        return StudentExamDB.Instance.GetById(id) as T;

      default:
        throw new InvalidOperationException();
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

        case @"Student":
          return StudentDB.Instance.GetAll() as List<T>;

        case @"StudentExam":
          return StudentExamDB.Instance.GetAll() as List<T>;

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

      case @"Student":
        return StudentDB.Instance.Add(t as Student);

      case @"StudentExam":
        return StudentExamDB.Instance.Add(t as StudentExam);

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

      case @"Student":
        return StudentDB.Instance.Update(t as Student);

      case @"StudentExam":
        return StudentExamDB.Instance.Update(t as StudentExam);

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

      case @"Student":
        return StudentDB.Instance.Delete(t as Student);

      case @"StudentExam":
        return StudentExamDB.Instance.Delete(t as StudentExam);

      default:
        throw new InvalidOperationException();
      }
    }

    public StudentExam CreateNewExam(Student student, Exam exam)
    {
      var questions = new List<Question>();

      foreach (var category in exam.Categories)
      {
        var categoryQuestions = QuestionDB.Instance.GetByCategory(category);

        foreach (var question in categoryQuestions)
        {
          if (!questions.Contains(question))
            questions.Add(question);
        }
      }

      StudentExam studentExam = new StudentExam(0, student, exam);
      foreach (var question in questions.OrderBy(x => Guid.NewGuid()).Take(exam.QuestionCount))
      {
        var answer = new Answer(0, studentExam, question, 0);
        studentExam.Answers.Add(answer);
      }

      return studentExam;
    }
  }
}
