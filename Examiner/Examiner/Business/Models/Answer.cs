namespace Examiner.Business.Models
{
  public class Answer : BaseModel
  {
    public Answer(int id, StudentExam studentExam, int alternative) : base(id)
    {
      this.StudentExam = studentExam;
      this.Alternative = alternative;
    }

    public StudentExam StudentExam { get; set; }

    public int Alternative { get; set; }

    public override string ToString()
    {
      return "Answer{Id=" + this.Id + ", StudentExam=" + this.StudentExam + ", Alternative=" + this.Alternative + '}';
    }
  }
}