namespace Examiner.Presentation.ViewModels
{
  using Examiner.Business;
  using Examiner.Business.Models;
  using GalaSoft.MvvmLight.Command;
  using System.Windows;
  using System.Windows.Input;

  public class CategoryViewModel : ViewModelBase
  {
    private int id;
    private string name;
    private string description;
    private bool isUpdate = false;

    public CategoryViewModel(Category category = null)
    {
      this.IsUpdate = false;

      if (category != null)
      {
        this.id = category.Id;
        this.name = category.Name;
        this.description = category.Description;
        this.IsUpdate = true;
      }
    }

    public bool IsUpdate
    {
      get
      {
        return this.isUpdate;
      }

      set
      {
        Set<bool>("IsUpdate", ref this.isUpdate, value);
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

          if (this.IsUpdate)
            ExaminerFacade.Instance.Update(category);
          else
            ExaminerFacade.Instance.Add(category);

          w.Close();
        });
      }
    }
  }
}