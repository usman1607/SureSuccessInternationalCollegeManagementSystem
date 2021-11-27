using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SSICMS.Core.Domain.Entities;

namespace SSICMS.Core.Data.EntityTypeConfigurations
{
    public class StudentEntityTypeConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Students");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.FirstName)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(s => s.LastName)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(s => s.PhoneNumber)
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder.Property(s => s.Email)
                .HasColumnType("varchar(50)")
                .IsRequired();

    

            builder.Property(s => s.Address)
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder.Property(s => s.Country)
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder.Property(s => s.State)
                .HasColumnType("varchar(50)")
                .IsRequired();
        }
    }
}
