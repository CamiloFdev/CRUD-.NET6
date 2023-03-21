using System;
using System.Net;

namespace Prueba.Domain.others
{
    public class BusinessException : Exception
    {
        public HttpStatusCode? StatusCode { get; }

        public int? StatusCodeNumber { get; }

        public BusinessException(string message, HttpStatusCode statusCode) : this(message)
        {
            StatusCode = statusCode;
            StatusCodeNumber = (int)statusCode;
        }


        public BusinessException(string message) :
            base(message)
        { }
        public static BusinessException NotFoundWithMessage(string message)
        {
            return new BusinessException(message, HttpStatusCode.NotFound);
        }

    }
}
