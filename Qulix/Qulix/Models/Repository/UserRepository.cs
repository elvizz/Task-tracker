using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Qulix.Models.Repository
{
    /// <summary>
    /// Репозиторий для работы с данными сущности Users
    /// </summary>
    public class UserRepository
    {
       private SqlConnection _sqlConn = DAL.getConnection;

        /// <summary>
        /// Возвращает всех исполнителей
        /// </summary>
        /// <returns></returns>
       public List<Users> GetUsers()
       {
           List<Users> users = new List<Users>();
           try
           {
               SqlCommand command = new SqlCommand("SELECT * FROM Users", _sqlConn);
               _sqlConn.Open();
               SqlDataReader reader = command.ExecuteReader();
               if (reader.HasRows)
               {
                   while (reader.Read())
                   {
                       users.Add(new Users(reader.GetGuid(0), reader["FirstName"].ToString(),
                                           reader["LastName"].ToString(), reader["ThirdName"].ToString()));
                   }
               }
           }
           catch (Exception)
           {
               throw;
           }
           finally
           {
               if (_sqlConn.State==ConnectionState.Open)
               {
                   _sqlConn.Close();
               }
           }
           return users;
       }

        /// <summary>
        /// Возвращает исполнителя по идентификатору
        /// </summary>
        /// <param name="userId">Идентификатор, тип Guid</param>
        /// <returns></returns>
       public Users GetUserById(Guid userId)
       {
           Users user = new Users();

           try
           {
               SqlCommand command = new SqlCommand(string.Format("Select * FROM Users Where [UserId]='{0}'", userId),_sqlConn);
               _sqlConn.Open();
               SqlDataReader reader = command.ExecuteReader();
               if (reader.HasRows)
               {
                   while (reader.Read())
                   {
                       user = new Users(reader.GetGuid(0), reader["FirstName"].ToString(), reader["LastName"].ToString(),
                                        reader["ThirdName"].ToString());
                   }
               }
           }
           catch (Exception)
           {
               throw;
           }
           finally
           {
               if (_sqlConn.State==ConnectionState.Open)
               {
                   _sqlConn.Close();
               }   
           }
           return user;
       }

        /// <summary>
        /// Добавление нового исполнителя
        /// </summary>
        /// <param name="user">Сущность Users</param>
       public void CreateUser(Users user)
       {
           try
           {
               SqlCommand command =
                   new SqlCommand(string.Format("INSERT INTO Users VALUES('{0}','{1}','{2}','{3}')", Guid.NewGuid(),
                                                user.FirstName, user.LastName, user.ThirdName),_sqlConn);
               _sqlConn.Open();
               command.ExecuteNonQuery();

           }
           catch (Exception)
           {
               throw;
           }
           finally
           {
            if(_sqlConn.State==ConnectionState.Open)
            {
                _sqlConn.Close();
            }   
           }
       }

        /// <summary>
        /// Удаление пользователя по индентификатору
        /// </summary>
        /// <param name="userId">Идентификатор, тип Guid</param>
       public void DeleteUser(Guid userId)
       {
           try
           {
               SqlCommand deleteUserTasks = new SqlCommand(string.Format("DELETE FROM Tasks Where [PersonId]='{0}'", userId), _sqlConn);
               SqlCommand deleteUser = new SqlCommand(string.Format("DELETE FROM Users Where [UserId]='{0}'",userId),_sqlConn);
               _sqlConn.Open();
               deleteUserTasks.ExecuteNonQuery();
               deleteUser.ExecuteNonQuery();
           }
           catch (Exception)
           {
               throw;
           }
           finally
           {
               if (_sqlConn.State==ConnectionState.Open)
               {
                   _sqlConn.Close();
               }
           }
       }

        /// <summary>
        /// Обновление данных исполнителя
        /// </summary>
        /// <param name="user">Сушность Users</param>
       public void UpdateUser(Users user)
       {
           try
           {
               SqlCommand command = new SqlCommand(
                       string.Format(
                           "UPDATE Users SET FirstName='{0}',LastName='{1}',ThirdName='{2}' WHERE [UserId]='{3}'",
                           user.FirstName, user.LastName, user.ThirdName, user.UserId),_sqlConn);
               _sqlConn.Open();
               command.ExecuteNonQuery();
           }
           catch (Exception)
           {
               throw;
           }
           finally
           {
               if (_sqlConn.State==ConnectionState.Open)
               {
                   _sqlConn.Close();
               }
           }
       }
    }
}