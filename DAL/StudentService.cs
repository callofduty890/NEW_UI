using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
        //根据班级查询信息
        public List<Student> GetStudentsByClass(string ClassName)
        {
            //构建SQL语句
            string sql = "select StudentId,StudentName,Gender,StudentIdNo,Birthday,PhoneNumber,ClassName from Students";
            sql += " inner join StudentClass on Students.ClassId=StudentClass.ClassId";
            sql += " where ClassName='{0}'";
            //拼接SQL语句
            sql = string.Format(sql, ClassName);
            //调用执行
            SqlDataReader objReader = SQLHelper.GetReader(sql);
            //循环读取返回查询到的结果
            List<Student> list = new List<Student>();
            //
            while (objReader.Read())
            {
                list.Add(new Student()
                {
                    StudentId = Convert.ToInt32(objReader["StudentId"]),
                    StudentName = objReader["StudentName"].ToString(),
                    Gender = objReader["Gender"].ToString(),
                    PhoneNumber = objReader["PhoneNumber"].ToString(),
                    Birthday = Convert.ToDateTime(objReader["Birthday"]),
                    StudentIdNo = objReader["StudentIdNo"].ToString(),
                    ClassName = objReader["ClassName"].ToString()
                });
            }
            objReader.Close();
            return list;
        }
        //根据学号查询信息
        public Student GetStudentById(string studentId)
        {
            //构建SQL语句
            string sql = "select StudentId,StudentName,Gender,Birthday,ClassName,";
            sql += "StudentIdNo,PhoneNumber,StudentAddress,CardNo,StuImage from Students";
            sql += " inner join StudentClass on Students.ClassId=StudentClass.ClassId ";
            sql += " where StudentId=" + studentId;
            //开始查询
            //调用执行
            SqlDataReader objReader = SQLHelper.GetReader(sql);
            //接收返回值
            Student objstudent = null;
            if (objReader.Read())
            {
                objstudent = new Student()
                {
                    StudentId = Convert.ToInt32(objReader["StudentId"]),
                    StudentName = objReader["StudentName"].ToString(),
                    Gender = objReader["Gender"].ToString(),
                    Birthday = Convert.ToDateTime(objReader["Birthday"]),
                    ClassName = objReader["ClassName"].ToString(),
                    CardNo = objReader["CardNo"].ToString(),
                    StudentIdNo = objReader["StudentIdNo"].ToString(),
                    PhoneNumber = objReader["PhoneNumber"].ToString(),
                    StudentAddress = objReader["StudentAddress"].ToString(),
                    StuImage = objReader["StuImage"] == null ? "" : objReader["StuImage"].ToString()
                };
            }
            objReader.Close();
            return objstudent;
        }
    }
}
