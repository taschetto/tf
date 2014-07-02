namespace Examiner.Persistence
{
  using System;
  using System.Collections.Generic;
  using System.Data;
  using Examiner.Business.DAOs;
  using Examiner.Business.Models;

  public class CategoryDB : ICategoryDao
  {
    private static CategoryDB instance = null;

    public static CategoryDB Instance
    {
      get
      {
        if (instance == null)
        {
          instance = new CategoryDB();
        }

        return instance;
      }
    }

    private Category ToCategory(DataRow row)
    {
      return new Category(
        (int)row["id"],
        (string)row["name"],
        (string)row["descript"]);
    }

    public bool Add(Category t)
    {
      string sql = string.Format(
        "INSERT [Category] (name, descript) " +
        " VALUES('{0}','{1}')",
        t.Name,
        t.Description);

      return ConnectionDB.Instance.ExecuteNonQuery(sql) > 0;
    }

    public bool Update(Category t)
    {
      string sql = string.Format(
        "UPDATE [Category] SET " +
        "name = '{0}', descript = '{1}' " +
        "WHERE id = {2}",
        t.Name,
        t.Description,
        t.Id);

      return ConnectionDB.Instance.ExecuteNonQuery(sql) > 0;
    }

    public bool Delete(Category t)
    {
      string sql = string.Format("DELETE FROM [Category] WHERE id = {0}", t.Id);

      return ConnectionDB.Instance.ExecuteNonQuery(sql) > 0;
    }

    public List<Category> GetAll()
    {
      var categories = new List<Category>();
      string sql = "select * from [Category]";
      var dataTable = ConnectionDB.Instance.ExecuteQuery(sql);

      foreach (DataRow row in dataTable.Rows)
      {
        categories.Add(ToCategory(row));
      }

      return categories;
    }

    public Category GetById(int id)
    {
      string sql = string.Format("SELECT * FROM [Category] WHERE id = {0}", id);
      var dataTable = ConnectionDB.Instance.ExecuteQuery(sql);

      foreach (DataRow row in dataTable.Rows)
      {
        return ToCategory(row);
      }

      return null;
    }

    public List<Category> GetByExam(Exam exam)
    {
      var categories = new List<Category>();
      string sql = string.Format("select * from [Category] INNER JOIN [CategoryExam] ON [Category].id = [CategoryExam].id_category WHERE [CategoryExam].id_exam = {0}", exam.Id);
      var dataTable = ConnectionDB.Instance.ExecuteQuery(sql);

      foreach (DataRow row in dataTable.Rows)
      {
        categories.Add(ToCategory(row));
      }

      return categories;
    }


    public List<Category> GetByQuestion(Question question)
    {
      var categories = new List<Category>();
      string sql = string.Format("select * from [Category] INNER JOIN [CategoryQuestion] ON [Category].id = [CategoryQuestion].id_category WHERE [CategoryQuestion].id_question = {0}", question.Id);
      var dataTable = ConnectionDB.Instance.ExecuteQuery(sql);

      foreach (DataRow row in dataTable.Rows)
      {
        categories.Add(ToCategory(row));
      }

      return categories;
    }
  }
}