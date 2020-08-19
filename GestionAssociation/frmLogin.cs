using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Threading;

namespace GestionAssociation
{
    public partial class frmLogin : DevExpress.XtraEditors.XtraForm
    {
        Thread t;
        public frmLogin()
        {
            InitializeComponent();
            try
            {
                t = new Thread(new ThreadStart(starsplach));
                t.Start();
                Thread.Sleep(5000);
                t.Abort();
            }
            catch (Exception)
            {}
        }
        public void starsplach(){
            try
            {
                try
                {
                    Application.Run(new spalch());
                }
                catch (Exception)
                {
                }
            }
            catch (Exception)
            {

            }
        }
        ado ado = new ado();
        DataTable tb = new DataTable();
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                tb = ado.readData("select * from USR where Imail = '" + textEdit1.Text + "' and [password] = '" + textEdit2.Text + "' and Droi ='المدير'  ");
                if (tb.Rows.Count == 1)
                {
                    DataTable data = new  DataTable();
                    data = ado.readData("select Nom from USR where Imail = '" + textEdit1.Text + "' and [password] = '" + textEdit2.Text + "' and Droi ='المدير'");
                    string d = data.Rows[0][0].ToString();
                    Form1 f = new Form1();
                    f.nom = d;
                    f.Show();
                    this.Hide();
                }
                else
                {
                    labelControl3.Visible = true;
                    
                }
                timer1.Start();
            }
            else 
            if (radioButton2.Checked == true)
            {
                tb = ado.readData("select * from USR where Imail = '" + textEdit1.Text + "' and [password] = '" + textEdit2.Text + "' and Droi ='الموضف'  ");
                if (tb.Rows.Count == 1)
                {
                    //form fin ghaytla7
                    MessageBox.Show("تاكد  ", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else {
                    labelControl3.Visible = true;
                    
                }
                timer1.Start();
            }
            else { MessageBox.Show("تاكد من ملأ جميع الخانات المطلوبة ", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if( labelControl3.Visible == true)
            {
                labelControl3.Visible = false;
            }
            
        }
    }
}