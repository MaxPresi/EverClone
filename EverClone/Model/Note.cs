using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace EverClone.Model
{
    public class Note
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [Indexed]
        public int NotebookId { get; set; }
        [MaxLength(50)]
        public string Title { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public string FilePath { get; set; }
    }
}
