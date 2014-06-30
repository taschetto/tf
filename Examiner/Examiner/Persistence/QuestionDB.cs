namespace Examiner.Persistence
{
  using System;
  using System.Collections.Generic;
  using System.Data;
  using System.Data.SqlClient;
  using Examiner.Business.DAOs;
  using Examiner.Business.Exceptions;
  using Examiner.Business.Models;
  using Microsoft.CSharp;

  public class QuestionDB : IQuestionDao
  {

    private static QuestionDB _referenceQuestionDb = null;

    public static QuestionDB GetInstance()
    {
      if (_referenceQuestionDb == null)
      {
        _referenceQuestionDb = new QuestionDB();
      }
      return (_referenceQuestionDb);
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
        comando.CommandText = string.Format("select * from [Question]");


        comando.Connection = ConnectionDB.CreateConnection();
        SqlDataAdapter adapter = new SqlDataAdapter(comando);
        DataTable table = new DataTable();

        adapter.Fill(table);


        /*Falta implementar o restante
         * 
         * 
         * 
         * 
         * 
         * 
         */

        comando.Connection.Open();
        comando.ExecuteNonQuery();
        comando.Connection.Close();

      }
      catch (SqlException e)
      {
        throw new DAOException(e);
      }
      
      return null;
    }

    public Question GetById(int id)
    {
      try
      {
        SqlCommand comando = new SqlCommand();
        comando.CommandType = CommandType.Text;
        comando.CommandText =
           string.Format("SELECT * FROM  Question WHERE id_question = {0}",
                          id
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

      return null;
    }
  }
}