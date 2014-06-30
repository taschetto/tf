using System;
using System.Collections.Generic;
using Examiner.Business.DAOs;
using Examiner.Business.Models;
namespace Examiner.Persistence
{
  

  public class CategoryDB : ICategoryDao
  {
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

      List<Category> IBaseDao<Category>.GetAll()
      {
          throw new NotImplementedException();
      }

      Category IBaseDao<Category>.GetById(int id)
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