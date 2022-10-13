using Barcode_Security_System.Util;
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
    public partial class New_Admin : Form
    {
        string imgLoc = "";
        private Functions fxn;
        public New_Admin()
        {
            InitializeComponent();
            fxn = new Functions();
        }        

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(first_name.Text) || string.IsNullOrEmpty(last_name.Text) ||
                string.IsNullOrEmpty(user_id.Text) || string.IsNullOrEmpty(psw.Text) || dp.Image == null)
            {
                fxn.ErrorPrompt(this, "Provide all details before proceeding", "Administrative account");
                return;
            }else if(psw.Text.Length < 5)
            {
                fxn.ErrorPrompt(this, "Password must be at least 6 characters", "Administrative account");
                return;
            }

            Database database = new Database();
            string sql = "INSERT INTO users (username, first_name, last_name, password, pic)" +
                            " VALUES (@id, @fn, @ln, @pw, @dp);";
            Hashtable attr = new Hashtable();
            attr.Add("@id", user_id.Text.Trim());
            attr.Add("@fn", first_name.Text.Trim());
            attr.Add("@ln", last_name.Text.Trim());
            attr.Add("@pw", psw.Text);
            attr.Add("@dp", fxn.ImageToBinary(imgLoc));

            if (database.Insert(sql, attr))
            {
                fxn.InfoPrompt(this, "Account Created Successfully", "Administrative account");
            }
            else
            {
                fxn.ErrorPrompt(this, "Account was not created, an error occured", "Administrative account");
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            fxn.ChooseImg(ref imgLoc, ref dp);
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
