namespace Examiner.Persistence
{
  using System;
  using Examiner.Business.Models;
  using Examiner.Business.DAOs;

  public class AlternativeDB : IAlternativeDao
  {
    private static AlternativeDB instance = null;

    public static AlternativeDB Instance
    {
      get
      {
        if (instance == null)
        {
          instance = new AlternativeDB();
        }

        return instance;
      }
    }

    public void Add(Alternative t)
    {
      throw new NotImplementedException();
    }

    public void Update(Alternative t)
    {
      throw new NotImplementedException();
    }

    public void Delete(Alternative t)
    {
      throw new NotImplementedException();
    }

    public System.Collections.Generic.List<Alternative> GetAll()
    {
      throw new NotImplementedException();
    }

    public Alternative GetById(int id)
    {
      throw new NotImplementedException();
    }
  }
}
