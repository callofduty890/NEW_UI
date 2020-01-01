using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//引用动态链接库
using Models;
using DAL.Helper;
using System.Data.SqlClient;

namespace DAL
{
    public class AdminService
    {
        //根据用户账号和密码登录
        public Admin AdminLogin(Admin objAdmin)
        {
            //构建查询语句
            string sql = "select LoginId,LoginPwd,AdminName from Admins where LoginId={0} and LoginPwd={1}";
            sql = string.Format(sql, objAdmin.LoginId, objAdmin.LoginPwd);
            //向数据库发送请求
            SqlDataReader objReader = SQLHelper.GetReader(sql);
            //判断是否读取成功
            if (objReader.Read())
            {
                //对用户进行赋值
                objAdmin.AdminName = objReader["AdminName"].ToString();
                //关闭
                objReader.Close();
            }
            else
            {
                objAdmin = null;
            }
            //返回处理结果
            return objAdmin;
        }
    }
}
