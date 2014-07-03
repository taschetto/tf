namespace Examiner.Business.Models
{
  using System.Collections.Generic;
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
      set
      {
        this.answers = value;
      }
    }

    public override string ToString()
    {
      return "StudentExam{Id=" + this.Id + ", Student=" + this.Student + ", Exam=" + this.Exam + ", Answers=" + this.Answers.Count + '}';
    }
  }
}
