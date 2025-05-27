namespace PhoneManagement.Enums
{
    /// <summary>
    /// Định nghĩa các loại thông báo cho phương thức ShowMessage.
    /// </summary>
    public enum MessageType
    {
        /// <summary>
        /// Thông báo thành công.
        /// </summary>
        Success,

        /// <summary>
        /// Thông báo lỗi.
        /// </summary>
        Error,

        /// <summary>
        /// Thông báo cảnh báo.
        /// </summary>
        Warning,

        /// <summary>
        /// Thông báo xác nhận (Yes/No).
        /// </summary>
        Confirm
    }
}
