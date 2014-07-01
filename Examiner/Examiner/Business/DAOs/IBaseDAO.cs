using System.Collections.Generic;

namespace Examiner.Business.DAOs
{
    public interface IBaseDao<T>
  {
    bool Add(T t);

    bool Update(T t);

    bool Delete(T t);

    List<T> GetAll();

    T GetById(int id);
  }
}
