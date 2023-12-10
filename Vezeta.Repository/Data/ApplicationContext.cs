using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Vezeeta.Core.Entities;

namespace Vezeeta.Repository.Data
{
    public class ApplicationContext : IdentityDbContext<User>
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Booking>(U =>
            {
                U.HasOne(s => s.Patient).WithMany(s => s.Bookings)
                .HasForeignKey(s => s.PatientId).OnDelete(DeleteBehavior.Restrict);

                U.HasOne(s => s.Doctor).WithMany(s => s.Bookings)
                .HasForeignKey(s => s.DoctorId).OnDelete(DeleteBehavior.Restrict);
            });
           
    

            modelBuilder.Entity<User>()
            .Property(e => e.UserName)
            .HasMaxLength(250);

            modelBuilder.Entity<User>()
            .Property(e => e.UserName)
            .HasMaxLength(250);
        }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
        public DbSet<User> Users{ get; set; }
    }
}
