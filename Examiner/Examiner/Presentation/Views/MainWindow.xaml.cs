﻿namespace Examiner
{
  using System.Windows;
  using Examiner.Presentation.ViewModels;

  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      this.InitializeComponent();
      this.DataContext = new MainViewModel();
    }

    private void MenuItem_Click(object sender, RoutedEventArgs e)
    {
      this.Close();
    }
  }
}
