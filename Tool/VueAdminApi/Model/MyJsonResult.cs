﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VueAdminApi.Model
{
    public class MyJsonResult
    {
        public int code { get; set; }

        public string message { get; set; }

        public object data { get; set; }

    }
}
