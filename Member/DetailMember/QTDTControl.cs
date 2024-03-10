using Guna.UI2.WinForms;
using HRM_Desktop.Member.DetailMember.QTDTDetial;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HRM_Desktop.Member.DetailMember
{
    public partial class QTDTControl : UserControl
    {

        public List<QTDT> qTDTs { get; set; }
        public Panel panel_body { get; set; }
        public string mnv;
        public QTDTControl(string mnv , Panel panel_body)
        {
            InitializeComponent();
            this.mnv = mnv;
            this.panel_body = panel_body;
            this.qTDTs = Connection.db.QTDTs.Where(x => x.ma_nv.Equals(mnv)).ToList();



        }
        private void QTDTControl_Load(object sender, EventArgs e)
        {

            foreach (var qTDT in qTDTs)
            {
                guna2DataGridView_qtdt.Rows.Add(
                    qTDT.ma_qua_trinh_dt,
                    qTDT.tu_ngay.ToString("dd/MM/yyyy"),
                    qTDT.den_ngay.ToString("dd/MM/yyyy"),
                    qTDT.TRUONG_DT.ten_truong_dt,
                    qTDT.HINH_THUC.ten_hinh_thuc,
                    qTDT.NGANH_DT.ten_nganh_dt,
                    qTDT.XEP_LOAI != null ? qTDT.XEP_LOAI.ten_xep_loai : "Chưa xếp loại"
                ) ;
            }

        }

        private void guna2DataGridView_qtdt_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == guna2DataGridView_qtdt.Columns["Column_edit"].Index && e.RowIndex >= 0)
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

            if (e.ColumnIndex == guna2DataGridView_qtdt.Columns["Column_delete"].Index && e.RowIndex >= 0)
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

        private void guna2DataGridView_qtdt_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void guna2DataGridView_qtdt_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            object ma_qtdt = guna2DataGridView_qtdt.Rows[e.RowIndex].Cells["Column_mqtdt"].Value;
            QTDT qTDT = qTDTs.Where(x => x.ma_qua_trinh_dt.Equals(ma_qtdt)).FirstOrDefault();

            if (guna2DataGridView_qtdt.Columns[e.ColumnIndex].Name == "Column_delete")
            {
                if (MessageBox.Show("Bạn muốn xóa nhân viên này", "Xóa nhân viên", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    if (ma_qtdt != null)
                    {

                        if (qTDT != null)
                        {

                            Connection.db.QTDTs.Remove(qTDT);
                            Connection.db.SaveChanges();
                            refreshTable();
                        }

                    }
                }
            }
            else if (guna2DataGridView_qtdt.Columns[e.ColumnIndex].Name == "Column_edit")
            {
                EditQTDTControl qTDTDetialControl = new EditQTDTControl(qTDT, this.panel_body);

                qTDTDetialControl.Dock = DockStyle.Fill;
                panel_body.Controls.Clear();
                panel_body.Controls.Add(qTDTDetialControl);
                qTDTDetialControl.BringToFront();


            }
            else
            {
                QTDTDetialControl qTDTDetialControl = new QTDTDetialControl(qTDT,this.panel_body);

                qTDTDetialControl.Dock = DockStyle.Fill;
                panel_body.Controls.Clear();
                panel_body.Controls.Add(qTDTDetialControl);
                qTDTDetialControl.BringToFront();
            }
        }

        private void refreshTable()
        {
            this.qTDTs = Connection.db.QTDTs.Where(x => x.ma_nv.Equals(mnv)).ToList();

            guna2DataGridView_qtdt.Rows.Clear();

            foreach (var qTDT in qTDTs)
            {
                guna2DataGridView_qtdt.Rows.Add(
                    qTDT.ma_qua_trinh_dt,
                    qTDT.tu_ngay.ToString("dd/MM/yy"),
                    qTDT.den_ngay.ToString("dd/MM/yy"),
                    qTDT.TRUONG_DT.ten_truong_dt,
                    qTDT.HINH_THUC.ten_hinh_thuc,
                    qTDT.NGANH_DT.ten_nganh_dt,
                    qTDT.XEP_LOAI.ten_xep_loai
                );
            }
        }
    }
}
