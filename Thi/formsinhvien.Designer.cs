namespace Thi
{
    partial class formmain
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
            this.mntrchucnang = new System.Windows.Forms.MenuStrip();
            this.helloToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mntrdangxuat = new System.Windows.Forms.ToolStripMenuItem();
            this.exammenutrip = new System.Windows.Forms.ToolStripMenuItem();
            this.mntrthi = new System.Windows.Forms.ToolStripMenuItem();
            this.traCứuĐiểmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mntrketqua = new System.Windows.Forms.ToolStripMenuItem();
            this.grbtimkiemtensv = new System.Windows.Forms.GroupBox();
            this.btntimkiemtensv = new System.Windows.Forms.Button();
            this.label22 = new System.Windows.Forms.Label();
            this.txtfindtensv = new System.Windows.Forms.TextBox();
            this.grbtimkiemmasv = new System.Windows.Forms.GroupBox();
            this.btntinkiemmasv = new System.Windows.Forms.Button();
            this.txtfindmasv = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.lblthongbao = new System.Windows.Forms.Label();
            this.dgvketqua = new System.Windows.Forms.DataGridView();
            this.mntrchucnang.SuspendLayout();
            this.grbtimkiemtensv.SuspendLayout();
            this.grbtimkiemmasv.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvketqua)).BeginInit();
            this.SuspendLayout();
            // 
            // mntrchucnang
            // 
            this.mntrchucnang.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.mntrchucnang.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mntrchucnang.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helloToolStripMenuItem,
            this.exammenutrip,
            this.traCứuĐiểmToolStripMenuItem});
            this.mntrchucnang.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.mntrchucnang.Location = new System.Drawing.Point(0, 0);
            this.mntrchucnang.Name = "mntrchucnang";
            this.mntrchucnang.Size = new System.Drawing.Size(775, 25);
            this.mntrchucnang.TabIndex = 116;
            this.mntrchucnang.Text = "menuStrip1";
            // 
            // helloToolStripMenuItem
            // 
            this.helloToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mntrdangxuat});
            this.helloToolStripMenuItem.Name = "helloToolStripMenuItem";
            this.helloToolStripMenuItem.Size = new System.Drawing.Size(77, 21);
            this.helloToolStripMenuItem.Text = "Hệ Thống";
            // 
            // mntrdangxuat
            // 
            this.mntrdangxuat.Name = "mntrdangxuat";
            this.mntrdangxuat.Size = new System.Drawing.Size(137, 22);
            this.mntrdangxuat.Text = "Đăng Xuất";
            this.mntrdangxuat.Click += new System.EventHandler(this.mntrdangxuat_Click_1);
            // 
            // exammenutrip
            // 
            this.exammenutrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mntrthi});
            this.exammenutrip.Name = "exammenutrip";
            this.exammenutrip.Size = new System.Drawing.Size(37, 21);
            this.exammenutrip.Text = "Thi";
            // 
            // mntrthi
            // 
            this.mntrthi.Name = "mntrthi";
            this.mntrthi.Size = new System.Drawing.Size(93, 22);
            this.mntrthi.Text = "Thi";
            this.mntrthi.Click += new System.EventHandler(this.mntrthi_Click_1);
            // 
            // traCứuĐiểmToolStripMenuItem
            // 
            this.traCứuĐiểmToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mntrketqua});
            this.traCứuĐiểmToolStripMenuItem.Name = "traCứuĐiểmToolStripMenuItem";
            this.traCứuĐiểmToolStripMenuItem.Size = new System.Drawing.Size(99, 21);
            this.traCứuĐiểmToolStripMenuItem.Text = "Tra Cứu Điểm";
            // 
            // mntrketqua
            // 
            this.mntrketqua.Name = "mntrketqua";
            this.mntrketqua.Size = new System.Drawing.Size(123, 22);
            this.mntrketqua.Text = "Kết Quả";
            this.mntrketqua.Click += new System.EventHandler(this.mntrketqua_Click_1);
            // 
            // grbtimkiemtensv
            // 
            this.grbtimkiemtensv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.grbtimkiemtensv.Controls.Add(this.btntimkiemtensv);
            this.grbtimkiemtensv.Controls.Add(this.label22);
            this.grbtimkiemtensv.Controls.Add(this.txtfindtensv);
            this.grbtimkiemtensv.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbtimkiemtensv.Location = new System.Drawing.Point(12, 139);
            this.grbtimkiemtensv.Name = "grbtimkiemtensv";
            this.grbtimkiemtensv.Size = new System.Drawing.Size(349, 105);
            this.grbtimkiemtensv.TabIndex = 119;
            this.grbtimkiemtensv.TabStop = false;
            this.grbtimkiemtensv.Text = "Tìm Kiếm Theo Tên Sinh Viên:";
            // 
            // btntimkiemtensv
            // 
            this.btntimkiemtensv.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btntimkiemtensv.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btntimkiemtensv.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btntimkiemtensv.Location = new System.Drawing.Point(135, 68);
            this.btntimkiemtensv.Name = "btntimkiemtensv";
            this.btntimkiemtensv.Size = new System.Drawing.Size(83, 31);
            this.btntimkiemtensv.TabIndex = 118;
            this.btntimkiemtensv.Text = "Tìm Kiếm";
            this.btntimkiemtensv.UseVisualStyleBackColor = true;
            this.btntimkiemtensv.Click += new System.EventHandler(this.btntimkiemtensv_Click_1);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(31, 40);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(79, 16);
            this.label22.TabIndex = 113;
            this.label22.Text = "Họ Và Tên :";
            // 
            // txtfindtensv
            // 
            this.txtfindtensv.Location = new System.Drawing.Point(135, 40);
            this.txtfindtensv.Multiline = true;
            this.txtfindtensv.Name = "txtfindtensv";
            this.txtfindtensv.Size = new System.Drawing.Size(173, 22);
            this.txtfindtensv.TabIndex = 114;
            // 
            // grbtimkiemmasv
            // 
            this.grbtimkiemmasv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.grbtimkiemmasv.Controls.Add(this.btntinkiemmasv);
            this.grbtimkiemmasv.Controls.Add(this.txtfindmasv);
            this.grbtimkiemmasv.Controls.Add(this.label19);
            this.grbtimkiemmasv.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbtimkiemmasv.Location = new System.Drawing.Point(413, 139);
            this.grbtimkiemmasv.Name = "grbtimkiemmasv";
            this.grbtimkiemmasv.Size = new System.Drawing.Size(349, 105);
            this.grbtimkiemmasv.TabIndex = 118;
            this.grbtimkiemmasv.TabStop = false;
            this.grbtimkiemmasv.Text = "Tìm Kiếm Theo Mã Sinh Viên:";
            // 
            // btntinkiemmasv
            // 
            this.btntinkiemmasv.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btntinkiemmasv.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btntinkiemmasv.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btntinkiemmasv.Location = new System.Drawing.Point(135, 66);
            this.btntinkiemmasv.Name = "btntinkiemmasv";
            this.btntinkiemmasv.Size = new System.Drawing.Size(83, 31);
            this.btntinkiemmasv.TabIndex = 117;
            this.btntinkiemmasv.Text = "Tìm Kiếm";
            this.btntinkiemmasv.UseVisualStyleBackColor = true;
            this.btntinkiemmasv.Click += new System.EventHandler(this.btntinkiemmasv_Click_1);
            // 
            // txtfindmasv
            // 
            this.txtfindmasv.Location = new System.Drawing.Point(135, 38);
            this.txtfindmasv.Multiline = true;
            this.txtfindmasv.Name = "txtfindmasv";
            this.txtfindmasv.Size = new System.Drawing.Size(173, 22);
            this.txtfindmasv.TabIndex = 116;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(18, 41);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(92, 16);
            this.label19.TabIndex = 115;
            this.label19.Text = "Mã Sinh Vien :";
            // 
            // lblthongbao
            // 
            this.lblthongbao.AutoSize = true;
            this.lblthongbao.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblthongbao.ForeColor = System.Drawing.Color.Red;
            this.lblthongbao.Location = new System.Drawing.Point(176, 196);
            this.lblthongbao.Name = "lblthongbao";
            this.lblthongbao.Size = new System.Drawing.Size(392, 31);
            this.lblthongbao.TabIndex = 120;
            this.lblthongbao.Text = "Vui lòng chọn mục bạn muốn !!!";
            // 
            // dgvketqua
            // 
            this.dgvketqua.BackgroundColor = System.Drawing.Color.White;
            this.dgvketqua.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvketqua.Location = new System.Drawing.Point(12, 306);
            this.dgvketqua.Name = "dgvketqua";
            this.dgvketqua.Size = new System.Drawing.Size(750, 165);
            this.dgvketqua.TabIndex = 121;
            // 
            // formmain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(775, 483);
            this.Controls.Add(this.dgvketqua);
            this.Controls.Add(this.lblthongbao);
            this.Controls.Add(this.grbtimkiemtensv);
            this.Controls.Add(this.grbtimkiemmasv);
            this.Controls.Add(this.mntrchucnang);
            this.MainMenuStrip = this.mntrchucnang;
            this.Name = "formmain";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sinh Viên";
            this.Load += new System.EventHandler(this.formmain_Load_1);
            this.mntrchucnang.ResumeLayout(false);
            this.mntrchucnang.PerformLayout();
            this.grbtimkiemtensv.ResumeLayout(false);
            this.grbtimkiemtensv.PerformLayout();
            this.grbtimkiemmasv.ResumeLayout(false);
            this.grbtimkiemmasv.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvketqua)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStripMenuItem helloToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mntrdangxuat;
        private System.Windows.Forms.ToolStripMenuItem traCứuĐiểmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mntrketqua;
        public System.Windows.Forms.MenuStrip mntrchucnang;
        private System.Windows.Forms.ToolStripMenuItem exammenutrip;
        private System.Windows.Forms.ToolStripMenuItem mntrthi;
        private System.Windows.Forms.GroupBox grbtimkiemtensv;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txtfindtensv;
        private System.Windows.Forms.GroupBox grbtimkiemmasv;
        private System.Windows.Forms.TextBox txtfindmasv;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button btntinkiemmasv;
        private System.Windows.Forms.Button btntimkiemtensv;
        private System.Windows.Forms.Label lblthongbao;
        private System.Windows.Forms.DataGridView dgvketqua;
    }
}