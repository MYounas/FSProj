using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace uniManageSys.Models
{
    [Table("Student")]
    public class Student
    {
        public int Id { get; set; }
        [Required]
        public string fullName { get; set; }
        [Required]
        public string userName { get; set; }
        [Required]
        //[RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Provide Valid Email")]
        public string Email { get; set; }
        [Required]
        //[StringLength(10,MinimumLength = 6)]
        //[RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9]).{6,50}$")]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        public string confirmPassword { get; set; }
        [Required]
        public string Field { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        //[StringLength(13,MinimumLength = 11)]
        public string Phone { get; set; }
        [Required]
        public string DateOfBirth { get; set; }
        [Required]
        public HttpPostedFileBase ImageUrl { get; set; }

    }
}