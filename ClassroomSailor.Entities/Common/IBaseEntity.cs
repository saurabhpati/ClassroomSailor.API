using System;
using System.ComponentModel.DataAnnotations;

namespace ClassroomSailor.Entities.Common
{
    public interface IBaseEntity
    {
        [Key]
        Int64 Id { get; set; }
    }
}
