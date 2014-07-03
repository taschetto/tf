namespace Examiner.Presentation.Views
{
  using System.Windows;
  using Examiner.Presentation.ViewModels;

  /// <summary>
  /// Interaction logic for StudentExamListWindow.xaml
  /// </summary>
  public partial class StudentExamListWindow : Window
  {
    public StudentExamListWindow()
    {
      this.InitializeComponent();
      this.DataContext = new StudentExamListViewModel();
    }
  }
}
