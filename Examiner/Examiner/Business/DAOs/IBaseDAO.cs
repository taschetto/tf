﻿namespace Examiner.Business
{
  using System.Collections.Generic;

  public interface IBaseDao<T>
  {
    void Add(T t);

    void Update(T t);

    void Delete(T t);

    List<T> GetAll();

    T GetById(int id);
  }
}