namespace Examiner.Presentation.ViewModels
{
  using System.Collections.ObjectModel;
  using Examiner.Business.Models;

  public class QuestionListViewModel : ViewModelBase
  {
    public QuestionListViewModel() : base(@"Questions")
    {
      this.Questions = new ObservableCollection<Question>();

      foreach (Question question in ExaminerFacade.Instance.GetAll<Question>())
      {
        this.Questions.Add(question);
      }
    }

    public ObservableCollection<Question> Questions { get; private set; }
  }
}
