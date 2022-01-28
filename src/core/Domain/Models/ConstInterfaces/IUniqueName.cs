using System.ComponentModel.DataAnnotations;

namespace Domain.Models.ConstInterfaces
{
    public interface IUniqueName
    {
        [MaxLength(100)]
        public string Name { get; set; }
    }
}