using PhoneManagement.Common;
using PhoneManagement.Dtos;
using PhoneManagement.Enums;
using PhoneManagement.Services;

namespace PhoneManagement
{
    /// <summary>
    /// Form để thêm mới hoặc cập nhật thông tin điện thoại.
    /// </summary>
    public partial class FormPhoneInsertOrUpdate : Form
    {
        /// <summary>
        /// Dịch vụ xử lý logic nghiệp vụ cho thương hiệu.
        /// </summary>
        private readonly IBrandService _brandService;

        /// <summary>
        /// Đối tượng PhoneDto chứa thông tin điện thoại được thêm hoặc chỉnh sửa.
        /// </summary>
        private readonly PhoneDto _phone;

        /// <summary>
        /// Cờ xác định chế độ chỉnh sửa (true) hoặc thêm mới (false).
        /// </summary>
        private readonly bool _isEditMode;

        /// <summary>
        /// Lấy đối tượng PhoneDto đã được cập nhật từ form.
        /// </summary>
        public PhoneDto Phone => _phone;

        /// <summary>
        /// Khởi tạo FormPhoneInsertOrUpdate với dịch vụ thương hiệu và đối tượng điện thoại (nếu có).
        /// </summary>
        /// <param name="brandService">Dịch vụ xử lý logic nghiệp vụ cho thương hiệu.</param>
        /// <param name="phone">Đối tượng PhoneDto để chỉnh sửa; null nếu thêm mới.</param>
        public FormPhoneInsertOrUpdate(IBrandService brandService, PhoneDto? phone = null)
        {
            InitializeComponent();
            _brandService = brandService;
            _phone = phone ?? new PhoneDto();
            _isEditMode = phone != null;
            InitializeControlsAsync();
        }

        /// <summary>
        /// Khởi tạo các điều khiển trên form bất đồng bộ, bao gồm tải danh sách thương hiệu và thiết lập giá trị ban đầu.
        /// </summary>
        private async void InitializeControlsAsync()
        {
            try
            {
                // Khởi tạo ComboBox Brand
                var brands = (await _brandService.GetAllAsync()).ToList();
                cboBrand.DataSource = brands;
                cboBrand.DisplayMember = "Name";
                cboBrand.ValueMember = "Id";
                cboBrand.SelectedIndex = -1;

                // Nếu là chế độ chỉnh sửa
                if (_isEditMode)
                {
                    txtModel.Text = _phone.Model;
                    txtPrice.Text = _phone.Price.ToString();
                    txtStock.Text = _phone.Stock.ToString();
                    cboBrand.SelectedValue = _phone.BrandId ?? null;
                    Text = AppResources.EditPhoneTitle;
                }
                else
                {
                    Text = AppResources.AddPhoneTitle;
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowMessage(ex.Message, MessageType.Error);
            }
        }

        /// <summary>
        /// Xử lý sự kiện khi nhấn nút Save: xác thực dữ liệu và lưu thông tin điện thoại.
        /// </summary>
        /// <param name="sender">Đối tượng gửi sự kiện (nút Save).</param>
        /// <param name="e">Thông tin sự kiện.</param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtModel.Text))
                    throw new ArgumentException(AppResources.ModelCannotBeEmpty);
                if (!decimal.TryParse(txtPrice.Text, out decimal price))
                    throw new ArgumentException(AppResources.InvalidPrice);
                if (!int.TryParse(txtStock.Text, out int stock))
                    throw new ArgumentException(AppResources.InvalidStock);

                _phone.Model = txtModel.Text;
                _phone.Price = price;
                _phone.Stock = stock;
                _phone.BrandId = cboBrand.SelectedValue != null ? (Guid?)cboBrand.SelectedValue : null;

                if (_isEditMode)
                {
                    _phone.Id = _phone.Id; // Giữ Id hiện tại
                }

                DialogResult = DialogResult.OK;
            }
            catch (ArgumentException ex)
            {
               
                MessageHelper.ShowMessage(ex.Message, MessageType.Warning);
            }
            catch (Exception ex)
            {
                
                MessageHelper.ShowMessage(string.Format(AppResources.UnknownError, ex.Message), MessageType.Error);
            }
        }

        /// <summary>
        /// Xử lý sự kiện khi nhấn nút Cancel: đóng form mà không lưu thay đổi.
        /// </summary>
        /// <param name="sender">Đối với nút cancel.</param>
        /// <param name="e">Thông tin sự kiện.</param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
