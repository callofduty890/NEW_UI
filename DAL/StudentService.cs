using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Helper;

namespace DAL
{

    public class StudentService
    {

        //判断身份证信息是否已经存在
        public bool IsIdNoExisted(string studentIdNo)
        {
            //构建SQL语句
            string sql = "select count(*) from Students where StudentIdNo=" + studentIdNo;
            //发起请求
            int result = Convert.ToInt32(SQLHelper.GetSingleResult(sql));
            //判断结果
            if (result == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 判断卡号是否已经存在
        /// </summary>
        /// <param name="cardNo"></param>
        /// <returns></returns>
        public bool IsCardNoExisted(string cardNo)
        {
            string sql = string.Format("select count(*) from Students where CardNo='{0}'", cardNo);
            int result = Convert.ToInt32(SQLHelper.GetSingleResult(sql));
            //判断结果
            if (result == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
