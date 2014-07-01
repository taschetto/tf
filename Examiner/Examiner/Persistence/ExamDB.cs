namespace Examiner.Persistence
{
  using System.Collections.Generic;
  using System.Data;
  using Examiner.Business.DAOs;
  using Examiner.Business.Models;
  
  public class ExamDB : IExamDao
  {
    private static ExamDB instance = null;

    public static ExamDB Instance
    {
      get
      {
        if (instance == null)
        {
          instance = new ExamDB();
        }

        return instance;
      }
    }

    private Exam ToExam(DataRow row)
    {
      return new Exam(
        (int)row["id"],
        (int)row["questionCount"],
        ((string)row["open"]).Equals("1"),
        (string)row["accessCode"]);
    }

    public bool Add(Exam t)
    {
      string sql = string.Format("INSERT [Exam] (questionCount, [open], accessCode) VALUES({0}, '{1}', '{2}')",
        t.QuestionCount,
        t.Open ? 1 : 0,
        t.AccessCode);

      return ConnectionDB.Instance.ExecuteNonQuery(sql) > 0;
    }

    public bool Update(Exam t)
    {
      string sql = string.Format("UPDATE [Exam] SET questionCount = {0}, [open] = '{1}', accessCode = '{2}' WHERE id = {3}",
            t.QuestionCount,
            t.Open ? 1 : 0,
            t.AccessCode,
            t.Id);

      return ConnectionDB.Instance.ExecuteNonQuery(sql) > 0;
    }

    public bool Delete(Exam t)
    {
      string sql = string.Format("DELETE FROM [Exam] WHERE id = {0}", t.Id);

      return ConnectionDB.Instance.ExecuteNonQuery(sql) > 0;
    }

    public List<Exam> GetAll()
    {
      var exams = new List<Exam>();
      string sql = "select * from [Exam]";
      var dataTable = ConnectionDB.Instance.ExecuteQuery(sql);

      foreach (DataRow row in dataTable.Rows)
      {
        exams.Add(ToExam(row));
      }

      return exams;
    }

    public Exam GetById(int id)
    {
      string sql = string.Format("SELECT * FROM [Exam] WHERE id = {0}", id);
      var dataTable = ConnectionDB.Instance.ExecuteQuery(sql);

      foreach (DataRow row in dataTable.Rows)
      {
        return ToExam(row);
      }

      return null;
    }
  }
}