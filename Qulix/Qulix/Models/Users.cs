using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Qulix.Models
{
    /// <summary>
    /// Сущность таблицы Users
    /// </summary>
    public class Users
    {
        public Guid UserId { get; set; }
        [Required(ErrorMessage = "Введите хотя бы имя")]
        [Display(Name = "Имя")]
        public string FirstName { get; set; }
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }
        [Display(Name = "Отчество")]
        public string ThirdName { get; set; }

        public Users(){}

        public Users(Guid userId, string firstName, string lastName, string thirdName)
        {
            UserId = userId;
            FirstName = firstName;
            LastName = lastName;
            ThirdName = thirdName;
        }
    }
}