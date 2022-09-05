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
using Client.ViewModel;
using Sunny.UI;
using log4net;

namespace Client.Forms.Wedgit
{
    public partial class YBJSPreview : UIForm
    {
        private static ILog log = LogManager.GetLogger(typeof(YBJSPreview));//typeof放当前类
        public YBJSPreview()
        {
            InitializeComponent();
        }

        List<ChargeItemVM> chargeItems;
        public GHRequestVM ghRequest;

        public MzjsResponse mzjsResponse;
        public string patient_id;
        public int admiss_times;

        public string mdtrt_id;
        public string psn_no;
        public string ipt_otp_no;

        public decimal left_je;


        private void YBJSPreview_Load(object sender, EventArgs e)
        {
            //加载下拉框字典数据
            if (SessionHelper.insutypes != null)
            {
                jz_insutype.DataSource = SessionHelper.insutypes;
                jz_insutype.ValueMember = "code";
                jz_insutype.DisplayMember = "name";
            }
            if (SessionHelper.mdtrtCertTypes != null)
            {
                mdtrt_cert_type.DataSource = SessionHelper.mdtrtCertTypes;
                mdtrt_cert_type.ValueMember = "code";
                mdtrt_cert_type.DisplayMember = "name";
            }
            if (SessionHelper.medTypes != null)
            {
                med_type.DataSource = SessionHelper.medTypes;
                med_type.ValueMember = "code";
                med_type.DisplayMember = "name";
            }
            var setway = new List<ComboxItem>();
            setway.Add(new ComboxItem("按项目结算", "01"));
            setway.Add(new ComboxItem("按定额结算", "02"));
            psn_setlway.DataSource = setway;
            psn_setlway.ValueMember = "value";
            psn_setlway.DisplayMember = "name";

            birctrl_matn_date.Text = "";


            if (admiss_times != 0 && !string.IsNullOrWhiteSpace(patient_id))
            {
                //查询患者医保基础信息
                var paramurl = string.Format($"/api/YbInfo/GetYjsUserInfo?patient_id={patient_id}&admiss_times={admiss_times}");

                var json =HttpClientUtil.Get(paramurl);
                 
                var result = WebApiHelper.DeserializeObject<ResponseResult<UserInfoResponseModel>>(json);

                if (result.status==1)
                {
                    if (result.data!=null && result.data.baseinfo!=null)
                    { 
                        txt_psn_no.Text = result.data.baseinfo.psn_no;
                        psn_name.Text = result.data.baseinfo.psn_name;
                        gend.Text = result.data.baseinfo.gend == "1" ? "男" :"女";
                        brdy.Text = result.data.baseinfo.brdy;


                        mdtrt_cert_type.SelectedValue = result.data.baseinfo.psn_cert_type;
                        mdtrt_cert_no.Text = result.data.baseinfo.certno;
                    }
                    if (result.data != null && result.data.insuinfo != null)
                    {
                        dgv_cbxx.Init();
                        dgv_cbxx.AutoGenerateColumns = false;
                        dgv_cbxx.DataSource = result.data.insuinfo; 

                        lbl_insplcadmdvs.Text = result.data.insuinfo[0].insuplc_admdvs;
                        jz_insutype.SelectedValue = result.data.insuinfo[0].insutype;
                    }

                    if (result.data != null && result.data.idetinfo != null) {
                        foreach (var item in result.data.idetinfo)
                        { 
                            lst_ident.Items.Add(item.psn_idet_type + "  " + item.psn_type_lv + "    " + item.begntime + "    " + item.endtime + "   " + item.memo);
                        }
                    }
                }
                else
                {
                    log.Error(result.message);
                } 
            }
            //绑定医师信息
            dise_dor_no.DataSource = SessionHelper.userDics.Where(p => !string.IsNullOrEmpty(p.yb_ys_code)).ToList();
            dise_dor_no.ValueMember = "code";
            dise_dor_no.DisplayMember = "name";

            //if (mzjsResponse != null)
            //{
            //    if (mzjsResponse.setlinfo != null)
            //    {
            //        //this.lblybkname.ForeColor = Color.Red;
            //        //this.lblprice.ForeColor = Color.Red;
            //        //this.lblSyje.ForeColor = Color.Red;

            //        //this.lblybkname.Text = mzjsResponse.setlinfo.psn_name;
            //        //this.lblprice.Text = mzjsResponse.setlinfo.medfee_sumamt;
            //        //this.lblSyje.Text = mzjsResponse.setlinfo.balc;

            //    }

            //    if (mzjsResponse.setldetail != null)
            //    {
            //        var _dat = mzjsResponse.setldetail.Select(p => new
            //        {
            //            fund_pay_type_name = p.fund_pay_type_name,
            //            fund_payamt = p.fund_payamt
            //        });
            //        //dgv_detail.Init();
            //        //dgv_detail.DataSource = _dat.ToList();
            //    }
            //}

        }

