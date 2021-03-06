﻿namespace Examiner.Persistence
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
      var exam = new Exam(
        (int)row["id"],
        (int)row["questionCount"],
        ((string)row["open"]).Equals("1"),
        (string)row["accessCode"]);
        
      exam.Categories = CategoryDB.Instance.GetByExam(exam);

      return exam;
    }

    public bool Add(Exam t)
    {
      string sql = string.Format("INSERT [Exam] (questionCount, [open], accessCode) VALUES({0}, '{1}', '{2}')",
        t.QuestionCount,
        t.Open ? 1 : 0,
        t.AccessCode);

      bool ret = ConnectionDB.Instance.ExecuteNonQuery(sql) > 0;

      if (!ret)
        return false;

      sql = "SELECT MAX(id) from [Exam]";
      var dataTable = ConnectionDB.Instance.ExecuteQuery(sql);

      foreach (DataRow row in dataTable.Rows)
      {
        t.Id = (int)row[0];
      }

      return SetCategories(t);
    }

    private bool SetCategories(Exam t)
    {
      string sql = string.Format("DELETE [CategoryExam] where id_exam = {0}", t.Id);
      ConnectionDB.Instance.ExecuteNonQuery(sql);

      foreach (var category in t.Categories)
      {
        sql = string.Format("INSERT [CategoryExam] (id_exam, id_category) VALUES({0}, {1})",
          t.Id,
          category.Id);

        ConnectionDB.Instance.ExecuteNonQuery(sql);
      }

      return true;
    }

    public bool Update(Exam t)
    {
      string sql = string.Format("UPDATE [Exam] SET questionCount = {0}, [open] = '{1}', accessCode = '{2}' WHERE id = {3}",
            t.QuestionCount,
            t.Open ? 1 : 0,
            t.AccessCode,
            t.Id);

      bool ret = ConnectionDB.Instance.ExecuteNonQuery(sql) > 0;

      if (!ret)
        return false;

      return this.SetCategories(t);
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