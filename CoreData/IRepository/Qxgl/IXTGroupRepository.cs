using Data.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.IRepository
{
    public interface IXTGroupRepository : IRepositoryBase<XTGroup> 
    {
        #region 扩展的dapper操作


        List<XTGroup> GetXTGroupsBySysId(string subsys_id);
         

        #endregion
    }
}
