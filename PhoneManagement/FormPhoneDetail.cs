using PhoneManagement.Dtos;

namespace PhoneManagement
{
    public partial class FormPhoneDetail : Form
    {
        private readonly PhoneDto _phone;

        public FormPhoneDetail(PhoneDto phone)
        {
            InitializeComponent();
            _phone = phone;
            LoadData();
        }

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
                MessageBox.Show($"Lỗi: {ex.Message}");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
