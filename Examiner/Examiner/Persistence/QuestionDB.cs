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

      var question = new Question(
        (int)row["id"],
        (string)row["questionContent"],
        (string)row["feedbackContent"], 
        alternatives,
        (int)row["rightAlternative"]);

      question.Categories = CategoryDB.Instance.GetByQuestion(question);

      return question;
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

    public bool Add(Question t)
    {
      string sql = string.Format(
        "INSERT [Question] (questionContent, feedbackContent, " +
        "alternative1, alternative2, alternative3, alternative4, alternative5, rightAlternative) " +
        " VALUES('{0}','{1}','{2}', '{3}', '{4}', '{5}', '{6}', {7})",
        t.QuestionContent,
        t.FeedbackContent,
        t.Alternatives[0],
        t.Alternatives[1],
        t.Alternatives[2],
        t.Alternatives[3],
        t.Alternatives[4],
        t.RightAlternative);

      bool ret = ConnectionDB.Instance.ExecuteNonQuery(sql) > 0;

      if (!ret)
        return false;

      if (t.Categories.Count > 0)
        return this.SetCategories(t);

      return true;
    }

    private bool SetCategories(Question t)
    {
      string sql = string.Format("DELETE [CategoryQuestion] where id_question = {0}", t.Id);
      ConnectionDB.Instance.ExecuteNonQuery(sql);

      foreach (var category in t.Categories)
      {
        sql = string.Format("INSERT [CategoryQuestion] (id_question, id_category) VALUES({0}, {1})",
          t.Id,
          category.Id);

        ConnectionDB.Instance.ExecuteNonQuery(sql);
      }

      return true;
    }

    public bool Update(Question t)
    {
      string sql = string.Format(
        "UPDATE [Question] SET questionContent = '{0}', feedbackContent = '{1}', " +
        "alternative1 = '{2}', alternative2 = '{3}', alternative3 = '{4}', alternative4 = '{5}', alternative5 = '{6}', rightAlternative = {7} " +
        "WHERE id = {8}",
        t.QuestionContent,
        t.FeedbackContent,
        t.Alternatives[0],
        t.Alternatives[1],
        t.Alternatives[2],
        t.Alternatives[3],
        t.Alternatives[4],
        t.RightAlternative,
        t.Id);

      bool ret = ConnectionDB.Instance.ExecuteNonQuery(sql) > 0;

      if (!ret)
        return false;

      if (t.Categories.Count > 0)
        return this.SetCategories(t);

      return true;
    }

    public bool Delete(Question t)
    {
      string sql = string.Format("DELETE FROM [Question] WHERE id = {0}", t.Id);

      return ConnectionDB.Instance.ExecuteNonQuery(sql) > 0;
    }

    public List<Question> GetAll()
    {
      var questions = new List<Question>();
      string sql = "select * from [Question]";
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