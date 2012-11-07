using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Qulix.Models
{
    /// <summary>
    /// Сущность таблицы Tasks
    /// </summary>
    public class Tasks
    {
        [Display(Name = "Номер")]
        public Guid TaskId { get; set; }

        [Required(ErrorMessage = "Введите название")]
        [Display(Name = "Название")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Введите описание работ")]
        [Display(Name = "Объем работы")]
        public string Job { get; set; }

        [Display(Name = "Дата начала (dd/mm/yyyy)")]
        [Required(ErrorMessage = "Установите дату")]
        [DataType(DataType.Date)]
        public DateTime StartedOn { get; set; }

        [Display(Name = "Дата окончания (dd/mm/yyyy)")]
        [Required(ErrorMessage = "Установите дату")]
        [DataType(DataType.Date)]
        public DateTime Finished { get; set; }

        [Display(Name = "Статус")]
        public int StateId { get; set; }

        [Display(Name = "Исполнитель")]
        [Required(ErrorMessage = "Выберите исполнителя")]
        public Guid PersonId { get; set; }

        public Tasks(){}

        public Tasks(Guid taskId, string title, string job, DateTime startedOn, DateTime finished, int stateId, Guid personId)
        {
            TaskId = taskId;
            Title = title;
            Job = job;
            StartedOn = startedOn;
            Finished = finished;
            StateId = stateId;
            PersonId = personId;
        }
    }
}