using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Examiner.Business.DAOs;
using Examiner.Business.Models;

namespace Examiner.Persistence
{


    public class StudentDB : IStudentDao
    {
        private static StudentDB _referenceStudentDb = null;

        public static StudentDB GetInstance()
        {
            if (_referenceStudentDb == null)
            {
                _referenceStudentDb = new StudentDB();
            }
            return (_referenceStudentDb);
        }

        public void Add(Student t)
        {
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText =
                    string.Format("INSERT [Student] (registration, password, name, email) " +
                                  "VALUES('{0}','{1}','{2}','{3})",
                                    t.Registration,
                                    t.Password,
                                    t.Name,
                                    t.Email
                                    );

                comando.Connection = ConnectionDB.CreateConnection();

                comando.Connection.Open();
                comando.ExecuteNonQuery();
                comando.Connection.Close();
            }
            catch (SqlException e)
            {
                throw new DAOException(e.Message);
            }
        }

        public void Update(Student t)
        {
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText =
                    string.Format("UPDATE [Student] set registration = {0}, password = {1}, name = {2}, email ={3} WHERE id_student = {4} ",
                                    t.Registration,
                                    t.Password,
                                    t.Name,
                                    t.Email,
                                    t.Id
                                    );

                comando.Connection = ConnectionDB.CreateConnection();

                comando.Connection.Open();
                comando.ExecuteNonQuery();
                comando.Connection.Close();
            }
            catch (SqlException e)
            {
                throw new DAOException(e.Message);
            }
        }

        public void Delete(Student t)
        {
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText =
                    string.Format("DELETE FROM [Student]  WHERE id_student = {0} ",
                                    t.Id
                                    );

                comando.Connection = ConnectionDB.CreateConnection();

                comando.Connection.Open();
                comando.ExecuteNonQuery();
                comando.Connection.Close();
            }
            catch (SqlException e)
            {
                throw new DAOException(e.Message);
            }
        }

        public List<Student> GetAll()
        {
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText =
                    string.Format("select * from Student");



                SqlDataAdapter adpter = new SqlDataAdapter(comando);
                DataTable table = new DataTable();

                adpter.Fill(table);

                /*Implentar
                 * 
                 * 
                 * 
                 * 
                 * 
                 */

                comando.Connection = ConnectionDB.CreateConnection();

                comando.Connection.Open();
                comando.ExecuteNonQuery();
                comando.Connection.Close();
            }
            catch (SqlException e)
            {
                throw new DAOException(e.Message);
            }
        }

        public Student GetById(int id)
        {
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText =
                   string.Format("SELECT * FROM  Student WHERE id_question = {0}",
                                  id
                                   );
                comando.Connection = ConnectionDB.CreateConnection();

                comando.Connection.Open();
                comando.ExecuteNonQuery();
                comando.Connection.Close();

            }
            catch (SqlException e)
            {
                throw new DAOException(e.Message);
            }
        }
    }
}
