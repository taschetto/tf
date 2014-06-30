using System.Collections.Generic;

namespace Examiner.Business.DAOs
{
    public interface IBaseDao<T>
  {
    void Add(T t);

    void Update(T t);

    void Delete(T t);

    List<T> GetAll();

    T GetById(int id);
  }
}
