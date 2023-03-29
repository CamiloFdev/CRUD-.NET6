using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prueba.Domain.AggregateRoots;
namespace Prueba.Adapters.EntityFramework.Relations
{
    internal class UserEntityConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("Id").ValueGeneratedOnAdd();
            builder.Property(x => x.FirstName).HasColumnName("FirstName").HasMaxLength(50).IsRequired();
            builder.Property(x => x.LastName).HasColumnName("LastName").HasMaxLength(50).IsRequired();
            builder.Property(x => x.Mail).HasColumnName("mail").HasMaxLength(50).IsRequired();

        }


    }
}
