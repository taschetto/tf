namespace Examiner.Presentation.Views
{
  using System.Windows;
  using Examiner.Business.Models;
  using Examiner.Presentation.ViewModels;

  public partial class StudentExamWindow : Window
  {
    public StudentExamWindow(StudentExam studentExam)
    {
      this.InitializeComponent();
      this.DataContext = new StudentExamViewModel(studentExam);
    }
  }
}
