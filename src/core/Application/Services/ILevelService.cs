using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface ILevelService
    {
        public Task<List<DTOs.Level>> GetAll();
        public Task<List<DTOs.Level>> GetByUserIdPositionId(int userId, int positionId);
    }
}