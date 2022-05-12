using Dapper;
using Data.Entities;
using Data.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class ClinicTypeRepository : RepositoryBase<ClinicType>, IClinicTypeRepository
    {
   
        public List<ClinicType> GetClinicTypes()
        {
            string ghsql = "select * from gh_zd_clinic_type where deleted_flag=0";
             
            return  Select(ghsql);


        }

        public List<ClinicType> GetRequestTypes()
        {
            string ghsql = "select * from gh_zd_request_type where deleted_flag=0";

            return Select(ghsql);


        }
    }
}
