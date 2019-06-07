﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace myAppbest.model
{
    public class Post
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(254)]
        public string Exprience { get; set; }
        public string VenueName { get; set; }
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Address { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int Distance { get; set; }
    }
}
