namespace Examiner.Presentation.ViewModels
{
  using Examiner.Business;
  using Examiner.Business.Models;
  using GalaSoft.MvvmLight;
  using GalaSoft.MvvmLight.Command;
  using System.Windows.Input;

  public class NewExamViewModel : ViewModelBase
  {
    private NewExamMainViewModel mainViewModel;
    private int examId;
    private string questionCount;
    private int studentId;
    private string studentName;
    private bool isClosed;
    private string accessCode;

    public NewExamViewModel(NewExamMainViewModel mainViewModel)
    {
      this.mainViewModel = mainViewModel;
      this.ExamId = 0;
      this.StudentId = 0;
      this.IsClosed = true;
      this.AccessCode = "";
    }

    public int ExamId
    {
      get
      {
        return this.examId;
      }
      set
      {
        Set<int>("ExamId", ref this.examId, value);
      }
    }

    public int StudentId
    {
      get
      {
        return this.studentId;
      }
      set
      {
        Set<int>("StudentId", ref this.studentId, value);
      }
    }

    public string StudentName
    {
      get
      {
        return this.studentName;
      }
      set
      {
        Set<string>("StudentName", ref this.studentName, value);
      }
    }

    public string QuestionCount
    {
      get
      {
        return this.questionCount;
      }
      set
      {
        Set<string>("QuestionCount", ref this.questionCount, value);
      }
    }

    public bool IsClosed {
      get
      {
        return this.isClosed;
      }
      set
      {
        Set<bool>("IsClosed", ref this.isClosed, value);
      }
    }

    public string AccessCode
    {
      get
      {
        return this.accessCode;
      }
      set
      {
        Set<string>("AccessCode", ref this.accessCode, value);
      }
    }

    public ICommand BeginExam
    {
      get
      {
        return new RelayCommand(() =>
        {
          var student = ExaminerFacade.Instance.GetById<Student>(this.StudentId);
          var exam = ExaminerFacade.Instance.GetById<Exam>(this.ExamId);

          if (student != null && exam != null)
            this.mainViewModel.BeginExam(student, exam);
        },
        () =>
        {
          var student = ExaminerFacade.Instance.GetById<Student>(this.StudentId);
          this.StudentName = student != null ? student.Name : "<Student Not Found>";

          var exam = ExaminerFacade.Instance.GetById<Exam>(this.ExamId);
          if (exam != null)
          {
            this.QuestionCount = exam.QuestionCount.ToString() + " questions, " + (exam.Open ? "Open" : "Closed");
            this.IsClosed = !exam.Open;
          }
          else
          {
            this.QuestionCount = "<Exam Not Found>";
            this.IsClosed = true;
            this.AccessCode = "";
          }

          return student != null && 
                 exam != null &&
                 (!this.IsClosed || (this.IsClosed && this.AccessCode == exam.AccessCode));
        });
      }
    }
  }
}
