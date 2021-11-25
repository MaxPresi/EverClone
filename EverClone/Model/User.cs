using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace EverClone.Model
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }
        [MaxLength(20)]
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
