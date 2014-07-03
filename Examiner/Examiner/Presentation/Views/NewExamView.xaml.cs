namespace Examiner.Presentation.Views
{
  using System.Windows.Controls;

  public partial class NewExamView : UserControl
  {
    public NewExamView()
    {
      this.InitializeComponent();
    }

    private void TextBox_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
    {
      e.Handled = IsTextNumeric(e.Text);
    }

    private void TextBox_PreviewTextInput_1(object sender, System.Windows.Input.TextCompositionEventArgs e)
    {
      e.Handled = IsTextNumeric(e.Text);
    }

    private static bool IsTextNumeric(string str)
    {
      System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex("[^0-9]");
      return reg.IsMatch(str);

    }
  }
}
