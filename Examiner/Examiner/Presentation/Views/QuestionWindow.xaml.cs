namespace Examiner.Presentation.Views
{
  using Examiner.Business.Models;
  using Examiner.Presentation.ViewModels;
  using System.Windows;

  public partial class QuestionWindow : Window
  {
    public QuestionWindow(Question question = null)
    {
      this.InitializeComponent();
      this.DataContext = new QuestionViewModel(question);
    }
  }
}
