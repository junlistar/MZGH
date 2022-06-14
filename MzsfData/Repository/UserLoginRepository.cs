using Dapper;
using MzsfData.Entities;
using MzsfData.IRepository;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace MzsfData.Repository
{
    public class UserLoginRepository : RepositoryBase<LoginUsers>, IUserLoginRepository
    {

        public List<LoginUsers> GetLoginUser(string uname, string pwd)
        {  
           

            string sql = GetSqlByTag(221001);
            if (string.IsNullOrEmpty(pwd) ){
                pwd = "";
            }
            var para = new DynamicParameters();
            para.Add("@uname", uname);
            para.Add("@uname", uname);
            para.Add("@pwd", pwd);

            return Select(sql, para);

        }

        //public int DeleteUser(Guid Id)
        //{
        //    string deleteSql = "DELETE FROM [dbo].[Users] WHERE Id=@Id";
        //    return Delete(Id, deleteSql);
        //}

        //public string ExecExecQueryParamSP(string spName, string name, int Id)
        //{
        //    using (IDbConnection conn = DataBaseConfig.GetSqlConnection())
        //    {
        //        DynamicParameters parameters = new DynamicParameters();
        //        parameters.Add("@UserName", name, DbType.String, ParameterDirection.Output, 100);
        //        parameters.Add("@Id", Id, DbType.String, ParameterDirection.Input);
        //        conn.Execute(spName, parameters, null, null, CommandType.StoredProcedure);
        //        string strUserName = parameters.Get<string>("@UserName");
        //        return strUserName;
        //    }
        //}

        //public async Task<Users> GetUserDetail(Guid Id)
        //{
        //    string detailSql = @"SELECT Id, UserName, Password, Gender, Birthday, CreateDate, IsDelete FROM [dbo].[Users] WHERE Id=@Id";
        //    return await Detail(Id, detailSql);
        //}

        //public async Task<List<Users>> GetUsers()
        //{
        //    string selectSql = @"SELECT Id, UserName, Password, Gender, Birthday, CreateDate, IsDelete FROM [dbo].[Users]";
        //    return await Select(selectSql);
        //}

        //public async Task PostUser(Users entity)
        //{
        //    string insertSql = @"INSERT INTO [dbo].[Users](Id, UserName, Password, Gender, Birthday, CreateDate, IsDelete) VALUES(@Id, @UserName, @Password, @Gender, @Birthday, @CreateDate, @IsDelete)";
        //    await Insert(entity, insertSql);
        //}

        //public async Task PutUser(Users entity)
        //{
        //    string updateSql = "UPDATE [dbo].[Users] SET UserName=@UserName, Password=@Password, Gender=@Gender, Birthday=@Birthday, CreateDate=@CreateDate, IsDelete=@IsDelete WHERE Id=@Id";
        //    await Update(entity, updateSql);
        //}
    }
}
