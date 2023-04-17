using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserSample.Domain.Service.Core
{
    public class UserSampleResponse<T>
    {
        public UserSampleResponse(T data,string message, bool isSuccess)
        {
            Data = data;
            Message= message;
            IsSuccess = isSuccess;
        }

        public UserSampleResponse(T data,  bool isSuccess)
        {
            Data = data;
            IsSuccess = isSuccess;
        }

        public UserSampleResponse()
        {

        }

        public T Data { get; set; }
        public string Message { get; set; }
        public bool IsSuccess { get; set; }

    }
}
