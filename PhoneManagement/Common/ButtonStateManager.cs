using PhoneManagement.Dtos;
using PhoneManagement.Enums;

namespace PhoneManagement.Common
{
    /// <summary>
    /// Lớp quản lý trạng thái Enabled của các nút dựa trên điện thoại được chọn.
    /// </summary>
    public class ButtonStateManager
    {
        /// <summary>
        /// Từ điển ánh xạ nút với điều kiện bật/tắt dựa trên PhoneDto.
        /// </summary>
        private readonly Dictionary<Button, Func<PhoneDto, bool>> _buttonConditions;

        /// <summary>
        /// Khởi tạo ButtonStateManager với các nút cần quản lý.
        /// </summary>
        /// <param name="btnUpdate">Nút cập nhật điện thoại.</param>
        /// <param name="btnDelete">Nút xóa điện thoại.</param>
        /// <param name="btnApprove">Nút duyệt điện thoại.</param>
        /// <param name="btnReject">Nút hủy duyệt điện thoại.</param>
        public ButtonStateManager(Button btnUpdate, Button btnDelete, Button btnApprove, Button btnReject)
        {
            _buttonConditions = new Dictionary<Button, Func<PhoneDto, bool>>
            {
                { btnUpdate, phone => phone is not null && phone.ModerationStatus != ModerationStatus.Approved  },
                { btnDelete, phone => phone is not null && phone.ModerationStatus != ModerationStatus.Approved  },
                { btnApprove, phone => phone is not null && phone.ModerationStatus != ModerationStatus.Approved },
                { btnReject, phone => phone is not null && phone.ModerationStatus != ModerationStatus.Rejected }
            };
        }

        /// <summary>
        /// Cập nhật trạng thái Enabled của các nút dựa trên điện thoại được chọn.
        /// </summary>
        /// <param name="phone">Đối tượng PhoneDto được chọn; null nếu không có lựa chọn.</param>
        public void UpdateButtonStates(PhoneDto? phone)
        {
            foreach (var pair in _buttonConditions)
            {
                pair.Key.Enabled = pair.Value(phone);
            }
        }
    }
}
