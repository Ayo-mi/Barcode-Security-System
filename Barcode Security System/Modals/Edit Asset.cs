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
    public partial class Edit_Asset : Form
    {
        private string id;
        private Functions fxn;
        public Edit_Asset(string id)
        {
            InitializeComponent();
            this.id = id;
            fxn = new Functions();
        }

        private string GetAssinee(string id)
        {
            string ass = "";

            if (!string.IsNullOrEmpty(id))
            {
                string sql = "SELECT first_name, last_name, dept, employee_id from employees where employee_id = @id limit 1;";
                Hashtable attr = new Hashtable();
                attr.Add("@id", id);
                Database database = new Database();
                MySqlDataReader data = database.Select(sql, attr);
                if (data != null)
                {
                    while (data.Read())
                        ass = data.GetString(0) + " " + data.GetString(1) + ", " + data.GetString(2) + " (" + data.GetString(3) + ")";                
                }
                
            }
            
            return ass;
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
                    stringCollection.Add(data.GetString(0) + " " + data.GetString(1) + ", " + data.GetString(2) + " (" + data.GetString(3) + ")");
                }
            }
            this.Invoke(new MethodInvoker(delegate { assignee.AutoCompleteCustomSource = stringCollection; }));
            Console.WriteLine(stringCollection.Count);
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void user_data_DoWork(object sender, DoWorkEventArgs e)
        {
            string sql = "SELECT * from assets where asset_id = @id limit 1;";
            Hashtable attr = new Hashtable();
            attr.Add("@id", id);
            Database database = new Database();
            MySqlDataReader data = database.Select(sql, attr);
            if (data != null)
            {
                while (data.Read())
                {
                    this.Invoke(new MethodInvoker(delegate {
                        item_name.Text = data.GetString(2);
                        brand.Text = data.GetString(3);
                        serial_number.Text = data.GetString(4);
                        //string a = string.IsNullOrEmpty(data[5].ToString()) ? "" : data.GetString(5);
                        assignee.Text = GetAssinee(data[5].ToString());
                    }));
                }
            }            
        }

        private void Edit_Asset_Load(object sender, EventArgs e)
        {
            if (!backgroundWorker1.IsBusy)
                backgroundWorker1.RunWorkerAsync();
            if (!user_data.IsBusy)
                user_data.RunWorkerAsync();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            string ass = "";
            int len = assignee.Text.Trim().Length;

            if (!string.IsNullOrEmpty(assignee.Text))
                ass = assignee.Text.Substring(len - 6, 5);

            if (string.IsNullOrEmpty(item_name.Text) || string.IsNullOrEmpty(serial_number.Text) || string.IsNullOrEmpty(brand.Text))
            {
                fxn.ErrorPrompt(this, "All fields are required except the assignee field", "Edit Asset");
                return;
            }

            Database database = new Database();
            string sql = "";
            Hashtable attr = new Hashtable();

            if (!string.IsNullOrEmpty(ass))
            {
                sql = "UPDATE assets SET name=@na, brand=@br, serial_number=@sn, assignee_id=@as WHERE asset_id=@id LIMIT 1;" +
                    "UPDATE employees SET asset_id=@id WHERE employee_id=@as LIMIT 1;";

                attr.Add("id", id);
                attr.Add("na", item_name.Text.Trim());
                attr.Add("br", brand.Text.Trim());
                attr.Add("sn", serial_number.Text.Trim());
                attr.Add("as", ass);
            }
            else
            {
                sql = "UPDATE assets SET name=@na, brand=@br, serial_number=@sn, assignee_id=@as WHERE asset_id=@id LIMIT 1;" +
                    "UPDATE employees SET asset_id=@as WHERE asset_id=@id LIMIT 1;";

                attr.Add("id", id);
                attr.Add("na", item_name.Text.Trim());
                attr.Add("br", brand.Text.Trim());
                attr.Add("sn", serial_number.Text.Trim());
                attr.Add("as", null);
            }

            if (database.Update(sql, attr))
            {                
                fxn.InfoPrompt(this, "Asset updated Successfully", "Asset");
            }
            else
            {
                fxn.ErrorPrompt(this, "Asset was not updated, an error occured", "Asset");
            }
        }
    }
}
