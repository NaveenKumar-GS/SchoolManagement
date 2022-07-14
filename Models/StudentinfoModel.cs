using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Schoolmanagementn.Models
{
    public class StudentinfoModel
    {
        [Required(ErrorMessage = " StudentId is Required")]
        [MaxLength(6)]
        public string StudentId { get; set; }
        [Required(ErrorMessage = "FullName is Required")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "FatherName  is Required")]
        public string FatherName { get; set; }
        [Required(ErrorMessage = "MotherName is Required")]
        public string MotherName { get; set; }
        public System.DateTime DateOfBirth { get; set; }
        [Range(5, 16, ErrorMessage = "” your age must be greater than 5 and less than 16")]
        public int Age { get; set; }
        [Required(ErrorMessage = "Gender is Required")]
        [StringLength(6, ErrorMessage = "Do not enter more than 6 characters")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Phone number is Required")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Entered Phone Number is not valid.")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Address  is Required")]
        public string Address { get; set; }
        public System.DateTime DateOfAdmission { get; set; }
        public string ClassName { get; set; }
        public string Religion { get; set; }
        public string Nationality { get; set; }
        public string State { get; set; }

    }
}