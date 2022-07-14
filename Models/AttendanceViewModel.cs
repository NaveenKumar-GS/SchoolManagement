using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Xunit;
using Xunit.Sdk;

namespace Schoolmanagementn.Models
{
    public class AttendanceViewModel
    {
        public string AttendenceId { get; set; }
       
        public string FullName { get; set; }
        [Required(ErrorMessage = " Date&Time is Required")]
        public System.DateTime DateTime { get; set; }
        [Required(ErrorMessage = " Attendance is Required")]
       
        public string Attendance1 { get; set; }
    }
}