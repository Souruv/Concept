using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace CF.ProjectService.Application.Common.Exceptions
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
        public static readonly KeyValuePair<string, string> ProjectNotFound = new KeyValuePair<string, string>("PROJECT_NOTFOUND", "Project not found");
        public static readonly KeyValuePair<string, string> ProjectCanNotDraft = new KeyValuePair<string, string>("PROJECT_DRAFT", "Can not save draft this project");
        public static readonly KeyValuePair<string, string> UserPermissionAction = new KeyValuePair<string, string>("USER_PERMISSION_ACTION", "You do not have permission to do this action");
        public static readonly KeyValuePair<string, string> SomeThingWrong = new KeyValuePair<string, string>("SOMETHING_INVALID", "Have something invalid, please check again.");

    }
}
