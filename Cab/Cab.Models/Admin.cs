﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Models
{
   public class Admin
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public int RetryAttempts { get; set; }
        public bool IsAuthenticated { get; set; }
        public bool IsAccountLocked { get; set; }
        public string Pending { get; set; }
        public string DriverAssigned { get; set; }
        public string Completed { get; set; }
        public int SelecteStatusID { get; set; }
        public string SelectStatusName { get; set; }
        public string Status { get; set; }


    }
}
