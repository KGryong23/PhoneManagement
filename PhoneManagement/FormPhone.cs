using PhoneManagement.Common;
using PhoneManagement.Dtos;
using PhoneManagement.Enums;
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
        private int _currentPage;

        /// <summary>
        /// Tổng số bản ghi trong cơ sở dữ liệu.
        /// </summary>
        private int _totalRecords;

        /// <summary>
        /// Quản lý trạng thái Enabled của các nút (Update, Delete, Approve, Reject).
        /// </summary>
        private readonly ButtonStateManager _buttonStateManager;

        /// <summary>
        /// Cấu hình các cột của DataGridView để hiển thị dữ liệu điện thoại.
        /// </summary>
        private readonly DataGridViewConfigurator _dataGridViewConfigurator;

        /// <summary>
        /// Khởi tạo FormPhone với các dịch vụ được tiêm và cấu hình giao diện.
        /// </summary>
        /// <param name="phoneService">Dịch vụ xử lý logic nghiệp vụ cho điện thoại.</param>
        /// <param name="brandService">Dịch vụ xử lý logic nghiệp vụ cho thương hiệu.</param>
        public FormPhone(IPhoneService phoneService, IBrandService brandService)
        {
            _phoneService = phoneService;
            _brandService = brandService;
            _currentPage = 1;
            _totalRecords = 0;

            InitializeComponent();

            _buttonStateManager = new ButtonStateManager(btnUpdate, btnDelete, btnApprove, btnReject);
            _dataGridViewConfigurator = new DataGridViewConfigurator(dgvPhones);

            ConfigureDataGridView();
            LoadPhonesAsync();
        }

        /// <summary>
        /// Cấu hình DataGridView để chỉ cho phép chọn một dòng và bật chế độ chọn toàn bộ dòng.
        /// </summary>
        private void ConfigureDataGridView()
        {
            dgvPhones.MultiSelect = false;
            dgvPhones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        /// <summary>
        /// Tải danh sách điện thoại phân trang bất đồng bộ, cập nhật DataGridView và thông tin trang.
        /// </summary>
        private async void LoadPhonesAsync()
        {
            try
            {
                var query = new BaseQuery
                {
                    Keyword = txtKeyword.Text,
                    Skip = (_currentPage - 1) * AppConstants.PageSize,
                    Take = AppConstants.PageSize
                };

                var result = await _phoneService.GetPagedAsync(query);
                _totalRecords = result.TotalRecords;
                int currentRecords = result.Data.Count();
                dgvPhones.DataSource = result.Data.ToList();

                _dataGridViewConfigurator.ConfigureColumns();

                int totalPages = (int)Math.Ceiling((double)_totalRecords / AppConstants.PageSize);
                lblPageInfo.Text = string.Format(AppResources.PageInfoFormat, _currentPage, totalPages, currentRecords, _totalRecords);
                btnPrevPage.Enabled = _currentPage > 1;
                btnNextPage.Enabled = _currentPage < totalPages;
            }
            catch (Exception ex)
            {
                MessageHelper.ShowMessage(ex.Message, MessageType.Error);
            }
        }

        /// <summary>
        /// Xử lý sự kiện khi nhấn nút Create: mở form thêm mới điện thoại và làm mới danh sách nếu thêm thành công.
        /// </summary>
        /// <param name="sender">Đối tượng gửi sự kiện (nút Create).</param>
        /// <param name="e">Thông tin sự kiện.</param>
        private async void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                var formInsertOrUpdate = new FormPhoneInsertOrUpdate(_brandService);
                if (formInsertOrUpdate.ShowDialog() == DialogResult.OK)
                {
                    await _phoneService.AddAsync(formInsertOrUpdate.Phone);
                    LoadPhonesAsync();
                    MessageHelper.ShowMessage(AppResources.AddPhoneSuccess, MessageType.Success);
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowMessage(ex.Message, MessageType.Error);
            }
        }

        /// <summary>
        /// Xử lý sự kiện khi nhấn nút Update: mở form cập nhật điện thoại được chọn và làm mới danh sách nếu cập nhật thành công.
        /// </summary>
        /// <param name="sender">Đối tượng gửi sự kiện (nút Update).</param>
        /// <param name="e">Thông tin sự kiện.</param>
        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvPhones.SelectedRows.Count == 0)
                    throw new ArgumentException(AppResources.SelectPhoneToUpdate);

                var phone = (PhoneDto)dgvPhones.SelectedRows[0].DataBoundItem;
                var formInsertOrUpdate = new FormPhoneInsertOrUpdate(_brandService, phone);
                if (formInsertOrUpdate.ShowDialog() == DialogResult.OK)
                {
                    await _phoneService.UpdateAsync(formInsertOrUpdate.Phone);
                    LoadPhonesAsync();
                    MessageHelper.ShowMessage(AppResources.UpdatePhoneSuccess, MessageType.Success);
                }
            }
            catch (ArgumentException ex)
            {
                MessageHelper.ShowMessage(ex.Message, MessageType.Warning);
            }
            catch (Exception ex)
            {
                MessageHelper.ShowMessage(ex.Message, MessageType.Error);
            }
        }

        /// <summary>
        /// Xử lý sự kiện khi nhấn nút Delete: xóa điện thoại được chọn sau khi xác nhận và làm mới danh sách.
        /// </summary>
        /// <param name="sender">Đối tượng gửi sự kiện (nút Delete).</param>
        /// <param name="e">Thông tin sự kiện.</param>
        private async void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvPhones.SelectedRows.Count == 0)
                    throw new ArgumentException(AppResources.SelectPhoneToDelete);

                var phone = (PhoneDto)dgvPhones.SelectedRows[0].DataBoundItem;
                var result = MessageHelper.ShowMessage(string.Format(AppResources.ConfirmDeletePhone, phone.Model), MessageType.Confirm);
                if (result == DialogResult.Yes)
                {
                    await _phoneService.DeleteAsync(phone.Id);
                    LoadPhonesAsync();
                    MessageHelper.ShowMessage(AppResources.DeletePhoneSuccess, MessageType.Success);
                }
            }
            catch (ArgumentException ex)
            {
                MessageHelper.ShowMessage(ex.Message, MessageType.Warning);
            }
            catch (Exception ex)
            {
                MessageHelper.ShowMessage(ex.Message, MessageType.Error);
            }
        }

        /// <summary>
        /// Xử lý sự kiện khi nhấn nút Approve: duyệt điện thoại được chọn và làm mới danh sách nếu thành công.
        /// </summary>
        /// <param name="sender">Đối tượng gửi sự kiện (nút Approve).</param>
        /// <param name="e">Thông tin sự kiện.</param>
        private async void btnApprove_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvPhones.SelectedRows.Count == 0)
                    throw new ArgumentException(AppResources.SelectPhoneToApprove);

                var phone = (PhoneDto)dgvPhones.SelectedRows[0].DataBoundItem;
                var success = await _phoneService.Approve(phone.Id);
                if (success)
                {
                    LoadPhonesAsync();
                    MessageHelper.ShowMessage(AppResources.ApprovePhoneSuccess, MessageType.Success);
                }
                else
                {
                    MessageHelper.ShowMessage(AppResources.RecordNotFound, MessageType.Error);
                }
            }
            catch (ArgumentException ex)
            {
                MessageHelper.ShowMessage(ex.Message, MessageType.Warning);
            }
            catch (Exception ex)
            {
                MessageHelper.ShowMessage(ex.Message, MessageType.Error);
            }
        }

        /// <summary>
        /// Xử lý sự kiện khi nhấn nút Reject: hủy duyệt điện thoại được chọn và làm mới danh sách nếu thành công.
        /// </summary>
        /// <param name="sender">Đối tượng gửi sự kiện (nút Reject).</param>
        /// <param name="e">Thông tin sự kiện.</param>
        private async void btnReject_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvPhones.SelectedRows.Count == 0)
                    throw new ArgumentException(AppResources.SelectPhoneToReject);

                var phone = (PhoneDto)dgvPhones.SelectedRows[0].DataBoundItem;
                var success = await _phoneService.Reject(phone.Id);
                if (success)
                {
                    LoadPhonesAsync();
                    MessageHelper.ShowMessage(AppResources.RejectPhoneSuccess, MessageType.Success);
                }
                else
                {
                    MessageHelper.ShowMessage(AppResources.RecordNotFound, MessageType.Error);
                }
            }
            catch (ArgumentException ex)
            {
                MessageHelper.ShowMessage(ex.Message, MessageType.Warning);
            }
            catch (Exception ex)
            {
                MessageHelper.ShowMessage(ex.Message, MessageType.Error);
            }
        }

        /// <summary>
        /// Xử lý sự kiện khi nhấn nút Search: tìm kiếm điện thoại theo từ khóa và làm mới danh sách.
        /// </summary>
        /// <param name="sender">Đối tượng gửi sự kiện (nút Search).</param>
        /// <param name="e">Thông tin sự kiện.</param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                _currentPage = 1;
                LoadPhonesAsync();
            }
            catch (Exception ex)
            {
                MessageHelper.ShowMessage(ex.Message, MessageType.Error);
            }
        }

        /// <summary>
        /// Xử lý sự kiện khi nhấn nút Previous Page: chuyển về trang trước và làm mới danh sách.
        /// </summary>
        /// <param name="sender">Đối tượng gửi sự kiện (nút Previous Page).</param>
        /// <param name="e">Thông tin sự kiện.</param>
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
                MessageHelper.ShowMessage(ex.Message, MessageType.Error);
            }
        }

        /// <summary>
        /// Xử lý sự kiện khi nhấn nút Next Page: chuyển đến trang tiếp theo và làm mới danh sách.
        /// </summary>
        /// <param name="sender">Đối tượng gửi sự kiện (nút Next Page).</param>
        /// <param name="e">Thông tin sự kiện.</param>
        private void btnNextPage_Click(object sender, EventArgs e)
        {
            try
            {
                int totalPages = (int)Math.Ceiling((double)_totalRecords / AppConstants.PageSize);
                if (_currentPage < totalPages)
                {
                    _currentPage++;
                    LoadPhonesAsync();
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowMessage(ex.Message, MessageType.Error);
            }
        }

        /// <summary>
        /// Xử lý sự kiện khi nhấn nút Clear Inputs: xóa từ khóa tìm kiếm và làm mới danh sách.
        /// </summary>
        /// <param name="sender">Đối tượng gửi sự kiện (nút Clear Inputs).</param>
        /// <param name="e">Thông tin sự kiện.</param>
        private void btnClearInputs_Click(object sender, EventArgs e)
        {
            try
            {
                txtKeyword.Text = string.Empty;
                LoadPhonesAsync();
            }
            catch (Exception ex)
            {
                MessageHelper.ShowMessage(ex.Message, MessageType.Error);
            }
        }

        /// <summary>
        /// Xử lý sự kiện khi nhấn nút View Detail: mở form chi tiết để xem thông tin điện thoại được chọn.
        /// </summary>
        /// <param name="sender">Đối tượng gửi sự kiện (nút View Detail).</param>
        /// <param name="e">Thông tin sự kiện.</param>
        private void btnViewDetail_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvPhones.SelectedRows.Count == 0)
                    throw new ArgumentException(AppResources.SelectPhoneToViewDetail);

                var phone = (PhoneDto)dgvPhones.SelectedRows[0].DataBoundItem;
                var formDetail = new FormPhoneDetail(phone);
                formDetail.ShowDialog();
            }
            catch (ArgumentException ex)
            {
                MessageHelper.ShowMessage(ex.Message, MessageType.Warning);
            }
            catch (Exception ex)
            {
                MessageHelper.ShowMessage(ex.Message, MessageType.Error);
            }
        }

        /// <summary>
        /// Xử lý sự kiện khi thay đổi lựa chọn trong DataGridView: cập nhật trạng thái các nút.
        /// </summary>
        /// <param name="sender">Đối tượng gửi sự kiện (DataGridView).</param>
        /// <param name="e">Thông tin sự kiện.</param>
        private void dgvPhones_SelectionChanged(object sender, EventArgs e)
        {
            var phone = dgvPhones.SelectedRows.Count > 0
                ? (PhoneDto)dgvPhones.SelectedRows[0].DataBoundItem
                : null;
            _buttonStateManager.UpdateButtonStates(phone);
        }
    }
}
