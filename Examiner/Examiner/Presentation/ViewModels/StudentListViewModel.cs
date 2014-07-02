namespace Examiner.Presentation.ViewModels
{
  using Examiner.Business.Models;
  using Examiner.Presentation.Views;

  public class StudentListViewModel : ListViewModel<Student>
  {

    public StudentListViewModel()
    {
      this.DisplayName = "Students";
    }

    protected override System.Windows.Window InsertWindow
    {
      get { return new StudentWindow(); }
    }

    protected override System.Windows.Window UpdateWindow
    {
      get { return new StudentWindow(this.Selected); }
    }
  }
}