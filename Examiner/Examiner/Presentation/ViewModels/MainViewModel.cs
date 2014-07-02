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
    private RelayCommand openStudent;
    private RelayCommand openAdmin;

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

    public ICommand OpenStudent
    {
      get
      {
        return this.openStudent ?? (this.openStudent = new RelayCommand(() =>
        {
          throw new NotImplementedException();
        }));
      }
    }

    public ICommand OpenAdmin
    {
      get
      {
        return this.openAdmin ?? (this.openAdmin = new RelayCommand(() =>
        {
          throw new NotImplementedException();
        }));
      }
    }
  }
}