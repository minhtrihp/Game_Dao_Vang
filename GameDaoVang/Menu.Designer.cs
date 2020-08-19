namespace GameDaoVang
{
    partial class Menu
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.timerChuotChay = new System.Windows.Forms.Timer(this.components);
            this.picMenu2 = new System.Windows.Forms.PictureBox();
            this.picMenu1 = new System.Windows.Forms.PictureBox();
            this.btChoi = new System.Windows.Forms.Button();
            this.btHuongDan = new System.Windows.Forms.Button();
            this.btThoat = new System.Windows.Forms.Button();
            this.picChuotChay = new System.Windows.Forms.PictureBox();
            this.picBangTen = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picMenu2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picChuotChay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBangTen)).BeginInit();
            this.SuspendLayout();
            // 
            // timerChuotChay
            // 
            this.timerChuotChay.Enabled = true;
            this.timerChuotChay.Interval = 30;
            this.timerChuotChay.Tick += new System.EventHandler(this.timerChuotChay_Tick);
            // 
            // picMenu2
            // 
            this.picMenu2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.picMenu2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.picMenu2.Location = new System.Drawing.Point(0, 302);
            this.picMenu2.Name = "picMenu2";
            this.picMenu2.Size = new System.Drawing.Size(656, 50);
            this.picMenu2.TabIndex = 0;
            this.picMenu2.TabStop = false;
            // 
            // picMenu1
            // 
            this.picMenu1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.picMenu1.Dock = System.Windows.Forms.DockStyle.Top;
            this.picMenu1.Location = new System.Drawing.Point(0, 0);
            this.picMenu1.Name = "picMenu1";
            this.picMenu1.Size = new System.Drawing.Size(656, 79);
            this.picMenu1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picMenu1.TabIndex = 0;
            this.picMenu1.TabStop = false;
            // 
            // btChoi
            // 
            this.btChoi.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btChoi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btChoi.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btChoi.Location = new System.Drawing.Point(275, 111);
            this.btChoi.Name = "btChoi";
            this.btChoi.Size = new System.Drawing.Size(112, 33);
            this.btChoi.TabIndex = 1;
            this.btChoi.Text = "Chơi ngay";
            this.btChoi.UseVisualStyleBackColor = false;
            this.btChoi.Click += new System.EventHandler(this.btChoi_Click);
            // 
            // btHuongDan
            // 
            this.btHuongDan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btHuongDan.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btHuongDan.Location = new System.Drawing.Point(275, 150);
            this.btHuongDan.Name = "btHuongDan";
            this.btHuongDan.Size = new System.Drawing.Size(112, 33);
            this.btHuongDan.TabIndex = 1;
            this.btHuongDan.Text = "Hướng dẫn";
            this.btHuongDan.UseVisualStyleBackColor = true;
            this.btHuongDan.Click += new System.EventHandler(this.btHuongDan_Click);
            // 
            // btThoat
            // 
            this.btThoat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btThoat.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btThoat.Location = new System.Drawing.Point(275, 189);
            this.btThoat.Name = "btThoat";
            this.btThoat.Size = new System.Drawing.Size(112, 33);
            this.btThoat.TabIndex = 1;
            this.btThoat.Text = "Thoát";
            this.btThoat.UseVisualStyleBackColor = true;
            this.btThoat.Click += new System.EventHandler(this.btThoat_Click);
            // 
            // picChuotChay
            // 
            this.picChuotChay.BackColor = System.Drawing.Color.Transparent;
            this.picChuotChay.Location = new System.Drawing.Point(602, 96);
            this.picChuotChay.Name = "picChuotChay";
            this.picChuotChay.Size = new System.Drawing.Size(54, 33);
            this.picChuotChay.TabIndex = 2;
            this.picChuotChay.TabStop = false;
            // 
            // picBangTen
            // 
            this.picBangTen.BackColor = System.Drawing.Color.Transparent;
            this.picBangTen.Image = global::GameDaoVang.Properties.Resources.img_title;
            this.picBangTen.Location = new System.Drawing.Point(185, 0);
            this.picBangTen.Name = "picBangTen";
            this.picBangTen.Size = new System.Drawing.Size(293, 79);
            this.picBangTen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBangTen.TabIndex = 4;
            this.picBangTen.TabStop = false;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 352);
            this.Controls.Add(this.picBangTen);
            this.Controls.Add(this.picChuotChay);
            this.Controls.Add(this.btThoat);
            this.Controls.Add(this.btHuongDan);
            this.Controls.Add(this.btChoi);
            this.Controls.Add(this.picMenu1);
            this.Controls.Add(this.picMenu2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu Game Đào Vàng";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Menu_FormClosing);
            this.Load += new System.EventHandler(this.Menu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picMenu2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picChuotChay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBangTen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picMenu2;
        private System.Windows.Forms.PictureBox picMenu1;
        private System.Windows.Forms.Button btChoi;
        private System.Windows.Forms.Button btHuongDan;
        private System.Windows.Forms.Button btThoat;
        private System.Windows.Forms.PictureBox picChuotChay;
        public System.Windows.Forms.Timer timerChuotChay;
        private System.Windows.Forms.PictureBox picBangTen;
    }
}

