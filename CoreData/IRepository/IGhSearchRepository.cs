using Data.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.IRepository
{
    public interface IGhSearchRepository : IRepositoryBase<GhSearch> 
    {
        #region 扩展的dapper操作

        List<GhSearch> GhSearchList(string gh_date, string visit_dept = "%", string clinic_type = "%", string doctor_code = "%",
            string group_sn = "%", string req_type = "%", string ampm = "%", string gh_opera = "%",
            string name = "%", string p_bar_code = "%");


        #endregion
    }
}
