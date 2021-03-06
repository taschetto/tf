﻿namespace Examiner.Presentation.Views
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

    private void TextBox_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
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
