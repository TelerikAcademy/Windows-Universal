using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SQLiteApp.Models
{
    [Table("Articles")]
    public class Article
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        [Unique, MaxLength(150)]
        public string Title { get; set; }

        public string Content { get; set; }
    }
}
