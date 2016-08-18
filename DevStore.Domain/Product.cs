using System;

namespace DevStore.Domain
{
    public class Product
    {
        public Product()
        {
            AquireDate = DateTime.Now;
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public DateTime AquireDate { get; set; }
        public bool IsActive { get; set; }
        public int CategorYId { get; set; }

        public virtual Category Category { get; set; }

        public override string ToString()
        {
            return this.Title;
        }
    }
}
