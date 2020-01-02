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
        //�����༶��������
        private StudentClassService studentClassService = new StudentClassService();
        //���캯��
        public FrmAddStudent()
        {
            InitializeComponent();
            //��ʼ�������б�
            this.cboClassName.DataSource = studentClassService.GetAllClasses();
            this.cboClassName.DisplayMember = "ClassName"; //������������ʾ�ı�
            this.cboClassName.ValueMember = "ClassId";//������������ʾ��Ӧvalueֵ
           
        }
        //�����ѧԱ
        private void btnAdd_Click(object sender, EventArgs e)
        {
            #region ��֤����

            #endregion

            #region ��װ���ݶ���
            #endregion

            #region ���������ӦUI������Ӧ
            #endregion

        }
        //�رմ���
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void FrmAddStudent_KeyDown(object sender, KeyEventArgs e)
        {
       

        }
        //ѡ������Ƭ
        private void btnChoseImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog objFileDialog = new OpenFileDialog();
            DialogResult reustlt = objFileDialog.ShowDialog();
            if (reustlt==DialogResult.OK)
            {
                this.pbStu.Image = Image.FromFile(objFileDialog.FileName);
            }
        }
        //��������ͷ
        private void btnStartVideo_Click(object sender, EventArgs e)
        {
         
        }
        //����
        private void btnTake_Click(object sender, EventArgs e)
        {
        
        }
        //�����Ƭ
        private void btnClear_Click(object sender, EventArgs e)
        {
            this.pbStu.Image = null;
        }
        //��������¼�
        private void FrmAddStudent_Load(object sender, EventArgs e)
        {

        }
    }
}