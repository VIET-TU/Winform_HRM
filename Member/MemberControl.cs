using Guna.UI2.WinForms;
using HRM_Desktop.Member;
using HRM_Desktop.Member.CreateMember;
using HRM_Desktop.Member.Filter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HRM_Desktop
{
    public partial class MemberControl : UserControl
    {
        public static int count = 0;
        public Panel Panel { get;  }
        public int limit = 5;

        public static SearchParam searchParam { get; set; } = null;

        public MemberControl(Panel panel)
        {

            InitializeComponent();

            this.Panel = panel;

            IEnumerable<HSNV> hSNVs = Connection.db.HSNVs
                   .Include(x => x.GIOI_TINH)
                   .Include(x => x.CHUC_VU)
                   .Include(x => x.NV_NGOAI_NGU.Select(y => y.NGOAI_NGU))
                   .ToList();

            int total_page = (int)Math.Ceiling(hSNVs.Count() / (float)limit);
            guna2HtmlLabel2_page_number.Text = $"Page 1/{total_page}";

            guna2Button_previous.Enabled = false;


            hSNVs = hSNVs.Take(limit);

            foreach (HSNV hSNV in hSNVs)
            {
                PHONG_BAN pb = Connection.db.PHONG_BAN.Where(x => x.ma_phong_ban == hSNV.ma_phong_ban)
                    .FirstOrDefault();

                Image avatarImage = Image.FromFile($"{hSNV.avatar}");

                string list_nn = "";
                foreach (var nvNgoaiNgu in hSNV.NV_NGOAI_NGU)
                {
                    list_nn += nvNgoaiNgu.NGOAI_NGU.ten_ngoai_ngu + "\n";
                }

                list_nn = list_nn.Trim();

                guna2DataGridView_member.Rows.Add(
                    avatarImage,
                    hSNV.ma_nv,
                    hSNV.ho_ten,
                    hSNV.GIOI_TINH.ten_gioi_tinh,
                    hSNV.ngay_sinh.ToString("dd/MM/yyyy"),
                    hSNV.que_quan,
                    pb.ten_phong_ban,
                    hSNV.CHUC_VU.ten_chuc_vu,
                    list_nn
                );

                guna2Panel_filter_member.Visible = false;

               
            }

            List<PHONG_BAN> pbs = Connection.db.PHONG_BAN.ToList();

            pbs.ForEach(g =>
            {
                comboBox_pb.Items.Add(g.ten_phong_ban + " (" + g.ma_phong_ban + ")");
            });

            List<CHUC_VU> cvs = Connection.db.CHUC_VU.ToList();

            cvs.ForEach(g =>
            {
                comboBox_cv.Items.Add(g.ten_chuc_vu + " (" + g.ma_chuc_vu + ")");
            });



            int yOffset = 20; // Khoảng cách giữa các CheckBox theo trục y


            foreach (var ngoaiNgu in Connection.db.NGOAI_NGU)
            {
                CheckBox checkBox = new CheckBox();
                checkBox.Text = ngoaiNgu.ten_ngoai_ngu;

                checkBox.Font = new Font("Arial", 10);
                checkBox.Width = 200;

                // Đặt vị trí cho CheckBox
                checkBox.Location = new Point(10, yOffset);
                checkBox.Location = new Point(10, yOffset);



                // Thêm CheckBox vào guna2GroupBox_ngoai_ngu
                groupBox_nn.Controls.Add(checkBox);

                yOffset += 30; // Tăng khoảng cách để tránh chồng lấn
            }

        }

        public MemberControl(Panel panel, SearchParam searchParam)
        {
            this.Panel = panel;

            IEnumerable<HSNV> hSNVs = Connection.db.HSNVs
             .Include(x => x.GIOI_TINH)
             .Include(x => x.CHUC_VU)
             .Include(x => x.PHONG_BAN)
             .Include(x => x.NV_NGOAI_NGU.Select(y => y.NGOAI_NGU))
             .Take(limit)
             .ToList();

            foreach (HSNV hSNV in hSNVs)
            {
               

                Image avatarImage = Image.FromFile($"{hSNV.avatar}");

                string list_nn = "";
                foreach (var nvNgoaiNgu in hSNV.NV_NGOAI_NGU)
                {
                    list_nn += nvNgoaiNgu.NGOAI_NGU.ten_ngoai_ngu + "\n";
                }

                list_nn = list_nn.Trim();

                guna2DataGridView_member.Rows.Add(
                    avatarImage,
                    hSNV.ma_nv,
                    hSNV.ho_ten,
                    hSNV.GIOI_TINH.ten_gioi_tinh,
                    hSNV.ngay_sinh.ToString("dd/MM/yyyy"),
                    hSNV.que_quan,
                    hSNV.PHONG_BAN.ten_phong_ban,
                    hSNV.CHUC_VU.ten_chuc_vu,
                    list_nn
                );


            }
        }



            public MemberControl()
        {

            InitializeComponent();

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            object maNhanVien = guna2DataGridView_member.Rows[e.RowIndex].Cells["Column_manv"].Value;
                


           
        }



        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MemberControl_Load(object sender, EventArgs e)
        {
           

        }


        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            object maNhanVien = guna2DataGridView_member.Rows[e.RowIndex].Cells["Column_manv"].Value;
            string maNhanVienStr = maNhanVien.ToString();
            HSNV hSNV = Connection.db.HSNVs.FirstOrDefault(x => x.ma_nv.Equals(maNhanVienStr));

            if (guna2DataGridView_member.Columns[e.ColumnIndex].Name == "Column_delete")
            {
                if (MessageBox.Show("Bạn muốn xóa nhân viên này", "Xóa nhân viên", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    if (maNhanVien != null)
                    {

                        if (hSNV != null)
                        {

                            Connection.db.HSNVs.Remove(hSNV);
                            Connection.db.SaveChanges();
                            refreshTable();
                        }

                    }
                }
            }
            else if (guna2DataGridView_member.Columns[e.ColumnIndex].Name == "Column_edit")
            {
                EditMemberControl editMemberControl = new EditMemberControl(hSNV, this.Panel);
                editMemberControl.Dock = DockStyle.Fill;
                this.Panel.Controls.Clear();
                this.Panel.Controls.Add(editMemberControl);
                editMemberControl.BringToFront();

            } else
            {
                if (hSNV != null)
                {
                    MemberDetailControl memberDetailControl = new MemberDetailControl(hSNV, this.Panel);
                    memberDetailControl.Dock = DockStyle.Fill;
                    this.Panel.Controls.Clear();
                    this.Panel.Controls.Add(memberDetailControl);
                    memberDetailControl.BringToFront();
                }
            }



          

        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {
          
        }

        public void ShowTable( int current_page = 1)

        {
            IEnumerable<HSNV> hSNVs = Connection.db.HSNVs
                .Include(x => x.GIOI_TINH)
                .Include(x => x.CHUC_VU)
                .Include(x => x.PHONG_BAN)
                .Include(x => x.NV_NGOAI_NGU.Select(y => y.NGOAI_NGU))
                .ToList();




            if (searchParam != null)
            {

                if (!string.IsNullOrEmpty(searchParam.ten_nv)) hSNVs = hSNVs.Where(x => x.ho_ten.ToLower().Contains(searchParam.ten_nv.ToLower()));


                if (!string.IsNullOrEmpty(searchParam.phong_ban)) hSNVs = hSNVs.Where(x => x.PHONG_BAN.ma_phong_ban.Equals(searchParam.phong_ban));

                if (!string.IsNullOrEmpty(searchParam.chuc_vu)) hSNVs = hSNVs.Where(x => x.CHUC_VU.ma_chuc_vu.Equals(searchParam.chuc_vu));

                if (searchParam.list_nn.Count > 0)
                {
                 //   hSNVs = hSNVs.Where(x => x.NV_NGOAI_NGU.Any(nvNgoaiNgu => searchParam.list_nn.Contains(nvNgoaiNgu.NGOAI_NGU.ten_ngoai_ngu)));

                    foreach(string nn in searchParam.list_nn)
                    {
                        hSNVs = hSNVs.Where(x => x.NV_NGOAI_NGU.Any(nvNgoaiNgu => nvNgoaiNgu.NGOAI_NGU.ten_ngoai_ngu.Equals(nn)));
                    }
                }


                int count = hSNVs.Count();
                int toltal_page = (int)Math.Ceiling(count / (float)limit);

                guna2HtmlLabel2_page_number.Text = $"Page {current_page}/{toltal_page}";

                if (current_page == 1) {
                    guna2Button_previous.Enabled = false;
                    guna2Button_next.Enabled = true;
                };

                if(current_page == toltal_page)
                {
                    guna2Button_next.Enabled = false;

                }


            } else
            {
                if (searchParam == null)
                {

                    int count = hSNVs.Count();
                    int toltal_page = (int)Math.Ceiling(count / (float)limit);

                    guna2HtmlLabel2_page_number.Text = $"Page {current_page}/{toltal_page}";
                    if (current_page == 1)
                    {
                        guna2Button_previous.Enabled = false;
                        guna2Button_next.Enabled = true;
                    };

                    if (current_page == toltal_page)
                    {
                        guna2Button_next.Enabled = false;

                    }
                }
            }

            hSNVs = hSNVs.OrderBy(x => x.ma_nv)
                .Skip(limit * (current_page - 1))
                .Take(limit);


            guna2DataGridView_member.Rows.Clear();

            foreach (HSNV hSNV in hSNVs)
            {
                PHONG_BAN pb = Connection.db.PHONG_BAN.Where(x => x.ma_phong_ban == hSNV.ma_phong_ban).FirstOrDefault();

                Image avatarImage = Image.FromFile(hSNV.avatar);

                string list_nn = "";
                foreach (var nvNgoaiNgu in hSNV.NV_NGOAI_NGU)
                {
                    list_nn += nvNgoaiNgu.NGOAI_NGU.ten_ngoai_ngu + "\n";
                }

                guna2DataGridView_member.Rows.Add(
                    avatarImage,
                    hSNV.ma_nv,
                    hSNV.ho_ten,
                    hSNV.GIOI_TINH.ten_gioi_tinh,
                    hSNV.ngay_sinh.ToString("dd/MM/yyyy"),
                    hSNV.que_quan,
                    pb.ten_phong_ban,
                    hSNV.CHUC_VU.ten_chuc_vu,
                    list_nn
                );


            }
        }

        public  void refreshTable()
        {
            ShowTable(1);
           

        }

        private void guna2PictureBox3_Click(object sender, EventArgs e)
        {
            ShowTable();
        }

        private void guna2Button_add_Click(object sender, EventArgs e)
        {
            MainCreateControl mainCreateControl = new MainCreateControl(this.Panel);
            mainCreateControl.Dock = DockStyle.Fill;
            this.Panel.Controls.Clear();
            this.Panel.Controls.Add(mainCreateControl);
            mainCreateControl.BringToFront();
        }

        private void guna2Button_reload_Click(object sender, EventArgs e)
        {
            searchParam = null;
            guna2Button_previous.Enabled = false;
            guna2Button_next.Enabled = true;
            ShowTable();
        }

        private void guna2DataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {


            if (e.ColumnIndex == guna2DataGridView_member.Columns["Column_edit"].Index && e.RowIndex >= 0)
            {
                string imagePath = @"C:\Users\Dell\Downloads\edit.png";

                if (File.Exists(imagePath))
                {
                    Image img = Image.FromFile(imagePath);

                    int x = e.CellBounds.Left + (e.CellBounds.Width - img.Width) / 2;
                    int y = e.CellBounds.Top + (e.CellBounds.Height - img.Height) / 2;

                    e.PaintBackground(e.CellBounds, true);
                    e.Graphics.DrawImage(img, new Rectangle(x, y, img.Width, img.Height));

                    e.Handled = true;
                }
            }

            if (e.ColumnIndex == guna2DataGridView_member.Columns["Column_delete"].Index && e.RowIndex >= 0)
            {
                string imagePath = @"C:\Users\Dell\Downloads\delete.png";

                if (File.Exists(imagePath))
                {
                    Image img = Image.FromFile(imagePath);

                    int x = e.CellBounds.Left + (e.CellBounds.Width - img.Width) / 2;
                    int y = e.CellBounds.Top + (e.CellBounds.Height - img.Height) / 2;

                    e.PaintBackground(e.CellBounds, true);
                    e.Graphics.DrawImage(img, new Rectangle(x, y, img.Width, img.Height));

                    e.Handled = true;
                }
            }

        }

        private void guna2Button_filter_Click(object sender, EventArgs e)
        {

           if (guna2Panel_filter_member.Visible)
            {
                guna2Panel_filter_member.Visible = false;
                guna2Button_filter.Text = "Filter";
                return;
            }

            guna2Panel_filter_member.Visible = true;
            guna2Button_filter.Text = "Close filter";



        }

        private void guna2DataGridView1_Resize(object sender, EventArgs e)
        {

        }

       

        private void guna2Panel__Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void guna2Button_huy_Click(object sender, EventArgs e)
        {
            textBox_hoten.Clear();
            comboBox_pb.SelectedIndex = -1;
            comboBox_cv.SelectedIndex = -1;

            List<CheckBox> danhSachCheckBox = groupBox_nn.Controls.OfType<CheckBox>().ToList();

            foreach (CheckBox checkBox in danhSachCheckBox)
            {
                checkBox.Checked = false;
            }

        }

        public string splitString(string str)
        {
            Regex regex = new Regex(@"\(([^)]*)\)");
            Match match = regex.Match(str);
            return match.Groups[1].Value;

        }

        private void button_timkiem_Click(object sender, EventArgs e)
        {
            var ten_nv = textBox_hoten.Text;
            var phong_ban = splitString(comboBox_pb.Text);
            var chuc_vu = splitString(comboBox_cv.Text);
            List<string> list_nn = new List<string>();

            List<CheckBox> danhSachCheckBox = groupBox_nn.Controls.OfType<CheckBox>().ToList();

            foreach (CheckBox checkBox in danhSachCheckBox)
            {
                if (checkBox.Checked)
                {
                    string tenNgoaiNgu = checkBox.Text;

                    list_nn.Add(tenNgoaiNgu);
                }
            }


            searchParam = new SearchParam()
            {
                ten_nv = ten_nv,
                phong_ban = phong_ban,
                chuc_vu = chuc_vu,
                list_nn = list_nn
            };

            ShowTable();
        }

        private void guna2Button_next_Click(object sender, EventArgs e)
        {
            string[] parts = guna2HtmlLabel2_page_number.Text.Split('/');

            int old_page = int.Parse(parts[0].Split(' ')[1]);
            int toltal_page = int.Parse(parts[1]);

            

            int new_page = old_page + 1;
            guna2HtmlLabel2_page_number.Text = $"Page {new_page}/{toltal_page}";

            if(new_page == toltal_page) guna2Button_next.Enabled = false;

            if (old_page >= 1 && old_page <= toltal_page) guna2Button_previous.Enabled = true;

            ShowTable( new_page);
        }

        private void guna2Button_previous_Click(object sender, EventArgs e)
        {
            string[] parts = guna2HtmlLabel2_page_number.Text.Split('/');

            int old_page = int.Parse(parts[0].Split(' ')[1]);
            int toltal_page = int.Parse(parts[1]);



            int new_page = old_page -1 ;
            guna2HtmlLabel2_page_number.Text = $"Page {new_page}/{toltal_page}";

            if (new_page == 1) guna2Button_previous.Enabled = false;

            if(new_page <= toltal_page)
            {
                guna2Button_next.Enabled=true;
            }

            ShowTable(new_page);
        }

        private void guna2Button_export_Click(object sender, EventArgs e)
        {
           

            Microsoft.Office.Interop.Excel.Application oExcel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbooks oBooks;
            Microsoft.Office.Interop.Excel.Sheets oSheets;
            Microsoft.Office.Interop.Excel.Workbook oBook;
            Microsoft.Office.Interop.Excel.Worksheet oSheet;

            // Tạo mới một workbook
            oExcel.Visible = true;
            oExcel.DisplayAlerts = false;
            oExcel.Application.SheetsInNewWorkbook = 1;
            oBooks = oExcel.Workbooks;
            oBook = (Microsoft.Office.Interop.Excel.Workbook)(oExcel.Workbooks.Add(Type.Missing));
            oSheets = oBook.Worksheets;
            oSheet = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(1);
            oSheet.Name = "Danh sách";

            // tao phan tieu de
            Microsoft.Office.Interop.Excel.Range head = oSheet.get_Range("A1", "Q1");
            head.MergeCells = true;
            head.Value2 = "Danh sách nhân viên";
            head.Font.Bold = true;
            head.Font.Name = "Times New Roman";
            head.Font.Size = "20";

            head.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            // Tạo tieu đề cột

            Microsoft.Office.Interop.Excel.Range cl1 = oSheet.get_Range("A3", "A3");
            cl1.Value2 = "Mã nhân viên";
            cl1.ColumnWidth = 15;

            Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B3", "B3");
            cl2.Value2 = "Họ và tên";
            cl2.ColumnWidth = 25.0;


            Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("C3", "C3");
            cl3.Value2 = "Số điện thoại";
            cl3.ColumnWidth = 25.0;


            Microsoft.Office.Interop.Excel.Range cl4 = oSheet.get_Range("D3", "D3");
            cl4.Value2 = "Quê quán";
            cl4.ColumnWidth = 25.0;

            Microsoft.Office.Interop.Excel.Range cl5 = oSheet.get_Range("E3", "E3");
            cl5.Value2 = "Số CCCD";
            cl5.ColumnWidth = 25.0;

            Microsoft.Office.Interop.Excel.Range cl6 = oSheet.get_Range("F3", "F3");
            cl6.Value2 = "Ngày sinh";
            cl6.ColumnWidth = 25.0;

            Microsoft.Office.Interop.Excel.Range cl7 = oSheet.get_Range("G3", "G3");
            cl7.Value2 = "Giới tính";
            cl7.ColumnWidth = 25.0;


            Microsoft.Office.Interop.Excel.Range cl8 = oSheet.get_Range("H3","H3");
            cl8.Value2 = "Nơi sinh";
            cl8.ColumnWidth = 25.0;


            Microsoft.Office.Interop.Excel.Range cl9 = oSheet.get_Range("I3", "I3");
            cl9.Value2 = "Dân tộc";
            cl9.ColumnWidth = 25.0;


            Microsoft.Office.Interop.Excel.Range cl10 = oSheet.get_Range("J3", "J3");
            cl10.Value2 = "Tôn giáo";
            cl10.ColumnWidth = 25.0;


            Microsoft.Office.Interop.Excel.Range cl11 = oSheet.get_Range("K3", "K3");
            cl11.Value2 = "Địa chỉ";
            cl11.ColumnWidth = 25.0;

            Microsoft.Office.Interop.Excel.Range cl12 = oSheet.get_Range("L3", "L3");
            cl12.Value2 = "Vợ chồng";
            cl12.ColumnWidth = 25.0;

            Microsoft.Office.Interop.Excel.Range cl13 = oSheet.get_Range("M3", "M3");
            cl13.Value2 = "Số con";
            cl13.ColumnWidth = 25.0;


            Microsoft.Office.Interop.Excel.Range cl14 = oSheet.get_Range("N3", "N3");
            cl14.Value2 = "Tên phòng ban";
            cl14.ColumnWidth = 25.0;


            Microsoft.Office.Interop.Excel.Range cl15 = oSheet.get_Range("O3", "O3");
            cl15.Value2 = "Tên chức vụ";
            cl15.ColumnWidth = 25.0;

            Microsoft.Office.Interop.Excel.Range cl16 = oSheet.get_Range("P3", "P3");
            cl16.Value2 = "Tên học vấn";
            cl16.ColumnWidth = 25.0;

            Microsoft.Office.Interop.Excel.Range cl17 = oSheet.get_Range("Q3", "Q3");
            cl17.Value2 = "Tên chuyên môn";
            cl17.ColumnWidth = 25.0;




            Microsoft.Office.Interop.Excel.Range rowHead = oSheet.get_Range("A3", "Q3");
            rowHead.Font.Bold = true;

            // ke vien

            rowHead.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;
            // Thiết lập màu nền
            rowHead.Interior.ColorIndex = 6;
            rowHead.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            // tạo mảng theo đb

            

            List<HSNV> hSNVs ;


            if (searchParam != null)
            {
                IEnumerable<HSNV> list_hSNVs = Connection.db.HSNVs
              .Include(x => x.GIOI_TINH)
              .Include(x => x.CHUC_VU)
              .Include(x => x.PHONG_BAN)
              .Include(x => x.NV_NGOAI_NGU.Select(y => y.NGOAI_NGU))
              .ToList();

                if (!string.IsNullOrEmpty(searchParam.ten_nv)) list_hSNVs = list_hSNVs.Where(x => x.ho_ten.ToLower().Contains(searchParam.ten_nv.ToLower()));


                if (!string.IsNullOrEmpty(searchParam.phong_ban)) list_hSNVs = list_hSNVs.Where(x => x.PHONG_BAN.ma_phong_ban.Equals(searchParam.phong_ban));

                if (!string.IsNullOrEmpty(searchParam.chuc_vu)) list_hSNVs = list_hSNVs.Where(x => x.CHUC_VU.ma_chuc_vu.Equals(searchParam.chuc_vu));

                if (searchParam.list_nn.Count > 0)
                {
                    //   hSNVs = hSNVs.Where(x => x.NV_NGOAI_NGU.Any(nvNgoaiNgu => searchParam.list_nn.Contains(nvNgoaiNgu.NGOAI_NGU.ten_ngoai_ngu)));

                    foreach (string nn in searchParam.list_nn)
                    {
                        list_hSNVs = list_hSNVs.Where(x => x.NV_NGOAI_NGU.Any(nvNgoaiNgu => nvNgoaiNgu.NGOAI_NGU.ten_ngoai_ngu.Equals(nn)));
                    }
                }

                hSNVs = list_hSNVs.ToList();
            } else
            {
                hSNVs = Connection.db.HSNVs.ToList();
            }
            
            object[,] arr = new object[hSNVs.Count(), 17];

            for (int row = 0; row < hSNVs.Count(); row++)
            {
                arr[row, 0] = hSNVs[row].ma_nv;
                arr[row, 1] = hSNVs[row].ho_ten;
                arr[row, 2] = hSNVs[row].dien_thoai;
                arr[row, 3] = hSNVs[row].que_quan;
                arr[row, 4] = hSNVs[row].so_cccd;
                arr[row, 5] = hSNVs[row].ngay_sinh;
                arr[row, 6] = hSNVs[row].GIOI_TINH.ten_gioi_tinh;
                arr[row, 7] = hSNVs[row].NOI_SINH.ten_noi_sinh;
                arr[row, 8] = hSNVs[row].DAN_TOC.ten_dan_toc;
                arr[row, 9] = hSNVs[row].TON_GIAO.ten_ton_giao;
                arr[row, 10] = hSNVs[row].dia_chi;
                arr[row, 11] = hSNVs[row].vo_chong;
                arr[row, 12] = hSNVs[row].con;
                arr[row, 13] = hSNVs[row].PHONG_BAN.ten_phong_ban;
                arr[row, 14] = hSNVs[row].CHUC_VU.ten_chuc_vu;
                arr[row, 15] = hSNVs[row].HOC_VAN.ten_hoc_van;
                arr[row, 16] = hSNVs[row].CHUYEN_MON.ten_chuyen_mon;

                if(row == 20)
                {
                   string a = hSNVs[row].ma_nv;
                }
            }

            int rowStart = 4;
            int columnStart = 1;
            int columnEnd = 17;
            int rowEnd = rowStart + hSNVs.Count - 1;

            // ô bắt đầu du lieu
            Microsoft.Office.Interop.Excel.Range c1 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, columnStart];

            // ô kết thức dữ liệu

            Microsoft.Office.Interop.Excel.Range c2 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnEnd];

            // lay ve vung dien du lieu

            Microsoft.Office.Interop.Excel.Range range = oSheet.get_Range(c1, c2);

            // dien du lieu vao vung da thiet lap

            range.Value2 = arr;

            // ke vien
            range.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;

            // can giua ca bang

            oSheet.get_Range(c1, c2).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            SaveFileDialog svf = new SaveFileDialog();
            svf.Title = "chọn đg dẫn và đặt tên tệp lưu dl ";
            svf.ShowDialog();
            string filename = svf.FileName;
            if (filename == "")
            {
                MessageBox.Show("ban chua dat ten file");
                return;
            }
            oBook.SaveAs(filename);
        }
    }

    public class SearchParam
    {
        public string ten_nv;
        public string phong_ban;
        public string chuc_vu;
        public List<string> list_nn;

        public SearchParam(string ten_nv = null, string phong_ban = null, string chuc_vu = null, List<string> list_nn = null)
        {
            this.ten_nv = ten_nv;
            this.phong_ban = phong_ban;
            this.chuc_vu = chuc_vu;
            this.list_nn = list_nn;
        }
    }
}
