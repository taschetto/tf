using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examiner.Presentation.ViewModels
{
  public class NewExamMainViewModel
  {
    private ObservableCollection<ViewModelBase> viewModelCollection;

    public ObservableCollection<ViewModelBase> ViewModelCollection
    {
      get
      {
        if (this.viewModelCollection == null)
        {
          this.viewModelCollection = new ObservableCollection<ViewModelBase>();
          this.viewModelCollection.Add(new NewExamViewModel());
        }

        return this.viewModelCollection;
      }
    }
  }
}
