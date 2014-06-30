namespace Examiner.Business.Models
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using System.Threading.Tasks;

  public class Student : BaseModel
  {
    private List<StudentExam> _studentExams;

    public Student(int id, string registration, string password, string name, string email) : base(id)
    {
      this.Registration = registration;
      this.Password = password;
      this.Name = name;
      this.Email = email;
    }

    public string Registration { get; private set; }

    public string Password { get; set; }

    public string Name { get; set; }

    public string Email { get; set; }

    public List<StudentExam> StudentExams 
    { 
      get
      {
        this._studentExams = this._studentExams ?? new List<StudentExam>();
        return this._studentExams;
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
      return "Student{Id=" + this.Id + ", Registration=" + this.Registration + ", Password=" + this.Password + ", Name=" + this.Name + ", Email=" + this.Email + ", StudentExams=" + this.StudentExams + '}';
    }
  }
}