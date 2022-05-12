using System;
using System.ComponentModel;
using System.Reflection;
namespace Client.ClassLib
{
    public class ResponseResult<T>
    {
        public int status { get; set; }
        public string message { get; set; }
        public T data { get; set; }
    }
     
}
