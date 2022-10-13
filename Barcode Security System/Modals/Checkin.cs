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

namespace Barcode_Security_System.Modal
{
    public partial class Checkin : Form
    {
        private string rep_id = "";
        private string assign = "";
        private Functions fxn;
        public Checkin()
        {
            InitializeComponent();
            fxn = new Functions();
        }

        public List<int> KeyCodes = new List<int> { 8, 35, 36, 37, 39, 45, 46, 16, 48, 49, 50, 51,
        52, 53, 54, 55, 56, 57, 96, 97, 98, 99, 100, 101, 102, 103, 104, 105};

        private void CheckAsset(string asset_id)
        {
            if (!string.IsNullOrEmpty(asset_id))
            {
                bool isF = false;
                int st = 0;                
                string sql = "SELECT status, rep_id, name, brand, assignee_id from assets where asset_id = @id LIMIT 1";
                Hashtable attr = new Hashtable();
                attr.Add("@id", asset_id.Trim());
                Database database = new Database();
                MySqlDataReader data = database.Select(sql, attr);

                if(data != null)
                {
                    if (data.Read())
                    {
                        if (string.IsNullOrEmpty(data[4].ToString()))
                        {
                            this.Invoke(new MethodInvoker(delegate
                            {
                                fxn.ErrorPrompt(this, "No user attached to this asset", "Check-In");
                                barcode.Focus();
                            }));
                            return;
                        }
                        else
                        {
                            isF = true;
                            st = data.GetInt32(0);
                            rep_id = string.IsNullOrEmpty(data[1].ToString()) ? "" : data.GetString(1);
                            assign = string.IsNullOrEmpty(data[4].ToString()) ? "" : data.GetString(4);
                            attr.Clear();
                            attr = GetUser(data.GetString(4));
                            this.Invoke(new MethodInvoker(delegate
                            {
                                user.Text = attr["names"].ToString() + ", " + attr["dept"].ToString();
                                asset.Text = data.GetString(3) + " " + data.GetString(2);
                                dp.Image = fxn.BinaryToImage(attr["pic"]);
                            }));

                            if (st == 0)
                            {
                                PrepareSignIn();
                            }
                            else if (st == 1)
                            {
                                PrepareSignOut();
                            }
                        }
                        
                    }
                }
                if (!isF)
                {
                    this.Invoke(new MethodInvoker(delegate
                    {
                        fxn.ErrorPrompt(this, "No Record found", "Check-In");
                        barcode.Focus();
                    }));
                }

            }
        }

        private void PrepareSignIn()
        {
            this.Invoke(new MethodInvoker(delegate
            {
                signout.Visible = false;
                signin.Visible = true;
                card.Visible = true;
                barcode.Focus();
            }));
            
        }

        private void PrepareSignOut()
        {
            this.Invoke(new MethodInvoker(delegate
            {
                signout.Visible = true;
                signin.Visible = false;
                card.Visible = true;
                barcode.Focus();
            }));
                            
        }

        private Hashtable GetUser(string id)
        {
            string sql = "SELECT first_name, last_name, dept, pic from employees where employee_id = @id limit 1;";
            Hashtable attr = new Hashtable();
            attr.Add("@id", id);
            Database database = new Database();
            MySqlDataReader data = database.Select(sql, attr);
            if (data != null)
            {
                if (data.Read())
                {
                    attr.Clear();
                    attr.Add("names", data.GetString(0) + " " + data.GetString(1));
                    attr.Add("dept", data.GetString(2));
                    attr.Add("pic", data[3]);
                }
            }

            return attr;
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            if(!string.IsNullOrEmpty(barcode.Text.Trim()) && barcode.Text.Length == 9)
                CheckAsset(barcode.Text.Trim());
        }

        private void barcode_TextChanged(object sender, EventArgs e)
        {
            if (barcode.Text.Length == 9 && !string.IsNullOrEmpty(barcode.Text) && !backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync();
            }
            else
                card.Visible = false;

        }

        private void barcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (KeyCodes.Contains(e.KeyValue) || (e.KeyCode == Keys.V && e.Control) || (e.KeyCode == Keys.A && e.Control) || (e.KeyCode == Keys.X && e.Control))
                e.SuppressKeyPress = false;
            else
                e.SuppressKeyPress = true;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (barcode.Text.Length == 9 && !string.IsNullOrEmpty(barcode.Text) && !backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync();
            }
            else
                card.Visible = false;
        }

        private void signinBg_DoWork(object sender, DoWorkEventArgs e)
        {
            Database database = new Database();
            string sql = "";
            Hashtable attr = new Hashtable();
            string id = fxn.RandomNumbers(11);
            string timein = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            sql = "INSERT INTO reports (report_id, asset_id, time_in, assinee)" +
                        " VALUES (@id, @as, @tm, @ass);";

            attr.Add("@id", id);
            attr.Add("@as", barcode.Text.Trim());
            attr.Add("@tm", timein);
            attr.Add("@ass", assign);


            if (database.Insert(sql, attr))
            {
                if (database.UpdateReportId(id, barcode.Text.Trim()))
                    PrepareSignOut();
            }
            else
            {
                this.Invoke(new MethodInvoker(delegate { fxn.ErrorPrompt(this, "Asset was not login successfull, an error occured", "Asset");
                    barcode.Focus();
                }));
            }
        }

        private void signin_Click(object sender, EventArgs e)
        {
            if (!signinBg.IsBusy)
                signinBg.RunWorkerAsync();
        }

        private void signoutBg_DoWork(object sender, DoWorkEventArgs e)
        {
            Database database = new Database();
            string sql = "";
            Hashtable attr = new Hashtable();
            string timeout = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            sql = "UPDATE reports set time_out=@tm where report_id=@id;" +
                "UPDATE assets set rep_id=@rp, status=@st where asset_id=@as;";

            attr.Add("@id", rep_id);
            attr.Add("@as", barcode.Text.Trim());
            attr.Add("@tm", timeout);
            attr.Add("@rp", "");
            attr.Add("@st", 0);


            if (database.Insert(sql, attr))
            {
                PrepareSignIn();
            }
            else
            {
                this.Invoke(new MethodInvoker(delegate { fxn.ErrorPrompt(this, "Asset was not logout successfull, an error occured", "Asset");
                    barcode.Focus();
                }));
            }
        }

        private void signout_Click(object sender, EventArgs e)
        {
            if (!signoutBg.IsBusy)
                signoutBg.RunWorkerAsync();
        }
    }
}
