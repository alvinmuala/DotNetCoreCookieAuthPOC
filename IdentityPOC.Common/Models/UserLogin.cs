using System;
using System.ComponentModel.DataAnnotations;

namespace IdentityPOC.Common.Models
{
    public class UserLogin
    {
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "Usercode")]
        [StringLength(6, ErrorMessage = "User Code length can't be more than 6 characters long")]
        public string Usercode { get; set; }
        [Required]
        [DataType(DataType.Password)]

        public string Password { get; set; }
    }
}
