namespace Examiner.Business.Models
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using System.Threading.Tasks;

  public class Question : BaseModel
  {
    private List<Category> categories;
    private List<Alternative> alternatives;
    private List<Answer> answers;

    public Question(int id, string questionContent, string feedbackContent, Alternative rightAlternative)
      : base(id)
    {
      this.QuestionContent = questionContent;
      this.FeedbackContent = feedbackContent;
      this.RightAlternative = rightAlternative;
    }

    public string QuestionContent { get; set; }

    public string FeedbackContent { get; set; }

    public Alternative RightAlternative { get; set; } 

    public List<Category> Categories
    {
      get
      {
        this.categories = this.categories ?? new List<Category>();
        return this.categories;
      }
    }

    public List<Alternative> Alternatives
    {
      get
      {
        this.alternatives = this.alternatives ?? new List<Alternative>();
        return this.alternatives;
      }
    }

    public List<Answer> Answers
    {
      get
      {
        this.answers = this.answers ?? new List<Answer>();
        return this.answers;
      }
    }

    public void AddCategory(Category category)
    {
      if (!this.Categories.Contains(category))
      {
        this.Categories.Add(category);
      }
    }

    public void AddAlternative(Alternative alternative)
    {
      if (!this.Alternatives.Contains(alternative))
      {
        this.Alternatives.Add(alternative);
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
      return "Question{Id=" + this.Id + ", QuestionContent=" + this.QuestionContent + ", FeedbackContent=" + this.FeedbackContent + ", RightAlternative=" + this.RightAlternative + ", Categories=" + this.Categories + ", Alternatives=" + this.Alternatives + ", Answers=" + this.Answers + '}';
    }
  }
}