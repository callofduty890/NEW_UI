using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

using Models;
using DAL;

namespace StudentManager
{
    public partial class FrmEditStudent : Form
    {
        //实例化学生班级操作对象
        private StudentClassService objClassService = new StudentClassService();
        //实例化学生操作类
        private StudentService objStudentService = new StudentService();


        public FrmEditStudent()
        {
            InitializeComponent();
        }

        public FrmEditStudent(Student objStudent) :this()
        {
            //初始化班级下拉框
            this.cboClassName.DataSource = objClassService.GetAllClasses();
            this.cboClassName.DisplayMember = "ClassName";//设置下拉框的显示文本
            this.cboClassName.ValueMember = "ClassId";//设置下拉框显示文本对应的value
            //显示学生信息
            this.txtStudentId.Text = objStudent.StudentId.ToString();
            this.txtStudentIdNo.Text = objStudent.StudentIdNo;
            this.txtStudentName.Text = objStudent.StudentName;
            this.txtPhoneNumber.Text = objStudent.PhoneNumber;
            this.txtAddress.Text = objStudent.StudentAddress;
            if (objStudent.Gender == "男")
            {
                this.rdoMale.Checked = true;
            }
            else
            {
                this.rdoFemale.Checked = true;
            }
            this.cboClassName.Text = objStudent.ClassName;
            this.dtpBirthday.Text = objStudent.Birthday.ToShortDateString();
            this.txtCardNo.Text = objStudent.CardNo;
            //显示照片
            this.pbStu.Image = Image.FromFile("default.png"); ;
        }

        //提交修改
        private void btnModify_Click(object sender, EventArgs e)
        {
            #region 数据验证
            //学生姓名不能空
            if (this.txtStudentName.Text.Trim().Length == 0)
            {
                MessageBox.Show("学生信息不能为空!", "提示信息");
                return;
            }
            //考勤卡号
            if (this.txtCardNo.Text.Trim().Length == 0)
            {
                MessageBox.Show("考勤卡号不能为空！", "提示信息");
                this.txtCardNo.Focus();
                return;
            }
            //验证性别
            if (!this.rdoFemale.Checked && !this.rdoMale.Checked)
            {
                MessageBox.Show("请选择学生性别！", "提示信息");
                return;
            }
            //验证班级
            if (this.cboClassName.SelectedIndex == -1)
            {
                MessageBox.Show("请选择班级！", "提示信息");
                return;
            }
            //验证年龄
            int age = DateTime.Now.Year - Convert.ToDateTime(this.dtpBirthday.Text).Year;
            if (age > 35 && age < 18)
            {
                MessageBox.Show("年龄必须在18-35岁之间！", "提示信息");
                return;
            }
            //身份证密码长度是否符合要求
            if (!Common.DataValidate.IsIdentityCard(this.txtStudentIdNo.Text.Trim()))
            {
                MessageBox.Show("身份证信息不符合要求!", "验证提示信息");
                this.txtStudentIdNo.Focus();
                return;
            }
            //身份证出生日期与输入的日期是否匹配
            if (!this.txtStudentIdNo.Text.Trim().Contains(this.dtpBirthday.Value.ToString("yyyyMMdd")))
            {
                MessageBox.Show("身份证号和出生日期不匹配！", "验证提示");
                this.txtStudentIdNo.Focus();
                this.txtStudentIdNo.SelectAll();
                return;
            }
            #endregion


            #region 构建学生对象
            Student objStudent = new Student()
            {
                StudentName = this.txtStudentName.Text.Trim(),
                Gender = this.rdoMale.Checked ? "男" : "女",
                Birthday = Convert.ToDateTime(this.dtpBirthday.Text),
                StudentIdNo = this.txtStudentIdNo.Text.Trim(),
                PhoneNumber = this.txtPhoneNumber.Text.Trim(),
                StudentAddress = this.txtAddress.Text.Trim() == "" ? "地址不详" : this.txtAddress.Text.Trim(),
                CardNo = this.txtCardNo.Text.Trim(),
                ClassId = Convert.ToInt32(this.cboClassName.SelectedValue),//获取选择班级对应classId
                Age = DateTime.Now.Year - Convert.ToDateTime(this.dtpBirthday.Text).Year,
                StudentId = Convert.ToInt32(this.txtStudentId.Text.Trim()),
                StuImage = ""
            };

            #endregion

            #region 发起请求
            //将对象传入
            if (objStudentService.ModifyStudent(objStudent)==1)
            {
                MessageBox.Show("学员信息修改成功!", "提示信息");
                this.Close();
            }
            else
            {
                MessageBox.Show("学员信息修改失败!", "提示信息");
            }
            #endregion

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //选择照片
        private void btnChoseImage_Click(object sender, EventArgs e)
        {
            //OpenFileDialog objFileDialog = new OpenFileDialog();
            //DialogResult result = objFileDialog.ShowDialog();
            //if (result == DialogResult.OK)
            //    this.pbStu.Image = Image.FromFile(objFileDialog.FileName);
        }
    }
}