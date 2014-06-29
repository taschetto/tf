namespace Examiner.Business.Models
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using System.Threading.Tasks;

  public class Exam : BaseModel
  {
    private List<Category> categories;
    private List<StudentExam> studentExams;

    public Exam(int id, int questionCount, bool open, string accessCode)
      : base(id)
    {
      this.QuestionCount = questionCount;
      this.Open = open;
      this.AccessCode = accessCode;
    }

    public int QuestionCount { get; set; }

    public bool Open { get; set; }

    public string AccessCode { get; set; }

    public List<Category> Categories
    {
      get
      {
        if (this.categories == null)
        {
          this.categories = new List<Category>();
        }

        return this.categories;
      }
    }

    public List<StudentExam> StudentExams
    {
      get
      {
        if (this.studentExams == null)
        {
          this.studentExams = new List<StudentExam>();
        }

        return this.studentExams;
      }
    }

    public void AddCategory(Category category)
    {
      if (!this.Categories.Contains(category))
      {
        this.Categories.Add(category);
      }
    }

    public void AddStudentExam(StudentExam studentExam)
    {
      if (!this.StudentExams.Contains(studentExam))
      {
        this.StudentExams.Add(studentExam);
      }
    }

    public override string ToString()
    {
      return "Exam{Id=" + this.Id + ", QuestionCount=" + this.QuestionCount + ", Open=" + this.Open + ", AccessCode=" + this.AccessCode + ", Categories=" + this.Categories + ", StudentExams=" + this.StudentExams + '}';
    }
  }
}
