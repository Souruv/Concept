using System;
using System.Collections.Generic;
using System.Text;

namespace CF.ConceptBrainService.Application.Common.Response
{
    public class CustomResponse<T>
    {
        public T Data { get; set; }
        public string Message { get; set; }
        public bool IsSucceed { get; set; } = false;
        public List<KeyValuePair<string, string>> Errors { get; set; } = new List<KeyValuePair<string, string>>();


    }
}
