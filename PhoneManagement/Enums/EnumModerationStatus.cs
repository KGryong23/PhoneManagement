using System.ComponentModel;

namespace PhoneManagement.Enums
{
    public enum ModerationStatus
    {
        [Description("Đã duyệt")]
        Approved = 0,
        [Description("Từ chối")]
        Rejected = 1,
    }
}
