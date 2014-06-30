namespace Examiner.Presentation.ViewModels
{
  using System.Collections.ObjectModel;
  using Examiner.Business.Models;

  public class CategoryListViewModel : ViewModelBase
  {
    public CategoryListViewModel()
      : base(@"Categories")
    {
      this.Categories = new ObservableCollection<Category>();

      foreach (Category category in ExaminerFacade.Instance.GetAll<Category>())
      {
        this.Categories.Add(category);
      }
    }

    public ObservableCollection<Category> Categories { get; private set; }
  }
}