namespace Examiner.Business.Models
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using System.Threading.Tasks;

  public class Alternative : BaseModel
  {
    private List<Answer> answers;

    public Alternative(int id, string answerContent, Question question) : base(id)
    {
      this.AnswerContent = answerContent;
      this.Question = question;
    }

    public string AnswerContent { get; set; }

    public Question Question { get; private set; }

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
      return "Alternative{Id=" + this.Id + ", AnswerContent=" + this.AnswerContent + ", Question=" + this.Question + ", Answers=" + this.Answers + '}';
    }
  }
}
