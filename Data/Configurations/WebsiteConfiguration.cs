using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResidentBookmark.Models;

namespace ResidentBookmark.Data.Configurations
{
    public class WebsiteConfiguration : IEntityTypeConfiguration<Website>
    {
        /* The class implements the IEntityTypeConfiguration<TEntity> interface, which has one method: Configure. 
        Configurations are defined in this method. */
        public void Configure(EntityTypeBuilder<Website> builder)
        {
            // The Location property is mapped to the database column named "Url".
            builder.Property(p => p.Location).HasColumnName("Url");
        }
    }
}