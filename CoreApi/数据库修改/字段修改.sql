--用户信息表 增加医保支付数据字段
if not exists(select * from syscolumns where id=object_id('mz_patient_mi') and name='yb_psn_no') begin
ALTER TABLE mz_patient_mi ADD yb_psn_no  varchar(30) default (null)
end
if not exists(select * from syscolumns where id=object_id('mz_patient_mi') and name='yb_insutype') begin
ALTER TABLE mz_patient_mi ADD yb_insutype  varchar(10) default (null)
end
if not exists(select * from syscolumns where id=object_id('mz_patient_mi') and name='yb_insuplc_admdvs') begin
ALTER TABLE mz_patient_mi ADD yb_insuplc_admdvs  varchar(10) default (null)
end



--fastreport报表 新建表
USE [his]
GO

/****** Object:  Table [dbo].[rt_report_data_fast]    Script Date: 2022-06-06 10:13:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[rt_report_data_fast_net](
	[report_code] [int] NOT NULL,
	[short_name] [char](20) NOT NULL,
	[long_name] [char](40) NULL,
	[report_sql] [text] NULL,
	[report_com] [image] NULL,
	[report_flag] [char](1) NULL,
	[datasetn] [int] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
 

CREATE TABLE [dbo].[rt_report_params_fast_net](
	[report_code] [int] NOT NULL,
	[param_name] [varchar](20) NOT NULL,
	[param_label] [char](20) NULL,
	[param_type] [varchar](12) NULL,
	[param_defaultvalue] [varchar](8000) NULL,
	[sqltag] [int] NULL,
	[sort_no] [smallint] NULL,
	[datasql] [varchar](500) NULL,
	[mul_choice] [varchar](50) NULL
) ON [PRIMARY]

GO
 
--生成号表  存储过程
USE [his]
GO

/****** Object:  Table [dbo].[gh_request_list]    Script Date: 2022-06-06 8:59:40 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[gh_request_list](
	[record_sn] [int] NOT NULL,
	[req_no] [smallint] NOT NULL,
	[out_type] [varchar](2) NULL,
	[start_time] [varchar](5) NULL,
	[end_time] [varchar](5) NULL,
	[isout_flag] [char](1) NULL,
	[op_date] [datetime] NULL,
	[section_number] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[record_sn] ASC,
	[req_no] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO



CREATE TABLE [dbo].[gh_zd_request_time](
	[Section_number] [int] NULL,
	[Section_number_comment] [varchar](50) NULL,
	[start_time] [time](7) NULL,
	[end_time] [time](7) NULL,
	[ampm] [varchar](1) NULL
) ON [PRIMARY]
GO


insert gh_zd_request_time

select 

'1'	,'08:00 至 08:30'	,'08:00:00.0000000',	'08:29:59.0000000',	'a'
union all 
select 
'2'	,'08:30 至 09:00'	,'08:30:00.0000000',	'08:59:59.0000000'	,'a'
union all 
select 
'3'	,'09:00 至 09:30',	'09:00:00.0000000',	'09:29:59.0000000'	,'a'
union all 
select 
'4',	'09:30 至 10:00'	,'09:30:00.0000000',	'09:59:59.0000000'	,'a'
union all 
select 
'5',	'10:00 至 10:30'	,'10:00:00.0000000',	'10:29:59.0000000'	,'a'
union all 
select 
'6',	'10:30 至 11:00',	'10:30:00.0000000',	'10:59:59.0000000'	,'a'
union all 
select 
'7'	,'11:00 至 11:30'	,'11:00:00.0000000',	'11:29:59.0000000'	,'a'
union all 
select 
'8'	,'11:30 至 12:00'	,'11:30:00.0000000',	'11:59:59.0000000'	,'a'
union all 
select 
'9'	,'14:00 至 14:30',	'14:00:00.0000000',	'14:29:59.0000000'	,'p'
union all 
select 
'10',	'14:30 至 15:00',	'14:30:00.0000000',	'14:59:59.0000000'	,'p'
union all 
select 
'11',	'15:00 至 15:30',	'15:00:00.0000000',	'15:29:59.0000000'	,'p'
union all 
select 
'12',	'15:30 至 16:00',	'15:30:00.0000000',	'15:59:59.0000000'	,'p'
union all 
select 
'13',	'16:00 至 16:30',	'16:00:00.0000000',	'16:29:59.0000000'	,'p'
union all 
select 
'14',	'16:30 至 17:00',	'16:30:00.0000000',	'16:59:59.0000000'	,'p'




USE [his]
GO

/****** Object:  StoredProcedure [dbo].[mzgh_CreateRequestNo_List]    Script Date: 2022-06-06 9:00:40 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


/*  
功能：荆州中心医院预约分时挂号的号源表生成过程  
参数：  
    @Op_type 操作类别，1:生成，2：重新生成，3：补生成  
    @sDate   生成号源表开始日期  
    @eDate   生成号源表结束日期  
    @Dept    生成的科室，%表示全部  
    @Doctor  生成的医生，%表示全部  
 返回：0，成功，非0，失败   
    
  exec mzgh_CreateRequestNo_List '1','2018-06-08','2018-06-08'      
*/  
alter Proc [dbo].[mzgh_CreateRequestNo_List]   
   @Op_type smallint ,  
   @sDate datetime,  
   @eDate datetime,  
   @Dept varchar(10)='%',  
   @Doctor varchar(10)='%'  
