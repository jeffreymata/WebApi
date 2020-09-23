using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApiInventario.Features.Models;

namespace WebApiInventario.Features.Models
{
    public class DetailsMap:IEntityTypeConfiguration<EquipmentDetail>
    {
        public void Configure(EntityTypeBuilder<EquipmentDetail> builder)
        {
            builder.ToTable(" Details", "dbo");
            builder.HasKey(q => q.Id);
            builder.Property(e => e.Id).IsRequired().UseSqlServerIdentityColumn();
            builder.HasOne(e => e.Equipments)
                .WithMany(e => e.DetailsList)
                .HasForeignKey(e => e.idEquipo);
            
            

            
        }
    }
}
