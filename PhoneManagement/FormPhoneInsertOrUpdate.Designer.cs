namespace PhoneManagement
{
    partial class FormPhoneInsertOrUpdate
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
            label5 = new Label();
            txtModel = new TextBox();
            txtPrice = new TextBox();
            txtStock = new TextBox();
            cboBrand = new ComboBox();
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(91, 94);
            label1.Name = "label1";
            label1.Size = new Size(62, 15);
            label1.TabIndex = 0;
            label1.Text = "Tên model";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(91, 130);
            label2.Name = "label2";
            label2.Size = new Size(24, 15);
            label2.TabIndex = 1;
            label2.Text = "Giá";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(91, 167);
            label3.Name = "label3";
            label3.Size = new Size(50, 15);
            label3.TabIndex = 2;
            label3.Text = "Tồn kho";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(91, 208);
            label5.Name = "label5";
            label5.Size = new Size(74, 15);
            label5.TabIndex = 4;
            label5.Text = "Thương hiệu";
            // 
            // txtModel
            // 
            txtModel.Location = new Point(190, 94);
            txtModel.Name = "txtModel";
            txtModel.Size = new Size(213, 23);
            txtModel.TabIndex = 5;
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(190, 130);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(213, 23);
            txtPrice.TabIndex = 6;
            // 
            // txtStock
            // 
            txtStock.Location = new Point(190, 167);
            txtStock.Name = "txtStock";
            txtStock.Size = new Size(213, 23);
            txtStock.TabIndex = 7;
            // 
            // cboBrand
            // 
            cboBrand.FormattingEnabled = true;
            cboBrand.Location = new Point(190, 208);
            cboBrand.Name = "cboBrand";
            cboBrand.Size = new Size(213, 23);
            cboBrand.TabIndex = 8;
            // 
            // button1
            // 
            button1.Location = new Point(190, 266);
            button1.Name = "button1";
            button1.Size = new Size(80, 30);
            button1.TabIndex = 9;
            button1.Text = "Lưu";
            button1.UseVisualStyleBackColor = true;
            button1.Click += btnSave_Click;
            // 
            // button2
            // 
            button2.Location = new Point(323, 266);
            button2.Name = "button2";
            button2.Size = new Size(80, 30);
            button2.TabIndex = 10;
            button2.Text = "Hủy";
            button2.UseVisualStyleBackColor = true;
            button2.Click += btnCancel_Click;
            // 
            // FormPhoneInsertOrUpdate
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(559, 385);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(cboBrand);
            Controls.Add(txtStock);
            Controls.Add(txtPrice);
            Controls.Add(txtModel);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FormPhoneInsertOrUpdate";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Cập nhật, thêm mới điện thoại";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label5;
        private TextBox txtModel;
        private TextBox txtPrice;
        private TextBox txtStock;
        private ComboBox cboBrand;
        private Button button1;
        private Button button2;
    }
}