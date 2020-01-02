using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DAL;
using Common;
using Models;

namespace StudentManager
{
    public partial class FrmAddStudent : Form
    {
        //创建班级操作对象
        private StudentClassService studentClassService = new StudentClassService();
        //创建学生实例化操作对象
        private StudentService objStudentService = new StudentService();
        //构造函数
        public FrmAddStudent()
        {
            InitializeComponent();
            //初始化下拉列表
            this.cboClassName.DataSource = studentClassService.GetAllClasses();
            this.cboClassName.DisplayMember = "ClassName"; //设置下拉框显示文本
            this.cboClassName.ValueMember = "ClassId";//设置下拉框显示对应value值
           
        }
        //添加新学员
        private void btnAdd_Click(object sender, EventArgs e)
        {
            #region 验证数据
            //学生姓名不能空
            if (this.txtStudentName.Text.Trim().Length==0)
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
            //检查身份证号码是否已经在数据库当中出现
            if (objStudentService.IsIdNoExisted(this.txtStudentIdNo.Text.Trim()))
            {
                MessageBox.Show("身份证号不能和现有学员身份证号重复！", "验证提示");
                this.txtStudentIdNo.Focus();
                this.txtStudentIdNo.SelectAll();
                return;
            }
            //检查考勤卡号是否已经在数据库当中出现
            if (objStudentService.IsCardNoExisted(this.txtCardNo.Text.Trim()))
            {
                MessageBox.Show("当前卡号已经存在！", "验证提示");
                this.txtCardNo.Focus();
                this.txtCardNo.SelectAll();
                return;
            }
            #endregion

            #region 封装数据对象
            Student objstudent = new Student();
            objstudent.StudentName = this.txtStudentName.Text.Trim();
            objstudent.Gender = this.rdoMale.Checked ? "男" : "女";
            objstudent.Birthday = Convert.ToDateTime(this.dtpBirthday.Text);
            objstudent.PhoneNumber = this.txtPhoneNumber.Text.Trim();
            objstudent.ClassName = this.cboClassName.Text;
            objstudent.StudentAddress = this.txtAddress.Text.Trim() == "" ? "地址不详" : this.txtAddress.Text.Trim();
            objstudent.CardNo = this.txtCardNo.Text.Trim();
            objstudent.ClassId = Convert.ToInt32(this.cboClassName.SelectedValue);
            objstudent.Age= DateTime.Now.Year - Convert.ToDateTime(this.dtpBirthday.Text).Year;
            objstudent.StuImage = this.pbStu.Image != null ? new SerializeObjectToString().SerializeObject(this.pbStu.Image) : "";

            #endregion

            #region 发起请求对应UI界面相应
            #endregion

        }
        //关闭窗体
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void FrmAddStudent_KeyDown(object sender, KeyEventArgs e)
        {
       

        }
        //选择新照片
        private void btnChoseImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog objFileDialog = new OpenFileDialog();
            DialogResult reustlt = objFileDialog.ShowDialog();
            if (reustlt==DialogResult.OK)
            {
                this.pbStu.Image = Image.FromFile(objFileDialog.FileName);
            }
        }
        //启动摄像头
        private void btnStartVideo_Click(object sender, EventArgs e)
        {
         
        }
        //拍照
        private void btnTake_Click(object sender, EventArgs e)
        {
        
        }
        //清除照片
        private void btnClear_Click(object sender, EventArgs e)
        {
            this.pbStu.Image = null;
        }
        //窗体加载事件
        private void FrmAddStudent_Load(object sender, EventArgs e)
        {

        }
    }
}