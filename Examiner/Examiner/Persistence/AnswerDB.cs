namespace Examiner.Persistence
{
  using System;
  using Examiner.Business.Models;
  using Examiner.Business.DAOs;
  using System.Data;
  using System.Collections.Generic;

  public class AnswerDB : IAnswerDao
  {
    private static AnswerDB instance = null;

    public static AnswerDB Instance
    {
      get
      {
        if (instance == null)
        {
          instance = new AnswerDB();
        }

        return instance;
      }
    }

    private Answer ToAnswer(DataRow row)
    {
      var studentExam = StudentExamDB.Instance.GetById((int)row["id_studentexam"]);
      var question = QuestionDB.Instance.GetById((int)row["id_question"]);

      return new Answer(
        (int)row["id"],
        studentExam,
        question,
        (int)row["alternative"]);
    }

    public bool Add(Answer t)
    {
      string sql = string.Format("INSERT [Answer] (id_question, id_studentexam, alternative) VALUES({0}, {1}, {2})",
        t.Question.Id,
        t.StudentExam.Id,
        t.Alternative);

      return ConnectionDB.Instance.ExecuteNonQuery(sql) > 0;
    }

    public bool Update(Answer t)
    {
      // Não é possível dar update em um Answer! Uma vez respondida, está feito.
      throw new NotSupportedException();
    }

    public bool Delete(Answer t)
    {
      string sql = string.Format("DELETE FROM [Answer] WHERE id = {0}", t.Id);

      return ConnectionDB.Instance.ExecuteNonQuery(sql) > 0;
    }

    public List<Answer> GetAll()
    {
      var answers = new List<Answer>();
      string sql = "select * from [Answer]";
      var dataTable = ConnectionDB.Instance.ExecuteQuery(sql);

      foreach (DataRow row in dataTable.Rows)
      {
        answers.Add(ToAnswer(row));
      }

      return answers;
    }

    public Answer GetById(int id)
    {
      string sql = string.Format("SELECT * FROM [Answer] WHERE id = {0}", id);
      var dataTable = ConnectionDB.Instance.ExecuteQuery(sql);

      foreach (DataRow row in dataTable.Rows)
      {
        return ToAnswer(row);
      }

      return null;
    }
  }
}
