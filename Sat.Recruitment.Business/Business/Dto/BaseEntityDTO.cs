using Sat.Recruitment.IBusiness.IDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sat.Recruitment.Business.Dto
{
    public class BaseEntityDTO : IBaseEntityDTO
    {
        public long Id { get; set; }
    }
}