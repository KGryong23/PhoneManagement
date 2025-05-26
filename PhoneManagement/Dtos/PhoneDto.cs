using PhoneManagement.Enums;

namespace PhoneManagement.Dtos
{
    public class PhoneDto
    {
        public Guid Id { get; set; }
        public string Model { get; set; } = null!;
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastModified { get; set; }
        public ModerationStatus ModerationStatus { get; set; }
        public string? ModerationStatusTxt { get; set; }
        public Guid? BrandId { get; set; }
        public string BrandName { get; set; } = null!;
    }
}
