namespace Examiner.Presentation.ViewModels
{
  using GalaSoft.MvvmLight;
  using Examiner.Business.Models;
  using System.Collections.Generic;
  using System.Windows.Input;
  using GalaSoft.MvvmLight.Command;

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
    private int rightAlternative;

    private int status1;
    private int status2;
    private int status3;
    private int status4;
    private int status5;

    private bool checked1;
    private bool checked2;
    private bool checked3;
    private bool checked4;
    private bool checked5;

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
        this.count++;
        this.isSaved = false;
        this.HasNext = this.count < this.studentExam.Exam.QuestionCount;
        this.Reset();
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
      this.rightAlternative = question.RightAlternative;
    }

    private void Reset()
    {
      this.Status1 = 0;
      this.Status2 = 0;
      this.Status3 = 0;
      this.Status4 = 0;
      this.Status5 = 0;
    }

    private void ProcessAnswer()
    {
      if (this.rightAlternative == 0)
      {
        this.Status1 = 2;
        this.Status2 = this.Checked2 ? 1 : 0;
        this.Status3 = this.Checked3 ? 1 : 0;
        this.Status4 = this.Checked4 ? 1 : 0;
        this.Status5 = this.Checked5 ? 1 : 0;
      }
      else if (this.rightAlternative == 1)
      {
        this.Status2 = 2;
        this.Status1 = this.Checked1 ? 1 : 0;
        this.Status3 = this.Checked3 ? 1 : 0;
        this.Status4 = this.Checked4 ? 1 : 0;
        this.Status5 = this.Checked5 ? 1 : 0;
      }
      else if (this.rightAlternative == 2)
      {
        this.Status3 = 2;
        this.Status1 = this.Checked1 ? 1 : 0;
        this.Status2 = this.Checked2 ? 1 : 0;
        this.Status4 = this.Checked4 ? 1 : 0;
        this.Status5 = this.Checked5 ? 1 : 0;
      }
      else if (this.rightAlternative == 3)
      {
        this.Status4 = 2;
        this.Status1 = this.Checked1 ? 1 : 0;
        this.Status2 = this.Checked2 ? 1 : 0;
        this.Status3 = this.Checked3 ? 1 : 0;
        this.Status5 = this.Checked5 ? 1 : 0;
      }
      else if (this.rightAlternative == 4)
      {
        this.Status5 = 2;
        this.Status1 = this.Checked1 ? 1 : 0;
        this.Status2 = this.Checked2 ? 1 : 0;
        this.Status3 = this.Checked3 ? 1 : 0;
        this.Status4 = this.Checked4 ? 1 : 0;
      }
    }

    private bool HasAnswer()
    {
      return this.Checked1 || this.Checked2 || this.Checked3 || this.Checked4 || this.Checked5;
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

    public int Status1
    {
      get
      {
        return this.status1;
      }
      set
      {
        Set<int>("Status1", ref this.status1, value);
      }
    }

    public int Status2
    {
      get
      {
        return this.status2;
      }
      set
      {
        Set<int>("Status2", ref this.status2, value);
      }
    }

    public int Status3
    {
      get
      {
        return this.status3;
      }
      set
      {
        Set<int>("Status3", ref this.status3, value);
      }
    }

    public int Status4
    {
      get
      {
        return this.status4;
      }
      set
      {
        Set<int>("Status4", ref this.status4, value);
      }
    }

    public int Status5
    {
      get
      {
        return this.status5;
      }
      set
      {
        Set<int>("Status5", ref this.status5, value);
      }
    }

    public bool Checked1
    {
      get
      {
        return this.checked1;
      }
      set
      {
        Set<bool>("Checked1", ref this.checked1, value);
      }
    }
    public bool Checked2
    {
      get
      {
        return this.checked2;
      }
      set
      {
        Set<bool>("Checked2", ref this.checked2, value);
      }
    }
    public bool Checked3
    {
      get
      {
        return this.checked3;
      }
      set
      {
        Set<bool>("Checked3", ref this.checked3, value);
      }
    }
    public bool Checked4
    {
      get
      {
        return this.checked4;
      }
      set
      {
        Set<bool>("Checked4", ref this.checked4, value);
      }
    }
    public bool Checked5
    {
      get
      {
        return this.checked5;
      }
      set
      {
        Set<bool>("Checked5", ref this.checked5, value);
      }
    }

    public ICommand Next
    {
      get
      {
        return new RelayCommand(() =>
        {
          this.NextAnswer();
        }, () => { return this.isSaved; });
      }
    }
    public ICommand SaveAnswer
    {
      get
      {
        return new RelayCommand(() =>
        {
          this.ProcessAnswer();
          this.isSaved = true;
        }, () => { return !this.isSaved && this.HasAnswer(); });
      }
    }
  }
}
