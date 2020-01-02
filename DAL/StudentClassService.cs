using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Models;
using DAL.Helper;

namespace DAL
{
    public class StudentClassService
    {
        //获取所有班级名称
        public List<StudentClass> GetAllClasses()
        {
            //构建SQL语句
            string sql = "select ClassId,ClassName from StudentClass";
            //传入SQL接受对象
            SqlDataReader objReader = SQLHelper.GetReader(sql);
            //创建对象接收
            List<StudentClass> list = new List<StudentClass>();
            //循环添加
            while (objReader.Read())
            {
                list.Add(new StudentClass()
                {
                    ClassId=Convert.ToInt32(objReader["ClassId"]),
                    ClassName=objReader["ClassName"].ToString()
                });
            }
            objReader.Close();
            return list;
        }
    }
}
