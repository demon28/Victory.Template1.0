﻿using System;
using System.Collections.Generic;
using System.Text;

namespace YH.VictoryTemp.Entity.Model
{
    public class JwtModel
    {
        public string ApiKey { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
    }

}
