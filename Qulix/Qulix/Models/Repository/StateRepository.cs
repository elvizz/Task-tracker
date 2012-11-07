using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Qulix.Models.Repository
{
    /// <summary>
    /// Репозиторий для работы с данными сущности States
    /// </summary>
    public class StateRepository
    {
        /// <summary>
        /// Возвращает список состояний
        /// </summary>
        /// <returns></returns>
        public List<States> GetStates()
        {
            List<States> states = new List<States>();
            SqlConnection sqlConn = DAL.getConnection;

            try
            {
                SqlCommand command = new SqlCommand("SELECT * FROM States", sqlConn);
                sqlConn.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        states.Add(new States(reader.GetInt32(0), reader["Title"].ToString()));
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (sqlConn.State == ConnectionState.Open)
                {
                    sqlConn.Close();
                }
            }
            return states;
        } 

    }
}