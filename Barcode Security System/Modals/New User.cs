using Barcode_Security_System.Util;
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

namespace Barcode_Security_System.Modals
{
    public partial class New_User : Form
    {
        private Functions fxn;
        private String imgLoc = "";
        public New_User()
        {
            InitializeComponent();
            fxn = new Functions();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            fxn.ChooseImg(ref imgLoc, ref dp);
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void New_User_Load(object sender, EventArgs e)
        {

            if (!backgroundWorker1.IsBusy)
                backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            string sql = "SELECT name, brand, serial_number, asset_id from assets where assignee_id is null;";
            Hashtable attr = new Hashtable();
            Database database = new Database();
            MySqlDataReader data = database.Select(sql, attr);
            AutoCompleteStringCollection stringCollection = new AutoCompleteStringCollection();
            if(data != null)
            {
                
                while (data.Read())
                {
                    stringCollection.Add(data.GetString(1) + " " + data.GetString(0) + ", " + data.GetString(2) + " ("+ data.GetString(3)+ ")");
                }
                this.Invoke(new MethodInvoker(delegate { asset.AutoCompleteCustomSource = stringCollection; }));
            }
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            string ass = "";
            int len = asset.Text.Trim().Length;

            if(!string.IsNullOrEmpty(asset.Text))
                ass = asset.Text.Substring(len-10, 9);

            if (string.IsNullOrEmpty(first_name.Text) || string.IsNullOrEmpty(last_name.Text) ||
                string.IsNullOrEmpty(dept.Text) || string.IsNullOrEmpty(email.Text) || string.IsNullOrEmpty(tel.Text) || dp.Image == null)
            {
                fxn.ErrorPrompt(this, "All fields are required except the asset field", "New User");
                return;
            }

            Database database = new Database();
            Hashtable attr = new Hashtable();
            string sql = "";
            string id = fxn.RandomNumbers(5);
            if (!string.IsNullOrEmpty(ass))
            {
                sql = "INSERT INTO employees (employee_id, first_name, last_name, dept, email, tel, asset_id, pic)" +
                            " VALUES (@id, @fn, @ln, @dep, @em, @tel, @as, @dp);";

                attr.Add("id", id);
                attr.Add("fn", first_name.Text.Trim());
                attr.Add("ln", last_name.Text.Trim());
                attr.Add("dep", dept.Text.Trim());
                attr.Add("em", email.Text.Trim());
                attr.Add("tel", tel.Text.Trim());
                attr.Add("as", ass.Trim());
                attr.Add("dp", fxn.ImageToBinary(imgLoc));
            }
            else
            {
                sql = "INSERT INTO employees (employee_id, first_name, last_name, dept, email, tel, pic)" +
                            " VALUES (@id, @fn, @ln, @dep, @em, @tel, @dp);";

                attr.Add("id", id);
                attr.Add("fn", first_name.Text.Trim());
                attr.Add("ln", last_name.Text.Trim());
                attr.Add("dep", dept.Text.Trim());
                attr.Add("em", email.Text.Trim());
                attr.Add("tel", tel.Text.Trim());
                attr.Add("dp", fxn.ImageToBinary(imgLoc));
            }

            if(database.Insert(sql, attr))
            {
                if (!string.IsNullOrEmpty(ass))
                    database.UpdateAssignee(ass, id);
                fxn.InfoPrompt(this, "User Created Successfully", "New User");

                first_name.Text = "";
                last_name.Text = "";
                dept.Text = "";
                email.Text = "";
                first_name.Text = "";
                asset.Text = "";
                dp.Image = null;
                imgLoc = "";
            }
            else
            {
                fxn.ErrorPrompt(this, "User was not created, an error occured", "New User");
            }
        }
    }
}
