namespace Examiner.Presentation.ViewModels
{
  using Examiner.Business;
  using Examiner.Business.Models;
  using GalaSoft.MvvmLight.Command;
  using System.Collections.ObjectModel;
  using System.Windows;
  using System.Windows.Input;

  public class QuestionViewModel : ModelViewModel<Question>
  {
    private string questionContent;
    private string[] alternatives;
    private int rightAlternative;
    private string feedbackContent;

    private bool rightAlternative1 = true;
    private bool rightAlternative2 = false;
    private bool rightAlternative3 = false;
    private bool rightAlternative4 = false;
    private bool rightAlternative5 = false;

    private ObservableCollection<CheckListItem<Category>> categories;

    public QuestionViewModel(Question question = null)
    {
      this.IsUpdate = question != null;

      this.categories = new ObservableCollection<CheckListItem<Category>>();
      foreach (var category in ExaminerFacade.Instance.GetAll<Category>())
      {
        var item = new CheckListItem<Category>(category, category.Name, false);
        this.categories.Add(item);
      }

      if (question != null)
      {
        this.Id = question.Id;
        this.QuestionContent = question.QuestionContent;
        this.alternatives = question.Alternatives;
        this.RightAlternative = question.RightAlternative;
        this.FeedbackContent = question.FeedbackContent;

        this.RightAlternative1 = this.rightAlternative == 0;
        this.RightAlternative2 = this.rightAlternative == 1;
        this.RightAlternative3 = this.rightAlternative == 2;
        this.RightAlternative4 = this.rightAlternative == 3;
        this.RightAlternative5 = this.rightAlternative == 4;

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

    public bool RightAlternative1
    {
      get
      {
        return this.rightAlternative1;
      }

      set
      {
        Set<bool>("RightAlternative1", ref this.rightAlternative1, value);
        if (value)
          this.RightAlternative = 0;
      }
    }

    public bool RightAlternative2
    {
      get
      {
        return this.rightAlternative2;
      }

      set
      {
        Set<bool>("RightAlternative2", ref this.rightAlternative2, value);
        if (value)
          this.RightAlternative = 1;
      }
    }

    public bool RightAlternative3
    {
      get
      {
        return this.rightAlternative3;
      }

      set
      {
        Set<bool>("RightAlternative3", ref this.rightAlternative3, value);
        if (value)
          this.RightAlternative = 2;
      }
    }

    public bool RightAlternative4
    {
      get
      {
        return this.rightAlternative4;
      }

      set
      {
        Set<bool>("RightAlternative4", ref this.rightAlternative4, value);
        if (value)
          this.RightAlternative = 3;
      }
    }

    public bool RightAlternative5
    {
      get
      {
        return this.rightAlternative5;
      }

      set
      {
        Set<bool>("RightAlternative5", ref this.rightAlternative5, value);
        if (value)
          this.RightAlternative = 4;
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

    public override Question Model
    {
      get
      {
        Question question = new Question(this.Id, this.QuestionContent, this.FeedbackContent, this.alternatives, this.RightAlternative);

        foreach (var item in this.categories)
        {
          if (item.IsChecked)
            question.AddCategory(item.Model);
        }

        return question;
      }
    }
  }
}