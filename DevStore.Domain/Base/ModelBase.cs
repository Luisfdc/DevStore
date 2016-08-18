using System;
using System.ComponentModel.DataAnnotations;

namespace DevStore.Domain.Base
{
    public class ModelBase
    {
        public ModelBase()
        {
            CreateDate = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }

        public DateTime CreateDate { get; set; }

    }
}
