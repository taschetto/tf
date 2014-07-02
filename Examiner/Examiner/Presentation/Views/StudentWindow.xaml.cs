﻿namespace Examiner.Presentation.Views
{
  using Examiner.Business.Models;
  using Examiner.Presentation.ViewModels;
  using System.Windows;

  public partial class StudentWindow : Window
  {
    public StudentWindow(Student student = null)
    {
      this.InitializeComponent();
      this.DataContext = new StudentViewModel(student);
    }
  }
}
