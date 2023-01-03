﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModel
{

    public class SubSystemGroupVM
    {
        public string group_code { get; set; }
        public string group_name { get; set; }
        public int sort { get; set; }
        public int active_flag { get; set; }
        public DateTime update_time { get; set; }
    }
    public class SubSystemVM
    {
        public string sys_code { get; set; }
        public string sys_name { get; set; }
        public int sys_no { get; set; }
        public string sys_desc { get; set; }
        public string file_path { get; set; }
        public string file_type { get; set; }
        public string icon_path { get; set; }
        public int open_mode { get; set; }
        public string open_mode_str
        {
            get
            {
                if (open_mode == 1)
                {
                    return "在程序中打开";
                }
                else if (open_mode == 1)
                {
                    return "外部打开";
                }
                return "";
            }
        }
        public int active_flag { get; set; }
        public DateTime update_time { get; set; }

        //检查版本更新地址
        public string sys_update_url { get; set; }
        //子系统相对目录
        public string sys_relative_path { get; set; }
        public string sys_group_code { get; set; }
        public string subsys_id { get; set; }
        public string group_no { get; set; }
    }

    public class MainClientConfigVM
    {
        public string id { get; set; }
        public string name { get; set; }
        public string show_image { get; set; }
        public string show_title { get; set; }
        public string title { get; set; }
        public string show_desc { get; set; }
        public DateTime update_time { get; set; }

    }
    public class YpGroup
    { 
        public string group_no { get; set; }
        public string dept_name { get; set; }
    }


    public class XTGroupVM
    {
        public string subsys_id { get; set; }
        public int user_group { get; set; }
        public string group_name { get; set; }

    }
    public class XTUserVM
    {
        public string user_name { get; set; }
        public string subsys_id { get; set; }
        public string pass_word { get; set; }
        public string user_group { get; set; }
        public string create_pw_date { get; set; }
        public string user_mi { get; set; }
        public string name { get; set; }

    }
    public class XTUserGroupVM
    {
        public string subsys_id { get; set; }
        public int user_group { get; set; }
        public string func_name { get; set; }
        public string func_desc { get; set; }

    }
    public class XTUserReportVM
    {
        public string subsys_id { get; set; }
        public int user_group { get; set; }
        public string report_code { get; set; }
        public string rep_id { get; set; }
        public string rep_name { get; set; }
        public string parent_id { get; set; }

    }

    public class XTFunctionsVM
    {
        public string subsys_id { get; set; }
        public int action_flag { get; set; }
        public string func_name { get; set; }
        public string func_desc { get; set; }
        public string parent_func { get; set; }
        public string sys_type { get; set; }

    }
}
