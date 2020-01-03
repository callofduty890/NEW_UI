using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

using DAL;
using Models;
//using Common;

namespace StudentManager
{
    public partial class FrmStudentManage : Form
    {
        //班级类
        private StudentClassService objClassService = new StudentClassService();
        //学生类
        private StudentService objStudentService = new StudentService();
        //定义一个List作为全局变量接受返回值
        List<Student> list = null;


        public FrmStudentManage()
        {
            InitializeComponent();
            //初始化班级下拉框
            this.cboClass.DataSource = objClassService.GetAllClasses();
            this.cboClass.DisplayMember = "ClassName";
            this.cboClass.ValueMember = "ClassId";
        }
        //按照班级查询
        private void btnQuery_Click(object sender, EventArgs e)
        {
            #region 数据验证
            //提示选中班级
            if (this.cboClass.SelectedIndex==-1)
            { 
                MessageBox.Show("请选择班级!", "提示");
                return;
            }
            #endregion
            //不显示未封装属性
            this.dgvStudentList.AutoGenerateColumns = false;

            //根据班级执行查询操作
            list = objStudentService.GetStudentsByClass(this.cboClass.Text);
            //绑定显示
            this.dgvStudentList.DataSource = list;
            //调整显示样式
            new Common.DataGridViewStyle().DgvStyle1(this.dgvStudentList);

        }
        //根据学号查询
        private void btnQueryById_Click(object sender, EventArgs e)
        {
            #region 数据验证
            if (this.txtStudentId.Text.Trim().Length==0)
            {
                MessageBox.Show("请输入学号!", "提示信息");
                this.txtStudentId.Focus();
                return;
            }
            //验证此学号在数据库中是否存在
            Student objStudent = objStudentService.GetStudentById(this.txtStudentId.Text.Trim());
            if (objStudent==null)
            {
                MessageBox.Show("学员信息不存在!", "提示信息");
                this.txtStudentId.Focus();
            }
            else
            {
                FrmStudentInfo objFrmStudentInfo = new FrmStudentInfo(objStudent);
                objFrmStudentInfo.Show();
            }
            #endregion
        }
        private void txtStudentId_KeyDown(object sender, KeyEventArgs e)
        {
         
        }
        //双击选中的学员对象并显示详细信息
        private void dgvStudentList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
        //修改学员对象
        private void btnEidt_Click(object sender, EventArgs e)
        {
            //验证数据
            if (this.dgvStudentList.RowCount==0)
            {
                MessageBox.Show("没有任何需要修改的学员信息!", "提示");
                return;
            }
            if (this.dgvStudentList.CurrentRow==null)
            {
                MessageBox.Show("请选中要修改的学员信息!", "提示");
                return;
            }

            //获取学号
            string studentId = this.dgvStudentList.CurrentRow.Cells["StudentId"].Value.ToString();
            //根据获取的学号进行查询
            Student objStudent = objStudentService.GetStudentById(studentId);
            //显示修改的学员窗口信息
            FrmEditStudent objfrmEditStudent = new FrmEditStudent(objStudent);
            //显示窗体
            Console.WriteLine(DateTime.Now.ToString() + " 弹窗显示");
            objfrmEditStudent.ShowDialog();
            Console.WriteLine(DateTime.Now.ToString() + " 弹窗显示完毕");
            //刷新结果
            btnQuery_Click(null, null);

        }
        //删除学员对象
        private void btnDel_Click(object sender, EventArgs e)
        {
            #region 验证信息
            if (this.dgvStudentList.RowCount==0)
            {
                MessageBox.Show("没有任何要删除的学员！", "提示");
                return;
            }
            if (this.dgvStudentList.CurrentRow==null)
            {
                MessageBox.Show("没有任何要删除的学员！", "提示");
                return;
            }
            #endregion

            //提示客户是否要删除数据
            DialogResult result = MessageBox.Show("确实要删除吗？", "删除确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            //判断结果
            if (result==DialogResult.OK)
            {
                string studentId = this.dgvStudentList.CurrentRow.Cells["StudentId"].Value.ToString();
                //传入执行
                if( objStudentService.DelectStudentById(studentId)==1)
                {
                    //刷新结果
                    btnQuery_Click(null, null);
                }

            }


        }
        //姓名降序
        private void btnNameDESC_Click(object sender, EventArgs e)
        {
         
        }
        //学号降序
        private void btnStuIdDESC_Click(object sender, EventArgs e)
        {
         
        }
        //添加行号
        private void dgvStudentList_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
        
        }
        //打印当前学员信息
        private void btnPrint_Click(object sender, EventArgs e)
        {
          
        }

        //关闭
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //导出到Excel
        private void btnExport_Click(object sender, EventArgs e)
        {

        }
    }

   
}