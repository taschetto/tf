namespace Examiner.Business.Models
{
  using System.Collections.Generic;

  public class Question : BaseModel
  {
    private List<Category> categories;
    private List<Answer> answers;

    public Question(int id, string questionContent, string feedbackContent, string[] alternatives, int rightAlternative)
      : base(id)
    {
      this.QuestionContent = questionContent;
      this.FeedbackContent = feedbackContent;
      this.Alternatives = alternatives;
      this.RightAlternative = rightAlternative;
    }

    public string QuestionContent { get; set; }

    public string FeedbackContent { get; set; }

    public string[] Alternatives { get; set; }

    public int RightAlternative { get; set; } 

    public List<Category> Categories
    {
      get
      {
        this.categories = this.categories ?? new List<Category>();
        return this.categories;
      }

      set
      {
        this.categories = value;
      }
    }

    public void AddCategory(Category category)
    {
      if (!this.Categories.Contains(category))
      {
        this.Categories.Add(category);
      }
    }

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
      return "Question{Id=" + this.Id + ", QuestionContent=" + this.QuestionContent + ", FeedbackContent=" + this.FeedbackContent + ", Alternatives=" + this.Alternatives + ", RightAlternative=" + this.RightAlternative + ", Categories=" + this.Categories.Count + ", Answers=" + this.Answers.Count + '}';
    }
  }
}