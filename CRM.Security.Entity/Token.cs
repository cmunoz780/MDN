﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Security.Entity
{
    public class Token
    {
        public int TokenId { get; set; }
        public int UserId { get; set; }
        public string AuthToken { get; set; }
        public System.DateTime IssuedOn { get; set; }
        public System.DateTime ExpiresOn { get; set; }
    }
}
