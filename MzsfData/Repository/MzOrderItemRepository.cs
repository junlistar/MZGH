using Dapper;
using MzsfData.Entities;
using MzsfData.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MzsfData.Repository
{
    public class MzOrderItemRepository : RepositoryBase<MzOrderItem>, IMzOrderItemRepository
    {
        CprChargesRepository chargesRepository = new CprChargesRepository();
        public List<MzOrderItem> GetMzOrderItem(string order_type,string py_code)
        {
            var sql = "";
            //西药
            if (order_type =="02")
            {
                sql = GetSqlByTag(221024);
                var para = new DynamicParameters();
                
                para.Add("@py_code", py_code + "%");
                para.Add("@d_code", "%");
                para.Add("@code", "%");
                para.Add("@name", "%");
                para.Add("@bill_item_code", "001");
                para.Add("@group_no", "000003");
                return Select(sql, para);
            }
            else if (order_type == "04")
            {
                //草药
                sql = GetSqlByTag(221025);
                var para = new DynamicParameters();
                para.Add("@py_code", py_code + "%");
                para.Add("@d_code", "%");
                para.Add("@code", "%");
                para.Add("@name", "%");
                para.Add("@bill_item_code", "002");
                para.Add("@group_no", "000004");
                return Select(sql, para); 
            }
            else if (order_type == "01")
            {
                //诊疗
                sql = GetSqlByTag(221026);
                var para = new DynamicParameters();
                para.Add("@py_code", py_code + "%");
                para.Add("@d_code", "%");
                para.Add("@code", "%");
                para.Add("@name", "%");
                para.Add("@bill_item_code", "%");
                para.Add("@group_no", "%");
                return Select(sql, para);
            }
            return new List<MzOrderItem>();
        } 

    }
}
