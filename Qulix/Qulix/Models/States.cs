using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Qulix.Models
{
    /// <summary>
    /// Сущность таблицы States
    /// </summary>
    public class States
    {
        public int StateId { get; set; }
        public string Title { get; set; }

        public States(int stateId, string title)
        {
            this.StateId = stateId;
            this.Title = title;
        }
    }
}