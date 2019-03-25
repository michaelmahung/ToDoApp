using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace MichaelToDo
{
    public class Task
    {
        [PrimaryKey]
        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Date { get; set; }

        public bool Done { get; set; }
    }
}
