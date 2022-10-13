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
    public partial class Edit_User : Form
    {
        private string id;
        private string imgLoc = "";
        private Functions fxn;
        private byte[] imgarr = null;
        public Edit_User(string id)
        {
            InitializeComponent();
            this.id = id;
            fxn = new Functions();
        }

        private string GetAsset(string id)
        {
            string ass = "";

            if (!string.IsNullOrEmpty(id))
            {
                string sql = "SELECT name, brand, serial_number, asset_id from assets where assignee_id = @id limit 1;";
                Hashtable attr = new Hashtable();
                attr.Add("@id", id);
                Database database = new Database();
                MySqlDataReader data = database.Select(sql, attr);
                if (data != null)
                {
                    while (data.Read())
                        ass = data.GetString(1) + " " + data.GetString(0) + ", " + data.GetString(2) + " (" + data.GetString(3) + ")";
                }

            }

            return ass;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            string sql = "SELECT name, brand, serial_number, asset_id from assets where assignee_id is null;";
            Hashtable attr = new Hashtable();
            Database database = new Database();
            MySqlDataReader data = database.Select(sql, attr);
            AutoCompleteStringCollection stringCollection = new AutoCompleteStringCollection();
            if (data != null)
            {

                while (data.Read())
                {
                    stringCollection.Add(data.GetString(1) + " " + data.GetString(0) + ", " + data.GetString(2) + " (" + data.GetString(3) + ")");
                }
                this.Invoke(new MethodInvoker(delegate { asset.AutoCompleteCustomSource = stringCollection; }));
            }
        }

        private void user_data_DoWork(object sender, DoWorkEventArgs e)
        {
            string sql = "SELECT * from employees where employee_id = @id limit 1;";
            Hashtable attr = new Hashtable();
            attr.Add("@id", id);
            Database database = new Database();
            MySqlDataReader data = database.Select(sql, attr);
            if (data != null)
            {
                while (data.Read())
                {
                    this.Invoke(new MethodInvoker(delegate {
                        first_name.Text = data.GetString(2);
                        last_name.Text = data.GetString(3);
                        dept.Text = data.GetString(4);
                        email.Text = data.GetString(5);
                        tel.Text = data.GetString(6);
                        dp.Image = fxn.BinaryToImage(data.GetValue(7));
                        asset.Text = GetAsset(data[1].ToString());
                        imgarr = (byte[])data.GetValue(7);
                    }));
                }
            }
        }

        private void Edit_User_Load(object sender, EventArgs e)
        {
            if (!backgroundWorker1.IsBusy)
                backgroundWorker1.RunWorkerAsync();
            if (!user_data.IsBusy)
                user_data.RunWorkerAsync();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            fxn.ChooseImg(ref imgLoc, ref dp);
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            string ass = "";
            int len = asset.Text.Trim().Length;

            if (!string.IsNullOrEmpty(asset.Text))
                ass = asset.Text.Substring(len - 10, 9);

            if (string.IsNullOrEmpty(first_name.Text) || string.IsNullOrEmpty(last_name.Text) ||
                string.IsNullOrEmpty(dept.Text) || string.IsNullOrEmpty(email.Text) || string.IsNullOrEmpty(tel.Text) 
                || dp.Image == null || (imgarr==null && string.IsNullOrEmpty(imgLoc)))
            {
                fxn.ErrorPrompt(this, "All fields are required except the asset field", "Edit User");
                return;
            }

            Database database = new Database();
            Hashtable attr = new Hashtable();
            string sql = "";

            if (!string.IsNullOrEmpty(ass))
            {
                sql = "UPDATE employees SET first_name=@fn, last_name=@ln, dept=@dep, email=@em, " +
                    "tel=@tel, asset_id=@as, pic=@dp WHERE employee_id=@id LIMIT 1;" +
                    "UPDATE assets SET assignee_id=@id WHERE asset_id=@as LIMIT 1;";
                attr.Add("id", id);
                attr.Add("fn", first_name.Text.Trim());
                attr.Add("ln", last_name.Text.Trim());
                attr.Add("dep", dept.Text.Trim());
                attr.Add("em", email.Text.Trim());
                attr.Add("tel", tel.Text.Trim());
                attr.Add("as", ass.Trim());
                if(!string.IsNullOrEmpty(imgLoc))
                    attr.Add("dp", fxn.ImageToBinary(imgLoc));
                else
                    attr.Add("dp", imgarr);

            }
            else
            {
                sql = "UPDATE employees SET first_name=@fn, last_name=@ln, dept=@dep, email=@em, " +
                    "tel=@tel, pic=@dp, asset_id=@as WHERE employee_id=@id LIMIT 1;" +
                    "UPDATE assets SET assignee_id=@as WHERE assignee_id=@id LIMIT 1;";

                attr.Add("id", id);
                attr.Add("fn", first_name.Text.Trim());
                attr.Add("ln", last_name.Text.Trim());
                attr.Add("dep", dept.Text.Trim());
                attr.Add("em", email.Text.Trim());
                attr.Add("tel", tel.Text.Trim());
                attr.Add("as", null);
                if (!string.IsNullOrEmpty(imgLoc))
                    attr.Add("dp", fxn.ImageToBinary(imgLoc));
                else
                    attr.Add("dp", imgarr);
            }

            if (database.Update(sql, attr))
            {
                if(!string.IsNullOrEmpty(ass))
                    database.UpdateAssignee(ass, id);                
                fxn.InfoPrompt(this, "User Updated Successfully", "Edit User");                
            }
            else
            {
                fxn.ErrorPrompt(this, "User was not updated, an error occured", "Edit User");
            }
        }
    }
}
