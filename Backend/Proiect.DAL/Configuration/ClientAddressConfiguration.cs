using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Proiect.DAL.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect.DAL.Configurations
{
    public class ClientAddressConfiguration : IEntityTypeConfiguration<ClientAddress>
    {
        public void Configure(EntityTypeBuilder<ClientAddress> builder)
        {
            builder.Property(x => x.City)
                .HasColumnType("nvarchar(100)")
                .HasMaxLength(100);
        }
    }
}

