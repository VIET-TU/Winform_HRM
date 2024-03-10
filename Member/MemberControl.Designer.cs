namespace HRM_Desktop
{
    partial class MemberControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MemberControl));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Button_reload = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button_export = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button_filter = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button_add = new Guna.UI2.WinForms.Guna2Button();
            this.guna2DataGridView_member = new Guna.UI2.WinForms.Guna2DataGridView();
            this.column_avartar = new System.Windows.Forms.DataGridViewImageColumn();
            this.Column_manv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_hoten = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_gioitinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_ngaysinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_phongban = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_nn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_edit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Column_delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.guna2AnimateWindow1 = new Guna.UI2.WinForms.Guna2AnimateWindow(this.components);
            this.textBox_hoten = new Guna.UI2.WinForms.Guna2TextBox();
            this.comboBox_pb = new Guna.UI2.WinForms.Guna2ComboBox();
            this.comboBox_cv = new Guna.UI2.WinForms.Guna2ComboBox();
            this.button_timkiem = new Guna.UI2.WinForms.Guna2Button();
            this.groupBox_nn = new System.Windows.Forms.GroupBox();
            this.guna2Button_moi = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Panel_filter_member = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2HtmlLabel_cv = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel_pb = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel_hvt = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2HtmlLabel2_page_number = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2Button_next = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button_previous = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2DataGridView_member)).BeginInit();
            this.guna2Panel_filter_member.SuspendLayout();
            this.guna2Panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(14, 17);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(181, 31);
            this.guna2HtmlLabel1.TabIndex = 0;
            this.guna2HtmlLabel1.Text = "LIST MEMBERS";
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.guna2Button_reload);
            this.guna2Panel1.Controls.Add(this.guna2Button_export);
            this.guna2Panel1.Controls.Add(this.guna2HtmlLabel1);
            this.guna2Panel1.Controls.Add(this.guna2Button_filter);
            this.guna2Panel1.Controls.Add(this.guna2Button_add);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(1400, 62);
            this.guna2Panel1.TabIndex = 1;
            this.guna2Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.guna2Panel1_Paint);
            // 
            // guna2Button_reload
            // 
            this.guna2Button_reload.BackColor = System.Drawing.Color.White;
            this.guna2Button_reload.BorderThickness = 1;
            this.guna2Button_reload.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button_reload.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button_reload.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button_reload.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button_reload.FillColor = System.Drawing.Color.Transparent;
            this.guna2Button_reload.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button_reload.ForeColor = System.Drawing.Color.Black;
            this.guna2Button_reload.Image = ((System.Drawing.Image)(resources.GetObject("guna2Button_reload.Image")));
            this.guna2Button_reload.Location = new System.Drawing.Point(1333, 16);
            this.guna2Button_reload.Name = "guna2Button_reload";
            this.guna2Button_reload.Size = new System.Drawing.Size(45, 32);
            this.guna2Button_reload.TabIndex = 9;
            this.guna2Button_reload.Click += new System.EventHandler(this.guna2Button_reload_Click);
            // 
            // guna2Button_export
            // 
            this.guna2Button_export.BorderThickness = 1;
            this.guna2Button_export.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button_export.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button_export.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button_export.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button_export.FillColor = System.Drawing.Color.White;
            this.guna2Button_export.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button_export.ForeColor = System.Drawing.Color.Black;
            this.guna2Button_export.Image = ((System.Drawing.Image)(resources.GetObject("guna2Button_export.Image")));
            this.guna2Button_export.Location = new System.Drawing.Point(1238, 16);
            this.guna2Button_export.Name = "guna2Button_export";
            this.guna2Button_export.Size = new System.Drawing.Size(89, 32);
            this.guna2Button_export.TabIndex = 8;
            this.guna2Button_export.Text = "Export";
            this.guna2Button_export.Click += new System.EventHandler(this.guna2Button_export_Click);
            // 
            // guna2Button_filter
            // 
            this.guna2Button_filter.BackColor = System.Drawing.Color.White;
            this.guna2Button_filter.BorderThickness = 1;
            this.guna2Button_filter.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button_filter.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button_filter.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button_filter.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button_filter.FillColor = System.Drawing.Color.Transparent;
            this.guna2Button_filter.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button_filter.ForeColor = System.Drawing.Color.Black;
            this.guna2Button_filter.Image = ((System.Drawing.Image)(resources.GetObject("guna2Button_filter.Image")));
            this.guna2Button_filter.Location = new System.Drawing.Point(1036, 16);
            this.guna2Button_filter.Name = "guna2Button_filter";
            this.guna2Button_filter.Size = new System.Drawing.Size(101, 32);
            this.guna2Button_filter.TabIndex = 7;
            this.guna2Button_filter.Text = " Filter";
            this.guna2Button_filter.Click += new System.EventHandler(this.guna2Button_filter_Click);
            // 
            // guna2Button_add
            // 
            this.guna2Button_add.BorderThickness = 1;
            this.guna2Button_add.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button_add.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button_add.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button_add.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button_add.FillColor = System.Drawing.Color.White;
            this.guna2Button_add.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button_add.ForeColor = System.Drawing.Color.Black;
            this.guna2Button_add.Image = ((System.Drawing.Image)(resources.GetObject("guna2Button_add.Image")));
            this.guna2Button_add.Location = new System.Drawing.Point(1143, 16);
            this.guna2Button_add.Name = "guna2Button_add";
            this.guna2Button_add.Size = new System.Drawing.Size(89, 32);
            this.guna2Button_add.TabIndex = 6;
            this.guna2Button_add.Text = "Add";
            this.guna2Button_add.Click += new System.EventHandler(this.guna2Button_add_Click);
            // 
            // guna2DataGridView_member
            // 
            this.guna2DataGridView_member.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.guna2DataGridView_member.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.guna2DataGridView_member.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.guna2DataGridView_member.ColumnHeadersHeight = 50;
            this.guna2DataGridView_member.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.guna2DataGridView_member.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.column_avartar,
            this.Column_manv,
            this.Column_hoten,
            this.Column_gioitinh,
            this.Column_ngaysinh,
            this.Column6,
            this.Column_phongban,
            this.Column8,
            this.Column_nn,
            this.Column_edit,
            this.Column_delete});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.guna2DataGridView_member.DefaultCellStyle = dataGridViewCellStyle5;
            this.guna2DataGridView_member.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2DataGridView_member.GridColor = System.Drawing.Color.White;
            this.guna2DataGridView_member.Location = new System.Drawing.Point(0, 62);
            this.guna2DataGridView_member.Name = "guna2DataGridView_member";
            this.guna2DataGridView_member.RightToLeft = System.Windows.Forms.RightToLeft.No;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.guna2DataGridView_member.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.guna2DataGridView_member.RowHeadersVisible = false;
            this.guna2DataGridView_member.RowHeadersWidth = 51;
            this.guna2DataGridView_member.RowTemplate.DividerHeight = 5;
            this.guna2DataGridView_member.RowTemplate.Height = 60;
            this.guna2DataGridView_member.RowTemplate.ReadOnly = true;
            this.guna2DataGridView_member.ShowCellErrors = false;
            this.guna2DataGridView_member.Size = new System.Drawing.Size(1400, 758);
            this.guna2DataGridView_member.StandardTab = true;
            this.guna2DataGridView_member.TabIndex = 2;
            this.guna2DataGridView_member.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.guna2DataGridView_member.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.guna2DataGridView_member.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.guna2DataGridView_member.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.guna2DataGridView_member.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.guna2DataGridView_member.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.guna2DataGridView_member.ThemeStyle.GridColor = System.Drawing.Color.White;
            this.guna2DataGridView_member.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.Silver;
            this.guna2DataGridView_member.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.guna2DataGridView_member.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.guna2DataGridView_member.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.guna2DataGridView_member.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.guna2DataGridView_member.ThemeStyle.HeaderStyle.Height = 50;
            this.guna2DataGridView_member.ThemeStyle.ReadOnly = false;
            this.guna2DataGridView_member.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.guna2DataGridView_member.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.guna2DataGridView_member.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(5)), true);
            this.guna2DataGridView_member.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.guna2DataGridView_member.ThemeStyle.RowsStyle.Height = 60;
            this.guna2DataGridView_member.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.guna2DataGridView_member.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.guna2DataGridView_member.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.guna2DataGridView1_CellClick);
            this.guna2DataGridView_member.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.guna2DataGridView1_CellContentClick);
            this.guna2DataGridView_member.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.guna2DataGridView1_CellPainting);
            this.guna2DataGridView_member.Resize += new System.EventHandler(this.guna2DataGridView1_Resize);
            // 
            // column_avartar
            // 
            this.column_avartar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.column_avartar.FillWeight = 150F;
            this.column_avartar.Frozen = true;
            this.column_avartar.HeaderText = "";
            this.column_avartar.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.column_avartar.MinimumWidth = 6;
            this.column_avartar.Name = "column_avartar";
            this.column_avartar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.column_avartar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.column_avartar.Width = 70;
            // 
            // Column_manv
            // 
            this.Column_manv.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column_manv.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column_manv.FillWeight = 26.60549F;
            this.Column_manv.Frozen = true;
            this.Column_manv.HeaderText = "Mã nhân viên";
            this.Column_manv.MinimumWidth = 6;
            this.Column_manv.Name = "Column_manv";
            this.Column_manv.Width = 161;
            // 
            // Column_hoten
            // 
            this.Column_hoten.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column_hoten.FillWeight = 22.60549F;
            this.Column_hoten.Frozen = true;
            this.Column_hoten.HeaderText = "Họ tên";
            this.Column_hoten.MinimumWidth = 6;
            this.Column_hoten.Name = "Column_hoten";
            this.Column_hoten.Width = 136;
            // 
            // Column_gioitinh
            // 
            this.Column_gioitinh.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column_gioitinh.FillWeight = 16.60549F;
            this.Column_gioitinh.Frozen = true;
            this.Column_gioitinh.HeaderText = "Giới tính";
            this.Column_gioitinh.MinimumWidth = 6;
            this.Column_gioitinh.Name = "Column_gioitinh";
            this.Column_gioitinh.Width = 125;
            // 
            // Column_ngaysinh
            // 
            this.Column_ngaysinh.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column_ngaysinh.FillWeight = 26.60549F;
            this.Column_ngaysinh.Frozen = true;
            this.Column_ngaysinh.HeaderText = "Ngày sinh";
            this.Column_ngaysinh.MinimumWidth = 6;
            this.Column_ngaysinh.Name = "Column_ngaysinh";
            this.Column_ngaysinh.Width = 161;
            // 
            // Column6
            // 
            this.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column6.FillWeight = 26.60549F;
            this.Column6.Frozen = true;
            this.Column6.HeaderText = "Quê quán";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            this.Column6.Width = 161;
            // 
            // Column_phongban
            // 
            this.Column_phongban.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column_phongban.FillWeight = 26.60549F;
            this.Column_phongban.Frozen = true;
            this.Column_phongban.HeaderText = "Phòng ban";
            this.Column_phongban.MinimumWidth = 6;
            this.Column_phongban.Name = "Column_phongban";
            this.Column_phongban.Width = 161;
            // 
            // Column8
            // 
            this.Column8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column8.FillWeight = 26.60549F;
            this.Column8.Frozen = true;
            this.Column8.HeaderText = "Chức vụ";
            this.Column8.MinimumWidth = 6;
            this.Column8.Name = "Column8";
            this.Column8.Width = 160;
            // 
            // Column_nn
            // 
            this.Column_nn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Column_nn.DefaultCellStyle = dataGridViewCellStyle4;
            this.Column_nn.FillWeight = 20.60549F;
            this.Column_nn.Frozen = true;
            this.Column_nn.HeaderText = "Ngoại ngữ";
            this.Column_nn.MinimumWidth = 6;
            this.Column_nn.Name = "Column_nn";
            this.Column_nn.Width = 161;
            // 
            // Column_edit
            // 
            this.Column_edit.FillWeight = 10.41566F;
            this.Column_edit.HeaderText = "";
            this.Column_edit.MinimumWidth = 6;
            this.Column_edit.Name = "Column_edit";
            this.Column_edit.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column_edit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Column_delete
            // 
            this.Column_delete.FillWeight = 10.95839F;
            this.Column_delete.HeaderText = "";
            this.Column_delete.MinimumWidth = 6;
            this.Column_delete.Name = "Column_delete";
            this.Column_delete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column_delete.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // textBox_hoten
            // 
            this.textBox_hoten.BorderRadius = 10;
            this.textBox_hoten.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBox_hoten.DefaultText = "";
            this.textBox_hoten.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.textBox_hoten.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.textBox_hoten.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textBox_hoten.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textBox_hoten.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textBox_hoten.Font = new System.Drawing.Font("Segoe UI", 10.8F);
            this.textBox_hoten.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textBox_hoten.Location = new System.Drawing.Point(21, 59);
            this.textBox_hoten.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox_hoten.Name = "textBox_hoten";
            this.textBox_hoten.PasswordChar = '\0';
            this.textBox_hoten.PlaceholderText = "";
            this.textBox_hoten.SelectedText = "";
            this.textBox_hoten.Size = new System.Drawing.Size(223, 35);
            this.textBox_hoten.TabIndex = 118;
            // 
            // comboBox_pb
            // 
            this.comboBox_pb.BackColor = System.Drawing.Color.Transparent;
            this.comboBox_pb.BorderRadius = 10;
            this.comboBox_pb.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBox_pb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_pb.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.comboBox_pb.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.comboBox_pb.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.comboBox_pb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.comboBox_pb.ItemHeight = 29;
            this.comboBox_pb.Location = new System.Drawing.Point(21, 142);
            this.comboBox_pb.Name = "comboBox_pb";
            this.comboBox_pb.Size = new System.Drawing.Size(223, 35);
            this.comboBox_pb.TabIndex = 119;
            // 
            // comboBox_cv
            // 
            this.comboBox_cv.BackColor = System.Drawing.Color.Transparent;
            this.comboBox_cv.BorderRadius = 10;
            this.comboBox_cv.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBox_cv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_cv.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.comboBox_cv.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.comboBox_cv.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.comboBox_cv.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.comboBox_cv.ItemHeight = 29;
            this.comboBox_cv.Location = new System.Drawing.Point(21, 231);
            this.comboBox_cv.Name = "comboBox_cv";
            this.comboBox_cv.Size = new System.Drawing.Size(223, 35);
            this.comboBox_cv.TabIndex = 121;
            // 
            // button_timkiem
            // 
            this.button_timkiem.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.button_timkiem.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.button_timkiem.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.button_timkiem.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.button_timkiem.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_timkiem.ForeColor = System.Drawing.Color.White;
            this.button_timkiem.Location = new System.Drawing.Point(124, 685);
            this.button_timkiem.Name = "button_timkiem";
            this.button_timkiem.Size = new System.Drawing.Size(120, 45);
            this.button_timkiem.TabIndex = 115;
            this.button_timkiem.Text = "Tìm kiếm";
            this.button_timkiem.Click += new System.EventHandler(this.button_timkiem_Click);
            // 
            // groupBox_nn
            // 
            this.groupBox_nn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_nn.Location = new System.Drawing.Point(21, 294);
            this.groupBox_nn.Name = "groupBox_nn";
            this.groupBox_nn.Size = new System.Drawing.Size(223, 238);
            this.groupBox_nn.TabIndex = 123;
            this.groupBox_nn.TabStop = false;
            this.groupBox_nn.Text = "Ngoại ngữ";
            // 
            // guna2Button_moi
            // 
            this.guna2Button_moi.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button_moi.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button_moi.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button_moi.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button_moi.FillColor = System.Drawing.Color.WhiteSmoke;
            this.guna2Button_moi.Font = new System.Drawing.Font("Segoe UI", 10.8F);
            this.guna2Button_moi.ForeColor = System.Drawing.Color.Black;
            this.guna2Button_moi.Location = new System.Drawing.Point(21, 685);
            this.guna2Button_moi.Name = "guna2Button_moi";
            this.guna2Button_moi.Size = new System.Drawing.Size(87, 45);
            this.guna2Button_moi.TabIndex = 116;
            this.guna2Button_moi.Text = "Mới";
            this.guna2Button_moi.Click += new System.EventHandler(this.guna2Button_huy_Click);
            // 
            // guna2Panel_filter_member
            // 
            this.guna2Panel_filter_member.Controls.Add(this.guna2Button_moi);
            this.guna2Panel_filter_member.Controls.Add(this.groupBox_nn);
            this.guna2Panel_filter_member.Controls.Add(this.button_timkiem);
            this.guna2Panel_filter_member.Controls.Add(this.guna2HtmlLabel_cv);
            this.guna2Panel_filter_member.Controls.Add(this.comboBox_cv);
            this.guna2Panel_filter_member.Controls.Add(this.guna2HtmlLabel_pb);
            this.guna2Panel_filter_member.Controls.Add(this.comboBox_pb);
            this.guna2Panel_filter_member.Controls.Add(this.textBox_hoten);
            this.guna2Panel_filter_member.Controls.Add(this.guna2HtmlLabel_hvt);
            this.guna2Panel_filter_member.Dock = System.Windows.Forms.DockStyle.Right;
            this.guna2Panel_filter_member.Location = new System.Drawing.Point(1136, 62);
            this.guna2Panel_filter_member.Name = "guna2Panel_filter_member";
            this.guna2Panel_filter_member.Size = new System.Drawing.Size(264, 758);
            this.guna2Panel_filter_member.TabIndex = 4;
            // 
            // guna2HtmlLabel_cv
            // 
            this.guna2HtmlLabel_cv.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel_cv.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel_cv.Location = new System.Drawing.Point(21, 203);
            this.guna2HtmlLabel_cv.Name = "guna2HtmlLabel_cv";
            this.guna2HtmlLabel_cv.Size = new System.Drawing.Size(64, 22);
            this.guna2HtmlLabel_cv.TabIndex = 122;
            this.guna2HtmlLabel_cv.Text = "Chức vụ";
            // 
            // guna2HtmlLabel_pb
            // 
            this.guna2HtmlLabel_pb.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel_pb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel_pb.Location = new System.Drawing.Point(21, 114);
            this.guna2HtmlLabel_pb.Name = "guna2HtmlLabel_pb";
            this.guna2HtmlLabel_pb.Size = new System.Drawing.Size(82, 22);
            this.guna2HtmlLabel_pb.TabIndex = 120;
            this.guna2HtmlLabel_pb.Text = "Phòng ban";
            // 
            // guna2HtmlLabel_hvt
            // 
            this.guna2HtmlLabel_hvt.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel_hvt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel_hvt.Location = new System.Drawing.Point(21, 29);
            this.guna2HtmlLabel_hvt.Name = "guna2HtmlLabel_hvt";
            this.guna2HtmlLabel_hvt.Size = new System.Drawing.Size(75, 22);
            this.guna2HtmlLabel_hvt.TabIndex = 117;
            this.guna2HtmlLabel_hvt.Text = "Họ và tên";
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.guna2Panel2.Controls.Add(this.guna2HtmlLabel2_page_number);
            this.guna2Panel2.Controls.Add(this.guna2Button_next);
            this.guna2Panel2.Controls.Add(this.guna2Button_previous);
            this.guna2Panel2.CustomBorderThickness = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.guna2Panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.guna2Panel2.FillColor = System.Drawing.Color.Transparent;
            this.guna2Panel2.Location = new System.Drawing.Point(0, 755);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(1136, 65);
            this.guna2Panel2.TabIndex = 5;
            // 
            // guna2HtmlLabel2_page_number
            // 
            this.guna2HtmlLabel2_page_number.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel2_page_number.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel2_page_number.Location = new System.Drawing.Point(675, 14);
            this.guna2HtmlLabel2_page_number.Name = "guna2HtmlLabel2_page_number";
            this.guna2HtmlLabel2_page_number.Size = new System.Drawing.Size(93, 27);
            this.guna2HtmlLabel2_page_number.TabIndex = 12;
            this.guna2HtmlLabel2_page_number.Text = "Page 1/12";
            // 
            // guna2Button_next
            // 
            this.guna2Button_next.BorderThickness = 1;
            this.guna2Button_next.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button_next.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button_next.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button_next.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button_next.FillColor = System.Drawing.Color.White;
            this.guna2Button_next.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button_next.ForeColor = System.Drawing.Color.Black;
            this.guna2Button_next.Image = ((System.Drawing.Image)(resources.GetObject("guna2Button_next.Image")));
            this.guna2Button_next.Location = new System.Drawing.Point(786, 14);
            this.guna2Button_next.Name = "guna2Button_next";
            this.guna2Button_next.Size = new System.Drawing.Size(56, 31);
            this.guna2Button_next.TabIndex = 11;
            this.guna2Button_next.Click += new System.EventHandler(this.guna2Button_next_Click);
            // 
            // guna2Button_previous
            // 
            this.guna2Button_previous.BorderThickness = 1;
            this.guna2Button_previous.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button_previous.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button_previous.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button_previous.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button_previous.FillColor = System.Drawing.Color.White;
            this.guna2Button_previous.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button_previous.ForeColor = System.Drawing.Color.Black;
            this.guna2Button_previous.Image = ((System.Drawing.Image)(resources.GetObject("guna2Button_previous.Image")));
            this.guna2Button_previous.Location = new System.Drawing.Point(596, 14);
            this.guna2Button_previous.Name = "guna2Button_previous";
            this.guna2Button_previous.Size = new System.Drawing.Size(56, 31);
            this.guna2Button_previous.TabIndex = 10;
            this.guna2Button_previous.Click += new System.EventHandler(this.guna2Button_previous_Click);
            // 
            // MemberControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.guna2Panel2);
            this.Controls.Add(this.guna2Panel_filter_member);
            this.Controls.Add(this.guna2DataGridView_member);
            this.Controls.Add(this.guna2Panel1);
            this.Name = "MemberControl";
            this.Size = new System.Drawing.Size(1400, 820);
            this.Load += new System.EventHandler(this.MemberControl_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2DataGridView_member)).EndInit();
            this.guna2Panel_filter_member.ResumeLayout(false);
            this.guna2Panel_filter_member.PerformLayout();
            this.guna2Panel2.ResumeLayout(false);
            this.guna2Panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2DataGridView guna2DataGridView_member;
        private Guna.UI2.WinForms.Guna2AnimateWindow guna2AnimateWindow1;
        private Guna.UI2.WinForms.Guna2Button guna2Button_filter;
        private Guna.UI2.WinForms.Guna2Button guna2Button_add;
        private Guna.UI2.WinForms.Guna2Button guna2Button_export;
        private Guna.UI2.WinForms.Guna2Button guna2Button_reload;
        private System.Windows.Forms.DataGridViewImageColumn column_avartar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_manv;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_hoten;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_gioitinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_ngaysinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_phongban;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_nn;
        private System.Windows.Forms.DataGridViewButtonColumn Column_edit;
        private System.Windows.Forms.DataGridViewButtonColumn Column_delete;
        private Guna.UI2.WinForms.Guna2TextBox textBox_hoten;
        private Guna.UI2.WinForms.Guna2ComboBox comboBox_pb;
        private Guna.UI2.WinForms.Guna2ComboBox comboBox_cv;
        private Guna.UI2.WinForms.Guna2Button button_timkiem;
        private System.Windows.Forms.GroupBox groupBox_nn;
        private Guna.UI2.WinForms.Guna2Button guna2Button_moi;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel_filter_member;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel_cv;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel_pb;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel_hvt;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2Button guna2Button_previous;
        private Guna.UI2.WinForms.Guna2Button guna2Button_next;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2_page_number;
    }
}
