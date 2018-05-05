using System;
using ClassroomSailor.Entities.User;

namespace ClassroomSailor.API.Models.User
{
    public class ClassroomSailorUserApiModel :  ClassroomSailorUserEntity
    {
        public String Role { get; set; }

        public String Password { get; set; }
    }
}
