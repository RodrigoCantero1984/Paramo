using Sat.Recruitment.Business.Dto;
using Sat.Recruitment.Business.Enum;
using Sat.Recruitment.IBusiness.IDto;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Sat.Recruitment.Business.DTO
{
    public class UserDTO : BaseEntityDTO, IUserDTO, IValidatableObject
    {
        [Required(ErrorMessage = "The name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The email is required")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "The address is required")]
        public string Address { get; set; }

        [Required(ErrorMessage = "The phone is required")]
        public string Phone { get; set; }

        public UserType UserType { get; set; } = UserType.Normal;

        public decimal Money { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            return results;
        }
    }
}