as  
  
declare @errcode integer  
DECLARE @ErrorMessage NVARCHAR(4000)  
declare @start_time varchar(10),@end_time varchar(10),@mid_time varchar(10),@eve_time varchar(10) 
declare @amss dec(12, 2)  
declare @pmss dec(12, 2)  
declare @midss dec(12, 2)
declare @evess dec(12, 2)
/*  
set @Op_type=2  
set @sDate='2017-10-16'  
set @eDate='2017-10-20 23:00:00'  
set @Dept='%'  
set @Doctor='%'  
*/
begin try   

set @start_time='08:00:00' --上午上班时间
set @mid_time='12:00:00'  --中午上班时间
set @end_time='14:00:00'  --下午上班时间
set @eve_time='19:00:00'  --夜间上班时间
set @amss=4 * 60 *60 --上午工作秒数  
set @pmss=3 * 60 *60 --下午工作秒数  
set @midss=2 * 60 *60 --中午工作秒数  
set @evess=2 * 60 *60 --夜间工作秒数  
if (@Op_type=2)  --删除  
begin  
  if exists(select * from gh_request a inner join gh_request_list b  on a.record_sn=b.record_sn 
           where  b.isout_flag='1' and isnull(a.unit_sn,'') like @Dept and isnull(a.doctor_sn,'') like @Doctor and   
            DATEDIFF(DD,a.request_date ,@sDate)<=0  and DATEDIFF(DD,a.request_date,@eDate) >=0)  
   begin   
       select 1 as Errcode,'已有挂出的号,不能重新生成' as ErrText  
     return   
   end  
   else   
   begin  
     delete gh_request_list  
     from gh_request a  
     where a.record_sn=gh_request_list.record_sn and isnull(a.unit_sn,'') like @Dept and isnull(a.doctor_sn,'') like @Doctor and   
     DATEDIFF(DD,a.request_date ,@sDate)<=0  and DATEDIFF(DD,a.request_date,@eDate) >=0  
   end  
end  
  
/*生成前，判断是否号源已经生成了*/  
if (@Op_type=1)    
begin  
  if exists(select * from gh_request a inner join  gh_request_list b on a.record_sn=b.record_sn 
           where  isnull(a.unit_sn,'') like @Dept and isnull(a.doctor_sn,'') like @Doctor and   
           DATEDIFF(DD,a.request_date ,@sDate)<=0  and DATEDIFF(DD,a.request_date,@eDate) >=0)  
    begin           
      select 1 as Errcode,'号源表已经生成，不能重复生成' as ErrText  
      return  
    end  
end  

select record_sn,1 as begin_no,abs(end_no - begin_no) +1 as end_no,ampm 
into  #req_tmp1 
from gh_request aa  
where DATEDIFF(DD,aa.request_date ,@sDate)<=0  and 
      DATEDIFF(DD,aa.request_date,@eDate) >=0  and 
      (isnull(aa.unit_sn,'') like @Dept)   and 
      (isnull(aa.doctor_sn,'') like @Doctor) and
       not exists(select record_sn from gh_request_list bb where aa.record_sn=bb.record_sn)
  
--if (@Op_type=1 or @Op_type=2)   
begin    
 select top  300 IDENTITY(integer,1,1) as req_no,  
     cast(CONVERT(char(10),GETDATE(),21)++' ' + @start_time as datetime) am, /*上午开始上班时间*/    
     cast(CONVERT(char(10),GETDATE(),21)++' ' + @mid_time as datetime) mid, /*中午开始上班时间*/ 
     cast(CONVERT(char(10),GETDATE(),21)+' '+@end_time as datetime) pm, /*下午开始上班时间*/  
     cast(CONVERT(char(10),GETDATE(),21)+' ' + @eve_time as datetime) eve /*夜间开始上班时间*/ 
  into #req_tmp  
 from gh_base_request  
  

 select a.record_sn,b.req_no,  
 RIGHT(CONVERT(varchar(16),case a.ampm when 'a' then DATEADD(ss,(b.req_no -1) * (CEILING(@amss /(end_no - begin_no +1))),am)
					when 'm' then DATEADD(ss,(b.req_no -1) * (CEILING(@midss /(end_no - begin_no +1))),mid)   
					when 'p' then DATEADD(ss,(b.req_no -1) * (CEILING(@pmss /(end_no - begin_no +1))),pm)    
					else DATEADD(ss,(b.req_no-1) *(CEILING(@evess  /(end_no - begin_no+ 1 ))),eve) end,21),5) as start_time,
 RIGHT(CONVERT(varchar(16),case a.ampm when 'a' then DATEADD(ss,b.req_no * (CEILING(@amss /(end_no - begin_no +1))) ,am)  
					when 'm' then DATEADD(ss,(b.req_no) * (CEILING(@midss /(end_no - begin_no +1))),mid)   
					when 'p' then DATEADD(ss,(b.req_no) * (CEILING(@pmss /(end_no - begin_no +1))),pm)    
					else DATEADD(ss,b.req_no * (CEILING(@evess  /(end_no - begin_no+1 ))) ,eve) end,21),5)    
  as end_time,  
  '0' as isout_flag 
  into #request   
 from #req_tmp  b  FULL join #req_tmp1 a  on b.req_no>=1  and b.req_no <=abs(a.end_no - a.begin_no) +1 
  
 
  insert into  gh_request_list(record_sn,req_no,start_time,end_time,isout_flag, section_number)  
  select record_sn,req_no,start_time,end_time,isout_flag,
  (select top 1 Section_number from gh_zd_request_time b where a.start_time >= b.start_time and a.start_time<=b.end_time) 
   as section_number
  from #request a
  where not record_sn is null

  drop  table #req_tmp
  drop  table #req_tmp1
  drop  table #request  
  select 0 as Errcode,'号源表生成成功' as ErrText  
