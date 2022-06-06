
--挂号-登录
insert into wh_tag_sql(tag,[sql],[description])
values(220001,'select a.*,b.name unit_name,c.name group_name,d.name doct_name,e.name clinic_name from gh_base_request a left join zd_unit_code b on a.unit_sn = b.unit_sn left join zd_unit_code c on a.group_sn = c.unit_sn left join a_employee_mi d on a.doctor_sn = d.emp_sn
left join gh_zd_clinic_type e on a.clinic_type = e.code
where a.unit_sn like @unit_sn and
      isnull(a.group_sn,'''') like @group_sn and
      isnull(a.doctor_sn,'''') like @doctor_sn and
      a.clinic_type like @clinic_type and
      isnull(cast(a.week as char),'''') like @week and
      isnull(cast(a.day as char),'''') like @day and
      a.ampm like @ampm and
      isnull(cast(a.window_no as char),'''') like @window_no and
      a.open_flag like @open_flag
order by op_date desc,unit_sn,
         group_sn,
         doctor_sn,
         clinic_type,
         week,
         day,
         ampm,
         window_no','挂号-登录')

--挂号 根据卡号查询用户
insert into wh_tag_sql(tag,[sql],[description])
values(220002,'select distinct a.patient_id, a.max_times times, a.[name], a.sex, a.birthday, cast(DateDiff(YY,a.birthday, GetDate()) as float) age, a.response_type, a.contract_code, a.occupation_type, a.charge_type, ''07'' haoming_code, ''2969317'' code, inpatient_no, getdate() visit_date, 
a.social_no, ''07'' real_haoming_code, a.home_district, a.home_street, a.relation_tel, a.hic_no, a.addition_no1, a.home_tel, a.relation_name, a.relation_code, a.max_times real_times, a.p_bar_code, a.p_bar_code2, a.black_flag, a.address, a.poverty_code, a.employer_name, a.employer_street, employer_district,
a.employer_tel, a.allergic_diag, a.marry_code, a.max_times, a.max_ledger_sn, a.max_receipt_sn, a.max_item_sn, a.enter_opera, a.enter_date, a.update_opera, a.update_date,a.yb_psn_no,a.yb_insuplc_admdvs,a.yb_insutype from 
 mz_patient_mi a where 
a.p_bar_code = @cardno or a.social_no=@cardno or a.hic_no=@cardno order by max_ledger_sn desc','挂号-根据卡号查询用户')

--挂号 根据patient_id查询用户
insert into wh_tag_sql(tag,[sql],[description])
values(220003,'select distinct a.patient_id, a.max_times times, a.[name], a.sex, a.birthday, cast(DateDiff(YY,a.birthday, GetDate()) as float) age, a.response_type, a.contract_code, a.occupation_type, a.charge_type, ''07'' haoming_code, ''2969317'' code, inpatient_no, getdate() visit_date, 
a.social_no, ''07'' real_haoming_code, a.home_district, a.home_street, a.relation_tel, a.hic_no, a.addition_no1, a.home_tel, a.relation_name, a.relation_code, a.max_times real_times, a.p_bar_code, a.p_bar_code2, a.black_flag, a.address, a.poverty_code, a.employer_name, a.employer_street, employer_district,
a.employer_tel, a.allergic_diag, a.marry_code, a.max_times, a.max_ledger_sn, a.max_receipt_sn, a.max_item_sn, a.enter_opera, a.enter_date, a.update_opera, a.update_date,a.yb_psn_no,a.yb_insuplc_admdvs,a.yb_insutype from 
 mz_patient_mi a where 
a.patient_id=@patient_id','挂号-根据patient_id查询用户')

--挂号 根据p_bar_code查询用户
insert into wh_tag_sql(tag,[sql],[description])
values(220004,'select * from mz_patient_mi a where a.p_bar_code=@barcode','挂号-根据p_bar_code查询用户')

--挂号 根据patient_id查询用户
insert into wh_tag_sql(tag,[sql],[description])
values(220005,'select * from mz_patient_mi a where a.patient_id=@patient_id','挂号-根据patient_id查询用户')
 
--挂号 清除现有身份证数据
insert into wh_tag_sql(tag,[sql],[description])
values(220006,' UPDATE mz_patient_mi SET hic_no='' WHERE hic_no=@hic_no','挂号-清除现有身份证数据')

--挂号 更新用户医保信息
delete from wh_tag_sql where tag=220007
insert into wh_tag_sql(tag,[sql],[description])
values(220007,'UPDATE mz_patient_mi SET social_no=@social_no,yb_psn_no=@yb_psn_no,yb_insutype=@yb_insutype,yb_insuplc_admdvs=@yb_insuplc_admdvs WHERE patient_id=@pid','挂号-更新用户医保信息')

--挂号 修改用户信息弹窗
insert into wh_tag_sql(tag,[sql],[description])
values(220008,'update mz_patient_mi
set social_no=@social_no,hic_no=@hic_no,p_bar_code=@p_bar_code,name=@name,sex=@sex,birthday=@birthday,home_tel=@tel,
home_district=@home_district,home_street=@home_street,occupation_type=@occupation_type,response_type=@response_type,charge_type=@charge_type,update_date=@update_date,update_opera=@update_opera 
where patient_id=@patient_id','挂号-修改用户信息弹窗')

--挂号 新增用户信息弹窗
insert into wh_tag_sql(tag,[sql],[description])
values(220009,'insert into mz_patient_mi(patient_id,social_no,hic_no,p_bar_code,name,sex,birthday,home_tel,
balance,max_times,max_ledger_sn,max_item_sn,max_receipt_sn,
home_district,home_street,occupation_type,response_type,charge_type,enter_date,update_date,enter_opera,update_opera) values
(@patient_id,@social_no,@hic_no,@p_bar_code,@name,@sex,@birthday,@home_tel,''0'',0,0,0,0,
@home_district,@home_street,@occupation_type,@response_type,@charge_type,@enter_date,@update_date,@enter_opera,@update_opera)','挂号-新增用户信息弹窗')

--挂号 修改用户信息页面
insert into wh_tag_sql(tag,[sql],[description])
values(220010,'update mz_patient_mi
set social_no=@social_no,hic_no=@hic_no,p_bar_code=@p_bar_code,name=@name,sex=@sex,birthday=@birthday,home_tel=@tel,
home_district=@home_district,home_street=@home_street,occupation_type=@occupation_type,response_type=@response_type,charge_type=@charge_type,
update_date=@update_date,update_opera=@update_opera,relation_name=@relation_name,marry_code=@marry_code,addition_no1=@addition_no1,employer_name=@employer_name
where patient_id=@patient_id','挂号-修改用户信息页面')

--挂号 新增用户信息页面
insert into wh_tag_sql(tag,[sql],[description])
values(220011,'insert into mz_patient_mi(patient_id,social_no,hic_no,p_bar_code,name,sex,birthday,home_tel,
balance,max_times,max_ledger_sn,max_item_sn,max_receipt_sn,
home_district,home_street,occupation_type,response_type,charge_type,enter_date,update_date,enter_opera,update_opera,
relation_name,marry_code,addition_no1,employer_name) values
(@patient_id,@social_no,@hic_no,@p_bar_code,@name,@sex,@birthday,@home_tel,''0'',0,0,0,0,
@home_district,@home_street,@occupation_type,@response_type,@charge_type,@enter_date,@update_date,@enter_opera,@update_opera,
@relation_name,@marry_code,@addition_no1,@employer_name)','挂号-新增用户信息页面')

--挂号 查询当前号是否超过数量
insert into wh_tag_sql(tag,[sql],[description])
values(220012,'select * from gh_request where record_sn = @record_sn and current_no<= end_no','挂号-查询当前号是否超过数量')

--挂号 更新挂号表
insert into wh_tag_sql(tag,[sql],[description])
values(220013,'UPDATE gh_request SET current_no =current_no+1 WHERE record_sn = @record_sn','挂号-更新挂号表')


--挂号 更新门诊用户信息
insert into wh_tag_sql(tag,[sql],[description])
values(220014,'update mz_patient_mi set max_times = max_times+1,max_ledger_sn =max_ledger_sn+1 where  patient_id=@patient_id;select max_ledger_sn,max_times from mz_patient_mi where  patient_id=@patient_id','挂号-更新门诊用户信息')


--挂号 更新发票号
insert into wh_tag_sql(tag,[sql],[description])
values(220015,'UPDATE mz_order_generator  
     SET max_sn = max_sn + 1
   WHERE(mz_order_generator.define = ''gh_receipt_sn'')
SELECT mz_order_generator.max_sn
   FROM mz_order_generator
   WHERE(mz_order_generator.define = ''gh_receipt_sn'')','挂号-更新发票号')

--挂号 新增用户挂号记录表
insert into wh_tag_sql(tag,[sql],[description])
values(220016,'insert into mz_visit_table(patient_id,times,visit_dept,doctor_code,visit_date,name,response_type,haoming_code,charge_type,
age,group_sn,clinic_type,req_type,gh_sequence,ampm,visit_flag,gh_opera,gh_date) values
(@patient_id,@times,@visit_dept,@doctor_code,@visit_date,@name,@response_type,@haoming_code,@charge_type,
@age,@group_sn,@clinic_type,@req_type,@gh_sequence,@ampm,@visit_flag,@gh_opera,@gh_date)','挂号-新增用户挂号记录表')
   

--挂号 新增挂号收费明细表
insert into wh_tag_sql(tag,[sql],[description])
values(220017,'insert into gh_detail_charge
  (patient_id, times, item_no, ledger_sn, happen_date, charge_code, audit_code, bill_code, exec_sn, apply_sn,
org_price, charge_price, charge_amount, charge_group, enter_opera, enter_date, enter_win_no, 
confirm_opera, confirm_date, confirm_win_no, charge_status, trans_flag, mz_dept_no)
values (@patient_id, @max_times, @item_no, @ledger_sn, @happen_date, @charge_code, @audit_code, @bill_code, @exec_sn, @apply_sn,
@org_price, @charge_price, @charge_amount, @charge_group,@enter_opera, @enter_date, @enter_win_no,
@confirm_opera,@confirm_date, @confirm_win_no, @charge_status, @trans_flag, @mz_dept_no)','挂号-新增挂号收费明细表')

--挂号 新增现金流表
insert into wh_tag_sql(tag,[sql],[description])
values(220018,'insert into gh_deposit
  (patient_id, item_no, ledger_sn, times, charge, cheque_type, cheque_no, depo_status, price_opera, price_date, mz_dept_no)
values
  (@patient_id, @item_no, @ledger_sn, @times, @charge, @cheque_type,@cheque_no, @depo_status, @price_opera, @price_date, @mz_dept_no)','挂号-新增现金流表')

--挂号 写入挂号发票明细表
insert into wh_tag_sql(tag,[sql],[description])
values(220019,'insert into gh_receipt_charge
  (patient_id, times, ledger_sn, receipt_sn, bill_code, charge, pay_unit)
values
  (@patient_id, @times, @ledger_sn, @receipt_sn, @bill_code, @charge, @pay_unit)','挂号-写入挂号发票明细表')


--挂号 写入挂号发票表
insert into wh_tag_sql(tag,[sql],[description])
values(220020,'insert into gh_receipt
  (patient_id, times, ledger_sn, receipt_sn, pay_unit, charge_total, settle_opera, settle_date, price_opera, price_date, receipt_no, charge_status, mz_dept_no)
values
  (@patient_id,@times,@ledger_sn, @receipt_sn, @pay_unit, @charge_total, @settle_opera,@settle_date, @price_opera, @price_date, @receipt_no, @charge_status, @mz_dept_no)','挂号-写入挂号发票表')

--挂号 更新挂号发票记录表
delete from wh_tag_sql where tag=220021
insert into wh_tag_sql(tag,[sql],[description])
values(220021,'update gh_op_receipt  set
                                 current_no = @new_no 
                                 where
                                 operator = @operator and
                                 happen_date = @happen_date and
                                 start_no = @start_no and
                                 current_no = @current_no and
                                 end_no = @end_no and
                                 step_length =@step_length and
                                 deleted_flag = @deleted_flag and
                                 report_flag = @report_flag and
                                 receipt_type = @receipt_type','挂号-更新挂号发票记录表')
 

--挂号 获取用户编号
insert into wh_tag_sql(tag,[sql],[description])
values(220022,' Update gh_config set patient_sn = patient_sn + 1;select patient_sn from gh_config','挂号-获取用户编号')


--挂号 科室字典
insert into wh_tag_sql(tag,[sql],[description])
values(220023,'select   zd_unit_code.code,
       zd_unit_code.name,
       zd_unit_code.py_code,
       zd_unit_code.d_code,
       zd_unit_code.unit_sn
from zd_unit_code
where zd_unit_code.deleted_flag = ''0''
order by code','挂号-科室字典')

--挂号 用户字典
insert into wh_tag_sql(tag,[sql],[description])
values(220024,'select * from a_employee_mi where deleted_flag=0  order by emp_sn','挂号-用户字典')

--挂号 用户身份字典
insert into wh_tag_sql(tag,[sql],[description])
values(220025,'select * from zd_responce_type','挂号-用户身份字典')

--挂号 职业字典
insert into wh_tag_sql(tag,[sql],[description])
values(220026,'select * from zd_occupation_code','挂号-职业字典')

--挂号 获取号名字典
insert into wh_tag_sql(tag,[sql],[description])
values(220027,'SELECT * from mz_zd_haoming WHERE mz_zd_haoming.delete_flag = ''0'' ORDER BY mz_zd_haoming.sort_order ASC','挂号-获取号名字典')
 
--挂号 地区字典
insert into wh_tag_sql(tag,[sql],[description])
values(220028,'select * from zd_district_code','挂号-地区字典')

--挂号 号别
insert into wh_tag_sql(tag,[sql],[description])
values(220029,'select * from gh_zd_clinic_type where deleted_flag=0','挂号-号别')

--挂号 号类
insert into wh_tag_sql(tag,[sql],[description])
values(220030,'select * from gh_zd_request_type where deleted_flag=0','挂号-号类')

--挂号 费别
insert into wh_tag_sql(tag,[sql],[description])
values(220031,'select * from zd_charge_type','挂号-费别')

--挂号 查询
delete from wh_tag_sql where tag=220032
insert into wh_tag_sql(tag,[sql],[description])
values(220032,'select
        a.patient_id,
        a.times,
        a.gh_date,
        a.name patient_name,
        a.gh_sequence,
        a.visit_flag,
        b.name unit_name,
        d.name clinic_name,
        c.name doctor_name,
        b1.name group_name,
        e.name req_name,
        f.name response_name,
        g.name charge_name,
        h.name haoming_name,
        c1.name opera_name,
        case a.ampm when ''a'' then ''上午'' when ''p'' then ''下午'' when ''p'' then ''下午'' else ''夜间'' end ampm,
        case when a.gh_sequence > 0 then cast(a.gh_sequence as varchar) else ''加号'' + cast(abs(a.gh_sequence) as varchar) end gh_order,
        case when a.gh_sequence > 0 then gh_sequence else abs(gh_sequence) + 10000 end gh_sequence_f,
        case a.visit_flag when ''0'' then ''未到'' when ''9'' then ''退号'' when ''8'' then ''已打印'' else ''已到'' end visit_status,
        case a.flag when ''a'' then ''未转移'' else ''已转移'' end flag,
        sum(i.charge_total) charge_fee,
        i.receipt_sn,
        i.receipt_no,
        p.p_bar_code 
from    view_mz_visit_table a left join  zd_unit_code b on a.visit_dept = b.unit_sn
        left join  zd_unit_code b1 on a.group_sn = b1.unit_sn 
        left join  a_employee_mi c on a.doctor_code = c.emp_sn
        left join  a_employee_mi c1 on a.gh_opera = c1.emp_sn
        left join  gh_zd_clinic_type d on a.clinic_type = d.code
        left join  gh_zd_request_type e on a.req_type = e.code
        left join  zd_responce_type f on a.response_type = f.code
        left join  zd_charge_type g on a.charge_type = g.code
        left join  mz_zd_haoming h on a.haoming_code = h.code
        left join  gh_receipt i on a.patient_id = i.patient_id and
                     a.times = i.times 
        left join  view_mz_allpatient p on a.patient_id = p.patient_id  
where datediff(dd,a.gh_date,@gh_date)=0 and 
        a.visit_dept like @visit_dept and
        a.clinic_type like @clinic_type and
        isnull(a.doctor_code, ''-1'') like @doctor_code and
        isnull(a.group_sn, ''-1'') like @group_sn and
        a.req_type like @req_type and
        a.ampm like @ampm and
        a.gh_opera like @gh_opera and 
        isnull(a.name,''-1'') like @name and
        isnull(p.p_bar_code,'''') like @p_bar_code
group by
        a.patient_id,
        a.times,
        a.gh_date,
        a.name,
        a.gh_sequence,
        a.visit_flag,
        b.name,
        d.name,
        c.name,
        b1.name,
        e.name,
        f.name,
        g.name,
        h.name,
        c1.name,
        a.ampm,
        a.flag,
        i.receipt_sn,
        i.receipt_no,
        p.p_bar_code        
order by
        a.gh_date,
        i.receipt_sn,
        unit_name,
        clinic_name,
        doctor_name,
        group_name,
        req_name,
        gh_sequence_f','挂号-查询')


--挂号 查询挂号信息
insert into wh_tag_sql(tag,[sql],[description])
values(220033,'select * from gh_request where record_sn =@record_sn','挂号-查询挂号信息')

--挂号 查询挂号信息(医生为空)
insert into wh_tag_sql(tag,[sql],[description])
values(220034,'select * from gh_request where request_date=@request_date
                            and unit_sn=@unit_sn and ampm=@ampm and clinic_type=@clinic_type','挂号-查询挂号信息(医生为空)')

--挂号 查询挂号信息（含医生）
insert into wh_tag_sql(tag,[sql],[description])
values(220035,'select * from gh_request where request_date=@request_date
                            and ampm=@ampm and doctor_sn=@doctor_sn','挂号-查询挂号信息（含医生）')

--挂号 新增挂号信息
insert into wh_tag_sql(tag,[sql],[description])
values(220036,'insert into gh_request
  (request_date, ampm, unit_sn, group_sn, doctor_sn, clinic_type, req_type, begin_no, current_no, end_no, enter_opera, enter_date, open_flag, window_no)
values
  (@request_date, @ampm, @unit_sn, @group_sn, @doctor_sn, @clinic_type, @req_type, @begin_no, @current_no, @end_no, @enter_opera, @enter_date, @open_flag, @window_no)','挂号-新增挂号信息')

--挂号 修改挂号信息
insert into wh_tag_sql(tag,[sql],[description])
values(220037,'update gh_request set request_date=@request_date,ampm=@ampm,unit_sn=@unit_sn,group_sn=@group_sn,doctor_sn=@doctor_sn,clinic_type=@clinic_type,
req_type=@req_type,end_no=@end_no, enter_opera=@enter_opera, enter_date=@enter_date, open_flag=@open_flag, window_no=@window_no
where record_sn=@record_sn','挂号-修改挂号信息')

--挂号 查询退款列表

delete from wh_tag_sql where tag=220038
insert into wh_tag_sql(tag,[sql],[description])
values(220038,'SELECT
      DISTINCT
	  v.visit_date,
      v.visit_dept,
      v.group_sn,
      v.doctor_code,
      v.ampm,
      u1.name unit_name,
	  u2.name group_name,
	  a.name doctor_name,
	  v.gh_sequence,
      v.patient_id,
      v.name,
      v.times, 
      ISNULL(v.response_type, '''') response_type,
      ISNULL(v.charge_type, '''') charge_type,
      ISNULL(v.clinic_type, '''') clinic_type,
      ISNULL(v.req_type, '''') req_type,
      ISNULL(c.name, '''') clinic_name,
      ISNULL(r.name, '''') request_name,
      ISNULL(v.gh_opera , '''') gh_opera,
      v.gh_date,
      CASE  WHEN v.gh_sequence < 0 THEN ''加号'' + CAST(ABS(v.gh_sequence) AS CHAR)
            ELSE CAST(ABS(v.gh_sequence) AS CHAR) 
            END gh_sequence_c,
      ISNULL(f.receipt_sn, '''') receipt_sn,
      ISNULL(f.receipt_no, '''') receipt_no,
      f.report_date,
	  charge= (select max(charge_total) from gh_receipt where patient_id=v.patient_id and  times=v.times ),
      ic_count = (SELECT COUNT(*) FROM ic_deposit h 
				  WHERE h.patient_id = f.patient_id AND
						h.cheque_no = f.receipt_no AND
						h.deposit_no = f.receipt_sn ),
      v.visit_flag,						
      visit_flag_name = CASE ISNULL(v.visit_flag, ''0'') WHEN ''1'' THEN ''挂号''
                                                  WHEN ''2'' THEN ''分诊''
                                                  WHEN ''4'' THEN ''已就诊''
                                                  WHEN ''9'' THEN ''取消分诊''
                   END    
FROM  view_mz_visit_table v 
      left join zd_unit_code u1 on v.visit_dept = u1.unit_sn 
      left join zd_unit_code u2 on v.group_sn = u2.unit_sn 
      left join a_employee_mi a on v.doctor_code = a.emp_sn  
      left join gh_zd_clinic_type c on v.clinic_type = c.code 
      left join gh_zd_request_type r on v.req_type = r.code
      left join gh_receipt f on f.patient_id = v.patient_id AND f.times = v.times 
WHERE 
      DATEDIFF(dd, v.visit_date, @request_date) = 0 AND 
      v.patient_id LIKE @patient_id
   
order by v.gh_date desc','挂号-查询退款列表')


--挂号 获取发票号信息
insert into wh_tag_sql(tag,[sql],[description])
values(220039,'select top 1 * from gh_op_receipt order by happen_date desc ','挂号-获取发票号信息')



--挂号 获取医生离开信息
insert into wh_tag_sql(tag,[sql],[description])
values(220040,'select * from gh_doctor_out ','挂号-获取医生离开信息')


--挂号 根据编号获取收费项目
insert into wh_tag_sql(tag,[sql],[description])
values(220041,'select * from zd_charge_item where code = @code ','挂号-根据编号获取收费项目')

--挂号 根据挂号信息获取收费项目
delete from wh_tag_sql where tag=220042
insert into wh_tag_sql(tag,[sql],[description])
values(220042,'select b.*,c.name,c.charge_price,c.charge_price,c.effective_price,c.audit_code,c.mz_bill_item,mz_charge_group from gh_zd_clinic_type a 
left join gh_zd_clinic_charge b on a.code = b.code
left join zd_charge_item c on b.charge_code = c.code
left join mz_bill_item d on d.code=c.mz_bill_item
where a.code=(select clinic_type from gh_request where record_sn=@record_sn)','挂号-根据挂号信息获取收费项目')


--挂号 根据患者id获取流水
insert into wh_tag_sql(tag,[sql],[description])
values(220043,'select gh_deposit.*,zd_cheque_type.name tname,zd_deposit_status.name sname from gh_deposit 
left join zd_cheque_type on gh_deposit.cheque_type = zd_cheque_type.code
left join zd_deposit_status on gh_deposit.depo_status = zd_deposit_status.code
where patient_id =@patient_id order by price_date desc','挂号-根据患者id获取流水')

--挂号 筛选条件查询流水
insert into wh_tag_sql(tag,[sql],[description])
values(220044,'select gh_deposit.* from gh_deposit
where patient_id =@patient_id and times=@times and depo_status=@status and item_no=@item_no','挂号-筛选条件查询流水')

--挂号 判断退款数据是否存在
insert into wh_tag_sql(tag,[sql],[description])
values(220045,'select * from gh_deposit where patient_id=@patient_id and times =@times and depo_status=@depo_status','挂号-判断退款数据是否存在')

--挂号 判断退款数据是否已经退号
insert into wh_tag_sql(tag,[sql],[description])
values(220046,'select * from gh_deposit where patient_id=@patient_id and times =@times and depo_status=@depo_status','挂号-判断退款数据是否已经退号')


--挂号  退款写数据到现金流表
insert into wh_tag_sql(tag,[sql],[description])
values(220047,'insert into gh_deposit(patient_id, item_no, ledger_sn, times, charge, 
cheque_type, cheque_no,depo_status, price_opera, price_date, mz_dept_no)
values(@patient_id,@item_no,@ledger_sn,@times,@charge,@cheque_type,@cheque_no,
@depo_status,@price_opera,@price_date,@mz_dept_no)','挂号-退款写数据到现金流表')

--挂号  查询组合支付是否退款完毕
insert into wh_tag_sql(tag,[sql],[description])
values(220048,'select sum(ledger_sn) from gh_deposit where patient_id=@patient_id and times=@times','挂号-查询组合支付是否退款完毕')

--挂号  更新用户挂号表状态为退号
insert into wh_tag_sql(tag,[sql],[description])
values(220049,'update mz_visit_table set visit_flag=9 where patient_id=@patient_id and times=@times','挂号-更新用户挂号表状态为退号')

--挂号  退号发票表写入对冲数据
insert into wh_tag_sql(tag,[sql],[description])
values(220050,'insert into gh_receipt(patient_id,times,ledger_sn,receipt_sn,pay_unit,charge_total,settle_opera,settle_date,price_opera,price_date,report_date,receipt_no,charge_status,mz_dept_no,op_receipt_sn)  
select patient_id,times,-ledger_sn,receipt_sn,pay_unit,-charge_total,@settle_opera,settle_date,@price_opera,price_date,report_date,receipt_no,7,mz_dept_no,op_receipt_sn
from gh_receipt  where patient_id =@patient_id and ledger_sn=@ledger_sn','挂号-退号发票表写入对冲数据')

--挂号  退号发票明细表写入对冲数据
insert into wh_tag_sql(tag,[sql],[description])
values(220051,'insert into gh_receipt_charge (patient_id,times,ledger_sn,receipt_sn,bill_code,charge,pay_unit)
select patient_id,times,-ledger_sn,receipt_sn,bill_code,-charge,pay_unit
from gh_receipt_charge
where patient_id =@patient_id and ledger_sn=@ledger_sn','挂号-退号发票明细表写入对冲数据')

--挂号  退号收费明细表写入对冲数据
insert into wh_tag_sql(tag,[sql],[description])
values(220052,'insert into gh_detail_charge (patient_id,times,item_no,ledger_sn,happen_date,charge_code,audit_code,bill_code,exec_sn,apply_sn,org_price,charge_price,charge_amount,
charge_group,enter_opera,enter_date,enter_win_no,confirm_opera,confirm_date,confirm_win_no,charge_status,trans_flag,fit_type,report_date,mz_dept_no)
select patient_id,times,item_no,-ledger_sn,happen_date,charge_code,audit_code,bill_code,exec_sn,apply_sn,org_price,charge_price,-charge_amount,
charge_group,@enter_opera,enter_date,enter_win_no,@confirm_opera,confirm_date,confirm_win_no,7,trans_flag,fit_type,report_date,mz_dept_no
from gh_detail_charge
where patient_id =@patient_id and ledger_sn=@ledger_sn','挂号-退号收费明细表写入对冲数据')


--挂号 基础号表查询
insert into wh_tag_sql(tag,[sql],[description])
values(220053,'select a.*,b.name unit_name,c.name group_name,d.name doct_name,e.name clinic_name from gh_base_request a
left join zd_unit_code b on a.unit_sn = b.unit_sn
left join zd_unit_code c on a.group_sn = c.unit_sn
left join a_employee_mi d on a.doctor_sn = d.emp_sn
left join gh_zd_clinic_type e on a.clinic_type = e.code
where a.unit_sn like @unit_sn and
      isnull(a.group_sn,'''') like @group_sn and
      isnull(a.doctor_sn,'''') like @doctor_sn and
      a.clinic_type like @clinic_type and
      isnull(cast(a.week as char),'''') like @week and
      isnull(cast(a.day as char),'''') like @day and
      a.ampm like @ampm and
      isnull(cast(a.window_no as char),'''') like @window_no and
      a.open_flag like @open_flag
order by op_date desc,unit_sn,
         group_sn,
         doctor_sn,
         clinic_type,
         week,
         day,
         ampm,
         window_no','挂号-基础号表查询')


--挂号  挂号基础表最新序号 
insert into wh_tag_sql(tag,[sql],[description])
values(220054,'update gh_config set base_request_sn=base_request_sn+1 where op_receipt_table=''gh_op_receipt'';
select base_request_sn from gh_config where op_receipt_table=''gh_op_receipt''','挂号-挂号基础表最新序号');
; 
--挂号  新增基础号表 
insert into wh_tag_sql(tag,[sql],[description])
values(220055,'insert into gh_base_request(request_sn,[week],[day],ampm,unit_sn,group_sn,doctor_sn,
clinic_type,totle_num,op_id,op_date,open_flag,window_no)
values(@request_sn,@week,@day,@ampm,@unit_sn,@group_sn,@doctor_sn,
@clinic_type,@totle_num,@op_id,@op_date,@open_flag,@window_no)','挂号-新增基础表');

--挂号  新增基础号区间表 
insert into wh_tag_sql(tag,[sql],[description])
values(220056,'insert into gh_base_request_segment(request_sn,req_type,begin_no,end_no)
values(@request_sn,@req_type,@begin_no,@end_no)','挂号-新增基础号区间表');

--挂号  删除基础号表 
insert into wh_tag_sql(tag,[sql],[description])
values(220057,'delete from gh_base_request where request_sn=@request_sn;delete from gh_base_request_segment where request_sn=@request_sn','挂号-删除基础号表');

--挂号  查询基础号表 
insert into wh_tag_sql(tag,[sql],[description])
values(220058,'select b.*,
	w.name window_name,	
        t.name clinic_name, 
	u1.name unit_name,
        u2.name group_name,
	a.name doct_name,
        c.req_type,
        c.begin_no,
        c.end_no      
from 	gh_base_request as b left join gh_zd_clinic_type as t on  b.clinic_type=t.code  
	left join gh_zd_window_no as w on b.window_no =w.window_no  
	left join zd_unit_code as u1 on b.unit_sn =u1.unit_sn  
	left join zd_unit_code as u2 on b.group_sn=u2.unit_sn 
	left join a_employee_mi as a on b.doctor_sn=a.emp_sn 
        inner join gh_base_request_segment c on b.request_sn = c.request_sn 
where  b.open_flag=''1''','挂号-查询基础号表')

--挂号  挂号数据日期查询 
insert into wh_tag_sql(tag,[sql],[description])
values(220059,'select b.record_sn,b.request_date,
        case b.ampm when ''a'' then ''上午'' when ''m'' then ''中午'' when ''p'' then ''下午'' else ''夜间'' end ampm,
       b.unit_sn,
       b.group_sn,
       b.doctor_sn,
       b.clinic_type,
       b.req_type,
       u1.name unit_name,
       u2.name group_name,
       a.name doct_name,
       c.name clinic_name,
       r.name req_name,
       b.begin_no,
       b.current_no,
       b.end_no,
       b.window_no,
       case b.open_flag when ''1'' then ''开放'' else ''不开放'' end open_flag
from gh_request b left join a_employee_mi a on b.doctor_sn = a.emp_sn 
     inner join zd_unit_code u1 on b.unit_sn = u1.unit_sn  
     left join zd_unit_code u2 on b.group_sn = u2.unit_sn 
     inner join gh_zd_clinic_type  c on b.clinic_type = c.code 
     inner join gh_zd_request_type r on b.req_type = r.code  
where b.request_date between @P1 and @P2 ','挂号-挂号数据日期查询');





--挂号  挂号数据条件查询 
insert into wh_tag_sql(tag,[sql],[description])
values(220060,'select b.record_sn,b.request_date,
        case b.ampm when ''a'' then ''上午'' when ''m'' then ''中午'' when ''p'' then ''下午'' else ''夜间'' end ampm,
       b.unit_sn,
       b.group_sn,
       b.doctor_sn,
       b.clinic_type,
       b.req_type,
       u1.name unit_name,
       u2.name group_name,
       a.name doct_name,
       c.name clinic_name,
       r.name req_name,
       b.begin_no,
       b.current_no,
       b.end_no,
       b.window_no,
       case b.open_flag when ''1'' then ''开放'' else ''不开放'' end open_flag
from gh_request b left join a_employee_mi a on b.doctor_sn = a.emp_sn 
     inner join zd_unit_code u1 on b.unit_sn = u1.unit_sn  
     left join zd_unit_code u2 on b.group_sn = u2.unit_sn 
     inner join gh_zd_clinic_type  c on b.clinic_type = c.code 
     inner join gh_zd_request_type r on b.req_type = r.code  
where b.request_date between @P1 and @P2
and b.unit_sn like @unit_sn and
      isnull(b.group_sn,'''') like @group_sn and
      isnull(b.doctor_sn,'''') like @doctor_sn and
      b.clinic_type like @clinic_type and
      b.req_type like @req_type and 
      b.ampm like @ampm and
      isnull(cast(b.window_no as char),'''') like @window_no and
      b.open_flag like @open_flag','挂号-挂号数据条件查询');



 --挂号  查询基础号表 
insert into wh_tag_sql(tag,[sql],[description])
values(220061,'select * from gh_base_request where request_sn=@request_sn','挂号-查询基础号表');

 --挂号  编辑基础号表 
insert into wh_tag_sql(tag,[sql],[description])
values(220062,'update gh_base_request
set [week]=@week,[day]=@day,ampm=@ampm,unit_sn=@unit_sn,group_sn=@group_sn,doctor_sn=@doctor_sn,
clinic_type=@clinic_type,totle_num=@totle_num,op_id=@op_id,op_date=@op_date,open_flag=@open_flag,window_no=@window_no 
where request_sn = @request_sn','挂号-编辑基础号表');
