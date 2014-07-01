namespace Examiner.Business.Models
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using System.Threading.Tasks;

  public class Category : BaseModel
  {
    private List<Exam> _exams;
    private List<Question> _questions;

    public Category(int id, string name, string description)
      : base(id)
    {
      this.Name = name;
      this.Description = description;
    }

    public string Name { get; set; }

    public string Description { get; set; }

    public List<Exam> Exams
    { 
      get
      {
        this._exams = this._exams ?? new List<Exam>();
        return this._exams;
      }
    }

    public List<Question> Questions 
    { 
      get
      {
        this._questions = this._questions ?? new List<Question>();
        return this._questions;
      }
    }

    public void AddExam(Exam exam)
    {
      if (!this.Exams.Contains(exam))
      {
        this.Exams.Add(exam);
      }
    }

    public void AddQuestion(Question question)
    {
      if (!this.Questions.Contains(question))
      {
        this.Questions.Add(question);
      }
    }

    public override string ToString()
    {
      return "Category{Id" + this.Id + ", Name=" + this.Name + ", Description=" + this.Description + ", Exams=" + this.Exams.Count + ", Questions=" + this.Questions.Count + '}';
    }
  }
}
