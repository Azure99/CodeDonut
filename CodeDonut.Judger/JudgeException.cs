﻿using System;

namespace CodeDonut.Judger
{
    public class TimeLimitExceedException : ApplicationException
    {
        TimeLimitExceedException(string message) : base(message){ }
    }

    public class RuntimeErrorException : ApplicationException
    {
        public string ErrorDetail { get; set; }
        public RuntimeErrorException(string message, string errorDetail) : base(message)
        {
            ErrorDetail = errorDetail;
        }
    }
}
