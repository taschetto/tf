namespace Examiner.Presentation.ViewModels
{
  using Examiner.Business;
  using Examiner.Business.Models;
  using GalaSoft.MvvmLight.Command;
  using System.Windows;
  using System.Windows.Input;

  public class CategoryViewModel : ModelViewModel<Category>
  {
    private string name;
    private string description;

    public CategoryViewModel(Category category = null)
    {
      this.IsUpdate = category != null;

      if (category != null)
      {
        this.Id = category.Id;
        this.Name = category.Name;
        this.Description = category.Description;
      }
    }

    public string Name
    {
      get
      {
        return this.name;
      }

      set
      {
        Set<string>("Name", ref this.name, value);
      }
    }

    public string Description
    {
      get
      {
        return this.description;
      }

      set
      {
        Set<string>("Description", ref this.description, value);
      }
    }

    public override Category Model
    {
      get
      {
        return new Category(this.Id, this.Name, this.Description);
      }
    }
  }
}