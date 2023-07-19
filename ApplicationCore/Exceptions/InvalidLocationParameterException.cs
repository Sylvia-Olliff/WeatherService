using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Exceptions;

public class InvalidLocationParameterException : Exception
{
    public InvalidLocationParameterException(string message) : base(message) { }
    public InvalidLocationParameterException(string message,  Exception innerException) : base(message, innerException) { }
}
