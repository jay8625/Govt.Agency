﻿using System;

namespace Govt.Agency.Services
{
    public class vwCreateView
    {
        //Primary key
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
