namespace Examiner.Presentation.ViewModels
{
  using Examiner.Business;
  using Examiner.Business.Models;
  using GalaSoft.MvvmLight;
  using GalaSoft.MvvmLight.Command;
  using System.Collections.ObjectModel;
  using System.Windows;
  using System.Windows.Input;

  public abstract class ListViewModel<T> : ViewModelBase
    where T : BaseModel
  {
    public string DisplayName { get; set; }


    private ObservableCollection<T> models;

    public ListViewModel()
    {
      this.RefreshList();
    }
    
    public ObservableCollection<T> Models
    {
      get
      {
        if (this.models == null)
          this.models = new ObservableCollection<T>();

        return this.models;
      }
    }

    protected void RefreshList()
    {
      this.Models.Clear();
      foreach (T t in ExaminerFacade.Instance.GetAll<T>())
      {
        this.Models.Add(t);
      }
    }

    protected abstract Window InsertWindow { get; }

    protected abstract Window UpdateWindow { get; }

    public ICommand Insert
    {
      get
      {
        return new RelayCommand(() =>
        {
          this.InsertWindow.ShowDialog();
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
          this.UpdateWindow.ShowDialog();
          this.RefreshList();
        }, () => { return this.Selected != null; });
      }
    }

    public ICommand Delete
    {
      get
      {
        return new RelayCommand(() =>
        {
          ExaminerFacade.Instance.Delete(this.Selected);
          this.RefreshList();
        }, () => { return this.Selected != null; });
      }
    }

    public T Selected { get; set; }
  }
}
