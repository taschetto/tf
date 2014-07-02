using Examiner.Business.Models;
using Examiner.Presentation.ViewModels;
using System.Windows;

namespace Examiner.Presentation.Views
{
  /// <summary>
  /// Interaction logic for CategoryWindow.xaml
  /// </summary>
  public partial class CategoryWindow : Window
  {
    public CategoryWindow(Category category = null)
    {
      this.InitializeComponent();
      this.DataContext = new CategoryViewModel(category);
    }
  }
}
