using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Proiect.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect.DAL.Configurations
{
    public class DesignerConfiguration : IEntityTypeConfiguration<Designer>
    {
        public void Configure(EntityTypeBuilder<Designer> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasColumnType("varchar(100)").HasMaxLength(100);
            builder.Property(x => x.Gender).HasColumnType("varchar(30)").HasMaxLength(30);
        }
    }
}
