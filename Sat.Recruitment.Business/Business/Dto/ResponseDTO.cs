using Sat.Recruitment.IBusiness.IDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sat.Recruitment.Business.Dto
{
    public class ResponseDTO<T> : IResponseDTO<T> where T : class
    {
        public T Data { get; set; }
        public List<string> Messages { get; set; } = new List<string>();
    }
}
