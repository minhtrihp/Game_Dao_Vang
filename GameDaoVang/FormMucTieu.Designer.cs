namespace GameDaoVang
{
    partial class FormMucTieu
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
            this.lbMucTieu = new System.Windows.Forms.Label();
            this.timerSangMan = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lbMucTieu
            // 
            this.lbMucTieu.BackColor = System.Drawing.Color.Transparent;
            this.lbMucTieu.Font = new System.Drawing.Font("Tahoma", 39.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMucTieu.Location = new System.Drawing.Point(274, 220);
            this.lbMucTieu.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbMucTieu.Name = "lbMucTieu";
            this.lbMucTieu.Size = new System.Drawing.Size(262, 77);
            this.lbMucTieu.TabIndex = 0;
            this.lbMucTieu.Text = "0";
            this.lbMucTieu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbMucTieu.UseCompatibleTextRendering = true;
            // 
            // timerSangMan
            // 
            this.timerSangMan.Enabled = true;
            this.timerSangMan.Tick += new System.EventHandler(this.timerSangMan_Tick);
            // 
            // FormMucTieu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::GameDaoVang.Properties.Resources.mucTieu;
            this.ClientSize = new System.Drawing.Size(800, 476);
            this.Controls.Add(this.lbMucTieu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.Name = "FormMucTieu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormMucTieu";
            this.Load += new System.EventHandler(this.FormMucTieu_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbMucTieu;
        private System.Windows.Forms.Timer timerSangMan;
    }
}