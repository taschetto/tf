namespace Examiner.Presentation.ViewModels
{
  using Examiner.Business;
  using Examiner.Business.Models;
  using GalaSoft.MvvmLight;
  using GalaSoft.MvvmLight.Command;
  using System.Windows;
  using System.Windows.Input;

  public abstract class ModelViewModel<T> : ViewModelBase
    where T : BaseModel
  {
    private int id;

    private bool isUpdate;

    public abstract T Model { get; }

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

    public ICommand Save
    {
      get
      {
        return new RelayCommand<Window>((w) =>
        {
          if (this.IsUpdate)
            ExaminerFacade.Instance.Update(this.Model);
          else
            ExaminerFacade.Instance.Add(this.Model);

          w.Close();
        });
      }
    }
  }
}
