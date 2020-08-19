namespace GameDaoVang
{
    partial class HuongDanChoi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HuongDanChoi));
            this.btBack = new System.Windows.Forms.PictureBox();
            this.lbHuongDan = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.btBack)).BeginInit();
            this.SuspendLayout();
            // 
            // btBack
            // 
            this.btBack.BackColor = System.Drawing.Color.Transparent;
            this.btBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btBack.Image = global::GameDaoVang.Properties.Resources.back1;
            this.btBack.Location = new System.Drawing.Point(594, 12);
            this.btBack.Name = "btBack";
            this.btBack.Size = new System.Drawing.Size(50, 50);
            this.btBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btBack.TabIndex = 2;
            this.btBack.TabStop = false;
            this.btBack.Click += new System.EventHandler(this.btBack_Click);
            this.btBack.MouseLeave += new System.EventHandler(this.btBack_MouseLeave_1);
            this.btBack.MouseHover += new System.EventHandler(this.btBack_MouseHover_1);
            // 
            // lbHuongDan
            // 
            this.lbHuongDan.BackColor = System.Drawing.Color.Transparent;
            this.lbHuongDan.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHuongDan.ForeColor = System.Drawing.Color.Gold;
            this.lbHuongDan.Location = new System.Drawing.Point(36, 41);
            this.lbHuongDan.Name = "lbHuongDan";
            this.lbHuongDan.Size = new System.Drawing.Size(552, 271);
            this.lbHuongDan.TabIndex = 3;
            this.lbHuongDan.Text = resources.GetString("lbHuongDan.Text");
            this.lbHuongDan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // HuongDanChoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(656, 352);
            this.Controls.Add(this.lbHuongDan);
            this.Controls.Add(this.btBack);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "HuongDanChoi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hướng Dẫn Chơi Game Đào Vàng";
            ((System.ComponentModel.ISupportInitialize)(this.btBack)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox btBack;
        private System.Windows.Forms.Label lbHuongDan;
    }
}