using Data.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Data.IRepository
{
    public interface IReportParamFastRepository : IRepositoryBase<ReportParam> 
    { 
        List<ReportParam> GetReportParam(string code);
         
    }
}
