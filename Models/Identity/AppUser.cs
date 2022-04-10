
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Models.Identity
{
    public class AppUser : IdentityUser
    {
        [Required]
        public   string  DisplayName { get; set; }
        public Address Adress { get; set; }
       
       
    }
}
