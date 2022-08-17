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
using System.Net.Http;
using System.Configuration;
using Client.ClassLib;
using System.Net.Http.Headers;
using Client.ViewModel;
using log4net;

namespace Client
{
    public partial class RelationInfoEdit : UIForm
    {
        public string _patientId = "";
        public string _relationCode = "";
        public string _relationName = "";

        private static ILog log = LogManager.GetLogger(typeof(UserInfoEdit));//typeof放当前类



        public RelationInfoEdit(string patientId, string relationCode = "", string relationName = "")
        {
            InitializeComponent();
            _patientId = patientId;
            _relationCode = relationCode;
            _relationName = relationName;

        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public bool IsTelephone(string str_telephone)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(str_telephone, @"^(\d{3,4}-)?\d{6,8}$");
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            // UpdateMzPatientRelation(string patient_id, string relation_code, string sfz_id, string username, string sex, string tel, string opera, string birth, string address)
            var _pid = txt_patientid.Text;
            var _code = cbxRelationCode.SelectedValue;
            var _sfz_id = txt_sfzid.Text;
            var _name = txt_relationname.Text;
            var _sex = cbxSex.Text == "男" ? 1 : 2;
            var _tel = txt_tel.Text;
            var _opera = SessionHelper.uservm.user_mi;
            var _birth = txt_birthday.Value;
            var _addr = txt_address.Text;

            if (_code==null || string.IsNullOrEmpty(_code.ToString()))
            {
                UIMessageTip.Show("请选择关系！"); cbxRelationCode.Focus();
                return;
            }
            if (string.IsNullOrEmpty(_name))
            {
                UIMessageTip.Show("请输入姓名！"); txt_relationname.Focus();
                return;
            }
            if (string.IsNullOrEmpty(_sfz_id))
            {
                UIMessageTip.Show("请输入身份证！"); txt_sfzid.Focus();
                return;
            }
            string paramurl = string.Format($"/api/user/UpdateMzPatientRelation?patient_id={_pid}&relation_code={_code}&sfz_id={_sfz_id}&username={_name}&sex={_sex}&tel={_tel}&opera={_opera}&birth={_birth}&address={_addr}");
             
            var json = HttpClientUtil.Get(paramurl);

            var result = WebApiHelper.DeserializeObject<ResponseResult<bool>>(json);
            if (result.status ==1)
            {
                UIMessageTip.Show("保存成功！");
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }


        private void UserInfoEdit_Load(object sender, EventArgs e)
        {
            try
            {
                InitUI(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                log.Error(ex.StackTrace);
            }
        }




        public void InitUI()
        {

            this.cbxRelationCode.DataSource = SessionHelper.relativeCodes;

            this.cbxRelationCode.ValueMember = "code";
            this.cbxRelationCode.DisplayMember = "name";

            this.cbxSex.Text = "男";


            txt_patientid.Text = _patientId;
            cbxRelationCode.SelectedValue = _relationCode??"";
            txt_relationname.Text = _relationCode??"";

            LoadUserInfo(_patientId);

            //this.txt_birthday.Value = DateTime.Now;

        }

        public void LoadUserInfo(string code)
        {
            try
            {
                //根据patientId查找已存在的病人
                string paramurl = string.Format($"/api/user/GetMzPatientRelationByPatientId?pid={code}");

                var json = HttpClientUtil.Get(paramurl);

                var result = WebApiHelper.DeserializeObject<ResponseResult<List<MzPatientRelationVM>>>(json);

                if (result.status == 1 && result.data.Count > 0)
                {
                    BindUserInfo(result.data[0]);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                log.Error(ex.StackTrace);
            }

        }
        /// <summary>
        /// 绑定数据
        /// </summary>
        /// <param name="userInfo"></param>
        private void BindUserInfo(MzPatientRelationVM userInfo)
        {
            try
            { 
                cbxRelationCode.SelectedValue = userInfo.relation_code;
                txt_relationname.Text = userInfo.username;
                txt_sfzid.Text = userInfo.sfz_id;
                txt_tel.Text = userInfo.tel;
                if (userInfo.birth.HasValue)
                {
                    txt_birthday.Value = userInfo.birth.Value; 
                }
                txt_address.Text = userInfo.address;
                cbxSex.Text = userInfo.sex == "1" ? "男" : "女";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                log.Error(ex.StackTrace);
            }
        }


    }
}
