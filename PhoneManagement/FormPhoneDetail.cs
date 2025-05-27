using PhoneManagement.Common;
using PhoneManagement.Dtos;
using PhoneManagement.Enums;

namespace PhoneManagement
{
    /// <summary>
    /// Form để hiển thị chi tiết thông tin điện thoại.
    /// </summary>
    public partial class FormPhoneDetail : Form
    {
        private readonly PhoneDto _phone;

        /// <summary>
        /// Ham khởi tạo FormPhoneDetail với đối tượng PhoneDto.
        /// </summary>
        public FormPhoneDetail(PhoneDto phone)
        {
            InitializeComponent();
            _phone = phone;
            LoadData();
        }
        /// <summary>
        /// Tải dữ liệu từ đối tượng PhoneDto và hiển thị lên các điều khiển trên form.
        /// </summary>
        private void LoadData()
        {
            try
            {
                txtModel.Text = _phone.Model;
                txtPrice.Text = _phone.Price.ToString("C2");
                txtStock.Text = _phone.Stock.ToString();
                txtModerationStatus.Text = _phone.ModerationStatusTxt;
                txtBrandName.Text = _phone.BrandName;
                txtCreated.Text = _phone.Created.ToString("yyyy-MM-dd HH:mm:ss");
                txtLastModified.Text = _phone.LastModified.ToString("yyyy-MM-dd HH:mm:ss");
            }
            catch (Exception ex)
            {
                MessageHelper.ShowMessage(string.Format(AppResources.UnknownError, ex.Message), MessageType.Error);
            }
        }
        /// <summary>
        /// Hàm xử lý sự kiện khi nhấn nút Close: đóng form.
        /// </summary>
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
