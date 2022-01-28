using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IPositionService
    {
        public Task<List<DTOs.Position>> GetAll();
        public Task<List<DTOs.Position>> GetByUserId(int userId);
    }
}