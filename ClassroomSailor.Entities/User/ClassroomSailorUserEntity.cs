using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace ClassroomSailor.Entities.User
{
    public class ClassroomSailorUserEntity : IdentityUser, IClassroomSailorUserEntity
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
    }
}
