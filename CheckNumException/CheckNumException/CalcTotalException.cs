using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckNumException
{
    public class CalcTotalException : Exception
    {
        public CalcTotalException()
        {

        }

        public CalcTotalException(string message) : base(message)
        {

        }

        public CalcTotalException(string message, Exception innerException) : base(message, innerException)
        {

        }

        public override string Message
        {
            get
            {
                return "警告！" + base.Message;
            }
        }
    }
}
