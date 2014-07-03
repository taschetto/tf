using Examiner.Business.Models;
using System.Collections.Generic;

namespace Examiner.Business.DAOs
{
  public interface IQuestionDao : IBaseDao<Question>
  {
    List<Question> GetByCategory(Category category);
  }
}
