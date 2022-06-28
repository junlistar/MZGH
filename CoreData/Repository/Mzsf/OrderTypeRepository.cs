using Dapper;
using Data.Entities.Mzsf;
using Data.IRepository.Mzsf;
using System;
using System.Collections.Generic;


namespace Data.Repository.Mzsf
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
