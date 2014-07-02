namespace Examiner.Presentation.ViewModels
{
  using Examiner.Business.Models;
  using Examiner.Presentation.Views;
  using System.Windows;

  public class CategoryListViewModel : ListViewModel<Category>
  {
    public CategoryListViewModel()
    {
      this.DisplayName = "Categories";
    }

    protected override Window InsertWindow
    {
      get { return new CategoryWindow(); }
    }

    protected override Window UpdateWindow
    {
      get { return new CategoryWindow(this.Selected); }
    }
  }
}