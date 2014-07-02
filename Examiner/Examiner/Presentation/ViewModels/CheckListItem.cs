using Examiner.Business.Models;
namespace Examiner.Presentation.ViewModels
{
  public class CheckListItem<T> where T : BaseModel
  {
    public CheckListItem(T t, string content, bool isChecked)
    {
      this.Model = t;
      this.Content = content;
      this.IsChecked = isChecked;
    }
    public T Model { get; set; }

    public string Content { get; set; }

    public bool IsChecked { get; set; }
  }
}
