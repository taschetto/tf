namespace Examiner.Persistence
{
  using System.Collections.Generic;
  using System.Data;
  using Examiner.Business.DAOs;
  using Examiner.Business.Models;

  public class QuestionDB : IQuestionDao
  {
    private static QuestionDB instance = null;

    private Question ToQuestion(DataRow row)
    {
      string[] alternatives = new string[5]
        {
          (string)row["alternative1"],
          (string)row["alternative2"],
          (string)row["alternative3"],
          (string)row["alternative4"],
          (string)row["alternative5"]
        };

      return new Question(
        (int)row["id"],
        (string)row["questionContent"],
        (string)row["feedbackContent"], 
        alternatives,
        (int)row["rightAlternative"]);
    }

    public static QuestionDB Instance
    {
      get
      {
        if (instance == null)
        {
          instance = new QuestionDB();
        }
        return instance;
      }
    }

    public void Add(Question t)
    {
      string sql = string.Format("INSERT [Question] (questionContent, feedbackContent, rightAlternative) VALUES('{0}','{1}','{2}')",
        t.QuestionContent,
        t.FeedbackContent,
        t.RightAlternative);

      ConnectionDB.Instance.ExecuteNonQuery(sql);
    }

    public void Update(Question t)
    {
      string sql = string.Format("UPDATE [Question] SET questionContent = {0}, feedbackContent = {1}, rightAlternative= {2}) WHERE = {3}",
        t.QuestionContent,
        t.FeedbackContent,
        t.RightAlternative,
        t.Id);

      ConnectionDB.Instance.ExecuteNonQuery(sql);
    }

    public void Delete(Question t)
    {
      string sql = string.Format("DELETE FROM [Question] WHERE id = {0}", t.Id);

      ConnectionDB.Instance.ExecuteNonQuery(sql);
    }

    public List<Question> GetAll()
    {
      var questions = new List<Question>();
      string sql = "select * from Question";
      var dataTable = ConnectionDB.Instance.ExecuteQuery(sql);

      foreach (DataRow row in dataTable.Rows)
      {
        questions.Add(ToQuestion(row));
      }

      return questions;
    }

    public Question GetById(int id)
    {
      string sql = string.Format("SELECT * FROM [Question] WHERE id = {0}", id);
      var dataTable = ConnectionDB.Instance.ExecuteQuery(sql);

      foreach (DataRow row in dataTable.Rows)
      {
        return ToQuestion(row);
      }

      return null;
    }
  }
}