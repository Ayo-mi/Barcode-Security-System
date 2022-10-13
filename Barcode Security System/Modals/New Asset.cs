using Barcode_Security_System.Util;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Barcode_Security_System.Modals
{
    public partial class New_Asset : Form
    {
        private Functions fxn;
        public New_Asset()
        {
            InitializeComponent();
            fxn = new Functions();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            string sql = "SELECT first_name, last_name, dept, employee_id from employees where asset_id is null;";
            Hashtable attr = new Hashtable();
            Database database = new Database();
            MySqlDataReader data = database.Select(sql, attr);
            AutoCompleteStringCollection stringCollection = new AutoCompleteStringCollection();
            if (data != null)
            {
                while (data.Read())
                {
                    stringCollection.Add(data.GetString(0) + " " + data.GetString(1) + ", " + data.GetString(2) + " ("+ data.GetString(3)+")");
                }
            }
            this.Invoke(new MethodInvoker(delegate { assignee.AutoCompleteCustomSource = stringCollection; }));
        }

        private void New_Asset_Load(object sender, EventArgs e)
        {
            if (!backgroundWorker1.IsBusy)
                backgroundWorker1.RunWorkerAsync();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            string ass = "";
            int len = assignee.Text.Trim().Length;

            if(!string.IsNullOrEmpty(assignee.Text))
                ass = assignee.Text.Substring(len-6, 5);

            if (string.IsNullOrEmpty(item_name.Text) || string.IsNullOrEmpty(serial_number.Text) || string.IsNullOrEmpty(brand.Text))
            {                
                fxn.ErrorPrompt(this, "All fields are required except the assignee field", "Asset");
                return;
            }

            Database database = new Database();
            string sql = "";
            Hashtable attr = new Hashtable();
            string id = fxn.RandomNumbers(9);

            if (!string.IsNullOrEmpty(ass))
            {
                sql = "INSERT INTO assets (asset_id, name, brand, serial_number, assignee_id, status)" +
                            " VALUES (@id, @na, @br, @sn, @as, @st);";

                attr.Add("id", id);
                attr.Add("na", item_name.Text.Trim());
                attr.Add("br", brand.Text.Trim());
                attr.Add("sn", serial_number.Text.Trim());
                attr.Add("as", ass);
                attr.Add("st", 0);
            }
            else
            {
                sql = "INSERT INTO assets (asset_id, name, brand, serial_number, status)" +
                            " VALUES (@id, @na, @br, @sn, @st);";

                attr.Add("id", id);
                attr.Add("na", item_name.Text.Trim());
                attr.Add("br", brand.Text.Trim());
                attr.Add("sn", serial_number.Text.Trim());
                attr.Add("st", 0);
            }
                            
            if (database.Insert(sql, attr))
            {
                if (!string.IsNullOrEmpty(ass))
                    database.UpdateAssetId(id, ass);
                fxn.InfoPrompt(this, "Asset added Successfully", "Asset");

                if (isPrint.Checked)
                {
                    Barcode bar = new Barcode();
                    ProcessStartInfo psi = new ProcessStartInfo();

                    bar.GenerateBarcode(id).drawBarcode(Application.StartupPath + "/bar.png");
                    PrintDialog printDialog1 = new PrintDialog();
                    psi.UseShellExecute = true;
                    psi.Verb = "print";
                    psi.WindowStyle = ProcessWindowStyle.Hidden;
                    psi.Arguments = printDialog1.PrinterSettings.PrinterName.ToString();
                    psi.FileName = Application.StartupPath + "/bar.png";
                    Process.Start(psi);
                }

                item_name.Text = "";
                brand.Text = "";
                serial_number.Text = "";
                assignee.Text = "";
            }
            else
            {
                fxn.ErrorPrompt(this, "Asset was not added, an error occured", "Asset");
            }
        }
    }
}
