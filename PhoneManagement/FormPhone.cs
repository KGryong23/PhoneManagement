using PhoneManagement.Common;
using PhoneManagement.Dtos;
using PhoneManagement.Services;

namespace PhoneManagement
{
    /// <summary>
    /// Form chính để quản lý danh sách điện thoại, hỗ trợ thêm, sửa, xóa, duyệt, hủy duyệt, và xem chi tiết.
    /// </summary>
    public partial class FormPhone : Form
    {
        /// <summary>
        /// Dịch vụ xử lý logic nghiệp vụ cho điện thoại.
        /// </summary>
        private readonly IPhoneService _phoneService;

        /// <summary>
        /// Dịch vụ xử lý logic nghiệp vụ cho thương hiệu.
        /// </summary>
        private readonly IBrandService _brandService;

        /// <summary>
        /// Trang hiện tại trong phân trang.
        /// </summary>
        private int _currentPage = 1;

        /// <summary>
        /// Số bản ghi trên mỗi trang (cố định).
        /// </summary>
        private readonly int _pageSize = 13;

        /// <summary>
        /// Tổng số bản ghi trong cơ sở dữ liệu.
        /// </summary>
        private int _totalRecords = 0;

        /// <summary>
        /// Quản lý trạng thái Enabled của các nút.
        /// </summary>
        private readonly ButtonStateManager _buttonStateManager;

        /// <summary>
        /// Cấu hình các cột của DataGridView.
        /// </summary>
        private readonly DataGridViewConfigurator _dataGridViewConfigurator;

        /// <summary>
        /// Khởi tạo FormPhone, inject các dịch vụ và cấu hình giao diện.
        /// </summary>
        /// <param name="phoneService">Dịch vụ điện thoại.</param>
        /// <param name="brandService">Dịch vụ thương hiệu.</param>
        public FormPhone(IPhoneService phoneService, IBrandService brandService)
        {
            _phoneService = phoneService;
            _brandService = brandService;

            InitializeComponent();

            _buttonStateManager = new ButtonStateManager(btnUpdate, btnDelete, btnApprove, btnReject);
            _dataGridViewConfigurator = new DataGridViewConfigurator(dgvPhones);


            ConfigureDataGridView();
            LoadPhonesAsync();
        }

