namespace Examiner.Presentation.ViewModels
{
  using System;
  using Examiner.Business.Models;
  using Examiner.Presentation.Views;

  public class StudentExamListViewModel : ListViewModel<StudentExam>
  {
    protected override System.Windows.Window InsertWindow
    {
      get { return this.UpdateWindow; }
    }

    protected override System.Windows.Window UpdateWindow
    {
      get { return new StudentExamWindow(this.Selected); }
    }
  }
}
