﻿namespace Examiner.Persistence
{
  using System;
  using System.Collections.Generic;
  using System.Data;
  using Examiner.Business.DAOs;
  using Examiner.Business.Models;

  public class StudentExamDB : IStudentExamDao
  {
    private static StudentExamDB instance = null;

    public static StudentExamDB Instance
    {
      get
      {
        if (instance == null)
        {
          instance = new StudentExamDB();
        }
        return instance;
      }
    }

    private StudentExam ToStudentExam(DataRow row)
    {
      Student student = StudentDB.Instance.GetById((int)row["id_student"]);
      Exam exam = ExamDB.Instance.GetById((int)row["id_exam"]);
      StudentExam studentExam = new StudentExam(
        (int)row["id"],
        student,
        exam);

      studentExam.Answers = AnswerDB.Instance.GetByStudentExam(studentExam);

      return studentExam;
    }

    public bool Add(StudentExam t)
    {
      string sql = string.Format("INSERT [StudentExam] (id_student, id_exam) VALUES({0}, {1})",
        t.Student.Id,
        t.Exam.Id);

      bool ret = ConnectionDB.Instance.ExecuteNonQuery(sql) > 0;

      if (!ret)
        return false;

      sql = "SELECT MAX(id) from [StudentExam]";
      var dataTable = ConnectionDB.Instance.ExecuteQuery(sql);

      foreach (DataRow row in dataTable.Rows)
      {
        t.Id = (int)row[0];
      }

      return SetAnswers(t);
    }

    private bool SetAnswers(StudentExam t)
    {
      foreach (var answer in t.Answers)
      {
        AnswerDB.Instance.Add(answer);
      }

      return true;
    }

    public bool Update(StudentExam t)
    {
      // Não é possível dar update em um StudentExam pois ele só possui chaves para relacionamento!
      throw new NotSupportedException();
    }

    public bool Delete(StudentExam t)
    {
      string sql = string.Format("DELETE FROM [StudentExam] WHERE id = {0}", t.Id);

      return ConnectionDB.Instance.ExecuteNonQuery(sql) > 0;
    }

    public List<StudentExam> GetAll()
    {
      var studentExams = new List<StudentExam>();
      string sql = "select * from [StudentExam]";
      var dataTable = ConnectionDB.Instance.ExecuteQuery(sql);

      foreach (DataRow row in dataTable.Rows)
      {
        studentExams.Add(ToStudentExam(row));
      }

      return studentExams;
    }

    public StudentExam GetById(int id)
    {
      string sql = string.Format("SELECT * FROM [StudentExam] WHERE id = {0}", id);
      var dataTable = ConnectionDB.Instance.ExecuteQuery(sql);

      foreach (DataRow row in dataTable.Rows)
      {
        return ToStudentExam(row);
      }

      return null;
    }
  }
}
