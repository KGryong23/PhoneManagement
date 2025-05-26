using PhoneManagement.Dtos;
using PhoneManagement.Services;

namespace PhoneManagement
{
    public partial class FormPhoneInsertOrUpdate : Form
    {
        private readonly IBrandService _brandService;
        private readonly PhoneDto _phone;
        private readonly bool _isEditMode;

        public PhoneDto Phone => _phone;

        public FormPhoneInsertOrUpdate(IBrandService brandService, PhoneDto? phone = null)
        {
            InitializeComponent();
            _brandService = brandService;
            _phone = phone ?? new PhoneDto();
            _isEditMode = phone != null;
            InitializeControlsAsync();
        }

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
                    Text = "Chỉnh sửa điện thoại";
                }
                else
                {
                    Text = "Thêm điện thoại mới";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtModel.Text))
                    throw new ArgumentException("Model không được để trống.");
                if (!decimal.TryParse(txtPrice.Text, out decimal price))
                    throw new ArgumentException("Giá không hợp lệ.");
                if (!int.TryParse(txtStock.Text, out int stock))
                    throw new ArgumentException("Số lượng tồn kho không hợp lệ.");

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
                MessageBox.Show($"Lỗi: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi không xác định: {ex.Message}");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
