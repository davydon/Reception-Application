//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ReceptionApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public partial class Department
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string DepartmentName { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string Intercom { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string Floor { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string HOD { get; set; }
    }
}