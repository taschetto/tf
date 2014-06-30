namespace Examiner.Persistence
{
  using System;
  using System.Collections.Generic;
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

    public void Add(Exam t)
    {
      throw new NotImplementedException();
    }

    public void Update(Exam t)
    {
      throw new NotImplementedException();
    }

    public void Delete(Exam t)
    {
      throw new NotImplementedException();
    }

    public List<Exam> GetAll()
    {
      throw new NotImplementedException();
    }

    public Exam GetById(int id)
    {
      throw new NotImplementedException();
    }
  }
}