using System;
using System.Collections.Generic;

namespace DevStore.Application
{
    public class ResponseObject
    {
        public ResponseObject()
        {
            Messages = new List<string>();
        }

        public ResponseObject(bool status, string message, Object obj)
        {
            Messages = new List<string> { message };
            Object = obj;
            Status = status;
        }

        public ResponseObject(bool status,string message)
        {
            Messages = new List<string>{message};
            Status = status;
        }
        public List<String> Messages { get; set; }
        public Boolean Status { get; set; }
        public Object Object { get; set; }
        public List<Object> Objects { get; set; }
    }
}
