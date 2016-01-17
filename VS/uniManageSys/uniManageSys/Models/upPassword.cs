using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace uniManageSys.Models
{
    public class upPassword
    {
        [Required]
        public string newPassword { get; set; }
        [Required]
        [Compare("newPassword")]
        public string confirmPassword { get; set; }
        [Required]
        public string oldPassword { get; set; }
    }
}