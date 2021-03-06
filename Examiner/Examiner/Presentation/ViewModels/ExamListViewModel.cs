﻿namespace Examiner.Presentation.ViewModels
{
  using Examiner.Business.Models;
  using Examiner.Presentation.Views;

  public class ExamListViewModel : ListViewModel<Exam>
  {

    public ExamListViewModel()
    {
      this.DisplayName = "Exams";
    }

    protected override System.Windows.Window InsertWindow
    {
      get { return new ExamWindow(); }
    }

    protected override System.Windows.Window UpdateWindow
    {
      get { return new ExamWindow(this.Selected); }
    }
  }
}
