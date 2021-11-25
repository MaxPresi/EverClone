using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace EverClone.Model
{
    public class Notebook
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [Indexed]
        public int UserId { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
