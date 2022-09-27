﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client.ClassLib;
using Client.ViewModel;
using Sunny.UI;
using log4net;
using System.Configuration;
using Client.Forms.Wedgit;
using Newtonsoft.Json;

namespace Client.Forms.Pages.mzgh
{
    public partial class GhDepositRecord : UIForm
    {
        private static ILog log = LogManager.GetLogger(typeof(GhDepositRecord));//typeof放当前类
        public GhDepositRecord()
        {
            InitializeComponent();
        }

        public string patient_id;

        private void btnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }
        public void BindData()
        {
            var _pid = txt_patientid.Text;
            if (string.IsNullOrWhiteSpace(_pid))
            {
                MessageBox.Show("id为空！");
                return;
            } 
            string paramurl = string.Format($"/api/guahao/GetGhDepositReceipts?patient_id={_pid}");
            var json = HttpClientUtil.Get(paramurl);


            var result = WebApiHelper.DeserializeObject<ResponseResult<List<GHReceiptModelVM>>>(json);

            if (result.status == 1)
            {
                if (result.data != null && result.data.Count > 0)
                {
                    var _dat = result.data.Select(p => new
                    {
                        patient_id = p.patient_id,
                        ledger_sn = p.ledger_sn,
                        times = p.times,
                        charge_total = p.charge_total,
                        cash_name = p.cash_name,
                        cash_date = p.price_date, 
                    }).OrderByDescending(p => p.cash_date).ToList();
                    dgv_mzdeposit.Init();
                    dgv_mzdeposit.DataSource = _dat;
                    dgv_mzdeposit.AutoResizeColumns();
                }

            }
            else
            {
                var _ds = new List<GHReceiptModelVM>();
                dgv_mzdeposit.DataSource = _ds.Select(p => new
                {
                    patient_id = p.patient_id,
                    ledger_sn = p.ledger_sn,
                    times = p.times,
                    charge_total = p.charge_total,
                    cash_name = p.cash_name,
                    cash_date = p.price_date,
                }).ToList();
            }
        }

        private void GhDepositRecord_Load(object sender, EventArgs e)
        {
            StyleHelper.SetGridColor(dgv_mzdeposit);//设置样式

            txt_patientid.Text = patient_id;

            BindData();
            dgv_mzdeposit.RowsDefaultCellStyle.SelectionBackColor = SessionHelper.dgv_row_seleced_color;
        }

        private void btnxp_Click(object sender, EventArgs e)
        {
            try
            {
                var _index = dgv_mzdeposit.SelectedIndex;
                if (_index >= 0)
                {
                    var _pid = dgv_mzdeposit.Rows[_index].Cells["pid"].Value.ToString();
                    var _times = dgv_mzdeposit.Rows[_index].Cells["times"].Value.ToString();
                    //Print ghprint = new Print(SessionHelper.mzsf_report_code);
                    //ghprint._printer = SessionHelper.sf_printer;
                    //ghprint._patient_id = _pid;
                    //ghprint._ledger_sn = _ledger_sn;
                    //ghprint.Show();

                    GhPrint ghprint = new GhPrint();
                    ghprint.times = _times;
                    ghprint.patient_id = _pid;
                    ghprint.Show();
                }

            }
            catch (Exception ex)
            {
                UIMessageTip.Show(ex.Message);
            }
        }

        private void btnfp_Click(object sender, EventArgs e)
        {
            try
            {
                var _index = dgv_mzdeposit.SelectedIndex;
                if (_index >= 0)
                {
                    var _pid = dgv_mzdeposit.Rows[_index].Cells["pid"].Value.ToString();
                    var _ledger_sn = dgv_mzdeposit.Rows[_index].Cells["ledger_sn"].Value.ToString();
                    var _times = dgv_mzdeposit.Rows[_index].Cells["times"].Value.ToString();
                    var _charge_total = dgv_mzdeposit.Rows[_index].Cells["charge_total"].Value.ToString();
                    PrintElecBill(_pid, _ledger_sn, _times, _charge_total);
                }

            }
            catch (Exception ex)
            {
                UIMessageTip.Show(ex.Message);
            }
        }

        public void PrintElecBill(string _patientId, string _ledger_sn,string _times,string _charge_total)
        {
            //补打电子发票
            try
            {
                var _subsys_id = "mz";

                //查询电子发票记录表  <List<FpData>> GetFpDatasByParams(string patient_id, int ledger_sn, string subsys_id)
                string paramurl = string.Format($"/api/mzsf/GetFpDatasByParams?patient_id={_patientId.ToString()}&ledger_sn={_ledger_sn.ToString()}&subsys_id={_subsys_id}");

                var json = HttpClientUtil.Get(paramurl);

                var result = WebApiHelper.DeserializeObject<ResponseResult<List<FpData>>>(json);

                if (result.status != 1)
                {
                    UIMessageTip.Show(result.message);

                    log.Error(result.message);

                    return;

                }
                if (result.data == null || result.data.Count == 0)
                {
                    if (UIMessageDialog.ShowAskDialog(this, "没有电子发票数据,是否生成？"))
                    {
                        var _add_result = ElecBillHelper.CreateElecBill(_patientId.ToString(), Convert.ToInt32(_ledger_sn), Convert.ToInt32(_times), _charge_total.ToString(), BillTypeEnum.GuaHao);
                        if (_add_result)
                        {
                            json = HttpClientUtil.Get(paramurl);

                            result = WebApiHelper.DeserializeObject<ResponseResult<List<FpData>>>(json);
                        }
                        else
                        {
                            log.Error("重新生成电子发票数据失败！");

                            return;
                        }
                    }
                    else
                    {
                        log.Error("没有电子发票数据！");

                        return;
                    }
                }

                string _billBatchCode = result.data[0].billBatchCode;
                string _billNo = result.data[0].billNo;
                string _random = result.data[0].random;

                ElecBillHelper.PrintElecBill(_billBatchCode, _billNo, _random);
            }
            catch (Exception ex)
            {
                UIMessageTip.Show(ex.Message);
                log.Error("打印电子发票失败！");
                log.Error(ex.Message);
            }
        }

        private void GhDepositRecord_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
