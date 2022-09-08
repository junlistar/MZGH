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
using System.Linq;

namespace Client.Forms.Wedgit
{
    public partial class YBJSPreview : UIForm
    {
        private static ILog log = LogManager.GetLogger(typeof(YBJSPreview));//typeof放当前类
        public YBJSPreview()
        {
            InitializeComponent();
        }

        public List<ChargeItemVM> chargeItems;

        public GHRequestVM ghRequest;

        public string patient_id;
        public int admiss_times;

        public string mdtrt_id;
        public string psn_no;
        public string ipt_otp_no;

        public decimal left_je;


        UIDataGridView dgv = new UIDataGridView();
        UIDataGridView dgvys = new UIDataGridView();

        public List<UserDicVM> doctList;
        public List<UnitVM> unitList;


        private void YBJSPreview_Load(object sender, EventArgs e)
        {
            YBHelper.mzjsResponse = new MzjsResponse();

            dgvys.KeyDown += Dgvys_KeyDown;

            dgv.CellClick += dgvks_CellContentClick;
            dgv.KeyDown += dgvks_KeyDown;

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
            if (SessionHelper.birctrlTypes != null)
            {
                var _birctrlTypes = SessionHelper.birctrlTypes;
                var _birItem = new BirctrlTypeVM();
                _birItem.code = "";
                _birItem.name = ""; 
                _birctrlTypes.Insert(0, _birItem);
                birctrl_type.DataSource = _birctrlTypes;
                birctrl_type.ValueMember = "code";
                birctrl_type.DisplayMember = "name";
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

                var json = HttpClientUtil.Get(paramurl);

                var result = WebApiHelper.DeserializeObject<ResponseResult<UserInfoResponseModel>>(json);

                if (result.status == 1)
                {
                    if (result.data != null && result.data.baseinfo != null)
                    {
                        txt_psn_no.Text = result.data.baseinfo.psn_no;
                        psn_name.Text = result.data.baseinfo.psn_name;
                        gend.Text = result.data.baseinfo.gend == "1" ? "男" : "女";
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

                    if (result.data != null && result.data.idetinfo != null)
                    {
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

                #region 绑定医生科室信息

                txtDoct.TextChanged -= txtDoct_TextChanged;
                txtks.TextChanged -= txtks_TextChanged;

                if (ghRequest != null)
                {
                    var _doct = doctList.Where(p => p.code == ghRequest.doctor_sn).FirstOrDefault();

                    if (_doct != null)
                    {
                        txtDoct.TagString = _doct.yb_ys_code;
                        txtDoct.Text = _doct.name;
                    }

                    var _dept = unitList.Where(p => p.unit_sn == ghRequest.unit_sn).FirstOrDefault();
                    if (_dept != null)
                    {
                        txtks.TagString = _dept.code;
                        txtks.Text = _dept.name;
                        caty_code.Text = _dept.yb_ks_code;
                        caty_name.Text = _dept.yb_ks_name;
                    }
                }
                else
                {
                    var _dept = unitList.Where(p => p.unit_sn == SessionHelper.uservm.dept_sn).FirstOrDefault();
                    var _doct = doctList.Where(p => p.code == SessionHelper.uservm.user_mi).FirstOrDefault();
                    if (_dept != null)
                    {
                        txtks.Text = _dept.name;
                        txtks.TagString = _dept.unit_sn;
                        caty_code.Text = _dept.yb_ks_code;
                        caty_name.Text = _dept.yb_ks_name;
                    }

                    if (_doct != null)
                    {
                        txtDoct.TagString = _doct.yb_ys_code;
                        txtDoct.Text = _doct.name;
                    }
                }

                txtDoct.TextChanged += txtDoct_TextChanged;
                txtks.TextChanged += txtks_TextChanged;

                #endregion

                #region 绑定诊断信息

                if (ghRequest != null)
                {
                    SessionHelper.diseinfoList = new List<Diseinfo>();
                    Diseinfo diseinfo = new Diseinfo();
                    diseinfo.vali_flag = "1";
                    if (!string.IsNullOrEmpty(ghRequest.icd_code))
                    {
                        var _icdmodel = SessionHelper.icdCodes.Where(p => p.code == ghRequest.icd_code).FirstOrDefault();
                        if (_icdmodel != null)
                        {
                            diseinfo.diag_code = _icdmodel.yb_code;
                            diseinfo.diag_name = _icdmodel.yb_name;
                            diseinfo.diag_type = SessionHelper.diagTypes[0].code;
                            diseinfo.diag_type_name = SessionHelper.diagTypes[0].name;
                            diseinfo.vali_flag = "1";
                            SessionHelper.diseinfoList.Add(diseinfo);
                        }
                        LoadIcdData();
                    }

                }

                #endregion


            }

            //dise_dor_no.DataSource = SessionHelper.userDics.Where(p => p.yb_ys_code != "").ToList();
            //dise_dor_no.ValueMember = "code";
            //dise_dor_no.DisplayMember = "name";

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
            try
            {

                //门诊结算
                var jsRequest = new YBRequest<MZJS2207A>();
                jsRequest.infno = "2207A";

                jsRequest.msgid = YBHelper.msgid;
                jsRequest.mdtrtarea_admvs = YBHelper.mdtrtarea_admvs;// "421099";// 
                jsRequest.insuplc_admdvs = SessionHelper.patientVM.yb_insuplc_admdvs.Trim();
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

                MZJS2207A _mzyjs = new MZJS2207A();
                _mzyjs.psn_no = psn_no;
                _mzyjs.mdtrt_cert_type = mdtrt_cert_type.SelectedValue.ToString(); //"02";
                _mzyjs.mdtrt_cert_no = mdtrt_cert_no.Text;//GuaHao.PatientVM.hic_no;
                _mzyjs.med_type = Convert.ToInt32(med_type.SelectedValue);//11; //门诊挂号 门诊挂号不能结算 11为普通门诊
                _mzyjs.medfee_sumamt = left_je;
                _mzyjs.psn_setlway = psn_setlway.SelectedValue.ToString(); //"01"; //01 按项目结算 02 按定额结算
                _mzyjs.mdtrt_id = mdtrt_id;
                _mzyjs.chrg_bchno = ipt_otp_no;//收费批次号
                _mzyjs.insutype = jz_insutype.SelectedValue.ToString(); //GuaHao.PatientVM.yb_insutype;
                _mzyjs.acct_used_flag = chkuse_flag.Checked ? "1" : "0";//0 否 1 是

                jsRequest.input.data = _mzyjs;

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
                    return;
                }
                else if (_jsresp.output != null)
                {
                    //记录医保日志 
                    var paramurl = string.Format($"/api/YbInfo/AddYB2207");
                    _jsresp.output.patient_id = patient_id;
                    _jsresp.output.admiss_times = admiss_times.ToString();
                    HttpClientUtil.PostJSON(paramurl, _jsresp.output);

                    YBHelper.mzjsResponse = _jsresp.output;
                    var setl_id = _jsresp.output.setlinfo.setl_id;
                    log.Debug($"医保结算成功:patient_id:{patient_id},admiss_times:{admiss_times},setl_id:{setl_id}");

                    ////门诊结算撤销
                    //var jscxRequest = new YBRequest<MZJSCX>();
                    //jscxRequest.infno = "2208";

                    //jscxRequest.msgid = YBHelper.msgid;
                    //jscxRequest.mdtrtarea_admvs = YBHelper.mdtrtarea_admvs;// "421099";// 
                    //jscxRequest.insuplc_admdvs = SessionHelper.patientVM.yb_insuplc_admdvs.Trim();
                    //jscxRequest.recer_sys_code = YBHelper.recer_sys_code;
                    //jscxRequest.dev_no = "";
                    //jscxRequest.dev_safe_info = "";
                    //jscxRequest.cainfo = "";
                    //jscxRequest.signtype = "";
                    //jscxRequest.infver = YBHelper.infver;
                    //jscxRequest.opter_type = YBHelper.opter_type;
                    //jscxRequest.opter = SessionHelper.uservm.user_mi;
                    //jscxRequest.opter_name = SessionHelper.uservm.name;
                    //jscxRequest.inf_time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    //jscxRequest.fixmedins_code = YBHelper.fixmedins_code;
                    //jscxRequest.fixmedins_name = YBHelper.fixmedins_name;
                    //jscxRequest.sign_no = YBHelper.msgid;
                    //jscxRequest.input = new RepModel<MZJSCX>();

                    //MZJSCX _mzjscx = new MZJSCX();
                    //_mzjscx.psn_no = _jsresp.output.setlinfo.psn_no;
                    //_mzjscx.setl_id = _jsresp.output.setlinfo.setl_id;//结算返回值 
                    //_mzjscx.mdtrt_id = _jsresp.output.setlinfo.mdtrt_id;

                    //jscxRequest.input.data = _mzjscx;

                    //json = WebApiHelper.SerializeObject(jscxRequest);
                    //BusinessID = "2208";
                    //Dataxml = json;
                    //Outputxml = "";
                    //parm = new object[] { BusinessID, json, Outputxml };


                    //YBHelper.AddYBLog(BusinessID, json, SessionHelper.patientVM.patient_id, jscxRequest.sign_no, jscxRequest.infver, 0, SessionHelper.uservm.user_mi, jscxRequest.inf_time);
                    ////提交
                    //result = ComHelper.InvokeMethod("yinhai.yh_hb_sctr", "yh_hb_call", ref parm);

                    //YBHelper.AddYBLog(BusinessID, parm[2].ToString(), SessionHelper.patientVM.patient_id, jscxRequest.sign_no, jscxRequest.infver, 1, SessionHelper.uservm.user_mi, jscxRequest.inf_time);

                    //log.Debug("结算撤销返回：" + parm[2]);

                    //var _jscxresp = WebApiHelper.DeserializeObject<YBResponse<RepModel<GHResponseModel>>>(parm[2].ToString());

                    //if (_jscxresp != null && !string.IsNullOrEmpty(_jscxresp.err_msg))
                    //{
                    //    MessageBox.Show(_jscxresp.err_msg);
                    //    log.Error(_jscxresp.err_msg);
                    //    return;
                    //}
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                UIMessageBox.ShowError(ex.Message);
                log.Error(ex.ToString());
            }
        }

        private void uiSymbolButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnYJS_Click(object sender, EventArgs e)
        {
            //判断医生医保编号是否正确
            if (string.IsNullOrEmpty(txtDoct.TagString))
            {
                UIMessageBox.ShowError("医生医保编号为空，请选择正确的医生");
                return;
            }

            //判断是否有诊断信息
            if (SessionHelper.diseinfoList == null || SessionHelper.diseinfoList.Count == 0)
            {
                UIMessageBox.ShowError("诊断信息为空！");
                return;
            }

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
            jzxxRequest.input.mdtrtinfo.med_type = med_type.SelectedValue.ToString(); //"11";
            jzxxRequest.input.mdtrtinfo.begntime = _dt;
            //门诊慢病处理
            //病种编码
            if (birctrl_type.Text!="")
            { 
                jzxxRequest.input.mdtrtinfo.birctrl_type = birctrl_type.SelectedValue.ToString();
                jzxxRequest.input.mdtrtinfo.birctrl_matn_date = birctrl_type.SelectedText;
            }

            if (cbx_mzmb.Text!="")
            {
                jzxxRequest.input.mdtrtinfo.dise_codg = cbx_mzmb.SelectedValue.ToString();
                jzxxRequest.input.mdtrtinfo.dise_name = cbx_mzmb.SelectedText;
            }


            //Diseinfo diseinfo = new Diseinfo();

            //diseinfo.diag_type = "01";
            //diseinfo.diag_srt_no = "1";
            //diseinfo.diag_code = "R50.900";
            //diseinfo.diag_name = "0";
            //diseinfo.diag_dept = "0";
            //diseinfo.dise_dor_no = "D421002005282";
            //diseinfo.dise_dor_name = "11";
            //diseinfo.diag_time = _dt;
            //diseinfo.vali_flag = "1";

            if (SessionHelper.diseinfoList != null)
            {
                int _idx = 1;
                foreach (var item in SessionHelper.diseinfoList)
                {
                    item.patient_id = patient_id;
                    item.admiss_times = admiss_times.ToString();
                    item.diag_time = _dt;
                    item.diag_srt_no = _idx++.ToString();
                    jzxxRequest.input.diseinfo.Add(item);
                }
            }

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
                return;
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
            mzmxRequest.insuplc_admdvs = SessionHelper.patientVM.yb_insuplc_admdvs.Trim();
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
            if (chargeItems != null)
            {
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
                    _detail.bilg_dept_codg = txtks.TagString; //ghRequest.unit_sn;
                    _detail.bilg_dept_name = txtks.Text; //ghRequest.unit_name;
                    _detail.bilg_dr_codg = txtDoct.TagString;//ghRequest.yb_ys_code;
                    _detail.bilg_dr_name = txtDoct.Text; //ghRequest.doctor_name;
                    _detail.hosp_appr_flag = "1";

                    feedetails.Add(_detail);
                }
            }
            else if (SessionHelper.cprCharges != null)
            {
                foreach (var item in SessionHelper.cprCharges)
                {
                    feedetail _detail = new feedetail();
                    _detail.feedetl_sn = SessionHelper.patientVM.patient_id + "_" + SessionHelper.patientVM.max_ledger_sn + "_" + _index++;
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
                    _detail.cnt = item.charge_amount;
                    _detail.pric = item.orig_price;
                    _detail.bilg_dept_codg = txtks.TagString; //SessionHelper.uservm.dept_sn;
                    _detail.bilg_dept_name = txtks.Text; // SessionHelper.uservm.name;
                    _detail.bilg_dr_codg = txtDoct.TagString;// "D421002005282";
                    _detail.bilg_dr_name = txtDoct.Text; //SessionHelper.uservm.name;
                    _detail.hosp_appr_flag = "1";

                    feedetails.Add(_detail);
                }
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
                return;
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
            yjsRequest.insuplc_admdvs = SessionHelper.patientVM.yb_insuplc_admdvs.Trim();
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
            _mzyjs.mdtrt_cert_type = mdtrt_cert_type.SelectedValue.ToString(); //"02";
            _mzyjs.mdtrt_cert_no = mdtrt_cert_no.Text;//GuaHao.PatientVM.hic_no;
            _mzyjs.med_type = Convert.ToInt32(med_type.SelectedValue);//11; //门诊挂号 门诊挂号不能结算 11为普通门诊
            _mzyjs.medfee_sumamt = left_je;
            _mzyjs.psn_setlway = psn_setlway.SelectedValue.ToString(); //"01"; //01 按项目结算 02 按定额结算
            _mzyjs.mdtrt_id = mdtrt_id;
            _mzyjs.chrg_bchno = ipt_otp_no;//收费批次号
            _mzyjs.insutype = jz_insutype.SelectedValue.ToString(); //GuaHao.PatientVM.yb_insutype;
            _mzyjs.acct_used_flag = chkuse_flag.Checked ? "1" : "0";//0 否 1 是

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
                return;
            }
            else
            {
                ////记录医保日志 预结算不写表
                //paramurl = string.Format($"/api/YbInfo/AddYB2207");
                //_yjsresp.output.patient_id = patient_id;
                //_yjsresp.output.admiss_times = admiss_times; 
                //HttpClientUtil.PostJSON(paramurl, _yjsresp.output);

                //填入数据
                medfee_sumamt.Text = _yjsresp.output.setlinfo.medfee_sumamt;
                fulamt_ownpay_amt.Text = _yjsresp.output.setlinfo.fulamt_ownpay_amt;
                act_pay_dedc.Text = _yjsresp.output.setlinfo.act_pay_dedc;
                hifp_pay.Text = _yjsresp.output.setlinfo.hifp_pay;
                cvlserv_pay.Text = _yjsresp.output.setlinfo.cvlserv_pay;
                hifes_pay.Text = _yjsresp.output.setlinfo.hifes_pay;
                hifmi_pay.Text = _yjsresp.output.setlinfo.hifmi_pay;
                hifob_pay.Text = _yjsresp.output.setlinfo.hifob_pay;
                maf_pay.Text = _yjsresp.output.setlinfo.maf_pay;
                oth_pay.Text = _yjsresp.output.setlinfo.oth_pay;
                fund_pay_sumamt.Text = _yjsresp.output.setlinfo.fund_pay_sumamt;
                psn_part_amt.Text = _yjsresp.output.setlinfo.psn_part_amt;
                acct_pay.Text = _yjsresp.output.setlinfo.acct_pay;
                psn_cash_pay.Text = _yjsresp.output.setlinfo.psn_cash_pay;
                hosp_part_amt.Text = _yjsresp.output.setlinfo.hosp_part_amt;
                jsxx_balc.Text = _yjsresp.output.setlinfo.balc;

                btnYJS.Enabled = false;
                btnJieSuan.Enabled = true;
            }
        }

        private void txtDoct_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Down)
                {
                    this.dgvys.Focus();
                }
                else if (e.KeyCode == Keys.Enter)
                {
                    if (dgvys.Rows.Count > 0)
                    {

                        var unit_sn = dgvys.Rows[0].Cells["code"].Value.ToString();
                        var name = dgvys.Rows[0].Cells["name"].Value.ToString();

                        txtDoct.TextChanged -= txtDoct_TextChanged;
                        txtDoct.Text = name;
                        txtDoct.TagString = unit_sn;
                        txtDoct.TextChanged += txtDoct_TextChanged;

                        dgvys.Hide();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                log.Error(ex.ToString());
            }
        }

        private void txtDoct_Leave(object sender, EventArgs e)
        {
            if (!dgvys.Focused)
            {
                dgvys.Hide();
            }
        }

        private void txtDoct_TextChanged(object sender, EventArgs e)
        {
            try
            {

                if (txtDoct.Text == "")
                {
                    return;
                }

                //查询信息 显示到girdview
                var tb = sender as UITextBox;
                var pbl = tb.Parent as UIPanel;
                //获取数据 

                if (doctList != null && doctList.Count > 0)
                {
                    var ipt = txtDoct.Text.Trim();

                    dgvys.Parent = this;
                    dgvys.Top = pbl.Top + tb.Top + tb.Height;
                    dgvys.Left = pbl.Left + tb.Left;
                    dgvys.Width = tb.Width;
                    dgvys.Height = 200;
                    dgvys.BringToFront();
                    dgvys.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dgvys.RowHeadersVisible = false;
                    dgvys.BackgroundColor = Color.White;
                    dgvys.ReadOnly = true;


                    List<UserDicVM> vm = doctList;

                    if (!string.IsNullOrWhiteSpace(ipt))
                    {
                        vm = vm.Where(p => p.py_code.StartsWith(ipt.ToUpper())).ToList();
                    }
                    dgvys.DataSource = vm;

                    dgvys.Columns["code"].HeaderText = "编号";
                    dgvys.Columns["name"].HeaderText = "名称";
                    dgvys.Columns["py_code"].Visible = false;
                    dgvys.Columns["d_code"].Visible = false;
                    dgvys.Columns["emp_sn"].Visible = false;
                    dgvys.Columns["yb_ys_code"].Visible = false;
                    dgvys.AutoResizeColumns();

                    dgvys.CellClick -= dgvys_CellContentClick;
                    dgvys.CellClick += dgvys_CellContentClick;
                    dgvys.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                log.Error(ex.ToString());
            }
        }
        private void dgvys_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex == -1)
                {
                    return;
                }
                var obj = sender as UIDataGridView;
                var code = obj.Rows[e.RowIndex].Cells["code"].Value.ToString();
                var name = obj.Rows[e.RowIndex].Cells["name"].Value.ToString();
                txtDoct.TextChanged -= txtDoct_TextChanged;
                txtDoct.Text = name;

                var _ybinfo = doctList.Where(p => p.code == code).FirstOrDefault();
                if (_ybinfo != null)
                {
                    txtDoct.TagString = _ybinfo.yb_ys_code;
                }
                else
                {
                    txtDoct.TagString = "";
                }

                txtDoct.TextChanged += txtDoct_TextChanged;

                dgvys.Hide();

                //更新诊断医生信息
                LoadIcdData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                log.Error(ex.ToString());
            }
        }
        private void Dgvys_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (dgvys.SelectedIndex != -1)
                {

                    var ev = new DataGridViewCellEventArgs(0, dgvys.SelectedIndex);

                    dgvys_CellContentClick(sender, ev);
                }
            }
        }

        private void txtks_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                //MessageBox.Show(e.KeyCode.ToString());
                if (e.KeyCode == Keys.Down)
                {
                    this.dgv.Focus();
                }
                else if (e.KeyCode == Keys.Enter)
                {
                    if (dgv.Rows.Count > 0)
                    {

                        var unit_sn = dgv.Rows[0].Cells["unit_sn"].Value.ToString();
                        var name = dgv.Rows[0].Cells["name"].Value.ToString();

                        txtks.TextChanged -= txtks_TextChanged;
                        txtks.Text = name;
                        txtks.TagString = unit_sn;
                        txtks.TextChanged += txtks_TextChanged;

                        dgv.Hide();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                log.Error(ex.ToString());
            }
        }

        private void dgvks_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (dgv.SelectedIndex != -1)
                {

                    var ev = new DataGridViewCellEventArgs(0, dgv.SelectedIndex);

                    dgvks_CellContentClick(sender, ev);
                }
            }

        }
        private void txtks_Leave(object sender, EventArgs e)
        {
            if (!dgv.Focused)
            {
                dgv.Hide();
            }

        }
        private void txtks_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //查询科室信息 显示到girdview
                var tb = sender as UITextBox;
                var pbl = tb.Parent as UIPanel;
                //获取数据 

                if (unitList != null && unitList.Count > 0)
                {
                    var ipt = txtks.Text.Trim();

                    dgv.Parent = this;
                    dgv.Top = pbl.Top + tb.Top + tb.Height;
                    dgv.Left = pbl.Left + tb.Left;
                    dgv.Width = tb.Width;
                    dgv.Height = 200;
                    dgv.BringToFront();
                    dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dgv.RowHeadersVisible = false;
                    dgv.BackgroundColor = Color.White;
                    dgv.ReadOnly = true;


                    List<UnitVM> vm = unitList;

                    if (!string.IsNullOrWhiteSpace(ipt))
                    {
                        vm = vm.Where(p => p.py_code.StartsWith(ipt.ToUpper())).ToList();
                    }
                    dgv.DataSource = vm;

                    dgv.Columns["code"].HeaderText = "编号";
                    dgv.Columns["name"].HeaderText = "名称";
                    dgv.Columns["py_code"].Visible = false;
                    dgv.Columns["d_code"].Visible = false;
                    dgv.Columns["unit_sn"].Visible = false;
                    dgv.AutoResizeColumns();

                    dgv.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                log.Error(ex.ToString());
            }
        }

        private void dgvks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex == -1)
                {
                    return;
                }
                var obj = sender as UIDataGridView;
                var unit_sn = obj.Rows[e.RowIndex].Cells["unit_sn"].Value.ToString();
                var name = obj.Rows[e.RowIndex].Cells["name"].Value.ToString();
                txtks.TextChanged -= txtks_TextChanged;
                txtks.Text = name;
                txtks.TagString = unit_sn;
                txtks.TextChanged += txtks_TextChanged;

                var _ybksInfo = SessionHelper.units.Where(p => p.code == unit_sn).FirstOrDefault();
                caty_code.Text = _ybksInfo.yb_ks_code;
                caty_name.Text = _ybksInfo.yb_ks_name;

                dgv.Hide();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                log.Error(ex.ToString());
            }
        }

        private void btnAddzd_Click(object sender, EventArgs e)
        {
            var _ys_ybcode = txtDoct.TagString;
            if (string.IsNullOrEmpty(_ys_ybcode))
            {
                UIMessageBox.Show("医生医保编号为空，请选择正确的医生");
                return;
            }

            AddZhenduan addZhenduan = new AddZhenduan();
            if (addZhenduan.ShowDialog() == DialogResult.OK)
            {
                LoadIcdData();
            }
        }

        private void btnDelZd_Click(object sender, EventArgs e)
        {
            var _index = dgvjzxx.SelectedIndex;
            var _diag_code = dgvjzxx.Rows[_index].Cells["diag_code"].Value;
            if (_diag_code != null)
            {
                foreach (var item in SessionHelper.diseinfoList.ToArray())
                {
                    SessionHelper.diseinfoList.Remove(item);
                }
                LoadIcdData();
            }
        }

        public void LoadIcdData()
        {
            //更新数据表
            if (SessionHelper.diseinfoList != null)
            {
                foreach (var item in SessionHelper.diseinfoList)
                {
                    item.dise_dor_no = txtDoct.TagString;
                    item.dise_dor_name = txtDoct.Text;
                    item.diag_dept = txtks.TagString;
                }

                var _dat = SessionHelper.diseinfoList.Select(p => new
                {
                    diag_type_name = p.diag_type_name,
                    diag_code = p.diag_code,
                    diag_name = p.diag_name,
                    diag_dept = p.diag_dept,
                    dise_dor_no = p.dise_dor_no,
                    dise_dor_name = p.dise_dor_name,
                    vali_flag = p.vali_flag == "1" ? "有效" : ""
                }).ToList();
                dgvjzxx.DataSource = _dat;
            }
        }
        /// <summary>
        /// 获取慢病
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoadMb_Click(object sender, EventArgs e)
        {
            try
            {

                //【5301】人员慢特病备案查询
                var jsRequest = new YBRequest<Request5301>();
                jsRequest.infno = "5301";

                jsRequest.msgid = YBHelper.msgid;
                jsRequest.mdtrtarea_admvs = YBHelper.mdtrtarea_admvs;// "421099";// 
                jsRequest.insuplc_admdvs = SessionHelper.patientVM.yb_insuplc_admdvs.Trim();
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
                jsRequest.input = new RepModel<Request5301>();

                jsRequest.input.data = new Request5301();
                jsRequest.input.data.psn_no = psn_no;

                var json = WebApiHelper.SerializeObject(jsRequest);
                var BusinessID = "5301";
                var Dataxml = json;
                var Outputxml = "";
                var parm = new object[] { BusinessID, json, Outputxml };

                //提交门诊挂号结算信息
                YBHelper.AddYBLog(BusinessID, json, SessionHelper.patientVM.patient_id, jsRequest.sign_no, jsRequest.infver, 0, SessionHelper.uservm.user_mi, jsRequest.inf_time);

                var result = ComHelper.InvokeMethod("yinhai.yh_hb_sctr", "yh_hb_call", ref parm);

                YBHelper.AddYBLog(BusinessID, parm[2].ToString(), SessionHelper.patientVM.patient_id, jsRequest.sign_no, jsRequest.infver, 1, SessionHelper.uservm.user_mi, jsRequest.inf_time);

                log.Debug("结算返回：" + parm[2].ToString());

                var _jsresp = WebApiHelper.DeserializeObject<YBResponse<Response5301>>(parm[2].ToString());

                //绑定下拉框
                if (_jsresp.output.feedetail!=null)
                {
                    var _mblist = _jsresp.output.feedetail;
                    var _mbItem = new Response5301Feedetail();
                    _mbItem.opsp_dise_code = "";
                    _mbItem.opsp_dise_name = "";
                    _mblist.Insert(0, _mbItem);

                    cbx_mzmb.DataSource = _mblist;
                    cbx_mzmb.DisplayMember = "opsp_dise_code";
                    cbx_mzmb.ValueMember = "opsp_dise_name";
                }
                else
                {
                    UIMessageBox.Show("没有查询到慢病数据");
                }

            }
            catch (Exception ex)
            {
                UIMessageBox.Show(ex.Message);
                log.Error(ex.ToString());
            }
        }

        private void lnkSetEmptyDate_Click(object sender, EventArgs e)
        {
            birctrl_matn_date.Text = "";
        }
    }
}
