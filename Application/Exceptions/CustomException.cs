﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class CustomException : Exception
    {
        public int StatusCode { get; set; }
        public CustomException(string? message, int StatusCode) : base(message)
        {
            this.StatusCode = StatusCode;
        }
    }
}
