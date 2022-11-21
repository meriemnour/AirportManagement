using AM.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Infrastructure.Configurations
{
    public class PassengerConfiguration : IEntityTypeConfiguration<Passenger>
    {
        public void Configure(EntityTypeBuilder<Passenger> builder)
        {   //type detenue bech nkoulou ili heki teb3a l classe ama mech table
            //ownsone methode (type ki apparttient lel passenger ,congfiguration fel classe qu'il l'appartient)
            builder.OwnsOne(p => p.FullName, full =>
            {
                full.Property(f => f.FirstName).HasColumnName("PassFirstName").HasMaxLength(30);
                full.Property(f => f.LastName).HasColumnName("PassLastName").IsRequired();
            });
            //tp5
            //configurer l'héritage TPH(table par hierarchie)
            /*builder.HasDiscriminator<int>("IsTraveller")
                .HasValue<Passenger>(0)
                .HasValue<Traveller>(1)
                .HasValue<Staff>(2);*/


        }
    }
}
