namespace Examiner.Presentation.Views
{
  using Examiner.Business.Models;
using Examiner.Presentation.ViewModels;
using System.Windows;

  public partial class ExamWindow : Window
  {
    public ExamWindow(Exam exam = null)
    {
      this.InitializeComponent();
      this.DataContext = new ExamViewModel(exam);
    }
  }
}
