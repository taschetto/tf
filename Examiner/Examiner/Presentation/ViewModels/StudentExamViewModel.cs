namespace Examiner.Presentation.ViewModels
{
  using System;
  using System.Collections.Generic;
  using System.Collections.ObjectModel;
  using System.Linq;
  using System.Text;
  using System.Threading.Tasks;
  using Examiner.Business.Models;

  public class StudentExamViewModel : ModelViewModel<StudentExam>
  {
    private StudentExam studentExam;

    public StudentExamViewModel(StudentExam studentExam)
    {
      this.studentExam = studentExam;
    }

    public StudentExam StudentExam
    {
      get
      {
        return this.studentExam;
      }
      set
      {
        Set<StudentExam>("StudentExam", ref this.studentExam, value);
      }
    }

    public string Result
    {
      get
      {
        int rights = 0;

        foreach (var answer in this.StudentExam.Answers)
        {
          if (answer.Alternative == answer.Question.RightAlternative)
            rights++;
        }

        string str = string.Format(@"{0}/{1}", rights, this.StudentExam.Answers.Count); 
        return str;
      }
    }

    public override bool IsReadonly
    {
      get
      {
        return true;
      }
    }

    public override StudentExam Model
    {
      get { throw new NotImplementedException(); }
    }
  }
}
