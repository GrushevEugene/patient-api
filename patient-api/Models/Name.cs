using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace patient_api.Models
{
    [Table("name")]
    public partial class Name
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }
        [Column("use")]
        [StringLength(255)]
        public string? Use { get; set; }
        [Required]
        [Column("family")]
        [StringLength(255)]
        public string? Family { get; set; }
        [Column("given")]
        public string[]? Given { get; set; }

    }
}