end  
return  
end try  
begin catch  
  select  @errcode=@@ERROR ,@ErrorMessage=ERROR_MESSAGE ()     
  select @errcode as  Errcode,@ErrorMessage as ErrText  
end catch    

GO




USE [his]
GO

/****** Object:  StoredProcedure [dbo].[mzgh_GetRequestNo_Hour]    Script Date: 2022-06-06 9:01:18 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/*  
功能：分时挂号的挂号的号码读取  
参数：@out_flag:挂号来源  
        01：手工号，查询最小的可挂号码  
        02：自助机，查询最小的可挂号码  
        03：预约号，判断需要挂号码是否挂出，如果挂出就取满足条件的号，未挂出就返回当前号  
    @record_sn: 号源表的记录号  
    @request_no：挂号的号码，手工挂号，自助机挂号=0，预约挂号：挂出号码  
 返回：成功返回不为0的号，失败为0  
*/  
CREATE proc [dbo].[mzgh_GetRequestNo_Hour]   
  @out_flag varchar(10),  
  @record_sn integer ,  
  @request_no integer  
as   
  declare @out_no integer /*返回可挂号的号码*/  
  declare @out_text varchar(100)  
  if (@out_flag='01') or (@out_flag='02')   
 begin  
   select top 1 @out_no=req_no from gh_request_list a left join gh_request b on a.record_sn=b.record_sn  
                 where a.record_sn=@record_sn and isnull(isout_flag,'0')='0'   
				    
				      --中医院分时段要求开启只能挂之后的号段，除了急诊和儿科
                      and (( datediff(dd,b.request_date,getdate())<=0  
                      and convert(time,getdate(),21)<=end_time) or  b.unit_sn in('1040201','1011001')) 
                order by req_no   
    if @@ROWCOUNT=0   
  set @out_text='号码已挂完'  
 end  
  if (@out_flag='03')   
 begin  
   if EXISTS(select * from gh_request_list where record_sn=@record_sn and req_no=@request_no   
    and isnull(isout_flag,'0')='0' and (req_no % 2) =1 )   
  set @out_no =@request_no  
   else   
   begin  
  select top 1 @out_no=req_no from gh_request_list   
  where record_sn=@record_sn and isnull(isout_flag,'0')='0'    
    and (req_no % 2) =1 /*暂时预约定义取奇数最小号码*/  
  order by req_no   
  set @out_text= CONVERT(varchar,@request_no)+'号已经挂出，自动产生一个新号'  
   end  
 end  
  select isnull(@out_no,0) as  out_request_no,@out_text as out_msg
GO



CREATE TABLE [dbo].[gh_zd_request_hour](
	[code] [varchar](10) NULL,
	[name] [varchar](10) NULL,
	[start_hour] [smallint] NULL,
	[end_hour] [smallint] NULL
) ON [PRIMARY]

GO

 insert gh_zd_request_hour
 select 'a','上午',0,12
 union all
 select 'm','中午',12,14
 union all
 select 'p','下午',14,17
 union all
 select 'e','夜间',19,21 

--增加 外部订单号字段
alter table gh_deposit add out_trade_no varchar(30);
alter table gh_deposit_b add out_trade_no varchar(30);


--增加 外部订单号字段
alter table mz_deposit add out_trade_no varchar(30);
alter table mz_deposit_b add out_trade_no varchar(30)

 
CREATE TABLE [dbo].[mz_patient_sfz](
	[patient_id] [varchar](30) NULL,
	[sfz_id] [varchar](30) NULL
) ON [PRIMARY]

 
 insert into gh_zd_clinic_type(code,name,py_code,d_code,deleted_flag)
 values(38,'24小时号','24XSH','24XSH','1')
GO 