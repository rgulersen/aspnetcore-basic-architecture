using System;
using System.ComponentModel.DataAnnotations;

namespace AspnetCoreBasicArchitecture.Model
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime DiteTime { get; set; }
    }
}
