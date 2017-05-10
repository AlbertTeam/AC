using Core.Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.IService.User
{
    public interface IUserDataAccess
    {
        #region 收藏
        int AddUserCollect(UserCollect model);
        IEnumerable<UserCollect> GetUserCollect(int userID);
        int DeleteCollect(int collectID);
        #endregion


        #region 用户

        UserInfo GetUserInfoByID(int userID);
        int InserUserInfo(UserInfo model);

        int UpdateUserInfo(UserInfo model);
        int UpdatePassWord(string pwd, int userID);
        #endregion
    }
}
