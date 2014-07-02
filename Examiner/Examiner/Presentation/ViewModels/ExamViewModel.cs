﻿namespace Examiner.Presentation.ViewModels
{
  using Examiner.Business;
  using Examiner.Business.Models;
  using GalaSoft.MvvmLight.Command;
  using System.Collections.ObjectModel;
  using System.Windows;
  using System.Windows.Input;

  public class ExamViewModel : ViewModelBase
  {
    private int id = 0;
    private int questionCount = 0;
    private bool open = true;
    private string accessCode = string.Empty;
    private ObservableCollection<CheckListItem<Category>> categories;
    private bool isUpdate = false;

    public ExamViewModel(Exam exam = null)
    {
      this.categories = new ObservableCollection<CheckListItem<Category>>();
      this.IsUpdate = false;

      foreach (var category in ExaminerFacade.Instance.GetAll<Category>())
      {
        var item = new CheckListItem<Category>(category, category.Name, false);
        this.categories.Add(item);
      }

      if (exam != null)
      { 
        this.id = exam.Id;
        this.questionCount = exam.QuestionCount;
        this.open = exam.Open;
        this.accessCode = exam.AccessCode;
        this.IsUpdate = true;

        // Melhorar esta lógica.
        foreach (var category in exam.Categories)
        {
          foreach (var item in this.categories)
          {
            if (item.Model.Equals(category))
              item.IsChecked = true;
          }
        }
      }
    }

    public bool IsUpdate
    {
      get
      {
        return this.isUpdate;
      }

      set
      {
        Set<bool>("IsUpdate", ref this.isUpdate, value);
      }
    }
    
    public int Id 
    { 
      get
      {
        return this.id;
      }

      set
      {
        Set<int>("Id", ref this.id, value);
      }
    }

    public int QuestionCount
    {
      get
      {
        return this.questionCount;
      }

      set
      {
        Set<int>("QuestionCount", ref this.questionCount, value);
      }
    }

    public bool Open
    {
      get
      {
        return this.open;
      }

      set
      {
        Set<bool>("Open", ref this.open, value);
      }
    }

    public string AccessCode
    {
      get
      {
        return this.accessCode;
      }

      set
      {
        Set<string>("AccessCode", ref this.accessCode, value);
      }
    }

    public ObservableCollection<CheckListItem<Category>> Categories 
    { 
      get
      {
        return this.categories;
      }
    }

    public ICommand Save
    {
      get
      {
        return new RelayCommand<Window>((w) =>
        {
          Exam exam = new Exam(this.Id, this.QuestionCount, this.Open, this.AccessCode);

          foreach (var item in this.categories)
          {
            if (item.IsChecked)
              exam.AddCategory(item.Model);
          }
          
          if (this.IsUpdate)
            ExaminerFacade.Instance.Update(exam);
          else
            ExaminerFacade.Instance.Add(exam);

          w.Close();
        });
      }
    }
  }
}