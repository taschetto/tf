namespace Examiner.Business.Models
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using System.Threading.Tasks;
  public class StudentExam : BaseModel
  {
    private List<Answer> answers;

    public StudentExam(int id, Student student, Exam exam) : base(id)
    {
      this.Student = student;
      this.Exam = exam;
    }

    public Student Student { get; set; }

    public Exam Exam { get; set; }

    public List<Answer> Answers
    {
      get
      {
        this.answers = this.answers ?? new List<Answer>();
        return this.answers;
      }
    }

    public void AddAnswer(Answer answer)
    {
      if (!this.Answers.Contains(answer))
      {
        this.Answers.Add(answer);
      }
    }

    public override string ToString()
    {
      return "StudentExam{Id=" + this.Id + ", Student=" + this.Student + ", Exam=" + this.Exam + ", Answers=" + this.Answers + '}';
    }
  }
}
