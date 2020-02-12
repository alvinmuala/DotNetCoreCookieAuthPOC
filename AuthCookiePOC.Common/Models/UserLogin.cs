using System;
using System.ComponentModel.DataAnnotations;

namespace AuthCookiePOC.Common.Models
{
    public class UserLogin
    {
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "Username")]
        [StringLength(12, ErrorMessage = "User name length can't be more than 12 characters long")]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]

        public string Password { get; set; }
    }
}
