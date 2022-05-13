using Dapper;
using Data.Entities;
using Data.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class MzHaomingRepository : RepositoryBase<MzHaoming>, IMzHaomingRepository
    {
   
        public List<MzHaoming> GetMzHaomings()
        {
            string ghsql = @"SELECT * from mz_zd_haoming WHERE mz_zd_haoming.delete_flag = '0' ORDER BY mz_zd_haoming.sort_order ASC";
             
            return  Select(ghsql);


        } 
    }
}
