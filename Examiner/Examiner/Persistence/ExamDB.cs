using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Examiner.Business.DAOs;
using Examiner.Business.Exceptions;
using Examiner.Business.Models;

namespace Examiner.Persistence
{
    public class ExamDB : IExamDao
    {
        private static ExamDB instance = null;

        public static ExamDB Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ExamDB();
                }

                return instance;
            }
        }

        public void Add(Exam t)
        {
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText =
                    string.Format("INSERT [Student] (questionCount, open, accessCode) " +
                                  "VALUES('{0}','{1}','{2}','{3})",
                                    t.QuestionCount,
                                    t.Open,
                                    t.AccessCode
                                    );

                comando.Connection = ConnectionDB.CreateConnection();

                comando.Connection.Open();
                comando.ExecuteNonQuery();
                comando.Connection.Close();
            }
            catch (SqlException e)
            {
                throw new DAOException(e);
            }
        }

        public void Update(Exam t)
        {
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText =
                    string.Format("UPDATE [Student] SET questionCount= {0}, open= {1}, accessCode= {2} " +
                                  "WHERE id_exam = {3}",
                                    t.QuestionCount,
                                    t.Open,
                                    t.AccessCode,
                                    t.Id
                                    );

                comando.Connection = ConnectionDB.CreateConnection();

                comando.Connection.Open();
                comando.ExecuteNonQuery();
                comando.Connection.Close();
            }
            catch (SqlException e)
            {
                throw new DAOException(e);
            }
        }

        public void Delete(Exam t)
        {
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText =
                    string.Format("DELETE FROM [Student] " +
                                  "WHERE id_exam = {0}",
                                    t.Id
                                    );

                comando.Connection = ConnectionDB.CreateConnection();

                comando.Connection.Open();
                comando.ExecuteNonQuery();
                comando.Connection.Close();
            }
            catch (SqlException e)
            {
                throw new DAOException(e);
            }
        }

        public List<Exam> GetAll()
        {
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "select * from Exam";

                comando.Connection = ConnectionDB.CreateConnection();
                SqlDataAdapter adpter = new SqlDataAdapter(comando);
                DataTable table = new DataTable();
                adpter.Fill(table);

                List<Exam> exams = new List<Exam>();

                for (int i = 0; i < table.Rows.Count; i++)
                {
                    Exam exam = new Exam(
                        (int)table.Rows[i][0],
                        (int)table.Rows[i][1],
                        (bool)table.Rows[i][2],
                        (String)table.Rows[i][3]
                        );

                    exams.Add(exam);
                }

                return exams;

            }
            catch (SqlException e)
            {
                throw new DAOException(e);
            }
        }

        public Exam GetById(int id)
        {
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText =
                    string.Format("SELECT * FROM  [EXAM] WHERE id_question = {0}",
                        id
                        );

                comando.Connection = ConnectionDB.CreateConnection();
                comando.Connection.Open();

                SqlDataReader reader = comando.ExecuteReader();


                if (!reader.Read())
                {
                    return null;
                }


                Exam exam = new Exam(
                        (int)reader["id_exam"],
                        (int)reader["questionCount"],
                        (bool)reader["open"],
                        (String)reader["accessCode"]
                        );


                comando.Connection.Close();
                return exam;

            }
            catch (SqlException e)
            {
                throw new DAOException(e);
            }
        }
    }
}