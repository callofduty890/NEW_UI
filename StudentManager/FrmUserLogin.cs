using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//添加引用自己的动态链接库
using Models;
using DAL;

namespace StudentManager
{
    public partial class FrmUserLogin : Form
    {
        public FrmUserLogin()
        {
            InitializeComponent();
        }


        //登录
        private void btnLogin_Click(object sender, EventArgs e)
        {
            #region 验证数据是否符合要求
            //账号不能为空
            if (this.txtLoginId.Text.Trim().Length==0)
            {
                //提示
                MessageBox.Show("请输入登陆账号!", "提示信息");
                this.txtLoginId.Focus();
                return;
            }
            //密码不能为空
            if (this.txtLoginPwd.Text.Trim().Length == 0)
            {
                //提示
                MessageBox.Show("请输入登陆密码!", "提示信息");
                this.txtLoginPwd.Focus();
                return;
            }
            #endregion

            #region 封装用户信息对象
            Admin objAdmin = new Admin()
            {
                LoginId = Convert.ToInt32(this.txtLoginId.Text.Trim()),
                LoginPwd = this.txtLoginPwd.Text.Trim()
            };
            #endregion

            #region 调用数据库类封装的方式
            //发送用户账号密码，接收用户名称
            Program.currentAdmin = new AdminService().AdminLogin(objAdmin);
            if (Program.currentAdmin != null)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("用户名账号或密码错误", "提示信息");
            }
            #endregion
        }
        //关闭
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
