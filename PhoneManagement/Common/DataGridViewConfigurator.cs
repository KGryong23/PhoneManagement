namespace PhoneManagement.Common
{
    /// <summary>
    /// Cấu hình các cột của DataGridView để hiển thị dữ liệu điện thoại.
    /// </summary>
    public class DataGridViewConfigurator
    {
        private readonly DataGridView _dataGridView;

        /// <summary>
        /// Khởi tạo DataGridViewConfigurator với DataGridView cần cấu hình.
        /// </summary>
        /// <param name="dataGridView">DataGridView cần cấu hình.</param>
        public DataGridViewConfigurator(DataGridView dataGridView)
        {
            _dataGridView = dataGridView;
        }

        /// <summary>
        /// Cấu hình các cột của DataGridView: ẩn cột không cần thiết, đổi tiêu đề, căn giữa.
        /// </summary>
        public void ConfigureColumns()
        {
            // Ẩn các cột không mong muốn
            _dataGridView.Columns["Id"].Visible = false;
            _dataGridView.Columns["Created"].Visible = false;
            _dataGridView.Columns["LastModified"].Visible = false;
            _dataGridView.Columns["BrandId"].Visible = false;
            _dataGridView.Columns["ModerationStatus"].Visible = false;

            // Thay đổi tiêu đề các cột
            _dataGridView.Columns["Model"].HeaderText = "Tên Model";
            _dataGridView.Columns["Price"].HeaderText = "Giá";
            _dataGridView.Columns["Stock"].HeaderText = "Tồn kho";
            _dataGridView.Columns["ModerationStatusTxt"].HeaderText = "Trạng thái kiểm duyệt";
            _dataGridView.Columns["BrandName"].HeaderText = "Tên thương hiệu";
        }
    }
}
