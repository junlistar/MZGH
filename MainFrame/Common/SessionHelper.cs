﻿using Client.ViewModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MainFrame.Common
{
    public class SessionHelper
    {
       

        public static HttpClient MyHttpClient = null;

        public static LoginUsersVM uservm = new LoginUsersVM();
        
         
    }
}