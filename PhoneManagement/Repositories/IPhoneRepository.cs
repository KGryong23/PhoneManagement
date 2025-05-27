using PhoneManagement.Dtos;
using PhoneManagement.Entitys;

namespace PhoneManagement.Repositories
{
    /// <summary>
    /// Interface cho Phone Repository
    /// </summary>
    public interface IPhoneRepository : IRepository<Phone>
    {
        Task<bool> AddAsync(PhoneDto dto);
    }
}
