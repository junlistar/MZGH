using Dapper;
using Data.Entities;
using Data.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class XTGroupRepository : RepositoryBase<XTGroup>, IXTGroupRepository
    {
   
        public List<XTGroup> GetXTGroupsBySysId(string subsys_id)
        {
            string ghsql = @"select * from xt_group where subsys_id = @subsys_id";
            var para = new DynamicParameters();

            para.Add("@subsys_id", subsys_id);
            return  Select(ghsql,para); 

        } 
    }
}
