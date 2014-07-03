namespace Examiner.Presentation.Views
{
  using Examiner.Presentation.ViewModels;
  using System.Windows;

  /// <summary>
  /// Interaction logic for NewExamWindow.xaml
  /// </summary>
  public partial class NewExamWindow : Window
  {
    public NewExamWindow()
    {
      this.InitializeComponent();
      this.DataContext = new NewExamMainViewModel();
    }
  }
}
