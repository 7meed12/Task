using System.ComponentModel.DataAnnotations;

namespace Models.Identity
{
    public class Address
    { 
        public int Id { get; set; }
        [Required(ErrorMessage = "First Name Is Required"), Display(Name = "First Name"), StringLength(50), RegularExpression(pattern: @"[a-zA-Z0-9\s]{3,}",
                        ErrorMessage = "name must be char only and more than 2 characters")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name Is Required"), Display(Name = "Last Name"), StringLength(50), RegularExpression(pattern: @"[a-zA-Z0-9\s]{3,}",
                          ErrorMessage = "name must be char only and more than 2 characters")]
        public string LastName { get; set; }
        [StringLength(50), RegularExpression(pattern: @"[a-zA-Z0-9\s]{3,}",
                       ErrorMessage = "Street must be char only and more than 2 characters")]
        public string Street { get; set; }
        [Required, StringLength(50), RegularExpression(pattern: @"[a-zA-Z0-9\s]{3,}",
                      ErrorMessage = "City must be char only and more than 2 characters")]
        public string City { get; set; }
        [Required, StringLength(50),
            RegularExpression(pattern: @"[a-zA-Z0-9\s]{3,}",
                         ErrorMessage = "State must be char only and more than 2 characters")]
        public string State { get; set; }
        [Required]
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }

    }
}