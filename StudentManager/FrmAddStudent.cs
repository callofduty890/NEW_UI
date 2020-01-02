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
        //�����༶��������
        private StudentClassService studentClassService = new StudentClassService();
        //����ѧ��ʵ������������
        private StudentService objStudentService = new StudentService();
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
            //ѧ���������ܿ�
            if (this.txtStudentName.Text.Trim().Length==0)
            {
                MessageBox.Show("ѧ����Ϣ����Ϊ��!", "��ʾ��Ϣ");
                return;
            }
            //���ڿ���
            if (this.txtCardNo.Text.Trim().Length == 0)
            {
                MessageBox.Show("���ڿ��Ų���Ϊ�գ�", "��ʾ��Ϣ");
                this.txtCardNo.Focus();
                return;
            }
            //��֤�Ա�
            if (!this.rdoFemale.Checked && !this.rdoMale.Checked)
            {
                MessageBox.Show("��ѡ��ѧ���Ա�", "��ʾ��Ϣ");
                return;
            }
            //��֤�༶
            if (this.cboClassName.SelectedIndex == -1)
            {
                MessageBox.Show("��ѡ��༶��", "��ʾ��Ϣ");
                return;
            }
            //��֤����
            int age = DateTime.Now.Year - Convert.ToDateTime(this.dtpBirthday.Text).Year;
            if (age > 35 && age < 18)
            {
                MessageBox.Show("���������18-35��֮�䣡", "��ʾ��Ϣ");
                return;
            }
            //���֤���볤���Ƿ����Ҫ��
            if (!Common.DataValidate.IsIdentityCard(this.txtStudentIdNo.Text.Trim()))
            {
                MessageBox.Show("���֤��Ϣ������Ҫ��!", "��֤��ʾ��Ϣ");
                this.txtStudentIdNo.Focus();
                return;
            }
            //���֤��������������������Ƿ�ƥ��
            if (!this.txtStudentIdNo.Text.Trim().Contains(this.dtpBirthday.Value.ToString("yyyyMMdd")))
            {
                MessageBox.Show("���֤�źͳ������ڲ�ƥ�䣡", "��֤��ʾ");
                this.txtStudentIdNo.Focus();
                this.txtStudentIdNo.SelectAll();
                return;
            }
            //������֤�����Ƿ��Ѿ������ݿ⵱�г���
            if (objStudentService.IsIdNoExisted(this.txtStudentIdNo.Text.Trim()))
            {
                MessageBox.Show("���֤�Ų��ܺ�����ѧԱ���֤���ظ���", "��֤��ʾ");
                this.txtStudentIdNo.Focus();
                this.txtStudentIdNo.SelectAll();
                return;
            }
            //��鿼�ڿ����Ƿ��Ѿ������ݿ⵱�г���
            if (objStudentService.IsCardNoExisted(this.txtCardNo.Text.Trim()))
            {
                MessageBox.Show("��ǰ�����Ѿ����ڣ�", "��֤��ʾ");
                this.txtCardNo.Focus();
                this.txtCardNo.SelectAll();
                return;
            }
            #endregion

            #region ��װ���ݶ���
            Student objstudent = new Student();
            objstudent.StudentName = this.txtStudentName.Text.Trim();
            objstudent.Gender = this.rdoMale.Checked ? "��" : "Ů";
            objstudent.Birthday = Convert.ToDateTime(this.dtpBirthday.Text);
            objstudent.PhoneNumber = this.txtPhoneNumber.Text.Trim();
            objstudent.ClassName = this.cboClassName.Text;
            objstudent.StudentAddress = this.txtAddress.Text.Trim() == "" ? "��ַ����" : this.txtAddress.Text.Trim();
            objstudent.CardNo = this.txtCardNo.Text.Trim();
            objstudent.ClassId = Convert.ToInt32(this.cboClassName.SelectedValue);
            objstudent.Age= DateTime.Now.Year - Convert.ToDateTime(this.dtpBirthday.Text).Year;
            objstudent.StuImage = this.pbStu.Image != null ? new SerializeObjectToString().SerializeObject(this.pbStu.Image) : "";

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