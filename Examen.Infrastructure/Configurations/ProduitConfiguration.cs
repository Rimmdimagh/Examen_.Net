using Examen.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.Infrastructure.Configurations
{
    public class ProduitConfiguration : IEntityTypeConfiguration<Produit>
    {
        

        public void Configure(EntityTypeBuilder<Produit> builder)
        {
            //clé etranger avec le fluent API
            builder.HasOne(f => f.categories).WithMany(p => p.ProduitList)
                .HasForeignKey(k => k.CategorieFK)
                .OnDelete(DeleteBehavior.Cascade);

            //Fluent API question a:
            builder.HasMany(f => f.fournisseurs).WithMany(p => p.produits)
                .UsingEntity(p => p.ToTable("Facture"));
            //Fluent API question b:
            builder.HasDiscriminator<char>("Discriminator")
                .HasValue<Produit>('P')
                .HasValue<Chimique>('C')
                .HasValue<Biologique>('B');

            


        }
    }
}
