namespace Examiner.Presentation.ViewModels
{
  using Examiner.Business.Models;

  public class StudentViewModel : ModelViewModel<Student>
  {
    private string name;
    private int registration;
    private string email;
    private string password;

    public StudentViewModel(Student student = null)
    {
      this.IsUpdate = student != null;

      if (student != null)
      {
        this.Id = student.Id;
        this.Name = student.Name;
        this.Email = student.Email;
        this.Password = student.Password;
      }
    }

    public string Name
    {
      get
      {
        return this.name;
      }

      set
      {
        Set<string>("Name", ref this.name, value);
      }
    }

    public int Registration
    {
      get
      {
        return this.registration;
      }

      set
      {
        Set<int>("Registration", ref this.registration, value);
      }
    }

    public string Email
    {
      get
      {
        return this.email;
      }

      set
      {
        Set<string>("Email", ref this.email, value);
      }
    }

    public string Password
    {
      get
      {
        return this.password;
      }

      set
      {
        Set<string>("Password", ref this.password, value);
      }
    }

    public override Student Model
    {
      get
      {
        return new Student(this.Id, this.Registration, this.Password, this.Name, this.Email);
      }
    }
  }
}
