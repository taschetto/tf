namespace Examiner.Presentation.ViewModels
{
  using Examiner.Business.Models;
  using Examiner.Presentation.Views;
  using System.Windows;

  public class QuestionListViewModel : ListViewModel<Question>
  {
    public QuestionListViewModel()
    {
      this.DisplayName = "Questions";
    }

    protected override Window InsertWindow
    {
      get { return new QuestionWindow(); }
    }

    protected override Window UpdateWindow
    {
      get { return new QuestionWindow(this.Selected); }
    }
  }
}