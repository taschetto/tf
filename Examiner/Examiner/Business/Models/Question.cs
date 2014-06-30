﻿namespace Examiner.Business.Models
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using System.Threading.Tasks;

  public class Question : BaseModel
  {
    private List<Category> _categories;
    private List<Alternative> _alternatives;
    private List<Answer> _answers;

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
        this._categories = this._categories ?? new List<Category>();
        return this._categories;
      }
    }

    public List<Alternative> Alternatives
    {
      get
      {
        this._alternatives = this._alternatives ?? new List<Alternative>();
        return this._alternatives;
      }
    }

    public List<Answer> Answers
    {
      get
      {
        this._answers = this._answers ?? new List<Answer>();
        return this._answers;
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