using Barcode_Security_System.Modals;
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

namespace Barcode_Security_System
{
    public partial class Assets : Form
    {
        private Main m;
        public Assets(Main m)
        {
            InitializeComponent();
            this.m = m;
            m.Title = "Assets";
        }

        private string GetUser(string id)
        {
            string user = "";
            string stmt = "SELECT first_name, last_name from employees where employee_id = @id limit 1;";
            Hashtable attr = new Hashtable();
            attr.Add("@id", id);
            Database dB = new Database();
            MySqlDataReader data = dB.Select(stmt, attr);
            if (data != null)
            {
                while (data.Read())
                {
                    user = data.GetString(0) + " " + data.GetString(1);
                }
            }

            return user;
        }

        private void FilterTable(string qry)
        {
            String stmt = String.Format("SELECT a.asset_id, a.name, a.brand, a.serial_number, e.employee_id FROM assets a" +
                " left join employees e on a.asset_id = e.asset_id where e.first_name like '%{0}%' or e.dept like '%{0}%' or e.tel like '%{0}%' or " +
                "a.brand like '%{0}%' or e.last_name like '%{0}%' or a.name like '%{0}%' or a.serial_number like '%{0}%';", qry);

            Hashtable attr = new Hashtable();
            this.Invoke(new MethodInvoker(delegate
            {
                tb.Rows.Clear();
            }));


            Database dB = new Database();
            MySqlDataReader data = dB.Select(stmt, attr);
            if (data != null)
            {
                int i = 1;
                while (data.Read())
                {
                    this.Invoke(new MethodInvoker(delegate
                    {
                        tb.Rows.Add(i, data[2] + " " + data[1], data[3], GetUser(data[4].ToString()), "Print Barcode", data[0]);
                    }));
                    i++;

                }
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            string stmt = "SELECT * from assets;";
            Hashtable attr = new Hashtable();            
            Database dB = new Database();
            MySqlDataReader data = dB.Select(stmt, attr);
            int i = 1;
            if (data != null)
            {
                while (data.Read())
                {
                    this.Invoke(new MethodInvoker(delegate
                    {
                        tb.Rows.Add(i, data["brand"]+", "+data["name"], data["serial_number"], GetUser(data["assignee_id"].ToString()), "Print Barcode", data["asset_id"]);
                    }));
                    i++;
                }
            }
        }

        private void Assets_Load(object sender, EventArgs e)
        {
            if (!backgroundWorker1.IsBusy)
                backgroundWorker1.RunWorkerAsync();
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            new New_Asset().Show();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            if (tb.SelectedRows.Count == 1)
            {
                string id = tb.SelectedRows[0].Cells[5].Value.ToString().Trim();
                new Edit_Asset(id).Show();
            }
        }

        private void filter_DoWork(object sender, DoWorkEventArgs e)
        {
            FilterTable(search.Text.Trim());
        }

        private void search_TextChanged(object sender, EventArgs e)
        {
            if (!filter.IsBusy)
                filter.RunWorkerAsync();
        }

        private void tb_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var t = (Guna.UI2.WinForms.Guna2DataGridView)sender;
            if(t.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                string id = tb.SelectedRows[0].Cells[5].Value.ToString().Trim();
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
        }
    }
}
