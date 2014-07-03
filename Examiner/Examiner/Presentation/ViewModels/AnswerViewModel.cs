namespace Examiner.Presentation.ViewModels
{
  using GalaSoft.MvvmLight;
  using Examiner.Business.Models;
  using System.Collections.Generic;
  using System.Windows.Input;
  using GalaSoft.MvvmLight.Command;
using System.Windows.Media;
  using Examiner.Business;

  public class AnswerViewModel : ViewModelBase
  {
    private StudentExam studentExam;
    private List<Answer>.Enumerator enumerator;
    private Answer currentAnswer;

    private bool hasNext;
    private bool isSaved;
    private int count;
    private int id;
    private string questionContent;
    private string feedbackContent;
    private string[] alternatives;
    private AlternativesEnum rightAlternative;
    private AlternativesEnum alternative;

    private Brush color1;
    private Brush color2;
    private Brush color3;
    private Brush color4;
    private Brush color5;

    public AnswerViewModel(StudentExam studentExam)
    {
      this.count = 0;
      this.alternatives = new string[5];
      this.studentExam = studentExam;
      this.enumerator = studentExam.Answers.GetEnumerator();
      this.NextAnswer();
    }
    private void NextAnswer()
    {
      if (this.enumerator.MoveNext())
      {
        this.currentAnswer = enumerator.Current;
        this.SetQuestion(this.currentAnswer.Question);
        this.Alternative = AlternativesEnum.A;
        this.count++;
        this.isSaved = false;
        this.HasNext = this.count < this.studentExam.Exam.QuestionCount;
        this.ResetColors();
      }
    }

    private void ResetColors()
    {
      this.Color1 = Brushes.Black;
      this.Color2 = Brushes.Black;
      this.Color3 = Brushes.Black;
      this.Color4 = Brushes.Black;
      this.Color5 = Brushes.Black;
    }

    private void AnswerColors()
    {
      if (this.Alternative == this.rightAlternative)
      {
        this.Color1 = this.Alternative == AlternativesEnum.A ? Brushes.Green : Brushes.Black;
        this.Color2 = this.Alternative == AlternativesEnum.B ? Brushes.Green : Brushes.Black;
        this.Color3 = this.Alternative == AlternativesEnum.C ? Brushes.Green : Brushes.Black;
        this.Color4 = this.Alternative == AlternativesEnum.D ? Brushes.Green : Brushes.Black;
        this.Color5 = this.Alternative == AlternativesEnum.E ? Brushes.Green : Brushes.Black;
      }
      else
      {
        this.Color1 = this.rightAlternative == AlternativesEnum.A ? Brushes.Green : (this.Alternative == AlternativesEnum.A ? Brushes.Red : Brushes.Black);
        this.Color2 = this.rightAlternative == AlternativesEnum.B ? Brushes.Green : (this.Alternative == AlternativesEnum.B ? Brushes.Red : Brushes.Black);
        this.Color3 = this.rightAlternative == AlternativesEnum.C ? Brushes.Green : (this.Alternative == AlternativesEnum.C ? Brushes.Red : Brushes.Black);
        this.Color4 = this.rightAlternative == AlternativesEnum.D ? Brushes.Green : (this.Alternative == AlternativesEnum.D ? Brushes.Red : Brushes.Black);
        this.Color5 = this.rightAlternative == AlternativesEnum.E ? Brushes.Green : (this.Alternative == AlternativesEnum.E ? Brushes.Red : Brushes.Black);
      }
    }

    private void SetQuestion(Question question)
    {
      this.Id = question.Id;
      this.QuestionContent = question.QuestionContent;
      this.FeedbackContent = question.FeedbackContent;
      this.Alternative1 = question.Alternatives[0];
      this.Alternative2 = question.Alternatives[1];
      this.Alternative3 = question.Alternatives[2];
      this.Alternative4 = question.Alternatives[3];
      this.Alternative5 = question.Alternatives[4];
      this.rightAlternative = (AlternativesEnum)question.RightAlternative;
    }

    public bool HasNext
    {
      get
      {
        return this.hasNext;
      }
      set
      {
        Set<bool>("HasNext", ref this.hasNext, value);
      }
    }

    public int Id
    {
      get
      {
        return this.id;
      }
      set
      {
        Set<int>("Id", ref this.id, value);
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

    public Brush Color1
    {
      get
      {
        return this.color1;
      }
      set
      {
        Set<Brush>("Color1", ref this.color1, value);
      }
    }

    public Brush Color2
    {
      get
      {
        return this.color2;
      }
      set
      {
        Set<Brush>("Color2", ref this.color2, value);
      }
    }

    public Brush Color3
    {
      get
      {
        return this.color3;
      }
      set
      {
        Set<Brush>("Color3", ref this.color3, value);
      }
    }

    public Brush Color4
    {
      get
      {
        return this.color4;
      }
      set
      {
        Set<Brush>("Color4", ref this.color4, value);
      }
    }

    public Brush Color5
    {
      get
      {
        return this.color5;
      }
      set
      {
        Set<Brush>("Color5", ref this.color5, value);
      }
    }

    public AlternativesEnum Alternative
    {
      get
      {
        return this.alternative;
      }
      set
      {
        Set<AlternativesEnum>("Alternative", ref this.alternative, value);
      }
    }

    private void Save()
    {
      ExaminerFacade.Instance.Add(this.studentExam);
    }

    public ICommand Next
    {
      get
      {
        return new RelayCommand(() =>
        {
          if (this.HasNext)
            this.NextAnswer();
          else
            this.Save();
        }, () => { return this.isSaved; });
      }
    }
    public ICommand SaveAnswer
    {
      get
      {
        return new RelayCommand(() =>
        {
          this.isSaved = true;
          this.AnswerColors();
          this.enumerator.Current.Alternative = (int)this.Alternative;
        }, () => { return !this.isSaved; });
      }
    }
  }
}
