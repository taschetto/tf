namespace Examiner.Business.Models
{
  using System.Collections.Generic;
  public class StudentExam : BaseModel
  {
    private List<Answer> _answers;

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
        this._answers = this._answers ?? new List<Answer>();
        return this._answers;
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
      return "StudentExam{Id=" + this.Id + ", Student=" + this.Student + ", Exam=" + this.Exam + ", Answers=" + this.Answers.Count + '}';
    }
  }
}
