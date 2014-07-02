namespace Examiner.Presentation.ViewModels
{
  using Examiner.Business;
  using Examiner.Business.Models;
  using System.Collections.ObjectModel;

  public class ExamViewModel : ModelViewModel<Exam>
  {
    private int questionCount = 0;
    private bool open = true;
    private string accessCode = string.Empty;

    private ObservableCollection<CheckListItem<Category>> categories;

    public ExamViewModel(Exam exam = null)
    {
      this.IsUpdate = exam != null;
      
      this.categories = new ObservableCollection<CheckListItem<Category>>();
      foreach (var category in ExaminerFacade.Instance.GetAll<Category>())
      {
        var item = new CheckListItem<Category>(category, category.Name, false);
        this.categories.Add(item);
      }

      if (exam != null)
      { 
        this.Id = exam.Id;
        this.QuestionCount = exam.QuestionCount;
        this.Open = exam.Open;
        this.AccessCode = exam.AccessCode;

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

    public override Exam Model
    {
      get
      {
        Exam exam = new Exam(this.Id, this.QuestionCount, this.Open, this.AccessCode);

        foreach (var item in this.categories)
        {
          if (item.IsChecked)
            exam.AddCategory(item.Model);
        }

        return exam;
      }
    }
  }
}