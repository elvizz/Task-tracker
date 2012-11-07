using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Qulix.Models.Repository
{
    /// <summary>
    /// Репозиторий для работы с данными сущности Tasks
    /// </summary>
    public class TaskRepository
    {
        SqlConnection _sqlConn = DAL.getConnection;

        /// <summary>
        /// Возвращает весь список задач из таблицы Tasks
        /// </summary>
        /// <returns></returns>
        public List<Tasks> GetTasks()
        {
            List<Tasks> Tasks = new List<Tasks>();

            try
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Tasks",_sqlConn);
                _sqlConn.Open();
                SqlDataReader reader= command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Tasks.Add(new Tasks(
                                      reader.GetGuid(0), reader["Title"].ToString(), reader["Job"].ToString(),
                                      (DateTime) reader["StartedOn"], (DateTime) reader["Finished"], reader.GetInt32(5),
                                      reader.GetGuid(6)));
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

            return Tasks;
        }

        /// <summary>
        /// Возвращает задачу по идентификатору
        /// </summary>
        /// <param name="taskId">Идентификатор, тип Guid</param>
        /// <returns></returns>
        public Tasks GetTaskById(Guid taskId)
        {
            Tasks task=new Tasks();

            try
            {
                SqlCommand sqlCommand = new SqlCommand(string.Format("Select * FROM Tasks Where [TaskId]='{0}'", taskId), _sqlConn);
                _sqlConn.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        task = new Tasks(
                            reader.GetGuid(0), reader["Title"].ToString(), reader["Job"].ToString(),
                            (DateTime) reader["StartedOn"], (DateTime) reader["Finished"], reader.GetInt32(5),
                            reader.GetGuid(6));
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (_sqlConn.State == ConnectionState.Open)
                {
                    _sqlConn.Close();
                } 
            }

            return task;
        }

        /// <summary>
        /// Удаляет задачу по идентификатору
        /// </summary>
        /// <param name="taskId">Идентификатор, тип Guid</param>
        public void DeleteTask(Guid taskId)
        {
            try
            {
                SqlCommand command = new SqlCommand(string.Format("DELETE FROM Tasks Where [TaskId]='{0}'", taskId), _sqlConn);
                _sqlConn.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (_sqlConn.State == ConnectionState.Open)
                {
                    _sqlConn.Close();
                }
            }
        }

        /// <summary>
        /// Обновление данных задачи
        /// </summary>
        /// <param name="task">Сущность Tasks</param>
        public void UpdateTask(Tasks task)
        {
            try
            {
                SqlCommand command = new SqlCommand(
                        string.Format(
                            "UPDATE Tasks SET Title='{0}',Job='{1}',StartedOn='{2}',Finished='{3}',StateId='{4}',PersonId='{5}' WHERE [TaskId]='{6}'",
                            task.Title,task.Job,task.StartedOn,task.Finished,task.StateId,task.PersonId,task.TaskId), _sqlConn);
                _sqlConn.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (_sqlConn.State == ConnectionState.Open)
                {
                    _sqlConn.Close();
                }
            }
        }

        /// <summary>
        /// Создание новой задачи
        /// </summary>
        /// <param name="task">Сущность Tasks</param>
        public void CreateTask(Tasks task)
        {
            try
            {
                SqlCommand command =
                    new SqlCommand(string.Format("INSERT INTO Tasks VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", Guid.NewGuid(),
                                                 task.Title, task.Job, task.StartedOn,task.Finished,task.StateId,task.PersonId), _sqlConn);
                _sqlConn.Open();
                command.ExecuteNonQuery();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (_sqlConn.State == ConnectionState.Open)
                {
                    _sqlConn.Close();
                }
            }
        }
    }
}