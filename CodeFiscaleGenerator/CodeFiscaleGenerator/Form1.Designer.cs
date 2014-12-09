namespace CodeFiscaleGenerator
{
    partial class Form1
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
            this.labelCbox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.registrationCbox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.subregistrationCbox = new System.Windows.Forms.ComboBox();
            this.fiscaleCodeTbox = new System.Windows.Forms.TextBox();
            this.createBtn = new System.Windows.Forms.Button();
            this.checkBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelCbox
            // 
            this.labelCbox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.labelCbox.FormattingEnabled = true;
            this.labelCbox.Location = new System.Drawing.Point(24, 30);
            this.labelCbox.Name = "labelCbox";
            this.labelCbox.Size = new System.Drawing.Size(105, 21);
            this.labelCbox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Label";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Registration status";
            // 
            // registrationCbox
            // 
            this.registrationCbox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.registrationCbox.FormattingEnabled = true;
            this.registrationCbox.Location = new System.Drawing.Point(24, 77);
            this.registrationCbox.Name = "registrationCbox";
            this.registrationCbox.Size = new System.Drawing.Size(222, 21);
            this.registrationCbox.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Subregistration status";
            // 
            // subregistrationCbox
            // 
            this.subregistrationCbox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.subregistrationCbox.FormattingEnabled = true;
            this.subregistrationCbox.Location = new System.Drawing.Point(24, 125);
            this.subregistrationCbox.Name = "subregistrationCbox";
            this.subregistrationCbox.Size = new System.Drawing.Size(222, 21);
            this.subregistrationCbox.TabIndex = 4;
            // 
            // fiscaleCodeTbox
            // 
            this.fiscaleCodeTbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fiscaleCodeTbox.ForeColor = System.Drawing.SystemColors.InfoText;
            this.fiscaleCodeTbox.Location = new System.Drawing.Point(24, 164);
            this.fiscaleCodeTbox.Name = "fiscaleCodeTbox";
            this.fiscaleCodeTbox.Size = new System.Drawing.Size(222, 26);
            this.fiscaleCodeTbox.TabIndex = 6;
            // 
            // createBtn
            // 
            this.createBtn.Location = new System.Drawing.Point(24, 202);
            this.createBtn.Name = "createBtn";
            this.createBtn.Size = new System.Drawing.Size(90, 23);
            this.createBtn.TabIndex = 7;
            this.createBtn.Text = "Create";
            this.createBtn.UseVisualStyleBackColor = true;
            this.createBtn.Click += new System.EventHandler(this.Create_Click);
            // 
            // checkBtn
            // 
            this.checkBtn.Location = new System.Drawing.Point(156, 202);
            this.checkBtn.Name = "checkBtn";
            this.checkBtn.Size = new System.Drawing.Size(90, 23);
            this.checkBtn.TabIndex = 8;
            this.checkBtn.Text = "Check";
            this.checkBtn.UseVisualStyleBackColor = true;
            this.checkBtn.Click += new System.EventHandler(this.Check_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Menu;
            this.ClientSize = new System.Drawing.Size(271, 241);
            this.Controls.Add(this.checkBtn);
            this.Controls.Add(this.createBtn);
            this.Controls.Add(this.fiscaleCodeTbox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.subregistrationCbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.registrationCbox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelCbox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Text = "CodeFiscaleGenerator v1.4 - created by -=Tj=-";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox labelCbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox registrationCbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox subregistrationCbox;
        private System.Windows.Forms.TextBox fiscaleCodeTbox;
        private System.Windows.Forms.Button createBtn;
        private System.Windows.Forms.Button checkBtn;
    }
}

