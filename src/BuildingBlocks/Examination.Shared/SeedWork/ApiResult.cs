using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examination.Shared.SeedWork
{
    public class ApiResult<T>
    {
        public bool IsSuccessed { get; set; }
        public string Message { get; set; }
        public T ResultObj { get; set; }
        public int StatusCode { get; set; }

        public ApiResult()
        {
        }
        public ApiResult(int statusCode, bool isSuccessed, string message = null)
        {
            StatusCode = statusCode;
            Message = message;
            IsSuccessed = isSuccessed;
        }
        public ApiResult(int statusCode, bool isSuccessed, T resultObj, string message = null)
        {
            StatusCode = statusCode;
            ResultObj = resultObj;
            Message = message;
            IsSuccessed = isSuccessed;
        }
    }
}