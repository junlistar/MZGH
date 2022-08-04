 
--220032挂号 查询 
select
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
        case a.ampm when 'a' then '上午' when 'm' then '中午' when 'p' then '下午' else '夜间' end ampm,
        case when a.gh_sequence > 0 then cast(a.gh_sequence as varchar) else '加号' + cast(abs(a.gh_sequence) as varchar) end gh_order,
        case when a.gh_sequence > 0 then gh_sequence else abs(gh_sequence) + 10000 end gh_sequence_f,
        case a.visit_flag when '0' then '未到' when '9' then '退号' when '8' then '已打印' else '已到' end visit_status,
        case a.flag when 'a' then '未转移' else '已转移' end flag,
        sum(i.charge_total) charge_fee,
        i.receipt_sn,
        i.receipt_no,i.ledger_sn,
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
where datediff(dd,a.visit_date,@gh_date)=0 and 
        a.visit_dept like @visit_dept and
        a.clinic_type like @clinic_type and
        isnull(a.doctor_code, '-1') like @doctor_code and
        isnull(a.group_sn, '-1') like @group_sn and
        a.req_type like @req_type and
        a.ampm like @ampm and
        a.gh_opera like @gh_opera and 
        isnull(a.name,'-1') like @name and
        isnull(p.p_bar_code,'') like @p_bar_code
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
        i.receipt_no,ledger_sn,
        p.p_bar_code        
order by
        a.gh_date,
        i.receipt_sn,
        unit_name,
        clinic_name,
        doctor_name,
        group_name,
        req_name,
        gh_sequence_f 