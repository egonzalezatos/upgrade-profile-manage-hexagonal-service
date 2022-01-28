using System.ComponentModel.DataAnnotations;
using Domain.Models.ConstInterfaces;

namespace Domain.Models
{
    public class Status : Entity, IUniqueName
    {
        
        [MaxLength(150)]
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}