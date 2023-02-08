using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkyfriSample.Dto
{

    public class Response<T>
    {

        public Response() => IsSuccess = true;
        public Response<T> SetError(string message)
        {
            IsSuccess = false;
            Message = message;
            return this;
        }
        public bool IsSuccess { get; set; }
        public T Result { get; set; }
        public string Message { get; set; }
        public int ResponseCode { get; set; }
    }

}