        /// <summary>
        /// Cấu hình DataGridView để chỉ cho phép chọn một dòng.
        /// </summary>
        private void ConfigureDataGridView()
        {
            dgvPhones.MultiSelect = false;
            dgvPhones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        /// <summary>
        /// Tải danh sách điện thoại phân trang, cập nhật DataGridView và thông tin trang.
        /// </summary>
        private async void LoadPhonesAsync()
        {
            try
            {
                var query = new BaseQuery
                {
                    Keyword = txtKeyword.Text,
                    Skip = (_currentPage - 1) * _pageSize,
                    Take = _pageSize
                };

                var result = await _phoneService.GetPagedAsync(query);
                _totalRecords = result.TotalRecords;
                var currentRecords = result.Data.Count();
                dgvPhones.DataSource = result.Data.ToList();

                _dataGridViewConfigurator.ConfigureColumns();

                int totalPages = (int)Math.Ceiling((double)_totalRecords / _pageSize);
                lblPageInfo.Text = $"Trang {_currentPage} / {totalPages} ({currentRecords}/{_totalRecords} bản ghi)";
                btnPrevPage.Enabled = _currentPage > 1;
                btnNextPage.Enabled = _currentPage < totalPages;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Mở form thêm mới điện thoại và làm mới danh sách nếu thêm thành công.
        /// </summary>
        private async void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                var formInsertOrUpdate = new FormPhoneInsertOrUpdate(_brandService);
                if (formInsertOrUpdate.ShowDialog() == DialogResult.OK)
                {
                    await _phoneService.AddAsync(formInsertOrUpdate.Phone);
                    LoadPhonesAsync();
                    MessageBox.Show("Thêm điện thoại thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Mở form cập nhật điện thoại được chọn và làm mới danh sách nếu cập nhật thành công.
        /// </summary>
        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvPhones.SelectedRows.Count == 0)
                    throw new ArgumentException("Vui lòng chọn một điện thoại để cập nhật.");

                var phone = (PhoneDto)dgvPhones.SelectedRows[0].DataBoundItem;
                var formInsertOrUpdate = new FormPhoneInsertOrUpdate(_brandService, phone);
                if (formInsertOrUpdate.ShowDialog() == DialogResult.OK)
                {
                    await _phoneService.UpdateAsync(formInsertOrUpdate.Phone);
                    LoadPhonesAsync();
                    MessageBox.Show("Cập nhật thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi không xác định: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Xóa điện thoại được chọn sau khi xác nhận và làm mới danh sách.
        /// </summary>
        private async void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvPhones.SelectedRows.Count == 0)
                    throw new ArgumentException("Vui lòng chọn một điện thoại để xóa.");

                var phone = (PhoneDto)dgvPhones.SelectedRows[0].DataBoundItem;
                var result = MessageBox.Show($"Bạn có chắc chắn muốn xóa điện thoại {phone.Model}?",
                    "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    await _phoneService.DeleteAsync(phone.Id);
                    LoadPhonesAsync();
                    MessageBox.Show("Xóa thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi không xác định: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Duyệt điện thoại được chọn và làm mới danh sách nếu thành công.
        /// </summary>
        private async void btnApprove_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvPhones.SelectedRows.Count == 0)
                    throw new ArgumentException("Vui lòng chọn một điện thoại để duyệt.");

                var phone = (PhoneDto)dgvPhones.SelectedRows[0].DataBoundItem;
                var success = await _phoneService.Approve(phone.Id);
                if (success)
                {
                    LoadPhonesAsync();
                    MessageBox.Show("Duyệt thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Bản ghi không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi không xác định: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Hủy duyệt điện thoại được chọn và làm mới danh sách nếu thành công.
        /// </summary>
        private async void btnReject_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvPhones.SelectedRows.Count == 0)
                    throw new ArgumentException("Vui lòng chọn một điện thoại để hủy duyệt.");

                var phone = (PhoneDto)dgvPhones.SelectedRows[0].DataBoundItem;
                var success = await _phoneService.Reject(phone.Id);
                if (success)
                {
                    LoadPhonesAsync();
                    MessageBox.Show("Hủy duyệt thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Bản ghi không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi không xác định: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Tìm kiếm điện thoại theo từ khóa và làm mới danh sách.
        /// </summary>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                _currentPage = 1;
                LoadPhonesAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Chuyển về trang trước và làm mới danh sách.
        /// </summary>
        private void btnPrevPage_Click(object sender, EventArgs e)
        {
            try
            {
                if (_currentPage > 1)
                {
                    _currentPage--;
                    LoadPhonesAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Chuyển đến trang tiếp theo và làm mới danh sách.
        /// </summary>
        private void btnNextPage_Click(object sender, EventArgs e)
        {
            try
            {
                int totalPages = (int)Math.Ceiling((double)_totalRecords / _pageSize);
                if (_currentPage < totalPages)
                {
                    _currentPage++;
                    LoadPhonesAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Xóa từ khóa tìm kiếm và làm mới danh sách.
        /// </summary>
        private void btnClearInputs_Click(object sender, EventArgs e)
        {
            try
            {
                txtKeyword.Text = "";
                LoadPhonesAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Mở form chi tiết để xem thông tin điện thoại được chọn.
        /// </summary>
        private void btnViewDetail_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvPhones.SelectedRows.Count == 0)
                    throw new ArgumentException("Vui lòng chọn một điện thoại để xem chi tiết.");

                var phone = (PhoneDto)dgvPhones.SelectedRows[0].DataBoundItem;
                var formDetail = new FormPhoneDetail(phone);
                formDetail.ShowDialog();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi không xác định: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Cập nhật trạng thái các nút khi chọn một dòng khác trong DataGridView.
        /// </summary>
        private void dgvPhones_SelectionChanged(object sender, EventArgs e)
        {
            var phone = dgvPhones.SelectedRows.Count > 0
                ? (PhoneDto)dgvPhones.SelectedRows[0].DataBoundItem
                : null;
            _buttonStateManager.UpdateButtonStates(phone);
        }
    }
}
