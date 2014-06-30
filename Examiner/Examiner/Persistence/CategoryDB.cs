namespace Examiner.Persistence
{
  using System;
  using System.Collections.Generic;
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

    public void Add(Category t)
    {
      throw new NotImplementedException();
    }

    public void Update(Category t)
    {
      throw new NotImplementedException();
    }

    public void Delete(Category t)
    {
      throw new NotImplementedException();
    }

    public List<Category> GetAll()
    {
      throw new NotImplementedException();
    }

    public Category GetById(int id)
    {
      throw new NotImplementedException();
    }
  }
}