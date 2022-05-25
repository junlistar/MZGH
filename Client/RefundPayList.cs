﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sunny.UI;
using Client.ClassLib;
using Client.ViewModel;
using log4net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Client
{
    public partial class RefundPayList : UIForm
    {
        private static ILog log = LogManager.GetLogger(typeof(RefundPayList));//typeof放当前类
        string _datestr = "";
        string _patient_id = "";
        int _ledger_sn = 0;

        public RefundPayList(string datestr, string patient_id, int ledger_sn)
        {
            InitializeComponent();
            _datestr = datestr;
            _patient_id = patient_id;
            _ledger_sn = ledger_sn;
        }

        private void RefundPayList_Load(object sender, EventArgs e)
        {

        }
        public void LoadData()
        {
            // request_date, string patient_id, string ledger_sn);

           
            Task<HttpResponseMessage> task = null; var json = "";
            var paramurl = string.Format($"/api/GuaHao/GetGhRefundPayList?request_date={_datestr}&patient_id={_patient_id}&ledger_sn={_ledger_sn}");

            log.Info(SessionHelper.MyHttpClient.BaseAddress + paramurl);


            task = SessionHelper.MyHttpClient.GetAsync(paramurl);

            task.Wait();
            var response = task.Result;
            if (response.IsSuccessStatusCode)
            {
                var read = response.Content.ReadAsStringAsync();
                read.Wait();
                json = read.Result;
            }
            else
            {
                log.Info(response.ReasonPhrase);
            }
            var result = WebApiHelper.DeserializeObject<ResponseResult<List<GhRefundPayVM>>>(json);

            //
        }
    }
}
