 --添加电子发票信息
 insert into fp_data(patient_id, ledger_sn,  billBatchCode,  billNo,  random,  createTime,  billQRCode,  pictureUrl,  pictureNetUrl,  subsys_id)
                                values(@patient_id,@ledger_sn,@billBatchCode,@billNo,@random,@createTime,@billQRCode,@pictureUrl,@pictureNetUrl,@subsys_id)