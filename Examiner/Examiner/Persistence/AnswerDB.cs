namespace Examiner.Persistence
{
  using System;
  using Examiner.Business.Models;
  using Examiner.Business.DAOs;

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

    public void Add(Answer t)
    {
      throw new NotImplementedException();
    }

    public void Update(Answer t)
    {
      throw new NotImplementedException();
    }

    public void Delete(Answer t)
    {
      throw new NotImplementedException();
    }

    public System.Collections.Generic.List<Answer> GetAll()
    {
      throw new NotImplementedException();
    }

    public Answer GetById(int id)
    {
      throw new NotImplementedException();
    }
  }
}
