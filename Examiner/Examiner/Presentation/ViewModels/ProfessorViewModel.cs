namespace Examiner.Presentation.ViewModels
{
  using GalaSoft.MvvmLight;
  using System.Collections.ObjectModel;

  public class ProfessorViewModel : ViewModelBase
  {
    private ObservableCollection<ViewModelBase> viewModelCollection;

    public ObservableCollection<ViewModelBase> ViewModelCollection
    {
      get
      {
        if (this.viewModelCollection == null)
        {
          this.viewModelCollection = new ObservableCollection<ViewModelBase>();
          this.viewModelCollection.Add(new ExamListViewModel());
          this.viewModelCollection.Add(new QuestionListViewModel());
          this.viewModelCollection.Add(new CategoryListViewModel());
          this.viewModelCollection.Add(new StudentListViewModel());
        }

        return this.viewModelCollection;
      }
    }
  }
}
