namespace Examiner.Persistence
{
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using Examiner.Business.DAOs;
    using Examiner.Business.Exceptions;
    using Examiner.Business.Models;

    public class QuestionDB : IQuestionDao
    {

        private static QuestionDB instance = null;

        public static QuestionDB Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new QuestionDB();
                }
                return instance;
            }
        }


        public void Add(Question t)
        {
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText =
                    string.Format("INSERT [Question] (questionContent, feedbackContent, rightAlternative) " +
                                  "VALUES('{0}','{1}','{2}')",
                                    t.QuestionContent,
                                    t.FeedbackContent,
                                    t.RightAlternative
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

        public void Update(Question t)
        {

            try
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText =
                   string.Format("UPDATE [Question] SET questionContent = {0}, feedbackContent = {1}, rightAlternative= {2}) " +
                                 "WHERE = {3}",
                                   t.QuestionContent,
                                   t.FeedbackContent,
                                   t.RightAlternative,
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

        public void Delete(Question t)
        {
            try
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText =
                   string.Format("DELETE FROM [Question] WHERE id_question = {0}",
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

        public List<Question> GetAll()
        {

            try
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "select * from Question";

                comando.Connection = ConnectionDB.CreateConnection();
                SqlDataAdapter adapter = new SqlDataAdapter(comando);
                DataTable table = new DataTable();

                List<Question> questions = new List<Question>();

                if (table.Rows.Count == 0)
                {
                    return null;
                }

                for (int i = 0; i < table.Rows.Count; i++)
                {
                    Question question = new Question(
                        (int)table.Rows[i][0],
                        (string)table.Rows[i][1],
                        (string)table.Rows[i][2],
                        AlternativeDB.Instance.GetById((int)table.Rows[i][3])
                        );
                    questions.Add(question);
                }

                return questions;
            }
            catch (SqlException e)
            {
                throw new DAOException(e);
            }
        }

        public Question GetById(int id)
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

                SqlDataReader reader = comando.ExecuteReader();

                if (!reader.Read())
                {
                    return null;
                }

                Question question= new Question(
                        (int)reader["id_question"],
                        (string)reader["questionContent"],
                        (string)reader["feedbackContent"],
                        AlternativeDB.Instance.GetById((int)reader["rightAlternative"])
                        );

                comando.Connection.Close();
                return question;

            }
            catch (SqlException e)
            {
                throw new DAOException(e);
            }

        }
    }
}
