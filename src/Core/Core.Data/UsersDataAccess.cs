using Core.Connection;
using Core.IService;
using Core.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Core.Data
{
    [Export(typeof(IUsersService))]
    public class UsersDataAccess: IUsersService
    {
        [Import]
        protected ICoreConnection Connection { set; get; }

        public int InsertUser(Users entity)
        {
            string sql = @"INSERT INTO [dbo].[Users]
                           ([UserName]
                           ,[PassWord]
                           ,[DataStatus]
                           ,[CreateTime]
                           ,[UpdateTime]
                           ,[Logo]
                           ,[Email]
                           ,[Phone])
                     VALUES
                           (@UserName
                           ,@PassWord
                           ,@DataStatus
                           ,@CreateTime
                           ,@UpdateTime
                           ,@Logo
                           ,@Email
                           ,@Phone)";
            return Connection.ConnectionClien().Execute(sql, entity);
        }
    }
}
