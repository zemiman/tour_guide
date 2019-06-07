using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace myAppbest.model
{
    class RegistrationTable
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(254)]
        public string fname { get; set; }
        public string lname { get; set; }
        public string username { get; set; }
        public string password { get; set; }
    }
}
