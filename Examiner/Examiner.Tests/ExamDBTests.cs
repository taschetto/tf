namespace Examiner.Tests
{
  using System;
  using System.Linq;
  using Examiner.Business.Models;
  using Examiner.Persistence;
  using NUnit.Framework;

  [TestFixture]
  public class ExamDBTests
  {
    [Test]
    public void AddExam()
    {
      var exam = new Exam(0, 5, true, string.Empty);
      Assert.AreEqual(true, ExamDB.Instance.Add(exam));
    }

    [Test]
    public void GetAllExam()
    {
      var exams = ExamDB.Instance.GetAll();
      Assert.GreaterOrEqual(exams.Count, 0);
    }

    [Test]
    public void DeleteExam()
    {
      var exams = ExamDB.Instance.GetAll();
      if (exams.Count > 0)
      {
        Exam exam = exams.First();
        Assert.AreEqual(true, ExamDB.Instance.Delete(exam));
      }
    }

    [Test]
    public void UpdateExam()
    {
      var exams = ExamDB.Instance.GetAll();
      if (exams.Count > 0)
      {
        Exam exam = exams.First();
        exam.QuestionCount = 15;
        Assert.AreEqual(true, ExamDB.Instance.Update(exam));
      }
    }

    [Test]
    public void GetById()
    {
      var exams = ExamDB.Instance.GetAll();
      if (exams.Count > 0)
      {
        Exam exam1 = exams.First();
        Exam exam2 = ExamDB.Instance.GetById(exam1.Id);
        Assert.AreEqual(true, exam1.Equals(exam2));
      }
    }
  }
}
