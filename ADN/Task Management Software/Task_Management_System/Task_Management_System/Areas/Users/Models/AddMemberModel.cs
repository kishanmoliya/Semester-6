using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Newtonsoft.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace Task_Management_System.Areas.Users.Models
{
    public class AddMemberModel
    {
        public int MemberID { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "USERNAME_TOO_SHORT")]
        [MaxLength(50, ErrorMessage = "USERNAME_TOO_LONG")]
        public string MemberName { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Phone Number Required!")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
                      ErrorMessage = "Entered Contact format is not valid.")]
        public string MemberContact { get; set; }

        [Required]
        [EmailAddress]
        public string MemberEmail { get; set; }

        [Required]
        public string MemberRole { get; set; }

        [Required]
        public string MemberTechnology { get; set; }

        [Required(ErrorMessage = "Please enter your age.")]
        [Range(15, 80, ErrorMessage = "Age must be between 18 and 100.")]
        public int MemberAge { get; set; }

        [Required(ErrorMessage = "Please enter your age.")]
        [Range(5000, 10000000, ErrorMessage = "Age must be between 5000 and 10000000.")]
        public double MemberSalary { get; set; }
    }
}
