﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


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
            //密码不能为空
            #region
        }
        //关闭
        private void btnClose_Click(object sender, EventArgs e)
        {
           
        }
    }
}
