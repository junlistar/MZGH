﻿using Dapper;
using Data.Entities;
using Data.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class UnitRepository : RepositoryBase<Unit>, IUnitRepository
    {
   
        public List<Unit> GetUnits()
        {
            string selectSql = @"select   zd_unit_code.code,
       zd_unit_code.name,
       zd_unit_code.py_code,
       zd_unit_code.d_code,
       zd_unit_code.unit_sn
from zd_unit_code
where  
      zd_unit_code.deleted_flag = '0'
order by code";


            return  Select(selectSql);


        }
 
    }
}
