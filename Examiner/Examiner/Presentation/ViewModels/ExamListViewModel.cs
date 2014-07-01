namespace Examiner.Presentation.ViewModels
{
  using System.Collections.ObjectModel;
  using Examiner.Business;
  using Examiner.Business.Models;

  public class ExamListViewModel : ViewModelBase
  {
    public ExamListViewModel() : base(@"Exams")
    {
      this.Exams = new ObservableCollection<Exam>();

      foreach (Exam exam in ExaminerFacade.Instance.GetAll<Exam>())
      {
        this.Exams.Add(exam);
      }
    }

    public ObservableCollection<Exam> Exams { get; private set; }
  }
}
