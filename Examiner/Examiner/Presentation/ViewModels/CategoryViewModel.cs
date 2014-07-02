namespace Examiner.Presentation.ViewModels
{
  using Examiner.Business;
  using Examiner.Business.Models;
  using GalaSoft.MvvmLight.Command;
  using System.Windows;
  using System.Windows.Input;

  public class CategoryViewModel : ViewModelBase
  {
    private bool isNew = true;

    private int id;
    private string name;
    private string description;

    public CategoryViewModel(Category category = null)
    {
      if (category != null)
      {
        this.id = category.Id;
        this.name = category.Name;
        this.description = category.Description;
        this.isNew = false;
      }
    }

    public int Id
    {
      get
      {
        return this.id;
      }

      set
      {
        Set<int>("Id", ref this.id, value);
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

    public ICommand Save
    {
      get
      {
        return new RelayCommand<Window>((w) =>
        {
          Category category = new Category(this.Id, this.Name, this.Description);
          if (this.isNew)
            ExaminerFacade.Instance.Add(category);
          else
            ExaminerFacade.Instance.Update(category);

          w.Close();
        });
      }
    }
  }
}