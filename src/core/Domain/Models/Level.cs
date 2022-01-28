using System;
using System.ComponentModel.DataAnnotations;
using Domain.Models.ConstInterfaces;

namespace Domain.Models
{
    public class Level : Entity, IUniqueName, ITraceable
    {
        [MaxLength(150)]
        [Required]
        public string Name { get; set; }

        [MaxLength(250)]
        public string? Description { get; set; }

        public Status Status { get; set; }
        
        public DateTime CreatedDate { get; set; }
        public int? CreatedByUserId { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int? UpdatedByUserId { get; set; }
    }
}