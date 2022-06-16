--221010 门诊收费 - 更新虚拟库存处理
declare @amount int
declare @fu int
declare @charge_code varchar(10)
declare @serial varchar(5)
declare @group varchar(10)
declare @DecRealStock char(1)
declare @DrugInfo varchar(100)
declare @GroupInfo varchar(50)
declare @ErrorInfo varchar(200)

set @amount=@P1
set @fu=@P2
set @charge_code=@P3
set @serial=@P4
set @group=@P5
set @DecRealStock='0'   --0不减实库存

set nocount on
--获取药品及库房信息
SELECT @GroupInfo = '库房：' + dept_name + '(' + @group + ')' FROM yp_group_name WHERE group_no = @group 

SELECT @DrugInfo = '药品：' + drugname + '/' + specification + '(' + @charge_code + '/' + @serial + ')'
    FROM yp_dict WHERE charge_code = @charge_code and serial = @serial

if exists(select * from sysobjects where id=object_id('mz_sys_config') and type='U')
begin
  if exists(select * from mz_sys_config where item_name='DecRealStock' and subsys_id='mz' and current_value='1')
    set @DecRealStock='1'
end

if @DecRealStock='0'     --减虚库存
begin
  UPDATE yp_base SET stock_amount2=stock_amount2 - @amount * @fu
  WHERE charge_code=@charge_code AND serial=@serial AND group_no=@group

  if exists(select * from yp_base WHERE charge_code=@charge_code AND serial=@serial AND group_no=@group and stock_amount2<0)
  begin
    set @ErrorInfo = '库存量低于本次收费数量!' + CHAR(13) + @GroupInfo + CHAR(13) + @DrugInfo 
    raiserror(@ErrorInfo,10,1) --raiserror 99999 @ErrorInfo
  end
end
else         --虚实库存都减
begin
  UPDATE yp_base SET stock_amount2=stock_amount2 - @amount * @fu,
     stock_amount=stock_amount - @amount * @fu
  WHERE charge_code=@charge_code AND serial=@serial AND group_no=@group

  if exists(select * from yp_base WHERE charge_code=@charge_code AND serial=@serial AND group_no=@group and stock_amount<0)
  begin
    set @ErrorInfo = '实库存量低于本次收费数量!' + CHAR(13) + @GroupInfo + CHAR(13) + @DrugInfo 
     raiserror(@ErrorInfo,10,1)/*raiserror 99999  @ErrorInfo */
  end;
end