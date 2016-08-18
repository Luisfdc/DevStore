﻿using System.Data.Entity.ModelConfiguration;
using DevStore.Domain;

namespace DevStore.Infra.Mapping
{
    public class ProductMap : EntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
            ToTable("Product");
            HasKey(x => x.Id);
            Property(x => x.Title).HasMaxLength(160).IsRequired();
            Property(x => x.Price).IsRequired();
            Property(x => x.AquireDate).IsRequired();
            HasRequired(x => x.Category);
        }
    }
}
