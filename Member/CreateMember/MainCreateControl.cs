using HRM_Desktop.Member.DetailMember;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HRM_Desktop.Member.CreateMember
{
    public partial class MainCreateControl : UserControl
    {
        public Panel Panel { get; }
        public CreateNVControl createNVControl;
        public MemberControl memberControl;
         public CreateQTCTControl createQTCTControl;
        public CreateQTDTControl createQTDTControl;
        public CreateNNControl createNNControl;

        public MainCreateControl(Panel panel)
        {
            InitializeComponent();
            this.Panel = panel;

        }

        private void guna2Panel_create_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MainCreateControl_Load(object sender, EventArgs e)
        {
            createNVControl = new CreateNVControl();
            createNVControl.Dock = DockStyle.Fill;
            guna2Panel_create.Controls.Clear();
            guna2Panel_create.Controls.Add(createNVControl);
            guna2Button_ttnv.Enabled = false;
            guna2Button_qtdt.Enabled = true;
            guna2Button_qtct.Enabled = true;
            guna2Button_nn.Enabled = true;
        }

        private void guna2Button_thoat_Click(object sender, EventArgs e)
        {
            memberControl = new MemberControl(this.Panel);

            memberControl.Dock = DockStyle.Fill;
            this.Panel.Controls.Clear();
            this.Panel.Controls.Add(memberControl);
            memberControl.BringToFront();
            
        }

        private void guna2Button_qtdt_Click(object sender, EventArgs e)
        {
            createQTDTControl = new CreateQTDTControl();
            createQTDTControl.Dock = DockStyle.Fill;
            guna2Panel_create.Controls.Clear();
            guna2Panel_create.Controls.Add(createQTDTControl);
            createQTDTControl.BringToFront();
            guna2Button_ttnv.Enabled = true;
            guna2Button_qtdt.Enabled = false;
            guna2Button_qtct.Enabled = true;
            guna2Button_nn.Enabled = true;



        }

        private void guna2Button_qtct_Click(object sender, EventArgs e)
        {
            createQTCTControl = new CreateQTCTControl();
            createQTCTControl.Dock = DockStyle.Fill;
            guna2Panel_create.Controls.Clear();
            guna2Panel_create.Controls.Add(createQTCTControl);
            createQTCTControl.BringToFront();
            guna2Button_ttnv.Enabled = true;
            guna2Button_qtdt.Enabled = true;
            guna2Button_qtct.Enabled = false;
            guna2Button_nn.Enabled = true;

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            createNVControl = new CreateNVControl();
            createNVControl.Dock = DockStyle.Fill;
            guna2Panel_create.Controls.Clear();
            guna2Panel_create.Controls.Add(createNVControl);
            createNVControl.BringToFront();
            guna2Button_ttnv.Enabled = false;
            guna2Button_qtdt.Enabled = true;
            guna2Button_qtct.Enabled = true;
            guna2Button_nn.Enabled = true;

        }

        private void button_luu_Click(object sender, EventArgs e)
        {
            if (!guna2Button_ttnv.Enabled)
            {
                if (createNVControl.createNV())
                {
                    memberControl = new MemberControl(this.Panel);
                    memberControl.Dock = DockStyle.Fill;
                    this.Panel.Controls.Clear();
                    this.Panel.Controls.Add(memberControl);
                    memberControl.BringToFront();

                }
            } else if(!guna2Button_qtdt.Enabled)
            {
               
                if (createQTDTControl.CreateQTDT())
                {
                    memberControl = new MemberControl(this.Panel);
                    memberControl.Dock = DockStyle.Fill;
                    this.Panel.Controls.Clear();
                    this.Panel.Controls.Add(memberControl);
                    memberControl.BringToFront();

                }
            } else if(!guna2Button_qtct.Enabled)
            {
                if(createQTCTControl.CreateQTCT())
                {
                    memberControl = new MemberControl(this.Panel);
                    memberControl.Dock = DockStyle.Fill;
                    this.Panel.Controls.Clear();
                    this.Panel.Controls.Add(memberControl);
                    memberControl.BringToFront();
                }
            } else if(!guna2Button_nn.Enabled)
            {
                if(createNNControl.CreateNN())
                {
                    memberControl = new MemberControl(this.Panel);
                    memberControl.Dock = DockStyle.Fill;
                    this.Panel.Controls.Clear();
                    this.Panel.Controls.Add(memberControl);
                    memberControl.BringToFront();
                }
            }
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            createNNControl = new CreateNNControl();
            createNNControl.Dock = DockStyle.Fill;
            guna2Panel_create.Controls.Clear();
            guna2Panel_create.Controls.Add(createNNControl);
            createNNControl.BringToFront();
            guna2Button_ttnv.Enabled = true;
            guna2Button_qtdt.Enabled = true;
            guna2Button_qtct.Enabled = true;
            guna2Button_nn.Enabled = false;
        }
    }
}
