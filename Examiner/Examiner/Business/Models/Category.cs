namespace Examiner.Business.Models
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using System.Threading.Tasks;

  public class Category : BaseModel
  {
    private List<Exam> exams;
    private List<Question> questions;

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
        this.exams = this.exams ?? new List<Exam>();
        return this.exams;
      }
    }

    public List<Question> Questions 
    { 
      get
      {
        this.questions = this.questions ?? new List<Question>();
        return this.questions;
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
      return "Category{Id" + this.Id + ", Name=" + this.Name + ", Description=" + this.Description + ", Exams=" + this.Exams + ", Questions=" + this.Questions + '}';
    }
  }
}
