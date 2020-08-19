namespace GameDaoVang
{
    partial class GioiThieu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GioiThieu));
            this.timerLoading = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.picBangTen = new System.Windows.Forms.PictureBox();
            this.picChuotChay = new System.Windows.Forms.PictureBox();
            this.lbLoading = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picBangTen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picChuotChay)).BeginInit();
            this.SuspendLayout();
            // 
            // timerLoading
            // 
            this.timerLoading.Enabled = true;
            this.timerLoading.Interval = 30;
            this.timerLoading.Tick += new System.EventHandler(this.timerLoading_Tick);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gold;
            this.label1.Location = new System.Drawing.Point(58, 150);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(549, 54);
            this.label1.TabIndex = 5;
            this.label1.Text = "Create by: Kiet - Tri - Thinh";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picBangTen
            // 
            this.picBangTen.BackColor = System.Drawing.Color.Transparent;
            this.picBangTen.Image = global::GameDaoVang.Properties.Resources.img_title;
            this.picBangTen.Location = new System.Drawing.Point(154, 35);
            this.picBangTen.Name = "picBangTen";
            this.picBangTen.Size = new System.Drawing.Size(356, 87);
            this.picBangTen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBangTen.TabIndex = 6;
            this.picBangTen.TabStop = false;
            // 
            // picChuotChay
            // 
            this.picChuotChay.Location = new System.Drawing.Point(185, 295);
            this.picChuotChay.Name = "picChuotChay";
            this.picChuotChay.Size = new System.Drawing.Size(56, 29);
            this.picChuotChay.TabIndex = 2;
            this.picChuotChay.TabStop = false;
            // 
            // lbLoading
            // 
            this.lbLoading.BackColor = System.Drawing.Color.Transparent;
            this.lbLoading.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbLoading.ForeColor = System.Drawing.Color.Gold;
            this.lbLoading.Location = new System.Drawing.Point(199, 204);
            this.lbLoading.Name = "lbLoading";
            this.lbLoading.Size = new System.Drawing.Size(269, 60);
            this.lbLoading.TabIndex = 7;
            this.lbLoading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GioiThieu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SaddleBrown;
            this.ClientSize = new System.Drawing.Size(656, 352);
            this.Controls.Add(this.lbLoading);
            this.Controls.Add(this.picBangTen);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picChuotChay);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "GioiThieu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Giới Thiệu Game Đào Vàng";
            this.Load += new System.EventHandler(this.GioiThieu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBangTen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picChuotChay)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timerLoading;
        private System.Windows.Forms.PictureBox picChuotChay;
        private System.Windows.Forms.PictureBox picBangTen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbLoading;
    }
}