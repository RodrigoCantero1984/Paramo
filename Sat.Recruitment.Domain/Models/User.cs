using System;
using System.Collections.Generic;
using System.Text;

namespace Sat.Recruitment.Domain.Models
{
    public class User: BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int UserType { get; set; }
        public decimal Money { get; set; }
    }
}
