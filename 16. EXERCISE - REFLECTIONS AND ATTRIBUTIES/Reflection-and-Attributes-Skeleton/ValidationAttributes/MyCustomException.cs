﻿using System;

namespace ValidationAttributes
{
    public class MyCustomException : Exception
    {
        public MyCustomException(string message)
            : base(message)
        {

        }
    }
}
