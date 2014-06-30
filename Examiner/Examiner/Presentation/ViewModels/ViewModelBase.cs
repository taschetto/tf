using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examiner.Presentation.ViewModels
{
  public class ViewModelBase : GalaSoft.MvvmLight.ViewModelBase
  {
    public ViewModelBase()
    {
      this.DisplayName = @"";
    }

    public ViewModelBase(string displayName)
    {
      this.DisplayName = displayName;
    }

    public string DisplayName { get; private set; }
  }
}
