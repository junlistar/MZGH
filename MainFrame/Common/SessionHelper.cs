using Client.ViewModel;
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

        //用户子系统列表 
        public static List<UserGroupSystemVM> userGroupSystems;

        //用户
        public static List<UserDicVM> userDics;

        public static List<YpGroup> ypGroupsList;

        public static int current_index;
    }
}
