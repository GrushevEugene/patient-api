using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace patient_api.Models
{
    public partial class PatientDbContext : DbContext
    {
        public PatientDbContext()
        {
        }

        public PatientDbContext(DbContextOptions<PatientDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Name> Name { get; set; } = null!;
        public virtual DbSet<Patient> Patient { get; set; } = null!;

    }
}
