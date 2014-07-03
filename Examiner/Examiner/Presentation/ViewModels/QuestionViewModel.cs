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
    private AlternativesEnum rightAlternative;
    private string feedbackContent;

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
        this.RightAlternative = (AlternativesEnum)question.RightAlternative;
        this.FeedbackContent = question.FeedbackContent;

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

    public AlternativesEnum RightAlternative 
    { 
      get
      {
        return this.rightAlternative;
      }
      set
      {
        Set<AlternativesEnum>("RightAlternative", ref this.rightAlternative, value);
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
        Question question = new Question(this.Id, this.QuestionContent, this.FeedbackContent, this.alternatives, (int)this.RightAlternative);

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