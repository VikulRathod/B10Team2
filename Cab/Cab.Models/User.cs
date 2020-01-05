﻿using MyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cab.Models
{
    public class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public int RetryAttempts { get; set; }
        public bool IsAuthenticated { get; set; }
        public bool IsAccountLocked { get; set; }
        public List<addCityName> CityName { get; set; }

        public int Mobile { get; set; }
    }
}
