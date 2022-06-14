using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Newtonsoft.Json;
using System.Web.Script.Serialization;


namespace MzsfData.Helpers
{
    public static class DataTableHelper
    {

        /// <summary>
        /// DataTable转json字符串方法一
        /// </summary>
        /// <param name="dataTable"></param>
        /// <returns></returns>
        public static string ToJson(this DataTable dataTable)
        {
            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            javaScriptSerializer.MaxJsonLength = Int32.MaxValue; //取得最大数值
            ArrayList arrayList = new ArrayList();
            foreach (DataRow row in dataTable.Rows)
            {
                Dictionary<string, object> dictionary = new Dictionary<string, object>();  //实例化一个参数集合
                foreach (DataColumn dataColumn in dataTable.Columns)
                {
                    dictionary.Add(dataColumn.ColumnName, row[dataColumn.ColumnName].ToString());
                }
                arrayList.Add(dictionary); //ArrayList集合中添加键值
            }
            return javaScriptSerializer.Serialize(arrayList);  //返回一个json字符串
        }


        /// <summary>
        /// DataTable转json字符串方法二
        /// </summary>
        /// <param name="dataTable"></param>
        /// <returns></returns>
        public static string DataTableToJson(DataTable dataTable)
        {
            string JsonString = string.Empty;
            JsonString = JsonConvert.SerializeObject(dataTable);
            return JsonString;
        }


        /// <summary>
        /// 将JSON转化为DataTable
        /// </summary>
        /// <param name="json">json字符串</param>
        /// <returns></returns>
        public static DataTable ToDataTable(this string json)
        {
            DataTable dataTable = new DataTable();  //实例化
            DataTable result;
            try
            {
                JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
                javaScriptSerializer.MaxJsonLength = Int32.MaxValue; //取得最大数值
                ArrayList arrayList = javaScriptSerializer.Deserialize<ArrayList>(json);
                if (arrayList.Count > 0)
                {
                    foreach (Dictionary<string, object> dictionary in arrayList)
                    {
                        if (dictionary.Keys.Count<string>() == 0)
                        {
                            result = dataTable;
                            return result;
                        }
                        if (dataTable.Columns.Count == 0)
                        {
                            foreach (string current in dictionary.Keys)
                            {
                                dataTable.Columns.Add(current, dictionary[current].GetType());
                            }
                        }
                        DataRow dataRow = dataTable.NewRow();
                        foreach (string current in dictionary.Keys)
                        {
                            dataRow[current] = dictionary[current];
                        }
                        dataTable.Rows.Add(dataRow); //循环添加行到DataTable中
                    }
                }
            }
            catch
            {
            }
            result = dataTable;
            return result;
        }
    }

}
