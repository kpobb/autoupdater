namespace Autoupdater
{
    partial class AutoupdaterForm
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
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.runCurrentBtn = new System.Windows.Forms.Button();
            this.updateBtn = new System.Windows.Forms.Button();
            this.progress = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(50, 74);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(262, 23);
            this.progressBar1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(123, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "New version: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(189, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "version";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(70, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(226, 24);
            this.label3.TabIndex = 3;
            this.label3.Text = "New updates were found!";
            // 
            // runCurrentBtn
            // 
            this.runCurrentBtn.Location = new System.Drawing.Point(50, 150);
            this.runCurrentBtn.Name = "runCurrentBtn";
            this.runCurrentBtn.Size = new System.Drawing.Size(110, 23);
            this.runCurrentBtn.TabIndex = 4;
            this.runCurrentBtn.Text = "Run current";
            this.runCurrentBtn.UseVisualStyleBackColor = true;
            // 
            // updateBtn
            // 
            this.updateBtn.Location = new System.Drawing.Point(202, 150);
            this.updateBtn.Name = "updateBtn";
            this.updateBtn.Size = new System.Drawing.Size(110, 23);
            this.updateBtn.TabIndex = 5;
            this.updateBtn.Text = "Update";
            this.updateBtn.UseVisualStyleBackColor = true;
            this.updateBtn.Click += new System.EventHandler(this.updateBtn_Click);
            // 
            // progress
            // 
            this.progress.AutoSize = true;
            this.progress.Location = new System.Drawing.Point(155, 80);
            this.progress.Name = "progress";
            this.progress.Size = new System.Drawing.Size(41, 13);
            this.progress.TabIndex = 6;
            this.progress.Text = "version";
            // 
            // NewUpdatesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 198);
            this.Controls.Add(this.progress);
            this.Controls.Add(this.updateBtn);
            this.Controls.Add(this.runCurrentBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBar1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewUpdatesForm";
            this.Text = "NewUpdates";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button runCurrentBtn;
        private System.Windows.Forms.Button updateBtn;
        private System.Windows.Forms.Label progress;
    }
}