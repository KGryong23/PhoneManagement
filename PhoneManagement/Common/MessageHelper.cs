using PhoneManagement.Enums;

namespace PhoneManagement.Common
{
    /// <summary>
    /// Lớp tiện ích cung cấp các phương thức hiển thị thông báo dùng chung cho ứng dụng.
    /// </summary>
    public static class MessageHelper
    {
        /// <summary>
        /// Hiển thị thông báo cho người dùng với các loại thông báo khác nhau (Success, Error, Warning, Confirm).
        /// </summary>
        /// <param name="message">Nội dung thông báo.</param>
        /// <param name="type">Loại thông báo (Success, Error, Warning, Confirm).</param>
        /// <returns>Kết quả của hộp thoại (DialogResult) nếu là Confirm; nếu không, trả về DialogResult.None.</returns>
        /// <exception cref="ArgumentException">Ném ra khi loại thông báo không hợp lệ.</exception>
        public static DialogResult ShowMessage(string message, MessageType type)
        {
            switch (type)
            {
                case MessageType.Success:
                    return MessageBox.Show(message, AppResources.SuccessTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                case MessageType.Error:
                    return MessageBox.Show(string.Format(AppResources.ErrorMessagePrefix, message), AppResources.SuccessTitle,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                case MessageType.Warning:
                    return MessageBox.Show(message, AppResources.SuccessTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                case MessageType.Confirm:
                    return MessageBox.Show(message, AppResources.SuccessTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                default:
                    throw new ArgumentException("Loại thông báo không hợp lệ.");
            }
        }
    }
}
