using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DAL;


namespace StudentManager
{
    public partial class FrmAddStudent : Form
    {
        //创建班级操作对象
        private StudentClassService studentClassService = new StudentClassService();
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

            #endregion

            #region 封装数据对象
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