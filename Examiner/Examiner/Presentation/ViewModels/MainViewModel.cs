namespace Examiner.Presentation.ViewModels
{
  using Examiner.Presentation.Views;
  using GalaSoft.MvvmLight;
  using GalaSoft.MvvmLight.Command;
  using System;
  using System.Windows.Input;

  public class MainViewModel : ViewModelBase
  {
    public MainViewModel()
    {
    }

    public ICommand OpenProfessor 
    { 
      get
      {
        return new RelayCommand(() =>
        {
          var w = new ProfessorWindow();
          w.ShowDialog();
        });
      }
    }

    public ICommand NewExam
    {
      get
      {
        return new RelayCommand(() =>
        {
          var w = new NewExamWindow();
          w.ShowDialog();
        });
      }
    }

    public ICommand Exams
    {
      get
      {
        return new RelayCommand(() =>
        {
          var w = new StudentExamListWindow();
          w.ShowDialog();
        });
      }
    }

    public ICommand About
    {
      get
      {
        return new RelayCommand(() =>
        {
          var w = new AboutWindow();
          w.ShowDialog();
        });
      }
    }
  }
}