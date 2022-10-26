 --获取退款 父级ledger_sn
 select max(ledger_sn) from mz_detail_charge where parent_ledger_sn=@parent_ledger_sn