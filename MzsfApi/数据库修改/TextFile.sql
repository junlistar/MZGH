--增加 外部订单号字段
alter table mz_deposit add out_trade_no varchar(30);
alter table mz_deposit_b add out_trade_no varchar(30);