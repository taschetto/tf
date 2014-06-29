namespace Examiner.Business.Models
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using System.Threading.Tasks;

  public class Answer : BaseModel
  {
    public Answer(int id, StudentExam studentExam, Alternative alternative) : base(id)
    {
      this.StudentExam = studentExam;
      this.Alternative = alternative;
    }

    public StudentExam StudentExam { get; set; }

    public Alternative Alternative { get; set; }

    public override string ToString()
    {
      return "Answer{Id=" + this.Id + ", StudentExam=" + this.StudentExam + ", Alternative=" + this.Alternative + '}';
    }
  }
}