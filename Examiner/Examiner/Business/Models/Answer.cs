namespace Examiner.Business.Models
{
  public class Answer : BaseModel
  {
    public Answer(int id, StudentExam studentExam, Question question, int alternative) : base(id)
    {
      this.StudentExam = studentExam;
      this.Question = question;
      this.Alternative = alternative;
    }

    public StudentExam StudentExam { get; set; }

    public Question Question { get; private set; }

    public int Alternative { get; set; }

    public override string ToString()
    {
      return "Answer{Id=" + this.Id + ", StudentExam=" + this.StudentExam + ", Alternative=" + this.Alternative + '}';
    }
  }
}