using System;
using System.ComponentModel.DataAnnotations;

namespace ClassroomSailor.Entities.Common
{
    public class BaseEntity
    {
        [Key]
        public Int64 Id { get; set; }
    }
}
