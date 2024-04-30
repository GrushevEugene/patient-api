using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace patient_api.Models
{
    [Table("patient")]
    public partial class Patient
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        public Name? Name { get; set; }

        [Column("gender")]
        [StringLength(255)]
        [EnumDataType(typeof(Values.Gender), ErrorMessage = "Value for {0} must be one of the defined values. (male | female | other | unknown)")]
        public string? Gender { get; set; }
        [Required]
        [Column("birthdate", TypeName = "timestamp without time zone")]
        public DateTime Birthdate { get; set; }
        [Column("active")]
        public bool? Active { get; set; }
        [Column("name_id")]
        public Guid? NameId { get; set; }
    }
}
