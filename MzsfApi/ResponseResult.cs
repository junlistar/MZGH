using System;
using System.ComponentModel;
using System.Reflection;

namespace MzsfApi
{
    public class ResponseResult<T>
    {
        /// <summary>
        /// 状态结果
        /// </summary>
        public ResultStatus Status { get; set; } = ResultStatus.Success;

        private string? _msg;

        /// <summary>
        /// 消息描述
        /// </summary>
        public string? Message
        {
            get
            {
                return !string.IsNullOrEmpty(_msg) ? _msg : EnumExtension.GetDescription(Status);
            }
            set
            {
                _msg = value;
            }
        }

        /// <summary>
        /// 返回结果
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// 成功状态返回结果
        /// </summary>
        /// <param name="result">返回的数据</param>
        /// <returns></returns>
        public static ResponseResult<T> SuccessResult(T data)
        {
            return new ResponseResult<T> { Status = ResultStatus.Success, Data = data };
        }

        /// <summary>
        /// 失败状态返回结果
        /// </summary>
        /// <param name="code">状态码</param>
        /// <param name="msg">失败信息</param>
        /// <returns></returns>
        public static ResponseResult<T> FailResult(string? msg = null)
        {
            return new ResponseResult<T> { Status = ResultStatus.Fail, Message = msg };
        }

        /// <summary>
        /// 异常状态返回结果
        /// </summary>
        /// <param name="code">状态码</param>
        /// <param name="msg">异常信息</param>
        /// <returns></returns>
        public static ResponseResult<T> ErrorResult(string? msg = null)
        {
            return new ResponseResult<T> { Status = ResultStatus.Error, Message = msg };
        }

        /// <summary>
        /// 自定义状态返回结果
        /// </summary>
        /// <param name="status"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public static ResponseResult<T> Result(ResultStatus status, T data, string? msg = null)
        {
            return new ResponseResult<T> { Status = status, Data = data, Message = msg };
        }

        /// <summary>
        /// 隐式将T转化为ResponseResult<T>
        /// </summary>
        /// <param name="value"></param>
        public static implicit operator ResponseResult<T>(T value)
        {
            return new ResponseResult<T> { Data = value };
        }
    }
    public enum ResultStatus
    {
        [Description("请求成功")]
        Success = 1,
        [Description("请求失败")]
        Fail = 0,
        [Description("请求异常")]
        Error = -1
    }

    /// <summary>
    /// 枚举扩展类
    /// </summary>
    public static class EnumExtension
    {
        /// <summary>
        /// 获取枚举描述
        /// </summary>
        /// <param name="en"></param>
        /// <returns></returns>
        public static string GetDescription(this Enum en)
        {
            Type type = en.GetType();
            FieldInfo fd = type.GetField(en.ToString());
            if (fd == null)
                return string.Empty;
            object[] attrs = fd.GetCustomAttributes(typeof(DescriptionAttribute), false);
            string name = string.Empty;
            foreach (DescriptionAttribute attr in attrs)
            {
                name = attr.Description;
            }
            return name;
        }
    }
}
