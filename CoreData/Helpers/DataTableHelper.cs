using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Newtonsoft.Json;
using System.Web.Script.Serialization;


namespace CoreData.Helpers
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

        /// <summary>
        /// DataTable通过反射获取单个对象
        /// </summary>
        public static T ToSingleModel<T>(this DataTable data) where T : new()
        {
            if (data != null && data.Rows.Count > 0 && data.Rows.Count < 2)
                return data.GetList<T>(null, true).Single();
            return default(T);
        }
        public static List<T> ToModels<T>(this DataTable data) where T : new()
        {
            if (data != null && data.Rows.Count > 0 && data.Rows.Count < 2)
                return data.GetList<T>(null, true);
            return new List<T>();
        }
        private static List<T> GetList<T>(this DataTable data, string prefix, bool ignoreCase = true) where T : new()
        {
            List<T> t = new List<T>();
            int columnscount = data.Columns.Count;
            if (ignoreCase)
            {
                for (int i = 0; i < columnscount; i++)
                    data.Columns[i].ColumnName = data.Columns[i].ColumnName.ToUpper();
            }
            try
            {
                var properties = new T().GetType().GetProperties();

                var rowscount = data.Rows.Count;
                for (int i = 0; i < rowscount; i++)
                {
                    var model = new T();
                    foreach (var p in properties)
                    {
                        var keyName = prefix + p.Name + "";
                        if (ignoreCase)
                            keyName = keyName.ToUpper();
                        for (int j = 0; j < columnscount; j++)
                        {
                            if (data.Columns[j].ColumnName == keyName && data.Rows[i][j] != null)
                            {
                                string pval = data.Rows[i][j].ToString();
                                if (!string.IsNullOrEmpty(pval))
                                {
                                    try
                                    {
                                        if (p.PropertyType.IsGenericType && p.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                                        {
                                            p.SetValue(model, Convert.ChangeType(data.Rows[i][j], p.PropertyType.GetGenericArguments()[0]), null);
                                        }
                                        else
                                        {
                                            p.SetValue(model, Convert.ChangeType(data.Rows[i][j], p.PropertyType), null);
                                        }
                                    }
                                    catch (Exception x)
                                    {
                                        throw x;
                                    }
                                }
                                break;
                            }
                        }
                    }
                    t.Add(model);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return t;
        }
        public static DataSet GetDataSet(IDataReader reader)
        {
            DataTable table = new DataTable();
            int fieldCount = reader.FieldCount;

            for (int i = 0; i < fieldCount; i++)
            {
                table.Columns.Add(reader.GetName(i), reader.GetFieldType(i));
            }

            table.BeginLoadData();
            object[] values = new object[fieldCount];
            while (reader.Read())
            {
                reader.GetValues(values);
                table.LoadDataRow(values, true);
            }

            table.EndLoadData();

            DataSet ds = new DataSet();
            ds.Tables.Add(table);

            return ds;
        }

    }

}
