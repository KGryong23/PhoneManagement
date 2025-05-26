using PhoneManagement.Common;
using PhoneManagement.Dtos;
using PhoneManagement.Enums;
using PhoneManagement.Extensions;
using PhoneManagement.Repositories;

namespace PhoneManagement.Services
{
    /// <summary>
    /// Service xử lý logic nghiệp vụ cho Phone
    /// </summary>
    public class PhoneService : IPhoneService
    {
        private readonly IPhoneRepository _phoneRepository;
        private readonly IBrandRepository _brandRepository;

        public PhoneService(IPhoneRepository phoneRepository, IBrandRepository brandRepository)
        {
            _phoneRepository = phoneRepository;
            _brandRepository = brandRepository;
        }

        /// <summary>
        /// Lấy danh sách Phone phân trang, tìm kiếm theo Model, sắp xếp theo Price
        /// </summary>
        public async Task<PagedResult<PhoneDto>> GetPagedAsync(BaseQuery query)
        {
            var result = await _phoneRepository.GetPagedAsync(query, "Model", "Price");
            var phones = result.Data.Select(p => new PhoneDto
            {
                Id = p.Id,
                Model = p.Model,
                Price = p.Price,
                Stock = p.Stock,
                Created = p.Created,
                LastModified = p.LastModified,
                ModerationStatus = p.ModerationStatus,
                ModerationStatusTxt = p.ModerationStatus switch
                {
                    ModerationStatus.Approved => "Đã duyệt",
                    ModerationStatus.Rejected => "Chưa duyệt",
                    _ => "Không xác định"
                },
                BrandId = p.BrandId,
                BrandName = p.BrandId.HasValue ? (_brandRepository.GetById(p.BrandId.Value))?.Name ?? "N/A" : "N/A"
            }).ToList();
            return new PagedResult<PhoneDto>(phones, result.TotalRecords);
        }

        /// <summary>
        /// Lấy Phone theo ID
        /// </summary>
        public async Task<PhoneDto> GetByIdAsync(Guid id)
        {
            var phone = await _phoneRepository.GetByIdAsync(id);
            return phone.ToDto() ?? new PhoneDto();
        }

        /// <summary>
        /// Thêm Phone mới với kiểm tra đầu vào
        /// </summary>
        public async Task<bool> AddAsync(PhoneDto dto)
        {
            if (string.IsNullOrEmpty(dto.Model))
                throw new ArgumentException("Tên mẫu điện thoại không thể để trống.", nameof(dto.Model));
            if (dto.Price <= 0)
                throw new ArgumentException("Giá phải lớn hơn 0.", nameof(dto.Price));
            if (dto.Stock < 0)
                throw new ArgumentException("Số lượng tồn kho không thể âm.", nameof(dto.Stock));
            if (dto.BrandId.HasValue)
            {
                var brand = await _brandRepository.GetByIdAsync(dto.BrandId.Value);
                if (brand is null)
                    throw new ArgumentException("Thương hiệu không tồn tại.", nameof(dto.BrandId));
            }

            var existingPhones = await _phoneRepository.FindAllAsync(x => x.Model == dto.Model);
            if (existingPhones.Any())
                throw new ArgumentException("Mẫu điện thoại đã tồn tại.", nameof(dto.Model));

            var phone = dto.ToEntity();
            await _phoneRepository.AddAsync(phone);
            return await _phoneRepository.SaveChangesAsync();
        }

        /// <summary>
        /// Cập nhật Phone với kiểm tra đầu vào
        /// </summary>
        public async Task<bool> UpdateAsync(PhoneDto dto)
        {
            if (dto.Id == Guid.Empty)
                throw new ArgumentException("ID không hợp lệ.", nameof(dto.Id));
            if (string.IsNullOrEmpty(dto.Model))
                throw new ArgumentException("Tên mẫu điện thoại không thể để trống.", nameof(dto.Model));
            if (dto.Price <= 0)
                throw new ArgumentException("Giá phải lớn hơn 0.", nameof(dto.Price));
            if (dto.Stock < 0)
                throw new ArgumentException("Số lượng tồn kho không thể âm.", nameof(dto.Stock));
            if (dto.BrandId.HasValue)
            {
                var brand = await _brandRepository.GetByIdAsync(dto.BrandId.Value);
                if (brand is null)
                    throw new ArgumentException("Thương hiệu không tồn tại.", nameof(dto.BrandId));
            }

            var existingPhones = await _phoneRepository.FindAllAsync(x => x.Model == dto.Model && x.Id != dto.Id);
            if(existingPhones.Any())
                throw new ArgumentException("Mẫu điện thoại đã tồn tại.", nameof(dto.Model));

            var phone = await _phoneRepository.GetByIdAsync(dto.Id);
            if (phone is null)
                throw new ArgumentException("Điện thoại không tồn tại.", nameof(dto.Id));

            phone.Model = dto.Model;
            phone.Price = dto.Price;
            phone.Stock = dto.Stock;
            phone.BrandId = dto.BrandId;

            _phoneRepository.Update(phone);
            return await _phoneRepository.SaveChangesAsync();
        }

        /// <summary>
        /// Xóa Phone
        /// </summary>
        public async Task<bool> DeleteAsync(Guid id)
        {
            var phone = await _phoneRepository.GetByIdAsync(id);
            if (phone is null)
                throw new ArgumentException("Điện thoại không tồn tại.", nameof(id));

            _phoneRepository.Delete(phone);
            return await _phoneRepository.SaveChangesAsync();
        }

        /// <summary>
        /// Duyệt Phone
        /// </summary>
        public async Task<bool> Approve(Guid id)
        {
            var phone = await _phoneRepository.GetByIdAsync(id);
            if (phone is null)
                return false;

            phone.ModerationStatus = ModerationStatus.Approved;

            _phoneRepository.Update(phone);
            return await _phoneRepository.SaveChangesAsync();
        }

        /// <summary>
        /// Từ chối Phone
        /// </summary>
        public async Task<bool> Reject(Guid id)
        {
            var phone = await _phoneRepository.GetByIdAsync(id);
            if (phone is null)
                return false;

            phone.ModerationStatus = ModerationStatus.Rejected;
            _phoneRepository.Update(phone);

            return await _phoneRepository.SaveChangesAsync();
        }
        // hihi
        //hoho
        //hhahahah
    }
}
