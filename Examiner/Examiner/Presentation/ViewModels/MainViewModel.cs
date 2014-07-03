namespace Examiner.Presentation.ViewModels
{
  using Examiner.Presentation.Views;
  using GalaSoft.MvvmLight;
  using GalaSoft.MvvmLight.Command;
  using System;
  using System.Windows.Input;

  public class MainViewModel : ViewModelBase
  {
    private RelayCommand openProfessor;
    private RelayCommand newExam;
    private RelayCommand exams;
    private RelayCommand about;

    public MainViewModel()
    {
    }

    public ICommand OpenProfessor 
    { 
      get
      {
        return this.openProfessor ?? (this.openProfessor = new RelayCommand(() =>
        {
          var w = new ProfessorWindow();
          w.ShowDialog();
        }));
      }
    }

    public ICommand NewExam
    {
      get
      {
        return this.newExam ?? (this.newExam = new RelayCommand(() =>
        {
          var w = new NewExamWindow();
          w.ShowDialog();
        }));
      }
    }

    public ICommand Exams
    {
      get
      {
        return this.exams ?? (this.exams = new RelayCommand(() =>
        {
          var w = new StudentExamListWindow();
          w.ShowDialog();
        }));
      }
    }

    public ICommand About
    {
      get
      {
        return this.about ?? (this.about = new RelayCommand(() =>
        {
          var w = new AboutWindow();
          w.ShowDialog();
        }));
      }
    }
  }
}