using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Helper;
using Models;

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
        //添加学员信息
        public int AddStudent(Student objStudent)
        {
            //【1】编写SQL语句         
            StringBuilder sqlBuilder = new StringBuilder();
            sqlBuilder.Append("insert into Students(studentName,Gender,Birthday,");
            sqlBuilder.Append("StudentIdNo,Age,PhoneNumber,StudentAddress,CardNo,ClassId,StuImage)");
            sqlBuilder.Append(" values('{0}','{1}','{2}',{3},{4},'{5}','{6}','{7}',{8},'{9}');select @@Identity");
            //【2】构建SQL语句对象
            string sql = string.Format(sqlBuilder.ToString(), objStudent.StudentName,
                     objStudent.Gender, objStudent.Birthday.ToString("yyyy-MM-dd"),
                    objStudent.StudentIdNo, objStudent.Age,
                    objStudent.PhoneNumber, objStudent.StudentAddress, objStudent.CardNo,
                    objStudent.ClassId, objStudent.StuImage);
            //【3】发起请求
            return Convert.ToInt32(SQLHelper.GetSingleResult(sql));
        }


    }
}
