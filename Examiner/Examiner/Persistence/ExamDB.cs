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
        (bool)row["open"],
        (string)row["accessCode"]);
    }

    public void Add(Exam t)
    {
      string sql = string.Format("INSERT [Student] (questionCount, open, accessCode) VALUES('{0}','{1}','{2}','{3})",
        t.QuestionCount,
        t.Open,
        t.AccessCode);

      ConnectionDB.Instance.ExecuteNonQuery(sql);
    }

    public void Update(Exam t)
    {
      string sql = string.Format("UPDATE [Student] SET questionCount= {0}, open= {1}, accessCode= {2} WHERE id_exam = {3}",
            t.QuestionCount,
            t.Open,
            t.AccessCode,
            t.Id);

      ConnectionDB.Instance.ExecuteNonQuery(sql);
    }

    public void Delete(Exam t)
    {
      string sql = string.Format("DELETE FROM [Student] WHERE id_exam = {0}", t.Id);

      ConnectionDB.Instance.ExecuteNonQuery(sql);
    }

    public List<Exam> GetAll()
    {
      var exams = new List<Exam>();
      string sql = "select * from Exam";
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