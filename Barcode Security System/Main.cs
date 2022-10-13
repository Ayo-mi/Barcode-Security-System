using Barcode_Security_System.Modal;
using Barcode_Security_System.Modals;
using Barcode_Security_System.Util;
using Guna.Charts.WinForms;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Barcode_Security_System
{
    public partial class Main : Form
    {
        private Form currentChildForm;
        private Functions fxn;
        public Main()
        {
            InitializeComponent();
            fxn = new Functions();
        }
        public void OpenChildForm(Form childForm)
        {
            if (childForm != null)
            {
                currentChildForm = childForm;
                currentChildForm.FormBorderStyle = FormBorderStyle.None;
                currentChildForm.Dock = DockStyle.Fill;
                currentChildForm.TopLevel = false;
                desktopPanel.Controls.Clear();
                desktopPanel.Controls.Add(currentChildForm);
                desktopPanel.Controls.Add(guna2Panel1);
                currentChildForm.Visible = true;
                currentChildForm.BringToFront();                
            }
        }

        public MySqlDataReader User
        {
            get; set;
        }

        public String Title
        {
            set { pageTitle.Text = value; }
        }

        private int CountRecord(string table, string whereClause="")
        {
            int count = 0;

            String stmt = String.Format("SELECT COUNT(*) as count from {0} {1};", table, whereClause);

            Hashtable attr = new Hashtable();
            Database dB = new Database();
            MySqlDataReader data = dB.Select(stmt, attr);
            if (data != null)
            {
                while (data.Read())
                {
                    count = data.GetInt32(0);                    
                }
            }

            return count;
        }

        private void PrepareChart()
        {
            LPoint lPoint1 = new LPoint();
            LPoint lPoint2 = new LPoint();
            LPoint lPoint3 = new LPoint();
            LPoint lPoint4 = new LPoint();
            LPoint lPoint5 = new LPoint();
            LPoint lPoint6 = new LPoint();

            lPoint1.Label = "Users";
            lPoint2.Label = "Assets";
            lPoint3.Label = "Users Unassigned";
            lPoint4.Label = "Assets Unassigned";
            lPoint5.Label = "Signed-in";
            lPoint6.Label = "Signed-out";

            lPoint1.Y = Convert.ToDouble(tUsers.Text);
            lPoint2.Y = Convert.ToDouble(tAssets.Text);
            lPoint3.Y = Convert.ToDouble(unUsers.Text);
            lPoint4.Y = Convert.ToDouble(unAssets.Text);
            lPoint5.Y = Convert.ToDouble(signin.Text);
            lPoint6.Y = Convert.ToDouble(signout.Text);
            polarchart.DataPoints.Clear();
            polarchart.DataPoints.AddRange(new LPoint[] {
                    lPoint1,
                    lPoint2,
                    lPoint3,
                    lPoint4,
                    lPoint5,
                    lPoint6
                });
            gunaChart1.Datasets.Clear();
            gunaChart1.Datasets.AddRange(new Guna.Charts.Interfaces.IGunaDataset[] { polarchart });

        }

        private void Main_Resize(object sender, EventArgs e)
        {
            int formWidth = this.Size.Width;
            int h = cardsSummPanel.Size.Height;
            int p = panel1.Size.Height;
            cardsSummPanel.Size = new Size(formWidth - 221, h);
            panel1.Size = new Size(formWidth - 521, p);
        }

        private void Main_Load(object sender, EventArgs e)
        {
            if (!statistics.IsBusy)
                statistics.RunWorkerAsync();
            this.Visible = false;
            new Functions().openDialogOverlay(new Login(this));
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            new Functions(this).openChildDialogOverlay(new Login(this));
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (!statistics.IsBusy)
                statistics.RunWorkerAsync();
            desktopPanel.Controls.Clear();
            desktopPanel.Controls.Add(scrollablePanel);
            desktopPanel.Controls.Add(guna2Panel1);
            pageTitle.Text = "Report Summary";
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Reports(this));
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Assets(this));
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Users(this));
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            new Functions(this).openChildDialogOverlay(new Checkin());
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            new New_Asset().Show();
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            new New_User().Show();
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            new New_Admin().Show();
        }

        private void label17_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hey there");
        }

        private void Main_Shown(object sender, EventArgs e)
        {
            user_names.Text = User["first_name"].ToString()+" "+User["last_name"].ToString();
            dp.Image = fxn.BinaryToImage(User["pic"]);
        }

        private void statistics_DoWork(object sender, DoWorkEventArgs e)
        {
            this.Invoke(new MethodInvoker(delegate
            {
                tUsers.Text = CountRecord("employees").ToString();
                tAssets.Text = CountRecord("assets").ToString();
                unUsers.Text = CountRecord("employees", "where asset_id is null").ToString();
                unAssets.Text = CountRecord("assets", "where assignee_id is null").ToString();
                signin.Text = CountRecord("assets", "where status = 1").ToString();
                signout.Text = CountRecord("assets", "where status = 0").ToString();

                PrepareChart();
            }));
        }
    }
}
