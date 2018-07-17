using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.greenland.tool.BizException
{
    public class ParameterNullOrEmptyException : ApplicationException
    {
        private Exception exception;

        public ParameterNullOrEmptyException()
        {

        }

        public ParameterNullOrEmptyException(string message) : base(message)
        {
        }

        public ParameterNullOrEmptyException(string msg, Exception innerException) : base(msg, innerException)
        {

        }
    }
}
