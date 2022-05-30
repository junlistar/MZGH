using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic; 


namespace Data.Helpers
{
    public class TagSqlHelper: RepositoryBase<string>
    {
        public static Dictionary<int, string> sql_dics = new Dictionary<int, string>();

        static TagSqlHelper()
        {
            
        }
        public void GetSqlByTag(int tag)
        {
            string sql = "select * from wh_tag_sql where description like '挂号-%'";
            var dt = ExecuteTable(sql);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var row = dt.Rows[i];
                sql_dics.Add(Convert.ToInt32(row["tag"]), row["sql"].ToString());
            }
        }
    }
}
