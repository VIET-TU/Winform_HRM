using HRM_Desktop.Member.DetailMember.QTDTDetial;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HRM_Desktop.Member.DetailMember
{
    public partial class NNControl : UserControl
    {
        public string mnv;
        public Panel panel;
        public NNControl(string mnv, Panel panel)
        {
            InitializeComponent();
            this.mnv = mnv;
            this.panel = panel;
        }

        private void NNControl_Load(object sender, EventArgs e)
        {
            var nns = Connection.db.NV_NGOAI_NGU.Where(x => x.ma_nv.Equals(mnv)).Include(x => x.NGOAI_NGU).Include(x => x.XEP_LOAI).ToList();
                guna2DataGridView_nn.Rows.Clear();
            foreach (var nn in nns)
            {
                guna2DataGridView_nn.Rows.Add(
                        nn.ma_ngoai_ngu,
                        nn.NGOAI_NGU.ten_ngoai_ngu,
                        nn.XEP_LOAI.ten_xep_loai
                    ); ;
            }
        }

        private void guna2DataGridView_nn_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == guna2DataGridView_nn.Columns["Column_edit"].Index && e.RowIndex >= 0)
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

            if (e.ColumnIndex == guna2DataGridView_nn.Columns["Column_delete"].Index && e.RowIndex >= 0)
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

        private void guna2DataGridView_nn_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string mnn = guna2DataGridView_nn.Rows[e.RowIndex].Cells["Column_mnn"].Value.ToString();
            var nn = Connection.db.NV_NGOAI_NGU.FirstOrDefault(x => x.ma_nv.Equals(mnv) && x.ma_ngoai_ngu.Equals(mnn));

            if (guna2DataGridView_nn.Columns[e.ColumnIndex].Name == "Column_delete")
            {
                if (MessageBox.Show("Bạn muốn xóa nhân viên này", "Xóa nhân viên", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    if (mnn != null)
                    {

                        if (nn != null)
                        {

                            Connection.db.NV_NGOAI_NGU.Remove(nn);
                            Connection.db.SaveChanges();
                            NNControl_Load(sender,e);
                        }

                    }
                }
            }
            else if (guna2DataGridView_nn.Columns[e.ColumnIndex].Name == "Column_edit")
            {

            }
        }
    }
}
