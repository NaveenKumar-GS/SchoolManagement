//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Schoolmanagementn
{
    using System;
    using System.Collections.Generic;
    
    public partial class Attendance
    {
        public string AttendenceId { get; set; }
        public string FullName { get; set; }
        public System.DateTime DateTime { get; set; }
        public string Attendance1 { get; set; }
    
        public virtual UserRegistration UserRegistration { get; set; }
    }
}
