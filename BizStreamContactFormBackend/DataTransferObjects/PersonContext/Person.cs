using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BizStreamContactFormBackend.DataTransferObjects.PersonContext
{
    public class Person
    {
        [Key]
        public int PersonId { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Your first name must be 100 characters or less.")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Your last name must be 100 characters or less.")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please enter your email.")]
        [RegularExpression("^[A-Za-z0-9]{1,30}@[a-zA-Z0-9]{1,10}.[a-z]{2,3}$", ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter a message.")]
        [StringLength(250, ErrorMessage = "Your message must be 250 characters or less.")]
        public string Message { get; set; }
    }
}
