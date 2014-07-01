using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Examiner.Business.Exceptions;

namespace Examiner.Persistence
{
    using System;
    using Examiner.Business.Models;
    using Examiner.Business.DAOs;

    public class AlternativeDB : IAlternativeDao
    {
        private static AlternativeDB instance = null;

        public static AlternativeDB Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AlternativeDB();
                }

                return instance;
            }
        }

        public void Add(Alternative t)
        {
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText =
                    string.Format("INSERT [Alternative] (question, answerContent) " +
                                  "VALUES('{0}','{1}')",
                                    t.Question,
                                    t.AnswerContent
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

        public void Update(Alternative t)
        {
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText =
                    string.Format("UPDATE [Alternative] SET question = {0}, answerContent = {1} " +
                                  "WHERE id_alternative = {2}",
                                    t.Question,
                                    t.AnswerContent,
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

        public void Delete(Alternative t)
        {
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText =
                    string.Format("DELETE FROM Alternative" +
                                  "WHERE id_alternative = {0}",
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

        public List<Alternative> GetAll()
        {
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "select * from Alternative";

                comando.Connection = ConnectionDB.CreateConnection();
                SqlDataAdapter adapter = new SqlDataAdapter(comando);
                DataTable table = new DataTable();

                List<Alternative> alternatives = new List<Alternative>();

                if (table.Rows.Count == 0)
                {
                    return null;
                }

                for (int i = 0; i < table.Rows.Count; i++)
                {
                    Alternative alternative = new Alternative(
                        (int)table.Rows[i][0],
                        (string)table.Rows[i][1],
                        QuestionDB.Instance.GetById((int)table.Rows[i][2])
                        );

                    alternatives.Add(alternative);
                }

                return alternatives;
            }
            catch (SqlException e)
            {
                throw new DAOException(e);
            }
        }

        public Alternative GetById(int id)
        {
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText =
                    string.Format("SELECT * FROM  [Alternative] WHERE id_alternative = {0}",
                        id
                        );

                comando.Connection = ConnectionDB.CreateConnection();
                comando.Connection.Open();

                SqlDataReader reader = comando.ExecuteReader();


                if (!reader.Read())
                {
                    return null;
                }

                Alternative alternative = new Alternative(
                        (int)reader["id_alternative"],
                        (string)reader["question"],
                        QuestionDB.Instance.GetById((int)reader["answerContent"])
                        );

                comando.Connection.Close();
                return alternative;
            }
            catch (SqlException e)
            {
                throw new DAOException(e);
            }
        }
    }
}
