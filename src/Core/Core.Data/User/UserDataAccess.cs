using Core.Connection;
using Core.Model.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Core.IService.User;

namespace Core.Data.User
{
   
    internal class UserDataAccess: IUserDataAccess
    {

        [Import]
        protected ICoreConnection Connection { set; get; }
        #region 用户收藏


        /// <summary>
        /// 获取用户收藏
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public IEnumerable<UserCollect> GetUserCollect(int userID)
        {
            string sql = "";
            using (IDbConnection conn = Connection.ConnectionClien(DBString.Query_AI))
            {
                return conn.Query<UserCollect>(sql, new { userID = userID });
            }
        }

        /// <summary>
        /// 添加用户收藏
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddUserCollect(UserCollect model)
        {
            string sql = @"INSERT INTO [dbo].[UserCollect]
                                            ([Content]
                                            ,[UserID]
                                            ,[CreateDate])
                                        VALUES
                                            (@Content
                                            ,@UserID
                                            ,@CreateDate)";
            using (IDbConnection conn = Connection.ConnectionClien(DBString.Action_AI))
            {
                return conn.Execute(sql, model);
            }
        }
        /// <summary>
        /// 删除收藏
        /// </summary>
        /// <param name="collectID"></param>
        /// <returns></returns>
        public int DeleteCollect(int collectID)
        {
            string sql = "DELETE FROM dbo.UserCollect WHERE ID=@ID";
            using (IDbConnection conn = Connection.ConnectionClien(DBString.Action_AI))
            {
                return conn.Execute(sql, new { ID = collectID });
            }
        }

        #endregion

        #region 用户信息
        /// <summary>
        /// 根据用户ID查询用户信息
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public UserInfo GetUserInfoByID(int userID)
        {
            string sql = "SELECT * FROM dbo.UserInfo WHERE ID=@userID";
            using (IDbConnection conn = Connection.ConnectionClien(DBString.Action_AI))
            {
                return conn.QueryFirst<UserInfo>(sql, new { userID = userID });
            }
        }

        /// <summary>
        /// 新增用户,返回的是用户的ID
        /// </summary>
        /// <param name="model"></param>
        public int InserUserInfo(UserInfo model)
        {
            string sql = @"INSERT INTO [dbo].[UserInfo]
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
                                           ,@Phone)
                            SELECT @@identity";
            using (IDbConnection conn = Connection.ConnectionClien(DBString.Action_AI))
            {
                return conn.Execute(sql, model);
            }
        }
        /// <summary>
        /// 更新用户信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateUserInfo(UserInfo model)
        {
            string sql = @"UPDATE [dbo].[UserInfo]
                               SET [UserName] = @UserName
                                  ,[PassWord] = @PassWord
                                  ,[DataStatus] = @DataStatus
                                  ,[UpdateTime] = @UpdateTime
                                  ,[Logo] = @Logo
                                  ,[Email] = @Email
                                  ,[Phone] = @Phone
                             WHERE ID=@ID";
            using (IDbConnection conn = Connection.ConnectionClien(DBString.Action_AI))
            {
                return conn.Execute(sql, model);
            }
        }

        /// <summary>
        /// 更新密码
        /// </summary>
        /// <param name="pwd"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        public int UpdatePassWord(string pwd, int userID)
        {
            string sql = @"UPDATE  dbo.UserInfo
                                SET     PassWord = @pwd ,
                                        UpdateTime = GETDATE()
                                WHERE   ID = @userID;";

            using (IDbConnection conn = Connection.ConnectionClien(DBString.Action_AI))
            {
                return conn.Execute(sql, new { pwd = pwd, userID = userID });
            }
        }
        #endregion
    }

}
