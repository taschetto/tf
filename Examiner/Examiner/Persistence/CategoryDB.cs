using System.Collections.Generic;

namespace Examiner.Persistence
{
  using Examiner.Business;

  public class CategoryDB : CategoryDAO
  {
    public void Add(Business.Models.Category t)
    {
      throw new System.NotImplementedException();
    }

    public void Update(Business.Models.Category t)
    {
      throw new System.NotImplementedException();
    }

    public void Delete(Business.Models.Category t)
    {
      throw new System.NotImplementedException();
    }

      public void Add(Category t)
      {
          throw new System.NotImplementedException();
      }

      public void Update(Category t)
      {
          throw new System.NotImplementedException();
      }

      public void Delete(Category t)
      {
          throw new System.NotImplementedException();
      }

      List<Category> BaseDAO<Category>.GetAll()
      {
          throw new System.NotImplementedException();
      }

      Category BaseDAO<Category>.GetById(int id)
      {
          throw new System.NotImplementedException();
      }

      public System.Collections.Generic.List<Business.Models.Category> GetAll()
    {
      throw new System.NotImplementedException();
    }

    public Business.Models.Category GetById(int id)
    {
      throw new System.NotImplementedException();
    }
  }
}