using System;
using System.Collections.Generic;
using System.Text;
//using SQLite;
//using SQLite.Net.Attributes;

namespace ServiceReminder.Models
{
    public class ReminderItem
    {
        public ReminderItem()
        {
                
        }

        //[PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsReminderEnabled { get; set; }
        public string Notes { get; set; }

        public int RepeatTimeIntervalInSeconds { get; set; }
    }

}