        private void uiSymbolButton1_Click(object sender, EventArgs e)
        { 
            //门诊结算
            var jsRequest = new YBRequest<MZJS2207A>();
            jsRequest.infno = "2207A";

            jsRequest.msgid = YBHelper.msgid;
            jsRequest.mdtrtarea_admvs = YBHelper.mdtrtarea_admvs;// "421099";// 
            jsRequest.insuplc_admdvs = GuaHao.PatientVM.yb_insuplc_admdvs.Trim();
            jsRequest.recer_sys_code = YBHelper.recer_sys_code;
            jsRequest.dev_no = "";
            jsRequest.dev_safe_info = "";
            jsRequest.cainfo = "";
            jsRequest.signtype = "";
            jsRequest.infver = YBHelper.infver;
            jsRequest.opter_type = YBHelper.opter_type;
            jsRequest.opter = SessionHelper.uservm.user_mi;
            jsRequest.opter_name = SessionHelper.uservm.name;
            jsRequest.inf_time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            jsRequest.fixmedins_code = YBHelper.fixmedins_code;
            jsRequest.fixmedins_name = YBHelper.fixmedins_name;
            jsRequest.sign_no = YBHelper.msgid;
            jsRequest.input = new RepModel<MZJS2207A>();

            MZJS2207A _mzjs = new MZJS2207A();
            _mzjs.psn_no = psn_no;
            _mzjs.mdtrt_cert_type = "02";
            _mzjs.mdtrt_cert_no = GuaHao.PatientVM.hic_no;
            _mzjs.med_type = 11; //门诊挂号
            _mzjs.medfee_sumamt = left_je;
            _mzjs.psn_setlway = "02"; //01 按项目结算 02 按定额结算
            _mzjs.mdtrt_id = mdtrt_id;
            _mzjs.chrg_bchno = ipt_otp_no;//收费批次号
            _mzjs.insutype = GuaHao.PatientVM.yb_insutype;
            _mzjs.acct_used_flag = "1";//0 否 1 是

            jsRequest.input.data = _mzjs;

            var json = WebApiHelper.SerializeObject(jsRequest);
            var BusinessID = "2207A";
            var Dataxml = json;
            var Outputxml = "";
            var parm = new object[] { BusinessID, json, Outputxml };

            //提交门诊挂号结算信息
            YBHelper.AddYBLog(BusinessID, json, SessionHelper.patientVM.patient_id, jsRequest.sign_no, jsRequest.infver, 0, SessionHelper.uservm.user_mi, jsRequest.inf_time);

            var result = ComHelper.InvokeMethod("yinhai.yh_hb_sctr", "yh_hb_call", ref parm);

            YBHelper.AddYBLog(BusinessID, parm[2].ToString(), SessionHelper.patientVM.patient_id, jsRequest.sign_no, jsRequest.infver, 1, SessionHelper.uservm.user_mi, jsRequest.inf_time);

            log.Debug("结算返回：" + parm[2].ToString());

            var _jsresp = WebApiHelper.DeserializeObject<YBResponse<MzjsResponse>>(parm[2].ToString());

            if (_jsresp != null && !string.IsNullOrEmpty(_jsresp.err_msg))
            {
                MessageBox.Show(_jsresp.err_msg);
                log.Error(_jsresp.err_msg);
            }
            else if (_jsresp.output != null)
            {
                //记录医保日志 
                var paramurl = string.Format($"/api/YbInfo/AddYB2207");
                _jsresp.output.patient_id = patient_id;
                _jsresp.output.admiss_times = admiss_times.ToString();
                HttpClientUtil.PostJSON(paramurl, _jsresp.output);

                mzjsResponse = _jsresp.output; 
                var setl_id = _jsresp.output.setlinfo.setl_id;
                log.Debug($"医保结算成功:patient_id:{patient_id},admiss_times:{admiss_times},setl_id:{setl_id}");

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
                _mzjscx.psn_no = _jsresp.output.setlinfo.psn_no;
                _mzjscx.setl_id = _jsresp.output.setlinfo.setl_id;//结算返回值 
                _mzjscx.mdtrt_id = _jsresp.output.setlinfo.mdtrt_id;

                jscxRequest.input.data = _mzjscx;

                json = WebApiHelper.SerializeObject(jscxRequest);
                BusinessID = "2208";
                Dataxml = json;
                Outputxml = "";
                parm = new object[] { BusinessID, json, Outputxml };


                YBHelper.AddYBLog(BusinessID, json, SessionHelper.patientVM.patient_id, jscxRequest.sign_no, jscxRequest.infver, 0, SessionHelper.uservm.user_mi, jscxRequest.inf_time);
                //提交
                result = ComHelper.InvokeMethod("yinhai.yh_hb_sctr", "yh_hb_call", ref parm);

                YBHelper.AddYBLog(BusinessID, parm[2].ToString(), SessionHelper.patientVM.patient_id, jscxRequest.sign_no, jscxRequest.infver, 1, SessionHelper.uservm.user_mi, jscxRequest.inf_time);

                log.Debug("结算撤销返回：" + parm[2]);

                var _jscxresp = WebApiHelper.DeserializeObject<YBResponse<RepModel<GHResponseModel>>>(parm[2].ToString());

                if (_jscxresp != null && !string.IsNullOrEmpty(_jscxresp.err_msg))
                {
                    MessageBox.Show(_jscxresp.err_msg);
                    log.Error(_jscxresp.err_msg);
                }
                else
                {
                    return;
                }
            } 
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void uiSymbolButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnYJS_Click(object sender, EventArgs e)
        {
            var paramurl = "";
            var _dt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            //提交门诊就诊信息 
            var jzxxRequest = new YBRequest<object>();
            jzxxRequest.infno = "2203";

            jzxxRequest.msgid = YBHelper.msgid;
            jzxxRequest.mdtrtarea_admvs = YBHelper.mdtrtarea_admvs;// "421099";// 
            jzxxRequest.insuplc_admdvs = SessionHelper.patientVM.yb_insuplc_admdvs.Trim();
            jzxxRequest.recer_sys_code = YBHelper.recer_sys_code;
            jzxxRequest.dev_no = "";
            jzxxRequest.dev_safe_info = "";
            jzxxRequest.cainfo = "";
            jzxxRequest.signtype = "";
            jzxxRequest.infver = YBHelper.infver;
            jzxxRequest.opter_type = YBHelper.opter_type;
            jzxxRequest.opter = SessionHelper.uservm.user_mi;
            jzxxRequest.opter_name = SessionHelper.uservm.name;
            jzxxRequest.inf_time = _dt;
            jzxxRequest.fixmedins_code = YBHelper.fixmedins_code;
            jzxxRequest.fixmedins_name = YBHelper.fixmedins_name;
            jzxxRequest.sign_no = YBHelper.msgid;
            jzxxRequest.input = new RepModel<object>();


            jzxxRequest.input.mdtrtinfo = new Mdtrtinfo();
            jzxxRequest.input.diseinfo = new List<Diseinfo>();

            jzxxRequest.input.mdtrtinfo.mdtrt_id = mdtrt_id;
            jzxxRequest.input.mdtrtinfo.psn_no = psn_no;
            jzxxRequest.input.mdtrtinfo.med_type = "11";
            jzxxRequest.input.mdtrtinfo.begntime = _dt;


            Diseinfo diseinfo = new Diseinfo();

            diseinfo.diag_type = "01";
            diseinfo.diag_srt_no = "1";
            diseinfo.diag_code = "R50.900";
            diseinfo.diag_name = "0";
            diseinfo.diag_dept = "0";
            diseinfo.dise_dor_no = "D421002005282";
            diseinfo.dise_dor_name = "11";
            diseinfo.diag_time = _dt;
            diseinfo.vali_flag = "1";

            diseinfo.patient_id = patient_id;
            diseinfo.admiss_times = admiss_times.ToString();

            jzxxRequest.input.diseinfo.Add(diseinfo);


            var json = WebApiHelper.SerializeObject(jzxxRequest);
            var BusinessID = "2203";
            var Dataxml = json;
            var Outputxml = "";
            var parm = new object[] { BusinessID, json, Outputxml };

            YBHelper.AddYBLog(BusinessID, json, SessionHelper.patientVM.patient_id, jzxxRequest.sign_no, jzxxRequest.infver, 0, SessionHelper.uservm.user_mi, jzxxRequest.inf_time);

            var result = ComHelper.InvokeMethod("yinhai.yh_hb_sctr", "yh_hb_call", ref parm);

            YBHelper.AddYBLog(BusinessID, parm[2].ToString(), SessionHelper.patientVM.patient_id, jzxxRequest.sign_no, jzxxRequest.infver, 1, SessionHelper.uservm.user_mi, jzxxRequest.inf_time);

            log.Debug("就诊系信息返回：" + parm[2]);

            var _jzxxresp = WebApiHelper.DeserializeObject<YBResponse<RepModel<GHResponseModel>>>(parm[2].ToString());

            if (_jzxxresp != null && !string.IsNullOrEmpty(_jzxxresp.err_msg))
            {
                MessageBox.Show(_jzxxresp.err_msg);
                log.Error(_jzxxresp.err_msg);
                return ;
            }
            else
            {
                //记录医保日志
                paramurl = string.Format($"/api/YbInfo/AddYB2203");

                JzxxUploadModel jzxxUploadModel = new JzxxUploadModel();
                jzxxUploadModel.patient_id = patient_id;
                jzxxUploadModel.admiss_times = admiss_times.ToString();
                jzxxUploadModel.mdtrtinfo = jzxxRequest.input.mdtrtinfo;
                jzxxUploadModel.diseinfo = jzxxRequest.input.diseinfo;

                HttpClientUtil.PostJSON(paramurl, jzxxUploadModel);
            }

            //提交门诊挂号明细信息 
            var mzmxRequest = new YBRequest<List<feedetail>>();
            mzmxRequest.infno = ((int)InfoNoEnum.门诊明细上传).ToString();

            mzmxRequest.msgid = YBHelper.msgid;
            mzmxRequest.mdtrtarea_admvs = YBHelper.mdtrtarea_admvs;// "421099";// 
            mzmxRequest.insuplc_admdvs = GuaHao.PatientVM.yb_insuplc_admdvs.Trim();
            mzmxRequest.recer_sys_code = YBHelper.recer_sys_code;
            mzmxRequest.dev_no = "";
            mzmxRequest.dev_safe_info = "";
            mzmxRequest.cainfo = "";
            mzmxRequest.signtype = "";
            mzmxRequest.infver = YBHelper.infver;
            mzmxRequest.opter_type = YBHelper.opter_type;
            mzmxRequest.opter = SessionHelper.uservm.user_mi;
            mzmxRequest.opter_name = SessionHelper.uservm.name;
            mzmxRequest.inf_time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            mzmxRequest.fixmedins_code = YBHelper.fixmedins_code;
            mzmxRequest.fixmedins_name = YBHelper.fixmedins_name;
            mzmxRequest.sign_no = YBHelper.msgid;
            mzmxRequest.input = new RepModel<List<feedetail>>();
            List<feedetail> feedetails = new List<feedetail>();
            int _index = 1;
            foreach (var item in chargeItems)
            {
                feedetail _detail = new feedetail();
                _detail.feedetl_sn = GuaHao.PatientVM.patient_id + "_" + GuaHao.PatientVM.max_ledger_sn + "_" + _index++;
                _detail.mdtrt_id = mdtrt_id;
                _detail.psn_no = psn_no;
                _detail.chrg_bchno = ipt_otp_no;
                _detail.rx_circ_flag = "0";
                _detail.fee_ocur_time = _dt;
                var ybbill = SessionHelper.ybhzCompare.Where(p => p.charge_code == item.charge_code).FirstOrDefault();
                if (ybbill != null)
                {
                    _detail.med_list_codg = ybbill.ybhz_code;
                }
                else
                {
                    MessageBox.Show("没有找到关联医保目录");
                }
                _detail.medins_list_codg = item.charge_code;
                _detail.det_item_fee_sumamt = item.charge_price;
                _detail.cnt = 1;
                _detail.pric = item.charge_price;
                _detail.bilg_dept_codg = ghRequest.unit_sn;
                _detail.bilg_dept_name = ghRequest.unit_name;
                _detail.bilg_dr_codg = ghRequest.yb_ys_code;
                _detail.bilg_dr_name = ghRequest.doctor_name;
                _detail.hosp_appr_flag = "1";

                feedetails.Add(_detail);
            }
            mzmxRequest.input.feedetail = feedetails;
            json = WebApiHelper.SerializeObject(mzmxRequest);
            BusinessID = ((int)InfoNoEnum.门诊明细上传).ToString();
            Dataxml = json;
            Outputxml = "";
            parm = new object[] { BusinessID, json, Outputxml };

            YBHelper.AddYBLog(BusinessID, json, SessionHelper.patientVM.patient_id, jzxxRequest.sign_no, jzxxRequest.infver, 0, SessionHelper.uservm.user_mi, jzxxRequest.inf_time);

            result = ComHelper.InvokeMethod("yinhai.yh_hb_sctr", "yh_hb_call", ref parm);

            YBHelper.AddYBLog(BusinessID, parm[2].ToString(), SessionHelper.patientVM.patient_id, jzxxRequest.sign_no, jzxxRequest.infver, 1, SessionHelper.uservm.user_mi, jzxxRequest.inf_time);

            log.Debug("明细提交返回：" + parm[2]);

            var _mxresp = WebApiHelper.DeserializeObject<YBResponse<Repsonse2204<List<JzxxResponse>>>>(parm[2].ToString());
            if (_mxresp != null && !string.IsNullOrEmpty(_mxresp.err_msg))
            {
                MessageBox.Show(_mxresp.err_msg);
                log.Error(_mxresp.err_msg);
                return ;
            }
            else
            {
                //记录医保日志
                paramurl = string.Format($"/api/YbInfo/AddYB2204");
                JzmxUploadModel jzmxUploadModel = new JzmxUploadModel();
                jzmxUploadModel.patient_id = patient_id;
                jzmxUploadModel.admiss_times = admiss_times.ToString();
                jzmxUploadModel.diseinfo = _mxresp.output.result;
                HttpClientUtil.PostJSON(paramurl, jzmxUploadModel);
            }


            //预结算
            var yjsRequest = new YBRequest<MZJS2207A>();
            yjsRequest.infno = ((int)InfoNoEnum.预结算).ToString();

            yjsRequest.msgid = YBHelper.msgid;
            yjsRequest.mdtrtarea_admvs = YBHelper.mdtrtarea_admvs;// "421099";// 
            yjsRequest.insuplc_admdvs = GuaHao.PatientVM.yb_insuplc_admdvs.Trim();
            yjsRequest.recer_sys_code = YBHelper.recer_sys_code;
            yjsRequest.dev_no = "";
            yjsRequest.dev_safe_info = "";
            yjsRequest.cainfo = "";
            yjsRequest.signtype = "";
            yjsRequest.infver = YBHelper.infver;
            yjsRequest.opter_type = YBHelper.opter_type;
            yjsRequest.opter = SessionHelper.uservm.user_mi;
            yjsRequest.opter_name = SessionHelper.uservm.name;
            yjsRequest.inf_time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            yjsRequest.fixmedins_code = YBHelper.fixmedins_code;
            yjsRequest.fixmedins_name = YBHelper.fixmedins_name;
            yjsRequest.sign_no = YBHelper.msgid;
            yjsRequest.input = new RepModel<MZJS2207A>();
            // mzmxRequest = new RepModel<List<feedetail>>();

            MZJS2207A _mzyjs = new MZJS2207A();
            _mzyjs.psn_no = psn_no;
            _mzyjs.mdtrt_cert_type = "02";
            _mzyjs.mdtrt_cert_no = GuaHao.PatientVM.hic_no;
            _mzyjs.med_type = 11; //门诊挂号 门诊挂号不能结算 11为普通门诊
            _mzyjs.medfee_sumamt = left_je;
            _mzyjs.psn_setlway = "01"; //01 按项目结算 02 按定额结算
            _mzyjs.mdtrt_id = mdtrt_id;
            _mzyjs.chrg_bchno = ipt_otp_no;//收费批次号
            _mzyjs.insutype = GuaHao.PatientVM.yb_insutype;
            _mzyjs.acct_used_flag = "1";//0 否 1 是

            yjsRequest.input.data = _mzyjs;
            json = WebApiHelper.SerializeObject(yjsRequest);
            BusinessID = "2206";//预结算
            Dataxml = json;
            Outputxml = "";
            parm = new object[] { BusinessID, json, Outputxml };

            YBHelper.AddYBLog(BusinessID, json, SessionHelper.patientVM.patient_id, jzxxRequest.sign_no, jzxxRequest.infver, 0, SessionHelper.uservm.user_mi, jzxxRequest.inf_time);

            result = ComHelper.InvokeMethod("yinhai.yh_hb_sctr", "yh_hb_call", ref parm);

            YBHelper.AddYBLog(BusinessID, parm[2].ToString(), SessionHelper.patientVM.patient_id, jzxxRequest.sign_no, jzxxRequest.infver, 1, SessionHelper.uservm.user_mi, jzxxRequest.inf_time);

            log.Debug("预结算返回：" + parm[2]);

            var _yjsresp = WebApiHelper.DeserializeObject<YBResponse<MzjsResponse>>(parm[2].ToString());

            if (_yjsresp != null && !string.IsNullOrEmpty(_yjsresp.err_msg))
            {
                MessageBox.Show(_yjsresp.err_msg);
                log.Error(_yjsresp.err_msg);
                return ;
            }
            else
            {
                ////记录医保日志 预结算不写表
                //paramurl = string.Format($"/api/YbInfo/AddYB2207");
                //_yjsresp.output.patient_id = patient_id;
                //_yjsresp.output.admiss_times = admiss_times; 
                //HttpClientUtil.PostJSON(paramurl, _yjsresp.output);
            }


        }
    }
}
