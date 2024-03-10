using HRM_Desktop.Member.DetailMember.QTCTDetial;
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

namespace HRM_Desktop.Member
{
    public partial class QTCTControl : UserControl
    {
        public List<QTCT> qTCTs { get; set; }
        public Panel panel_body { get; set; }
        public string mnv;
        public QTCTControl(string mnv, Panel panel_body)
        {
            InitializeComponent();
            this.mnv = mnv;
            this.panel_body = panel_body;
            this.qTCTs = Connection.db.QTCTs.Where(x => x.ma_nv.Equals(mnv)).ToList();



        }
       

        private void QTCTControl_Load(object sender, EventArgs e)
        {
            guna2DataGridView_qtct.Rows.Clear();

            var qTCTs = Connection.db.QTCTs.Where(x => x.ma_nv.Equals(mnv)).ToList();
            foreach (var qTCT in qTCTs)
            {
                guna2DataGridView_qtct.Rows.Add(
                    qTCT.ma_qtct,
                    qTCT.tu_ngay.Value.ToString("dd/MM/yyyy"),
                    qTCT.den_ngay.Value.ToString("dd/MM/yyyy"),
                    qTCT.PHONG_BAN.ten_phong_ban,
                    qTCT.CHUC_VU.ten_chuc_vu
                );
            }
        }

        private void guna2DataGridView_qtct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string mqtct = guna2DataGridView_qtct.Rows[e.RowIndex].Cells["Column_mqtct"].Value.ToString();
            var qtct = Connection.db.QTCTs.FirstOrDefault(x => x.ma_qtct.Equals(mqtct));

            if (guna2DataGridView_qtct.Columns[e.ColumnIndex].Name == "Column_delete")
            {
                if (MessageBox.Show("Bạn muốn xóa nhân viên này", "Xóa nhân viên", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    if (mqtct != null)
                    {

                        if (qtct != null)
                        {

                            Connection.db.QTCTs.Remove(qtct);
                            Connection.db.SaveChanges();
                            QTCTControl_Load(sender, e);
                        }

                    }
                }
            }
            else if (guna2DataGridView_qtct.Columns[e.ColumnIndex].Name == "Column_edit")
            {
                EditQTCTControl editQTCTControl = new EditQTCTControl(mnv,mqtct, this.panel_body);
                editQTCTControl.Dock = DockStyle.Fill;
                panel_body.Controls.Clear();
                panel_body.Controls.Add(editQTCTControl);
                editQTCTControl.BringToFront();
            }
        }

        private void guna2DataGridView_qtct_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == guna2DataGridView_qtct.Columns["Column_edit"].Index && e.RowIndex >= 0)
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

            if (e.ColumnIndex == guna2DataGridView_qtct.Columns["Column_delete"].Index && e.RowIndex >= 0)
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
    }
}
