using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Model.User
{
    public class UserInfo
    {
        public int ID { get; set; }

        public string UserName { get; set; }

        public string PassWord { get; set; }

        public int DataStatus { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime UpdateTime { get; set; }

        public string Logo { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }
    }
}
