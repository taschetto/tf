namespace Examiner.Presentation.ViewModels
{
  using System.Collections.ObjectModel;
  using Examiner.Business;
  using Examiner.Business.Models;
  using GalaSoft.MvvmLight.Command;
  using System.Windows.Input;
  using Examiner.Presentation.Views;

  public class QuestionListViewModel : ViewModelBase
  {
    public QuestionListViewModel()
      : base(@"Questions")
    {
      this.Questions = new ObservableCollection<Question>();
      this.RefreshList();
    }

    private void RefreshList()
    {
      this.Questions.Clear();
      foreach (Question question in ExaminerFacade.Instance.GetAll<Question>())
      {
        this.Questions.Add(question);
      }
    }

    public ObservableCollection<Question> Questions { get; private set; }

    public ICommand Insert
    {
      get
      {
        return new RelayCommand(() =>
        {
          var w = new QuestionWindow();
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
          var w = new QuestionWindow(this.SelectedQuestion);
          w.ShowDialog();
          this.RefreshList();
        }, () => { return this.SelectedQuestion != null; });
      }
    }

    public ICommand Delete
    {
      get
      {
        return new RelayCommand(() =>
        {
          ExaminerFacade.Instance.Delete(this.SelectedQuestion);
          this.RefreshList();
        }, () => { return this.SelectedQuestion != null; });
      }
    }

    public Question SelectedQuestion { get; set; }
  }
}