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
        //�༶��
        private StudentClassService objClassService = new StudentClassService();
        //ѧ����
        private StudentService objStudentService = new StudentService();
        //����һ��List��Ϊȫ�ֱ������ܷ���ֵ
        List<Student> list = null;


        public FrmStudentManage()
        {
            InitializeComponent();
            //��ʼ���༶������
            this.cboClass.DataSource = objClassService.GetAllClasses();
            this.cboClass.DisplayMember = "ClassName";
            this.cboClass.ValueMember = "ClassId";
        }
        //���հ༶��ѯ
        private void btnQuery_Click(object sender, EventArgs e)
        {
            #region ������֤
            //��ʾѡ�а༶
            if (this.cboClass.SelectedIndex==-1)
            { 
                MessageBox.Show("��ѡ��༶!", "��ʾ");
                return;
            }
            #endregion
            //����ʾδ��װ����
            this.dgvStudentList.AutoGenerateColumns = false;

            //���ݰ༶ִ�в�ѯ����
            list = objStudentService.GetStudentsByClass(this.cboClass.Text);
            //����ʾ
            this.dgvStudentList.DataSource = list;
            //������ʾ��ʽ
            new Common.DataGridViewStyle().DgvStyle1(this.dgvStudentList);

        }
        //����ѧ�Ų�ѯ
        private void btnQueryById_Click(object sender, EventArgs e)
        {
            #region ������֤
            if (this.txtStudentId.Text.Trim().Length==0)
            {
                MessageBox.Show("������ѧ��!", "��ʾ��Ϣ");
                this.txtStudentId.Focus();
                return;
            }
            //��֤��ѧ�������ݿ����Ƿ����
            Student objStudent = objStudentService.GetStudentById(this.txtStudentId.Text.Trim());
            if (objStudent==null)
            {
                MessageBox.Show("ѧԱ��Ϣ������!", "��ʾ��Ϣ");
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
        //˫��ѡ�е�ѧԱ������ʾ��ϸ��Ϣ
        private void dgvStudentList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
        //�޸�ѧԱ����
        private void btnEidt_Click(object sender, EventArgs e)
        {
            //��֤����
            if (this.dgvStudentList.RowCount==0)
            {
                MessageBox.Show("û���κ���Ҫ�޸ĵ�ѧԱ��Ϣ!", "��ʾ");
                return;
            }
            if (this.dgvStudentList.CurrentRow==null)
            {
                MessageBox.Show("��ѡ��Ҫ�޸ĵ�ѧԱ��Ϣ!", "��ʾ");
                return;
            }

            //��ȡѧ��
            string studentId = this.dgvStudentList.CurrentRow.Cells["StudentId"].Value.ToString();
            //���ݻ�ȡ��ѧ�Ž��в�ѯ
            Student objStudent = objStudentService.GetStudentById(studentId);
            //��ʾ�޸ĵ�ѧԱ������Ϣ
            FrmEditStudent objfrmEditStudent = new FrmEditStudent(objStudent);
            //��ʾ����
            Console.WriteLine(DateTime.Now.ToString() + " ������ʾ");
            objfrmEditStudent.ShowDialog();
            Console.WriteLine(DateTime.Now.ToString() + " ������ʾ���");
            //ˢ�½��
            btnQuery_Click(null, null);

        }
        //ɾ��ѧԱ����
        private void btnDel_Click(object sender, EventArgs e)
        {
            #region ��֤��Ϣ
            if (this.dgvStudentList.RowCount==0)
            {
                MessageBox.Show("û���κ�Ҫɾ����ѧԱ��", "��ʾ");
                return;
            }
            if (this.dgvStudentList.CurrentRow==null)
            {
                MessageBox.Show("û���κ�Ҫɾ����ѧԱ��", "��ʾ");
                return;
            }
            #endregion

            //��ʾ�ͻ��Ƿ�Ҫɾ������
            DialogResult result = MessageBox.Show("ȷʵҪɾ����", "ɾ��ȷ��", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            //�жϽ��
            if (result==DialogResult.OK)
            {
                string studentId = this.dgvStudentList.CurrentRow.Cells["StudentId"].Value.ToString();
                //����ִ��
                if( objStudentService.DelectStudentById(studentId)==1)
                {
                    //ˢ�½��
                    btnQuery_Click(null, null);
                }

            }


        }
        //��������
        private void btnNameDESC_Click(object sender, EventArgs e)
        {
         
        }
        //ѧ�Ž���
        private void btnStuIdDESC_Click(object sender, EventArgs e)
        {
         
        }
        //����к�
        private void dgvStudentList_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
        
        }
        //��ӡ��ǰѧԱ��Ϣ
        private void btnPrint_Click(object sender, EventArgs e)
        {
          
        }

        //�ر�
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //������Excel
        private void btnExport_Click(object sender, EventArgs e)
        {

        }
    }

   
}