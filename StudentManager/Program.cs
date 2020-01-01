using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;


using System.Diagnostics;

using Models;

namespace StudentManager
{
    static class Program
    {
        //定义一个用户名称，可以在主窗体下方显示出来
        public static Admin currentAdmin = null;

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //显示登陆窗口
            FrmUserLogin frmUserLogin = new FrmUserLogin();
            //打开登陆窗口
            DialogResult result = frmUserLogin.ShowDialog();
            //获取返回结果
            if (result==DialogResult.OK)
            {
                Application.Run(new FrmMain());
            }
            else
            {
                //关闭所有窗体
                Application.Exit();
            }

            

        }

    }
}
