namespace PhoneManagement
{
    partial class FormPhoneDetail
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            txtModel = new TextBox();
            txtPrice = new TextBox();
            txtStock = new TextBox();
            txtModerationStatus = new TextBox();
            txtBrandName = new TextBox();
            txtCreated = new TextBox();
            txtLastModified = new TextBox();
            btnClose = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(120, 103);
            label1.Name = "label1";
            label1.Size = new Size(62, 15);
            label1.TabIndex = 0;
            label1.Text = "Tên model";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(120, 132);
            label2.Name = "label2";
            label2.Size = new Size(24, 15);
            label2.TabIndex = 1;
            label2.Text = "Giá";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(120, 161);
            label3.Name = "label3";
            label3.Size = new Size(50, 15);
            label3.TabIndex = 2;
            label3.Text = "Tồn kho";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(120, 190);
            label4.Name = "label4";
            label4.Size = new Size(59, 15);
            label4.TabIndex = 3;
            label4.Text = "Trạng thái";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(120, 219);
            label5.Name = "label5";
            label5.Size = new Size(74, 15);
            label5.TabIndex = 4;
            label5.Text = "Thương hiệu";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(120, 248);
            label6.Name = "label6";
            label6.Size = new Size(70, 15);
            label6.TabIndex = 5;
            label6.Text = "Khởi tạo lúc";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(120, 277);
            label7.Name = "label7";
            label7.Size = new Size(81, 15);
            label7.TabIndex = 6;
            label7.Text = "Cập nhật cuối";
            // 
            // txtModel
            // 
            txtModel.Enabled = false;
            txtModel.Location = new Point(210, 100);
            txtModel.Name = "txtModel";
            txtModel.ReadOnly = true;
            txtModel.Size = new Size(210, 23);
            txtModel.TabIndex = 7;
            // 
            // txtPrice
            // 
            txtPrice.Enabled = false;
            txtPrice.Location = new Point(210, 129);
            txtPrice.Name = "txtPrice";
            txtPrice.ReadOnly = true;
            txtPrice.Size = new Size(210, 23);
            txtPrice.TabIndex = 8;
            // 
            // txtStock
            // 
            txtStock.Enabled = false;
            txtStock.Location = new Point(210, 158);
            txtStock.Name = "txtStock";
            txtStock.ReadOnly = true;
            txtStock.Size = new Size(210, 23);
            txtStock.TabIndex = 9;
            // 
            // txtModerationStatus
            // 
            txtModerationStatus.Enabled = false;
            txtModerationStatus.Location = new Point(210, 187);
            txtModerationStatus.Name = "txtModerationStatus";
            txtModerationStatus.ReadOnly = true;
            txtModerationStatus.Size = new Size(210, 23);
            txtModerationStatus.TabIndex = 10;
            // 
            // txtBrandName
            // 
            txtBrandName.Enabled = false;
            txtBrandName.Location = new Point(210, 216);
            txtBrandName.Name = "txtBrandName";
            txtBrandName.ReadOnly = true;
            txtBrandName.Size = new Size(210, 23);
            txtBrandName.TabIndex = 11;
            // 
            // txtCreated
            // 
            txtCreated.Enabled = false;
            txtCreated.Location = new Point(210, 245);
            txtCreated.Name = "txtCreated";
            txtCreated.ReadOnly = true;
            txtCreated.Size = new Size(210, 23);
            txtCreated.TabIndex = 12;
            // 
            // txtLastModified
            // 
            txtLastModified.Enabled = false;
            txtLastModified.Location = new Point(210, 274);
            txtLastModified.Name = "txtLastModified";
            txtLastModified.ReadOnly = true;
            txtLastModified.Size = new Size(210, 23);
            txtLastModified.TabIndex = 13;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(345, 356);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(75, 23);
            btnClose.TabIndex = 14;
            btnClose.Text = "Đóng ";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // FormPhoneDetail
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(579, 447);
            Controls.Add(btnClose);
            Controls.Add(txtLastModified);
            Controls.Add(txtCreated);
            Controls.Add(txtBrandName);
            Controls.Add(txtModerationStatus);
            Controls.Add(txtStock);
            Controls.Add(txtPrice);
            Controls.Add(txtModel);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormPhoneDetail";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Xem chi tiết";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox txtModel;
        private TextBox txtPrice;
        private TextBox txtStock;
        private TextBox txtModerationStatus;
        private TextBox txtBrandName;
        private TextBox txtCreated;
        private TextBox txtLastModified;
        private Button btnClose;
    }
}