using System;
using System.ComponentModel;
using System.Reflection;
namespace Mzsf.ClassLib
{
    public class ResponseResult<T>
    {
        public int status { get; set; }
        public string message { get; set; }
        public T data { get; set; }
    }
     
}
