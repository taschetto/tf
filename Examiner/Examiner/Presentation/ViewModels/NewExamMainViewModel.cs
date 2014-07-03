namespace Examiner.Presentation.ViewModels
{
  using System;
  using Examiner.Business;
  using Examiner.Business.Models;
  using GalaSoft.MvvmLight;

  public class NewExamMainViewModel : ViewModelBase
  {
    private ViewModelBase currentViewModel;

    public NewExamMainViewModel()
    {
      this.CurrentViewModel = new NewExamViewModel(this);
    }

    public void BeginExam(Student student, Exam exam)
    {
      var viewModel = new AnswerViewModel(ExaminerFacade.Instance.CreateNewExam(student, exam));
      viewModel.CloseAction = this.CloseAction;
      this.CurrentViewModel = viewModel;
    }

    public ViewModelBase CurrentViewModel
    {
      get
      {
        return this.currentViewModel;
      }

      set
      {
        Set<ViewModelBase>("CurrentViewModel", ref this.currentViewModel, value);
      }
    }

    public Action CloseAction { get; set; }
  }
}
