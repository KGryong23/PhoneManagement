namespace PhoneManagement
{
    partial class FormPhone
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            btnCreatePhone = new Button();
            txtKeyword = new TextBox();
            button2 = new Button();
            dgvPhones = new DataGridView();
            btnPrevPage = new Button();
            btnNextPage = new Button();
            lblPageInfo = new TextBox();
            contextMenuStrip1 = new ContextMenuStrip(components);
            btnUpdate = new Button();
            btnDelete = new Button();
            btnApprove = new Button();
            btnReject = new Button();
            button6 = new Button();
            button7 = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvPhones).BeginInit();
            SuspendLayout();
            // 
            // btnCreatePhone
            // 
            btnCreatePhone.Location = new Point(12, 86);
            btnCreatePhone.Name = "btnCreatePhone";
            btnCreatePhone.Size = new Size(97, 38);
            btnCreatePhone.TabIndex = 0;
            btnCreatePhone.Text = "Thêm mới";
            btnCreatePhone.UseVisualStyleBackColor = true;
            btnCreatePhone.Click += btnCreate_Click;
            // 
            // txtKeyword
            // 
            txtKeyword.Location = new Point(647, 95);
            txtKeyword.Name = "txtKeyword";
            txtKeyword.Size = new Size(264, 29);
            txtKeyword.TabIndex = 1;
            // 
            // button2
            // 
            button2.Location = new Point(526, 86);
            button2.Name = "button2";
            button2.Size = new Size(104, 38);
            button2.TabIndex = 2;
            button2.Text = "Tìm kiếm";
            button2.UseVisualStyleBackColor = true;
            button2.Click += btnSearch_Click;
            // 
            // dgvPhones
            // 
            dgvPhones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPhones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPhones.Location = new Point(12, 130);
            dgvPhones.MultiSelect = false;
            dgvPhones.Name = "dgvPhones";
            dgvPhones.ReadOnly = true;
            dgvPhones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPhones.Size = new Size(991, 364);
            dgvPhones.TabIndex = 3;
            dgvPhones.SelectionChanged += dgvPhones_SelectionChanged;
            // 
            // btnPrevPage
            // 
            btnPrevPage.Location = new Point(557, 505);
            btnPrevPage.Name = "btnPrevPage";
            btnPrevPage.Size = new Size(96, 38);
            btnPrevPage.TabIndex = 4;
            btnPrevPage.Text = "Trước";
            btnPrevPage.UseVisualStyleBackColor = true;
            btnPrevPage.Click += btnPrevPage_Click;
            // 
            // btnNextPage
            // 
            btnNextPage.Location = new Point(659, 505);
            btnNextPage.Name = "btnNextPage";
            btnNextPage.Size = new Size(97, 38);
            btnNextPage.TabIndex = 5;
            btnNextPage.Text = "Sau";
            btnNextPage.UseVisualStyleBackColor = true;
            btnNextPage.Click += btnNextPage_Click;
            // 
            // lblPageInfo
            // 
            lblPageInfo.AccessibleDescription = "";
            lblPageInfo.Enabled = false;
            lblPageInfo.Location = new Point(773, 514);
            lblPageInfo.Name = "lblPageInfo";
            lblPageInfo.Size = new Size(230, 29);
            lblPageInfo.TabIndex = 6;
            lblPageInfo.TextAlign = HorizontalAlignment.Center;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(125, 505);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(83, 36);
            btnUpdate.TabIndex = 7;
            btnUpdate.Text = "Cập nhật";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(214, 505);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(86, 36);
            btnDelete.TabIndex = 8;
            btnDelete.Text = "Xóa";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnApprove
            // 
            btnApprove.Location = new Point(306, 505);
            btnApprove.Name = "btnApprove";
            btnApprove.Size = new Size(95, 36);
            btnApprove.TabIndex = 9;
            btnApprove.Text = "Duyệt";
            btnApprove.UseVisualStyleBackColor = true;
            btnApprove.Click += btnApprove_Click;
            // 
            // btnReject
            // 
            btnReject.Location = new Point(407, 505);
            btnReject.Name = "btnReject";
            btnReject.Size = new Size(96, 36);
            btnReject.TabIndex = 10;
            btnReject.Text = "Hủy duyệt";
            btnReject.UseVisualStyleBackColor = true;
            btnReject.Click += btnReject_Click;
            // 
            // button6
            // 
            button6.Location = new Point(12, 505);
            button6.Name = "button6";
            button6.Size = new Size(107, 36);
            button6.TabIndex = 11;
            button6.Text = "Xem chi tiết";
            button6.UseVisualStyleBackColor = true;
            button6.Click += btnViewDetail_Click;
            // 
            // button7
            // 
            button7.Location = new Point(935, 95);
            button7.Name = "button7";
            button7.Size = new Size(68, 29);
            button7.TabIndex = 12;
            button7.Text = "Clear";
            button7.UseVisualStyleBackColor = true;
            button7.Click += btnClearInputs_Click;
            // 
            // FormPhone
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1029, 630);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(btnReject);
            Controls.Add(btnApprove);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(lblPageInfo);
            Controls.Add(btnNextPage);
            Controls.Add(btnPrevPage);
            Controls.Add(dgvPhones);
            Controls.Add(button2);
            Controls.Add(txtKeyword);
            Controls.Add(btnCreatePhone);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "FormPhone";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "+";
            ((System.ComponentModel.ISupportInitialize)dgvPhones).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtKeyword;
        private Button button2;
        private DataGridView dgvPhones;
        private Button btnPrevPage;
        private Button btnNextPage;
        private Button btnCreatePhone;
        private TextBox lblPageInfo;
        private ContextMenuStrip contextMenuStrip1;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnApprove;
        private Button btnReject;
        private Button button6;
        private Button button7;
    }
}
