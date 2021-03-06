﻿namespace Examiner.Business.Models
{
  using System.Collections.Generic;

  public class Student : BaseModel
  {
    private List<StudentExam> studentExams;

    public Student(int id, int registration, string password, string name, string email) : base(id)
    {
      this.Registration = registration;
      this.Password = password;
      this.Name = name;
      this.Email = email;
    }

    public int Registration { get; set; }

    public string Password { get; set; }

    public string Name { get; set; }

    public string Email { get; set; }

    public List<StudentExam> StudentExams 
    { 
      get
      {
        this.studentExams = this.studentExams ?? new List<StudentExam>();
        return this.studentExams;
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
      return "Student{Id=" + this.Id + ", Registration=" + this.Registration + ", Password=" + this.Password + ", Name=" + this.Name + ", Email=" + this.Email + ", StudentExams=" + this.StudentExams.Count + '}';
    }
  }
}