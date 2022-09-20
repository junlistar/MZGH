using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sunny.UI;
using YbjsLib.Model;

namespace YbjsLib
{
    public partial class YBJSPreview : UIForm
    {
        public YBJSPreview()
        {
            InitializeComponent();
        }
        public string patient_id;
        public int admiss_times;
        public string insuplcAdmdvs;

        public string icd_code;
        public string dept_sn;
        public string doct_sn;
        public string opter;
        public string opter_name;

        public string mdtrt_id;
        public string psn_no;
        public string ipt_otp_no;

        public decimal left_je;


        UIDataGridView dgv = new UIDataGridView();
        UIDataGridView dgvys = new UIDataGridView();


        MzjsResponse mzjsResponse;
        MzjsResponse yjsResponse;


        //数据
        string json_2207;


        private void YBJSPreview_Load(object sender, EventArgs e)
        {
            try
            {

                mzjsResponse = new MzjsResponse();

                dgvys.KeyDown += Dgvys_KeyDown;

                dgv.CellClick += dgvks_CellContentClick;
                dgv.KeyDown += dgvks_KeyDown;

                //加载下拉框字典数据
                if (YBHelper.insutypes != null)
                {
                    var _list = YBHelper.insutypes;
                    jz_insutype.DataSource = _list;
                    jz_insutype.ValueMember = "code";
                    jz_insutype.DisplayMember = "name";
                }
                if (YBHelper.mdtrtCertTypes != null)
                {
                    var _list = YBHelper.mdtrtCertTypes;
                    mdtrt_cert_type.DataSource = _list;
                    mdtrt_cert_type.ValueMember = "code";
                    mdtrt_cert_type.DisplayMember = "name";
                }
                if (YBHelper.medTypes != null)
                {
                    var _list = YBHelper.medTypes;
                    med_type.DataSource = _list;
                    med_type.ValueMember = "code";
                    med_type.DisplayMember = "name";
                }
                if (YBHelper.birctrlTypes != null)
                {
                    var _list = YBHelper.birctrlTypes;
                    var _birctrlTypes = _list;
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

                if (YBHelper.userInfoResponseModel != null && YBHelper.userInfoResponseModel.baseinfo != null)
                {
                    txt_psn_no.Text = YBHelper.userInfoResponseModel.baseinfo.psn_no;
                    psn_name.Text = YBHelper.userInfoResponseModel.baseinfo.psn_name;
                    gend.Text = YBHelper.userInfoResponseModel.baseinfo.gend == "1" ? "男" : "女";
                    brdy.Text = YBHelper.userInfoResponseModel.baseinfo.brdy;


                    mdtrt_cert_type.SelectedValue = YBHelper.userInfoResponseModel.baseinfo.psn_cert_type;
                    mdtrt_cert_no.Text = YBHelper.userInfoResponseModel.baseinfo.certno;
                }
                if (YBHelper.userInfoResponseModel != null && YBHelper.userInfoResponseModel.insuinfo != null)
                {
                    dgv_cbxx.Init();
                    dgv_cbxx.AutoGenerateColumns = false;
                    dgv_cbxx.DataSource = YBHelper.userInfoResponseModel.insuinfo;

                    lbl_insplcadmdvs.Text = YBHelper.userInfoResponseModel.insuinfo[0].insuplc_admdvs;
                    jz_insutype.SelectedValue = YBHelper.userInfoResponseModel.insuinfo[0].insutype;
                }

                if (YBHelper.userInfoResponseModel != null && YBHelper.userInfoResponseModel.idetinfo != null)
                {
                    foreach (var item in YBHelper.userInfoResponseModel.idetinfo)
                    {
                        lst_ident.Items.Add(item.psn_idet_type + "  " + item.psn_type_lv + "    " + item.begntime + "    " + item.endtime + "   " + item.memo);
                    }
                }


                #region 绑定医生科室信息

                txtDoct.TextChanged -= txtDoct_TextChanged;
                txtks.TextChanged -= txtks_TextChanged;


                if (YBHelper.jiuzhenInfo != null)
                {
                    txtDoct.TagString = YBHelper.jiuzhenInfo.atddr_no;
                    txtDoct.Text = YBHelper.jiuzhenInfo.dr_name;

                    txtks.Text = YBHelper.jiuzhenInfo.dept_name;
                    txtks.TagString = YBHelper.jiuzhenInfo.dept_code;
                    caty_code.Text = YBHelper.jiuzhenInfo.caty;
                    caty_name.Text = YBHelper.jiuzhenInfo.caty_name;

                    med_type.SelectedValue = YBHelper.jiuzhenInfo.med_type;
                    psn_setlway.SelectedValue = YBHelper.jiuzhenInfo.psn_setlway;
                    chkuse_flag.Checked = YBHelper.jiuzhenInfo.acct_used_flag == "1";
                    jz_insutype.SelectedValue = YBHelper.jiuzhenInfo.insutype;
                    mdtrt_cert_type.SelectedValue = YBHelper.jiuzhenInfo.mdtrt_cert_type;
                }
                else
                {
                    //不同身份医保支付接口会获取不到科室医生信息
                    var _dept = YBHelper.unitList.Where(p => p.unit_sn == dept_sn).FirstOrDefault();
                    var _doct = YBHelper.doctList.Where(p => p.code == doct_sn || p.yb_ys_code == doct_sn).FirstOrDefault();
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

                YBHelper.diseinfoList = new List<Diseinfo>();
                Diseinfo diseinfo = new Diseinfo();
                diseinfo.vali_flag = "1";
                if (!string.IsNullOrEmpty(icd_code))
                {
                    var _icdmodel = YBHelper.icdCodes.Where(p => p.code == icd_code).FirstOrDefault();
                    if (_icdmodel != null)
                    {
                        diseinfo.diag_code = _icdmodel.yb_code;
                        diseinfo.diag_name = _icdmodel.yb_name;
                        diseinfo.diag_type = YBHelper.diagTypeList[0].code;
                        diseinfo.diag_type_name = YBHelper.diagTypeList[0].name;
                        diseinfo.vali_flag = "1";
                        YBHelper.diseinfoList.Add(diseinfo);
                    }
                    LoadIcdData();
                }

                if (YBHelper.edit_diseinfo == "1")
                {
                    btnAddzd.Show();
                    btnDelZd.Show();
                }


                #endregion


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void uiSymbolButton1_Click(object sender, EventArgs e)
        {
            try
            {
                //门诊结算
                var jsRequest = new YBRequest<MZJS2207A>();
                jsRequest.infno = "2207";

                jsRequest.msgid = YBHelper.msgid;
                jsRequest.mdtrtarea_admvs = YBHelper.mdtrtarea_admvs;// "421099";// 
                jsRequest.insuplc_admdvs = insuplcAdmdvs;
                jsRequest.recer_sys_code = YBHelper.recer_sys_code;
                jsRequest.dev_no = "";
                jsRequest.dev_safe_info = "";
                jsRequest.cainfo = "";
                jsRequest.signtype = "";
                jsRequest.infver = YBHelper.infver;
                jsRequest.opter_type = YBHelper.opter_type;
                jsRequest.opter = opter;
                jsRequest.opter_name = opter_name;
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

                if (yjsResponse != null)
                {
                    _mzyjs.fulamt_ownpay_amt = yjsResponse.setlinfo.fulamt_ownpay_amt;
                    _mzyjs.overlmt_selfpay = yjsResponse.setlinfo.overlmt_selfpay;
                    _mzyjs.preselfpay_amt = yjsResponse.setlinfo.preselfpay_amt;
                    _mzyjs.inscp_scp_amt = yjsResponse.setlinfo.inscp_scp_amt;
                }

                jsRequest.input.data = _mzyjs;

                var json = WebApiHelper.SerializeObject(jsRequest);
                var BusinessID = "2207";
                var Dataxml = json;
                var Outputxml = "";
                var parm = new object[] { BusinessID, json, Outputxml };

                //提交门诊挂号结算信息
                YBHelper.AddYBLog(BusinessID, admiss_times, json, patient_id, jsRequest.sign_no, jsRequest.infver, 0, opter, jsRequest.inf_time);

                var result = ComHelper.InvokeMethod("yinhai.yh_hb_sctr", "yh_hb_call", ref parm);

                YBHelper.AddYBLog(BusinessID, admiss_times, parm[2].ToString(), patient_id, jsRequest.sign_no, jsRequest.infver, 1, opter, jsRequest.inf_time);

                //log.Debug("结算返回：" + parm[2].ToString());

                var _jsresp = WebApiHelper.DeserializeObject<YBResponse<MzjsResponse>>(parm[2].ToString());

                if (_jsresp != null && !string.IsNullOrEmpty(_jsresp.err_msg))
                {
                    MessageBox.Show(_jsresp.err_msg);
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
                    YBHelper.acct_used_flag = _mzyjs.acct_used_flag;

                     var setl_id = _jsresp.output.setlinfo.setl_id;
                    //log.Debug($"医保结算成功:patient_id:{patient_id},admiss_times:{admiss_times},setl_id:{setl_id}");

                    //医保结算打印单据
                    //门诊结算
                    var jsPrint = new YBRequest<MzjsPrintModel>();
                    jsPrint.infno = "YH03";

                    jsPrint.msgid = YBHelper.msgid;
                    jsPrint.mdtrtarea_admvs = YBHelper.mdtrtarea_admvs;// "421099";// 
                    jsPrint.insuplc_admdvs = insuplcAdmdvs;
                    jsPrint.recer_sys_code = YBHelper.recer_sys_code;
                    jsPrint.dev_no = "";
                    jsPrint.dev_safe_info = "";
                    jsPrint.cainfo = "";
                    jsPrint.signtype = "";
                    jsPrint.infver = YBHelper.infver;
                    jsPrint.opter_type = YBHelper.opter_type;
                    jsPrint.opter = opter;
                    jsPrint.opter_name = opter_name;
                    jsPrint.inf_time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    jsPrint.fixmedins_code = YBHelper.fixmedins_code;
                    jsPrint.fixmedins_name = YBHelper.fixmedins_name;
                    jsPrint.sign_no = YBHelper.msgid;
                    jsPrint.input = new RepModel<MzjsPrintModel>();

                    MzjsPrintModel mzjsPrintModel = new MzjsPrintModel();
                    mzjsPrintModel.mdtrt_id = _jsresp.output.setlinfo.mdtrt_id;
                    mzjsPrintModel.psn_no = _jsresp.output.setlinfo.psn_no;
                    mzjsPrintModel.med_type = _jsresp.output.setlinfo.med_type;
                    mzjsPrintModel.setl_id = _jsresp.output.setlinfo.setl_id;

                    jsPrint.input.data = mzjsPrintModel;

                    json = WebApiHelper.SerializeObject(jsPrint);
                    BusinessID = "YH03";
                    Dataxml = json;
                    Outputxml = "";
                    parm = new object[] { BusinessID, json, Outputxml };

                    Task.Run(() =>
                    {

                        //提交门诊挂号结算信息
                        YBHelper.AddYBLog(BusinessID, admiss_times, json, patient_id, jsRequest.sign_no, jsRequest.infver, 0, opter, jsRequest.inf_time);

                        result = ComHelper.InvokeMethod("yinhai.yh_hb_sctr", "yh_hb_call", ref parm);

                        YBHelper.AddYBLog(BusinessID, admiss_times, parm[2].ToString(), patient_id, jsRequest.sign_no, jsRequest.infver, 1, opter, jsRequest.inf_time);

                    });

                }
                DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                UIMessageBox.ShowError(ex.Message);
            }
        }

        private void uiSymbolButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnYJS_Click(object sender, EventArgs e)
        {
            insuplcAdmdvs = lbl_insplcadmdvs.Text;

            //判断医生医保编号是否正确
            if (string.IsNullOrEmpty(txtDoct.TagString))
            {
                UIMessageBox.ShowError("医生医保编号为空，请选择正确的医生");
                return;
            }

            //判断是否有诊断信息
            if (YBHelper.diseinfoList == null || YBHelper.diseinfoList.Count == 0)
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
            jzxxRequest.insuplc_admdvs = insuplcAdmdvs;
            jzxxRequest.recer_sys_code = YBHelper.recer_sys_code;
            jzxxRequest.dev_no = "";
            jzxxRequest.dev_safe_info = "";
            jzxxRequest.cainfo = "";
            jzxxRequest.signtype = "";
            jzxxRequest.infver = YBHelper.infver;
            jzxxRequest.opter_type = YBHelper.opter_type;
            jzxxRequest.opter = opter;
            jzxxRequest.opter_name = opter_name;
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
            if (birctrl_type.Text != "")
            {
                jzxxRequest.input.mdtrtinfo.birctrl_type = birctrl_type.SelectedValue.ToString();
                jzxxRequest.input.mdtrtinfo.birctrl_matn_date = birctrl_type.SelectedText;
            }

            if (cbx_mzmb.Text != "")
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

            if (YBHelper.diseinfoList != null)
            {
                int _idx = 1;
                foreach (var item in YBHelper.diseinfoList)
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

            YBHelper.AddYBLog(BusinessID, admiss_times, json, patient_id, jzxxRequest.sign_no, jzxxRequest.infver, 0, opter, jzxxRequest.inf_time);

            var result = ComHelper.InvokeMethod("yinhai.yh_hb_sctr", "yh_hb_call", ref parm);

            YBHelper.AddYBLog(BusinessID, admiss_times, parm[2].ToString(), patient_id, jzxxRequest.sign_no, jzxxRequest.infver, 1, opter, jzxxRequest.inf_time);


            var _jzxxresp = WebApiHelper.DeserializeObject<YBResponse<RepModel<GHResponseModel>>>(parm[2].ToString());

            if (_jzxxresp != null && !string.IsNullOrEmpty(_jzxxresp.err_msg))
            {
                MessageBox.Show(_jzxxresp.err_msg);
                //log.Error(_jzxxresp.err_msg);
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
            mzmxRequest.insuplc_admdvs = insuplcAdmdvs;
            mzmxRequest.recer_sys_code = YBHelper.recer_sys_code;
            mzmxRequest.dev_no = "";
            mzmxRequest.dev_safe_info = "";
            mzmxRequest.cainfo = "";
            mzmxRequest.signtype = "";
            mzmxRequest.infver = YBHelper.infver;
            mzmxRequest.opter_type = YBHelper.opter_type;
            mzmxRequest.opter = opter;
            mzmxRequest.opter_name = opter_name;
            mzmxRequest.inf_time = _dt;
            mzmxRequest.fixmedins_code = YBHelper.fixmedins_code;
            mzmxRequest.fixmedins_name = YBHelper.fixmedins_name;
            mzmxRequest.sign_no = YBHelper.msgid;
            mzmxRequest.input = new RepModel<List<feedetail>>();
            List<feedetail> feedetails = new List<feedetail>();
            int _index = 1;
            if (YBHelper.chargeItems != null)
            {
                foreach (var item in YBHelper.chargeItems)
                {
                    feedetail _detail = new feedetail();
                    _detail.feedetl_sn = patient_id + "_" + admiss_times + "_" + _index++;
                    _detail.mdtrt_id = mdtrt_id;
                    _detail.psn_no = psn_no;
                    _detail.chrg_bchno = ipt_otp_no;
                    _detail.rx_circ_flag = "0";
                    _detail.fee_ocur_time = _dt;
                    var ybbill = YBHelper.ybhzCompare.Where(p => p.charge_code == item.charge_code).FirstOrDefault();
                    if (ybbill != null)
                    {
                        _detail.med_list_codg = ybbill.ybhz_code;
                    }
                    else
                    {
                        MessageBox.Show("没有找到关联医保目录");
                    }
                    _detail.medins_list_codg = item.charge_code;
                    _detail.det_item_fee_sumamt = item.charge_price* item.charge_amount;
                    _detail.cnt = item.charge_amount;
                    _detail.pric = item.charge_price;
                    _detail.bilg_dept_codg = txtks.TagString; //ghRequest.unit_sn;
                    _detail.bilg_dept_name = txtks.Text; //ghRequest.unit_name;
                    _detail.bilg_dr_codg = txtDoct.TagString;//ghRequest.yb_ys_code;
                    _detail.bilg_dr_name = txtDoct.Text; //ghRequest.doctor_name;
                    _detail.hosp_appr_flag = "1";

                    feedetails.Add(_detail);
                }
            }
            //else if (SessionHelper.cprCharges != null)
            //{
            //    foreach (var item in SessionHelper.cprCharges)
            //    {
            //        feedetail _detail = new feedetail();
            //        _detail.feedetl_sn = patient_id + "_" + admiss_times + "_" + _index++;
            //        _detail.mdtrt_id = mdtrt_id;
            //        _detail.psn_no = psn_no;
            //        _detail.chrg_bchno = ipt_otp_no;
            //        _detail.rx_circ_flag = "0";
            //        _detail.fee_ocur_time = _dt;
            //        var ybbill = YBHelper.ybhzCompare.Where(p => p.charge_code == item.charge_code).FirstOrDefault();
            //        if (ybbill != null)
            //        {
            //            _detail.med_list_codg = ybbill.ybhz_code;
            //        }
            //        else
            //        {
            //            MessageBox.Show("没有找到关联医保目录");
            //        }
            //        _detail.medins_list_codg = item.charge_code;
            //        _detail.det_item_fee_sumamt = item.charge_price;
            //        _detail.cnt = item.charge_amount;
            //        _detail.pric = item.orig_price;
            //        _detail.bilg_dept_codg = txtks.TagString; //SessionHelper.uservm.dept_sn;
            //        _detail.bilg_dept_name = txtks.Text; // SessionHelper.uservm.name;
            //        _detail.bilg_dr_codg = txtDoct.TagString;// "D421002005282";
            //        _detail.bilg_dr_name = txtDoct.Text; //SessionHelper.uservm.name;
            //        _detail.hosp_appr_flag = "1";

            //        feedetails.Add(_detail);
            //    }
            //}

            mzmxRequest.input.feedetail = feedetails;
            json = WebApiHelper.SerializeObject(mzmxRequest);
            BusinessID = ((int)InfoNoEnum.门诊明细上传).ToString();
            Dataxml = json;
            Outputxml = "";
            parm = new object[] { BusinessID, json, Outputxml };

            YBHelper.AddYBLog(BusinessID, admiss_times, json, patient_id, jzxxRequest.sign_no, jzxxRequest.infver, 0, opter, jzxxRequest.inf_time);

            result = ComHelper.InvokeMethod("yinhai.yh_hb_sctr", "yh_hb_call", ref parm);

            YBHelper.AddYBLog(BusinessID, admiss_times, parm[2].ToString(), patient_id, jzxxRequest.sign_no, jzxxRequest.infver, 1, opter, jzxxRequest.inf_time);

            //log.Debug("明细提交返回：" + parm[2]);

            var _mxresp = WebApiHelper.DeserializeObject<YBResponse<Repsonse2204<List<JzxxResponse>>>>(parm[2].ToString());
            if (_mxresp != null && !string.IsNullOrEmpty(_mxresp.err_msg))
            {
                MessageBox.Show(_mxresp.err_msg);
                //log.Error(_mxresp.err_msg);
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
            yjsRequest.insuplc_admdvs = insuplcAdmdvs;
            yjsRequest.recer_sys_code = YBHelper.recer_sys_code;
            yjsRequest.dev_no = "";
            yjsRequest.dev_safe_info = "";
            yjsRequest.cainfo = "";
            yjsRequest.signtype = "";
            yjsRequest.infver = YBHelper.infver;
            yjsRequest.opter_type = YBHelper.opter_type;
            yjsRequest.opter = opter;
            yjsRequest.opter_name = opter_name;
            yjsRequest.inf_time = _dt;
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

            YBHelper.AddYBLog(BusinessID, admiss_times, json, patient_id, jzxxRequest.sign_no, jzxxRequest.infver, 0, opter, jzxxRequest.inf_time);

            result = ComHelper.InvokeMethod("yinhai.yh_hb_sctr", "yh_hb_call", ref parm);

            YBHelper.AddYBLog(BusinessID, admiss_times, parm[2].ToString(), patient_id, jzxxRequest.sign_no, jzxxRequest.infver, 1, opter, jzxxRequest.inf_time);

            //log.Debug("预结算返回：" + parm[2]);

            var _yjsresp = WebApiHelper.DeserializeObject<YBResponse<MzjsResponse>>(parm[2].ToString());

            if (_yjsresp != null && !string.IsNullOrEmpty(_yjsresp.err_msg))
            {
                MessageBox.Show(_yjsresp.err_msg);
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

                yjsResponse = _yjsresp.output;
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

                if (YBHelper.doctList != null && YBHelper.doctList.Count > 0)
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
                    dgvys.ReadOnly = true;


                    List<UserDicVM> vm = YBHelper.doctList;

                    if (!string.IsNullOrWhiteSpace(ipt))
                    {
                        vm = vm.Where(p => p.py_code.StartsWith(ipt.ToUpper())).ToList();
                    }
                    dgvys.DataSource = vm;

                    dgvys.Columns["code"].HeaderText = "编号";
                    dgvys.Columns["name"].HeaderText = "名称";
                    dgvys.Columns["yb_ys_code"].HeaderText = "医保编号";
                    dgvys.Columns["py_code"].Visible = false;
                    dgvys.Columns["d_code"].Visible = false;
                    dgvys.Columns["emp_sn"].Visible = false;
                    dgvys.Columns["dept_sn"].Visible = false;
                    dgvys.Columns["dept_name"].Visible = false;
                    dgvys.AutoResizeColumns();

                    dgvys.CellClick -= dgvys_CellContentClick;
                    dgvys.CellClick += dgvys_CellContentClick;
                    dgvys.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

                var _ybinfo = YBHelper.doctList.Where(p => p.code == code).FirstOrDefault();
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

                if (YBHelper.unitList != null && YBHelper.unitList.Count > 0)
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
                    dgv.ReadOnly = true;


                    List<UnitVM> vm = YBHelper.unitList;

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

                var _ybksInfo = YBHelper.unitList.Where(p => p.code == unit_sn).FirstOrDefault();
                caty_code.Text = _ybksInfo.yb_ks_code;
                caty_name.Text = _ybksInfo.yb_ks_name;

                dgv.Hide();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                foreach (var item in YBHelper.diseinfoList.ToArray())
                {
                    YBHelper.diseinfoList.Remove(item);
                }
                LoadIcdData();
            }
        }

        public void LoadIcdData()
        {
            //更新数据表
            if (YBHelper.diseinfoList != null)
            {
                foreach (var item in YBHelper.diseinfoList)
                {
                    item.dise_dor_no = txtDoct.TagString;
                    item.dise_dor_name = txtDoct.Text;
                    item.diag_dept = txtks.TagString;
                }

                var _dat = YBHelper.diseinfoList.Select(p => new
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
                jsRequest.insuplc_admdvs = insuplcAdmdvs;
                jsRequest.recer_sys_code = YBHelper.recer_sys_code;
                jsRequest.dev_no = "";
                jsRequest.dev_safe_info = "";
                jsRequest.cainfo = "";
                jsRequest.signtype = "";
                jsRequest.infver = YBHelper.infver;
                jsRequest.opter_type = YBHelper.opter_type;
                jsRequest.opter = opter;
                jsRequest.opter_name = opter_name;
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
                 
                YBHelper.AddYBLog(BusinessID, admiss_times, json, patient_id, jsRequest.sign_no, jsRequest.infver, 0,opter, jsRequest.inf_time);

                var result = ComHelper.InvokeMethod("yinhai.yh_hb_sctr", "yh_hb_call", ref parm);

                YBHelper.AddYBLog(BusinessID, admiss_times, parm[2].ToString(),patient_id, jsRequest.sign_no, jsRequest.infver, 1, opter, jsRequest.inf_time);

                //log.Debug("结算返回：" + parm[2].ToString());

                var _jsresp = WebApiHelper.DeserializeObject<YBResponse<Response5301>>(parm[2].ToString());

                //绑定下拉框
                if (_jsresp.output.feedetail != null)
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
                //log.Error(ex.ToString());
            }
        }

        private void lnkSetEmptyDate_Click(object sender, EventArgs e)
        {
            birctrl_matn_date.Text = "";
        }

        private void dgv_cbxx_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //获取参保地信息，显示到界面，并传入预结算
            var _index = dgv_cbxx.SelectedIndex;
            var _insuplc_admdvs = dgv_cbxx.Rows[_index].Cells["insuplc_admdvs"].Value;
            if (_insuplc_admdvs != null)
            {
                lbl_insplcadmdvs.Text = _insuplc_admdvs.ToString();
                insuplcAdmdvs = _insuplc_admdvs.ToString();
            }
        }
    }
}
