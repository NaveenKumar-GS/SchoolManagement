using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Schoolmanagementn.Models
{
    public class RegistrationViewModel
    {
        [Required(ErrorMessage = " User Id is Required")]
        [RegularExpression(@"^\(?([SMU]{3})\)?[-.]?([0-9]{1})[-.]?([0-9]{3})$", ErrorMessage = "It's wrong " +"! "+"Ask your Admin for your User Id   EX:SMU0101 ")]
        public string UserId { get; set; }
        [Required(ErrorMessage ="Please Enter your Full Name")]
        [DataType(DataType.Text)]
        public string FullName { get; set; }
        [Required(ErrorMessage ="Please Select Role Here")]
        public string Role { get; set; }

        [Required(ErrorMessage = "Phone Number is Required")]
          
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Entered Phone Number is not valid.")]
        public string PhoneNumber { get; set; }
        
        [Required]
        
        [RegularExpression(@"(?=.*\d)(?=.*[A-Za-z]).{8,}", ErrorMessage = "Your password must be at least 8 characters long and contain at least 1 letter and 1 number")]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^([0-9a-zA-Z]([\+\-_\.][0-9a-zA-Z]+)*)+@(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]*\.)+[a-zA-Z0-9]{2,3})$", ErrorMessage = "Your email address is not in a valid format. Example of correct format: joe.example@example.org")]
        public string EmailId { get; set; }
    }
}