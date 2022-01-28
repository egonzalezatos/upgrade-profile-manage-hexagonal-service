using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface ITechnologyService
    {
        public Task<List<DTOs.Technology>> GetAll();
        public Task<List<DTOs.Technology>> GetByUserIdPositionId(int userId, int positionId);
    }
}