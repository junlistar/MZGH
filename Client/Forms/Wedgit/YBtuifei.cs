using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client.ClassLib;
using Sunny.UI;
using log4net;

namespace Client.Forms.Wedgit
{
    public partial class YBtuifei : UIForm
    {
        private static ILog log = LogManager.GetLogger(typeof(YBtuifei));//typeof放当前类
        public YBtuifei()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            var _psn_no = txt_psn_no.Text;
            var _setl_id = txt_setl_id.Text;
            var _mdtrt_id = txt_mdtrt_id.Text;

            if (string.IsNullOrWhiteSpace(_psn_no) || string.IsNullOrWhiteSpace(_setl_id) || string.IsNullOrWhiteSpace(_mdtrt_id))
            {
                UIMessageTip.Show("请将参数填写完整！");
                return;
            }

            //门诊结算撤销
            var jscxRequest = new YBRequest<MZJSCX>();
            jscxRequest.infno = "2208";

            jscxRequest.msgid = YBHelper.msgid;
            jscxRequest.mdtrtarea_admvs = YBHelper.mdtrtarea_admvs;// "421099";// 
            jscxRequest.insuplc_admdvs = SessionHelper.patientVM.yb_insuplc_admdvs.Trim();
            jscxRequest.recer_sys_code = YBHelper.recer_sys_code;
            jscxRequest.dev_no = "";
            jscxRequest.dev_safe_info = "";
            jscxRequest.cainfo = "";
            jscxRequest.signtype = "";
            jscxRequest.infver = YBHelper.infver;
            jscxRequest.opter_type = YBHelper.opter_type;
            jscxRequest.opter = SessionHelper.uservm.user_mi;
            jscxRequest.opter_name = SessionHelper.uservm.name;
            jscxRequest.inf_time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            jscxRequest.fixmedins_code = YBHelper.fixmedins_code;
            jscxRequest.fixmedins_name = YBHelper.fixmedins_name;
            jscxRequest.sign_no = YBHelper.msgid;
            jscxRequest.input = new RepModel<MZJSCX>();

            MZJSCX _mzjscx = new MZJSCX();
            _mzjscx.psn_no = _psn_no;
            _mzjscx.setl_id = _setl_id;//结算返回值 
            _mzjscx.mdtrt_id = _mdtrt_id;

            jscxRequest.input.data = _mzjscx;

            var json = WebApiHelper.SerializeObject(jscxRequest);
            var BusinessID = "2208";
            var Dataxml = json;
            var Outputxml = "";
            var parm = new object[] { BusinessID, json, Outputxml };


            YBHelper.AddYBLog(BusinessID, json, SessionHelper.patientVM.patient_id, jscxRequest.sign_no, jscxRequest.infver, 0, SessionHelper.uservm.user_mi, jscxRequest.inf_time);
            //提交
            var result = ComHelper.InvokeMethod("yinhai.yh_hb_sctr", "yh_hb_call", ref parm);

            YBHelper.AddYBLog(BusinessID, parm[2].ToString(), SessionHelper.patientVM.patient_id, jscxRequest.sign_no, jscxRequest.infver, 1, SessionHelper.uservm.user_mi, jscxRequest.inf_time);

            log.Debug("结算撤销返回：" + parm[2]);

            var _jscxresp = WebApiHelper.DeserializeObject<YBResponse<MzjsResponse>>(parm[2].ToString());

            if (_jscxresp != null && !string.IsNullOrEmpty(_jscxresp.err_msg))
            {
                MessageBox.Show(_jscxresp.err_msg);
                log.Error(_jscxresp.err_msg);
                return;
            }
            else
            {
                MessageBox.Show("退费成功！余额：" + _jscxresp.output.setlinfo.balc);
                txt_psn_no.Text = "";
                txt_setl_id.Text = "";
                txt_mdtrt_id.Text = "";
            }
        }

        private void YBtuifei_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
