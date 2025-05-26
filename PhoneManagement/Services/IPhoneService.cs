using PhoneManagement.Common;
using PhoneManagement.Dtos;

namespace PhoneManagement.Services
{
    /// <summary>
    /// Interface cho Phone Service
    /// </summary>
    public interface IPhoneService
    {
        Task<PagedResult<PhoneDto>> GetPagedAsync(BaseQuery query);
        Task<PhoneDto> GetByIdAsync(Guid id);
        Task<bool> AddAsync(PhoneDto dto);
        Task<bool> UpdateAsync(PhoneDto dto);
        Task<bool> DeleteAsync(Guid id);
        Task<bool> Approve(Guid id);
        Task<bool> Reject(Guid id);
    }
}
