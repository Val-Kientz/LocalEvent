using SQLite;
using System;

namespace LocalEventReminder.Models
{
    public class LocalEvent
    {
        [PrimaryKey, AutoIncrement]

        public int ID { get; set; }
        public string EventName { get; set; }
        public string Description { get; set; }
        public string URL { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
