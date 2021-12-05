using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace CF.ConceptBrainService.Application.Common.Exceptions
{
    public class CustomException : Exception
    {
        public string EKey { get; set; }
        public string EMessage { get; set; }
        public CustomException(string key, string message) : base(message)
        {
            EKey = key;
            EMessage = message;
        }

    }
    public class ExceptionHelper
    {
        public static void ThrowCustomException(string key, string message, HttpStatusCode code = HttpStatusCode.BadRequest)
        {
            var exception = new CustomException(key, message);
            exception.Data.Add(key, message);
            exception.Data.Add("HttpStatusCode", code);
            throw exception;
        }

        public static void ThrowCustomException(KeyValuePair<string, string> error, HttpStatusCode code = HttpStatusCode.BadRequest)
        {
            ThrowCustomException(error.Key, error.Value, code);
        }


    }

    public class ExceptionMessages
    {
        public static readonly KeyValuePair<string, string> ProjectNameAlreadyInUse = new KeyValuePair<string, string>("PROJECT_NAME_INUSE", "File name is already in use. Please enter another name.");
        public static readonly KeyValuePair<string, string> UserAlreadyExists = new KeyValuePair<string, string>("USER_ALREADY_EXISTS", "User already exists in system.");

    }

    public class CustomResponse<T>
    {
        public T Data { get; set; }
        public string Message { get; set; }
        public bool IsSucceed { get; set; } = false;
        public List<KeyValuePair<string, string>> Errors { get; set; } = new List<KeyValuePair<string, string>>();

    }
}
