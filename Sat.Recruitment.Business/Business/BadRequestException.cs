using System;
using System.Collections.Generic;
using System.Text;



namespace Sat.Recruitment.Business
{
    public class BadRequestException : Exception
    {
        public BadRequestException(List<string> errors)
        {
            this.Errors = errors;
        }
        public List<string> Errors { get; set; }
    }
}
