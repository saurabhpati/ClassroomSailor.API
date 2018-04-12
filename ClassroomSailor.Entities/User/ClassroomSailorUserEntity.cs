using System;
using System.ComponentModel.DataAnnotations;
using ClassroomSailor.Entities.Common;

namespace ClassroomSailor.Entities.User
{
    public class ClassroomSailorUserEntity : BaseEntity
    {
        [Required(ErrorMessage = "First name is required")]
        [StringLength(255, ErrorMessage = "First name cannot be more than 255 characters.")]
        public String FirstName { get; set; }

        [StringLength(255, ErrorMessage = "Middle name cannot be more than 255 characters")]
        public String MiddleName { get; set; }

        [Required(ErrorMessage = "First name is required")]
        [StringLength(255, ErrorMessage = "First name cannot be more than 255 characters.")]
        public String LastName { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Invalid date of birth")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        [StringLength(128, ErrorMessage = "Email cannot exceed 128 characters")]
        public String Email { get; set; }

        [StringLength(16)]
        [DataType(DataType.PhoneNumber)]
        public String ContactNumber { get; set; }
    }
}
