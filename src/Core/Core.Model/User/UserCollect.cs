using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Model.User
{
    public class UserCollect
    {
        public int ID { get; set; }

        public string Content { get; set; }

        public int UserID { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
