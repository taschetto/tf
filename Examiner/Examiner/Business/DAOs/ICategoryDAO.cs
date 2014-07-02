using Examiner.Business.Models;
using System.Collections.Generic;

namespace Examiner.Business.DAOs
{
  public interface ICategoryDao : IBaseDao<Category>
  {
    List<Category> GetByExam(Exam exam);
    List<Category> GetByQuestion(Question question);
  }
}
