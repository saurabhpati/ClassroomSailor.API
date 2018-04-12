using System;
using ClassroomSailor.API.Models.Common;
using ClassroomSailor.Entities.Subject;

namespace ClassroomSailor.API.Models.Subject
{
    public class SubjectApiModel : SubjectEntity, IApiModel
    {
        public String Url { get; set; }
    }
}
