namespace Examiner.Presentation.ViewModels
{
  using System.Collections.ObjectModel;
  using Examiner.Business;
  using Examiner.Business.Models;
  using System.Windows.Input;
  using GalaSoft.MvvmLight.Command;
  using Examiner.Presentation.Views;

  public class ExamListViewModel : ViewModelBase
  {
    public ExamListViewModel() : base(@"Exams")
    {
      this.Exams = new ObservableCollection<Exam>();
      this.RefreshList();
    }

    private void RefreshList()
    {
      this.Exams.Clear();
      foreach (Exam exam in ExaminerFacade.Instance.GetAll<Exam>())
      {
        this.Exams.Add(exam);
      }
    }

    public ObservableCollection<Exam> Exams { get; private set; }

    public ICommand Insert
    {
      get
      {
        return new RelayCommand(() =>
        {
          var w = new ExamWindow();
          w.ShowDialog();
          this.RefreshList();
        });
      }
    }

    public ICommand Update
    {
      get
      {
        return new RelayCommand(() =>
        {
          var w = new ExamWindow(this.SelectedExam);
          w.ShowDialog();
          this.RefreshList();
        }, () => { return this.SelectedExam != null; });
      }
    }

    public ICommand Delete
    {
      get
      {
        return new RelayCommand(() =>
        {
          ExaminerFacade.Instance.Delete(this.SelectedExam);
          this.RefreshList();
        }, () => { return this.SelectedExam != null; });
      }
    }

    public Exam SelectedExam { get; set; }
  }
}
