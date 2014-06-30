namespace Examiner.Presentation.ViewModels
{
  using System;
  using System.Collections.Generic;
  using System.Collections.ObjectModel;
  using System.Linq;
  using System.Text;
  using System.Threading.Tasks;

  public class ProfessorViewModel : ViewModelBase
  {

    public ProfessorViewModel()
    {

    }
    private ObservableCollection<ViewModelBase> viewModelCollection;

    public ObservableCollection<ViewModelBase> ViewModelCollection
    {
      get
      {
        if (this.viewModelCollection == null)
        {
          this.viewModelCollection = new ObservableCollection<ViewModelBase>();
          this.viewModelCollection.Add(new ExamListViewModel());
          this.viewModelCollection.Add(new CategoryListViewModel());
          this.viewModelCollection.Add(new QuestionListViewModel());
        }

        return this.viewModelCollection;
      }
    }
  }
}
