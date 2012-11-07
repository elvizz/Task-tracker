using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Qulix.Models.Repository;

namespace Qulix.Models
{
    /// <summary>
    /// Класс уровня доступа к данным
    /// </summary>
    public class DAL
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;
        private static SqlConnection _sqlConnection;
        private static StateRepository _stateRepository;
        private static TaskRepository _taskRepository;
        private static UserRepository _userRepository;

        /// <summary>
        /// Строка подключения к бд
        /// </summary>
        public static SqlConnection getConnection{
            get
        {
            if (_sqlConnection==null)
                _sqlConnection = new SqlConnection(connectionString);
            return _sqlConnection;
        }}

        /// <summary>
        /// Статическое свойство для доступа к классу работы с данными сущности State
        /// </summary>
        public static StateRepository State
        {
            get{
                if (_stateRepository==null)
                   return _stateRepository = new StateRepository();
                return _stateRepository;
            }
        }

        /// <summary>
        /// Статическое свойство для доступа к классу работы с данными сущности Task
        /// </summary>
        public static TaskRepository Task
        {
            get
            {
                if (_taskRepository==null)
                  return  _taskRepository = new TaskRepository();
                return _taskRepository;
            }
        }

        /// <summary>
        /// Статическое свойство для доступа к классу работы с данными сущности Task
        /// </summary>
        public static UserRepository User
        {
            get
            {
                if (_userRepository == null)
                    return _userRepository = new UserRepository();
                return _userRepository;
            }
        }
    }
}