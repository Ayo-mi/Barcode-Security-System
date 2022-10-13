﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barcode_Security_System.Util
{
    class DBConfig
    {
        private string server_name = "localhost";
        private string user = "root";
        private string password = "";
        private string database = "barcode_security";

        public string Server
        {
            get { return server_name; }
        }

        public string User
        {
            get { return user; }
        }

        public string Password
        {
            get { return password; }
        }

        public string Database
        {
            get { return database; }
        }
    }
}
