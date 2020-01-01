using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    [Serializable]
    public class Admin
    {
        //用户账号
        public int LoginId { get; set; }
        //用户密码
        public string AdminName { get; set;}
        //用户名
        public string LoginPwd { get; set; }
    }
}
