using System.ComponentModel.DataAnnotations;

namespace Domain.Models.ManagementModels
{
    public class UserProfile : Entity
    {
        [Required]
        public int UserId { get; set; }
        
        [Required]
        public JobProfile JobProfile { get; set; }
    }
}