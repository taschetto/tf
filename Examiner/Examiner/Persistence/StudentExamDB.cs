namespace Examiner.Persistence
{
  using System;
  using System.Collections.Generic;
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
    public void Add(StudentExam t)
    {
      throw new NotImplementedException();
    }

    public void Update(StudentExam t)
    {
      throw new NotImplementedException();
    }

    public void Delete(StudentExam t)
    {
      throw new NotImplementedException();
    }

    public List<StudentExam> GetAll()
    {
      throw new NotImplementedException();
    }

    public StudentExam GetById(int id)
    {
      throw new NotImplementedException();
    }
  }
}
