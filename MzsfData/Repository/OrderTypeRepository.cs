using Dapper;
using MzsfData.Entities;
using MzsfData.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MzsfData.Repository
{
    public class OrderTypeRepository : RepositoryBase<OrderType>, IOrderTypeRepository
    { 
        public List<OrderType> GetOrderTypes()
        { 
            string ghsql = GetSqlByTag(221023);
             
            return Select(ghsql);
        } 
    }
}
