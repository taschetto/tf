namespace Examiner.Presentation.ViewModels
{
  using Examiner.Business;
  using Examiner.Business.Models;
  using GalaSoft.MvvmLight.Command;
  using System.Collections.ObjectModel;
  using System.Windows;
  using System.Windows.Input;

  public class QuestionViewModel : ViewModelBase
  {
    private bool isNew = true;

    private int id;
    private string questionContent;
    private string[] alternatives;
    private int rightAlternative;
    private string feedbackContent;
    private ObservableCollection<CheckListItem<Category>> categories;

    public QuestionViewModel(Question question = null)
    {
      this.categories = new ObservableCollection<CheckListItem<Category>>();

      foreach (var category in ExaminerFacade.Instance.GetAll<Category>())
      {
        var item = new CheckListItem<Category>(category, category.Name, false);
        this.categories.Add(item);
      }

      if (question != null)
      {
        this.id = question.Id;
        this.questionContent = question.QuestionContent;
        this.alternatives = question.Alternatives;
        this.rightAlternative = question.RightAlternative;
        this.feedbackContent = question.FeedbackContent;
        this.isNew = false;

        // Melhorar esta lógica.
        foreach (var category in question.Categories)
        {
          foreach (var item in this.categories)
          {
            if (item.Model.Equals(category))
              item.IsChecked = true;
          }
        }
      }
      else
      {
        this.alternatives = new string[5];
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

    public string QuestionContent
    {
      get
      {
        return this.questionContent;
      }

      set
      {
        Set<string>("QuestionContent", ref this.questionContent, value);
      }
    }

    public string Alternative1
    {
      get
      {
        return this.alternatives[0];
      }

      set
      {
        Set<string>("Alternative1", ref this.alternatives[0], value);
      }
    }

    public string Alternative2
    {
      get
      {
        return this.alternatives[1];
      }

      set
      {
        Set<string>("Alternative2", ref this.alternatives[1], value);
      }
    }

    public string Alternative3
    {
      get
      {
        return this.alternatives[2];
      }

      set
      {
        Set<string>("Alternative3", ref this.alternatives[2], value);
      }
    }

    public string Alternative4
    {
      get
      {
        return this.alternatives[3];
      }

      set
      {
        Set<string>("Alternative4", ref this.alternatives[3], value);
      }
    }

    public string Alternative5
    {
      get
      {
        return this.alternatives[4];
      }

      set
      {
        Set<string>("Alternative5", ref this.alternatives[4], value);
      }
    }

    public int RightAlternative
    {
      get
      {
        return this.rightAlternative;
      }

      set
      {
        Set<int>("RightAlternative", ref this.rightAlternative, value);
      }
    }

    public string FeedbackContent
    {
      get
      {
        return this.feedbackContent;
      }

      set
      {
        Set<string>("FeedbackContent", ref this.feedbackContent, value);
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
          Question question = new Question(this.Id, this.QuestionContent, this.FeedbackContent, this.alternatives, this.RightAlternative);

          foreach (var item in this.categories)
          {
            if (item.IsChecked)
              question.AddCategory(item.Model);
          }

          if (this.isNew)
            ExaminerFacade.Instance.Add(question);
          else
            ExaminerFacade.Instance.Update(question);

          w.Close();
        });
      }
    }
  }
}
