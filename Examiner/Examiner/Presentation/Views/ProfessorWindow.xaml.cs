namespace Examiner.Presentation.Views
{
  using System.Windows;
  using Examiner.Presentation.ViewModels;

  public partial class ProfessorWindow : Window
  {
    public ProfessorWindow()
    {
      this.InitializeComponent();

      this.DataContext = new ProfessorViewModel();
    }
  }
}
