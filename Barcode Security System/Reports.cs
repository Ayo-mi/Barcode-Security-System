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
    public partial class Reports : Form
    {
        private Main m;
        public Reports(Main m)
        {
            InitializeComponent();
            this.m = m;
            m.Title = "Reports";
        }

        private Hashtable GetAsset(string id)
        {
            string stmt = "SELECT name, brand, serial_number, assignee_id from assets where asset_id = @id limit 1;";
            Hashtable attr = new Hashtable();
            attr.Add("@id", id);
            Database dB = new Database();
            MySqlDataReader data = dB.Select(stmt, attr);
            if (data != null)
            {
                while (data.Read())
                {
                    attr.Add("name", data.GetString(1)+" "+data.GetString(0));
                    attr.Add("brand", data.GetString(1));
                    attr.Add("serial", data.GetString(2));
                    attr.Add("ass", data[3].ToString());
                }
            }

            return attr;
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
            String stmt = String.Format("SELECT r.asset_id, r.assinee, r.time_in, r.time_out FROM reports r left join assets a on r.asset_id = a.asset_id" +
                " left join employees e on a.assignee_id = e.employee_id where e.first_name like '%{0}%' or " +
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
                        DateTime tm_in = DateTime.Parse(data["time_in"].ToString(), System.Globalization.CultureInfo.CurrentCulture);
                        string outt = "";
                        if (!string.IsNullOrEmpty(data["time_out"].ToString()))
                        {
                            DateTime tm_out = DateTime.Parse(data["time_out"].ToString(), System.Globalization.CultureInfo.CurrentCulture);
                            outt = tm_out.ToString("H:mm tt ddd, MMM d, yyyy");
                        }


                        tb.Rows.Add(i, GetAsset(data[0].ToString())["name"], GetAsset(data[0].ToString())["serial"],
                            GetUser(data[1].ToString()), tm_in.ToString("H:mm tt ddd, MMM d, yyyy"), outt);
                    }));
                    i++;

                }
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            string stmt = "SELECT * from reports;";
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
                        DateTime tm_in = DateTime.Parse(data["time_in"].ToString(), System.Globalization.CultureInfo.CurrentCulture);
                        string outt = "";
                        if (!string.IsNullOrEmpty(data["time_out"].ToString()))
                        {
                            DateTime tm_out = DateTime.Parse(data["time_out"].ToString(), System.Globalization.CultureInfo.CurrentCulture);
                            outt = tm_out.ToString("H:mm tt ddd, MMM d, yyyy");
                        }
                        
                                                
                        tb.Rows.Add(i, GetAsset(data[2].ToString())["name"], GetAsset(data[2].ToString())["serial"],
                            GetUser(data[5].ToString()), tm_in.ToString("H:mm tt ddd, MMM d, yyyy"), outt);
                    }));
                    i++;
                }
            }
        }

        private void Reports_Load(object sender, EventArgs e)
        {
            if (!backgroundWorker1.IsBusy)
                backgroundWorker1.RunWorkerAsync();            
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
    }
}
