﻿using System;
using System.Collections.Generic;

namespace AspnetCoreBasicArchitecture.ViewModel
{
    public class UserManagerResponseViewModel
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public IEnumerable<string> Errors { get; set; }
        public DateTime? ExpireDate { get;  set; }
    }
}
