namespace Examiner.Presentation.ViewModels
{
  using Examiner.Business;
  using Examiner.Business.Models;
  using Examiner.Presentation.Views;
  using GalaSoft.MvvmLight.Command;
  using System.Collections.ObjectModel;
  using System.Windows.Input;

  public class CategoryListViewModel : ViewModelBase
  {
    public CategoryListViewModel()
      : base(@"Categories")
    {
      this.Categories = new ObservableCollection<Category>();
      this.RefreshList();
    }

    private void RefreshList()
    {
      this.Categories.Clear();
      foreach (Category category in ExaminerFacade.Instance.GetAll<Category>())
      {
        this.Categories.Add(category);
      }
    }

    public ObservableCollection<Category> Categories { get; private set; }

    public ICommand Create
    {
      get
      {
        return new RelayCommand(() =>
        {
          var w = new CategoryWindow();
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
          var w = new CategoryWindow(this.SelectedCategory);
          w.ShowDialog();
          this.RefreshList();
        }, () => { return this.SelectedCategory != null; });
      }
    }

    public ICommand Delete
    {
      get
      {
        return new RelayCommand(() =>
        {
          ExaminerFacade.Instance.Delete(this.SelectedCategory);
          this.RefreshList();
        }, () => { return this.SelectedCategory != null; });
      }
    }

    public Category SelectedCategory { get; set; }
  }
}