using System;
using System.Collections.Generic;

namespace CastExtensions.OldExtensions
{
    public static class ExceptionExtension
    {
        public static IEnumerable<Exception> EnumerateInnerExceptions(this Exception exception)
        {
            Exception innerException = exception.InnerException;
            while (innerException != null)
            {
                yield return innerException;
                innerException = innerException.InnerException;
            }
        }
    }
}
