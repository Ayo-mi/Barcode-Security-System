using Barcode_Security_System.Modals;
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

namespace Barcode_Security_System
{
    public partial class Users : Form
    {
        private Main m;
        public Users(Main m)
        {
            InitializeComponent();
            this.m = m;
            m.Title = "Users";
        }

        private string GetAsset(string id)
        {
            string user = "";
            string stmt = "SELECT name, brand from assets where asset_id = @id limit 1;";
            Hashtable attr = new Hashtable();
            attr.Add("@id", id);
            Database dB = new Database();
            MySqlDataReader data = dB.Select(stmt, attr);
            if (data != null)
            {
                while (data.Read())
                {
                    user = data.GetString(1) + " " + data.GetString(0);
                }
            }

            return user;
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            new New_User().Show();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            string stmt = "SELECT * from employees;";
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
                        tb.Rows.Add(i, data[2] + " " + data[3], data[4], GetAsset(data[8].ToString()), data[6], data[1]);
                    }));
                    i++;
                }
            }
        }

        private void FilterTable(string qry)
        {
            String stmt = String.Format("SELECT e.employee_id, e.first_name, e.last_name, e.dept, e.tel, e.asset_id FROM employees " +
                "e left join assets a on e.asset_id = a.asset_id where e.first_name like '%{0}%' or e.dept like '%{0}%' or e.tel like '%{0}%' or " +
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
                        tb.Rows.Add(i, data[1] + " " + data[2], data[3], GetAsset(data[5].ToString()), data[4], data[0]);
                    }));
                    i++;

                }
            }
        }

        private void Users_Load(object sender, EventArgs e)
        {
            if (!backgroundWorker1.IsBusy)
                backgroundWorker1.RunWorkerAsync();            
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            if (tb.SelectedRows.Count == 1)
            {
                string id = tb.SelectedRows[0].Cells[5].Value.ToString().Trim();
                new Edit_User(id).Show();
            }
        }

        private void filter_DoWork(object sender, DoWorkEventArgs e)
        {
            FilterTable(search.Text.Trim()); ;
        }

        private void search_TextChanged(object sender, EventArgs e)
        {
            if (!filter.IsBusy)
                filter.RunWorkerAsync();
        }
    }
}
