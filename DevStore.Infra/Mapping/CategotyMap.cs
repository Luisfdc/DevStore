using System.Data.Entity.ModelConfiguration;
using DevStore.Domain;

namespace DevStore.Infra.Mapping
{
    public class CategotyMap : EntityTypeConfiguration<Category>
    {
        public CategotyMap()
        {
            ToTable("Category");
            HasKey(x => x.Id);
            Property(x => x.Title)
                .HasMaxLength(60)
                .IsRequired();
        }
    }
}
