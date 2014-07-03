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
    private int studentId;

    public NewExamViewModel(NewExamMainViewModel mainViewModel)
    {
      this.mainViewModel = mainViewModel;
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

    public ICommand BeginExam
    {
      get
      {
        return new RelayCommand(() =>
        {
          var student = ExaminerFacade.Instance.GetById<Student>(this.StudentId);
          var exam = ExaminerFacade.Instance.GetById<Exam>(this.ExamId);

          if (student != null && exam != null)
          {
            this.mainViewModel.BeginExam(student, exam);
          }
        });
      }
    }
  }
}
