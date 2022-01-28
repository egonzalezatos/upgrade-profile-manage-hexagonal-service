using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class JobProfile : Entity
    {
        [Required]
        public JobPosition JobPosition { get; set; }

        [Required]
        public Technology Technology { get; set; }

        [Required]
        public Level Level { get; set; }
    }
}