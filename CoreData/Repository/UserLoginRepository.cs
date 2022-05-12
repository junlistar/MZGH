using Dapper;
using Data.Entities;
using Data.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class UserLoginRepository : RepositoryBase<LoginUsers>, IUserLoginRepository
    {

        public List<LoginUsers> GetLoginUser(string uname, string pwd)
        {
            string sql = @"SELECT xt_user.user_name,
         xt_user.subsys_id,   
         xt_user.user_group,
         xt_user.user_mi, 
         a_employee_mi.dept_sn,
          a_employee_mi.name
    FROM xt_user,   
         a_employee_mi  
   WHERE ( xt_user.user_mi = a_employee_mi.emp_sn ) and  
         ( ( xt_user.subsys_id = 'mzgh' ) AND  
         ( xt_user.user_name = @uname )  And
           xt_user.pass_word =@pwd )  ";

            if(string.IsNullOrEmpty(pwd) ){
                pwd = "";
            }

            var para = new DynamicParameters();
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
