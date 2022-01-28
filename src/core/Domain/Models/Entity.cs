using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public abstract class Entity
    {
        [Key] public int Id { get; set; }
    }
}