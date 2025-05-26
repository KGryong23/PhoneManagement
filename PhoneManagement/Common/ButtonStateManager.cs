using PhoneManagement.Dtos;
using PhoneManagement.Enums;

namespace PhoneManagement.Common
{
    /// <summary>
    /// Quản lý trạng thái Enabled của các nút dựa trên ModerationStatus của điện thoại.
    /// </summary>
    public class ButtonStateManager
    {
        private readonly Button _btnUpdate;
        private readonly Button _btnDelete;
        private readonly Button _btnApprove;
        private readonly Button _btnReject;

        /// <summary>
        /// Khởi tạo ButtonStateManager với các nút cần quản lý.
        /// </summary>
        /// <param name="btnUpdate">Nút Cập nhật.</param>
        /// <param name="btnDelete">Nút Xóa.</param>
        /// <param name="btnApprove">Nút Duyệt.</param>
        /// <param name="btnReject">Nút Hủy duyệt.</param>
        public ButtonStateManager(Button btnUpdate, Button btnDelete, Button btnApprove, Button btnReject)
        {
            _btnUpdate = btnUpdate;
            _btnDelete = btnDelete;
            _btnApprove = btnApprove;
            _btnReject = btnReject;
        }

        /// <summary>
        /// Cập nhật trạng thái Enabled của các nút dựa trên trạng thái kiểm duyệt của điện thoại.
        /// </summary>
        /// <param name="phone">Đối tượng PhoneDto, có thể null nếu không có dòng được chọn.</param>
        public void UpdateButtonStates(PhoneDto? phone)
        {
            // Mặc định vô hiệu hóa tất cả các nút nếu không có dòng chọn
            _btnUpdate.Enabled = false;
            _btnDelete.Enabled = false;
            _btnApprove.Enabled = false;
            _btnReject.Enabled = false;

            if (phone != null)
            {
                var status = phone.ModerationStatus;

                if (status == ModerationStatus.Approved)
                {
                    _btnUpdate.Enabled = false;
                    _btnDelete.Enabled = false;
                    _btnApprove.Enabled = false;
                    _btnReject.Enabled = true;
                }
                else
                {
                    _btnUpdate.Enabled = true;
                    _btnDelete.Enabled = true;
                    _btnApprove.Enabled = true;
                    _btnReject.Enabled = false;
                }
            }
        }
    }
}
