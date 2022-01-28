using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models.ConstInterfaces
{
    public interface ITraceable
    {
        [Required]
        public DateTime CreatedDate { get; set; }
        public int? CreatedByUserId { get; set; }

        public DateTime UpdatedDate { get; set; }
        public int? UpdatedByUserId { get; set; }
    }
}