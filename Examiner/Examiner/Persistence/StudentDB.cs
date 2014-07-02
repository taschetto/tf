namespace Examiner.Persistence
{
  using System.Collections.Generic;
  using System.Data;
  using Examiner.Business.DAOs;
  using Examiner.Business.Models;

  public class StudentDB : IStudentDao
  {
    private static StudentDB instance = null;

    public static StudentDB Instance
    {
      get
      {
        if (instance == null)
        {
          instance = new StudentDB();
        }

        return instance;
      }
    }

    private Student ToStudent(DataRow row)
    {
      return new Student(
        (int)row["id"],
        (int)row["registration"],
        (string)row["password"],
        (string)row["name"],
        (string)row["email"]);
    }

    public bool Add(Student t)
    {
      string sql = string.Format("INSERT [Student] (registration, password, name, email) VALUES('{0}','{1}','{2}','{3}')",
        t.Registration,
        t.Password,
        t.Name,
        t.Email);

      return ConnectionDB.Instance.ExecuteNonQuery(sql) > 0;
    }

    public bool Update(Student t)
    {
      string sql = string.Format("UPDATE [Student] set registration = '{0}', password = '{1}', name = '{2}', email = '{3}' WHERE id = {4} ",
        t.Registration,
        t.Password,
        t.Name,
        t.Email,
        t.Id);

      return ConnectionDB.Instance.ExecuteNonQuery(sql) > 0;
    }

    public bool Delete(Student t)
    {
      string sql = string.Format("DELETE FROM [Student] WHERE id = {0} ", t.Id);

      return ConnectionDB.Instance.ExecuteNonQuery(sql) > 0;
    }

    public List<Student> GetAll()
    {
      List<Student> students = new List<Student>();
      string sql = "select * from [Student]";
      var dataTable = ConnectionDB.Instance.ExecuteQuery(sql);

      foreach (DataRow row in dataTable.Rows)
      {
        students.Add(ToStudent(row));
      }

      return students;
    }

    public Student GetById(int id)
    {
      string sql = string.Format("SELECT * FROM [Student] WHERE id = {0}", id);
      var dataTable = ConnectionDB.Instance.ExecuteQuery(sql);

      foreach (DataRow row in dataTable.Rows)
      {
        return ToStudent(row);
      }

      return null;
    }
  }
}