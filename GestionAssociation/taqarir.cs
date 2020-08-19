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
using System.Data.SqlClient;

namespace GestionAssociation
{
    public partial class taqarir : DevExpress.XtraEditors.XtraForm
    {
        public taqarir()
        {
            InitializeComponent();
        }
        ado ad = new ado();
        private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxEdit1.Text == "الحسابات")
            {
                simpleButton1.Visible = true;
                simpleButton2.Visible = true;
                radioButton1.Visible = true;
                radioButton2.Visible = true;
                textEdit1.Visible = false;
                label4.Visible = false;
            }
            else
            {
                radioButton1.Visible = false;
                radioButton2.Visible = false;
                textEdit1.Visible = true;
                label4.Visible = true;
            }
        }

        private void taqarir_Load(object sender, EventArgs e)
        {
            // string[] tpPrint = new string[] { "المنخريطين", "اطفال الروض" ,"الأساتذة","المسؤولين","المستخدمين","الحسابات" };
            for (int i = 2015; i <= DateTime.Now.Year; i++)
            {
                comboBox1.Items.Add(i);
            }
            string[] HH = new string[] {  "يناير", " فبراير", " مارس", " ابريل", " ماي", " يونيو", " يوليو", " أغسطس", " سبتمبر", " أكتوبر", " نوفمبر", " ديسمبر" };
            comboBox2.Items.AddRange(HH);

        }
       

        private void textEdit1_KeyPress(object sender, KeyPressEventArgs e)
        {
          
        }

        private void textEdit1_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {
            if (textEdit1.Text == "")
            {
                simpleButton1.Visible = false;
            }
            else
            {
                simpleButton1.Visible = true;
            }
        }

        private void textEdit1_Click(object sender, EventArgs e)
        {
            textEdit1.Text = "";
            
        }
        public int convA()
        {
            int conn = Convert.ToInt32(comboBox1.Text);
            return conn;
        }
        public int convM()
        {
            int conn = Convert.ToInt32(comboBox2.Text);
            return conn;
        }
        DataTable tb = new DataTable();
        string y;
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            
            if (radioButton2.Checked == true)
            {
                y = "المصاريف";
            }
            if (radioButton1.Checked == true)
            {
                y = "المذاخيل";
            }
            if (comboBoxEdit1.Text == "المنخريطين")
            {
            tb= ad.readData("select NumC AS [رقم المنخرط],dateC AS [تاريخ الانخراط],typeC1 AS [نوع الانخراط 1],typeC2 AS [نوع الانخراط 2],Nom AS [اسم المنخرط],cin AS [رقم بطاقة التعريف],age AS العمر,Qartie AS الحي ,prix AS [ثمن الانخرط] from condidtur where NumC = '" + textEdit1.Text+ "'");
                dataGridView1.DataSource = tb;
            }
            if (comboBoxEdit1.Text == "اطفال الروض")
            {
                tb = ad.readData("select NumE AS [رقم التلميذ],datedebut AS [تاريخ الانخراط],Nom AS [اسم التلميذ],IdE AS [رقم عقد الازدياد],age AS العمر,Qartie AS الحي,prix AS الثمن from eleve where NumE ='" + textEdit1.Text + "'");
                dataGridView1.DataSource = tb;
            }
            if (comboBoxEdit1.Text == "الأساتذة")
            {
                tb = ad.readData("select NumP AS [رقم الأستاذ(ة)],datedebut AS [تاريخ الانخراط],mission AS المهام,salire AS الأجرة,Nom AS [اسم الأستاذ(ة)],Cin AS [رقم بطاقة التعريف],tele AS [رقم الهاتف],Qartie AS الحي from prof where NumP = '" + textEdit1.Text + "'");
                dataGridView1.DataSource = tb;
            }
            if (comboBoxEdit1.Text == "المستخدمين")
            {
                tb = ad.readData("select NumU AS [رقم المستخدم],datedebut AS [تاريخ الانخراط],mission AS المهام,salire AS الاجرة,Nom AS [اسم المستخدم],Cin AS [رقم بطاقة التعريف],tele AS [رقم الهاتف],Qartie AS الحي from USR where NumU ='" + textEdit1.Text + "'");
                dataGridView1.DataSource = tb;
            }
            if (comboBoxEdit1.Text == "الحسابات")
            {
                
                tb = ad.readData("SELECT c.idC [رقم الحساب], c.typeCompte [نوع الحساب], c.Anne  السنة, c.Mois  الشهر, c.descrption AS الوصف, c.NomU [اسم المسؤول],c.prix  الثمن from Compte c where c.typeCompte  =N'" +y+ "'and c.Anne = '" + comboBox1.Text+ "' and c.Mois = N'" + comboBox2.Text+ "' ");
                dataGridView1.DataSource = tb;
            }
            if (comboBoxEdit1.Text == "المسؤولين")
            {
                tb = ad.readData("select  NumR AS [رقم المسؤل],img AS الصورة,datedebut AS [تاريخ الانخراط],mission AS المهام ,salire AS الاجرة ,Nom AS [اسم المسؤول] ,Cin AS [رقم بطاقة التعريف] ,tele AS [رقم الهاتف] ,Qartie AS الحي from resp where NumR = '" + textEdit1.Text + "'");
                dataGridView1.DataSource = tb;
            }
        }
        DataTable data = new DataTable();
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (comboBoxEdit1.Text != "")
            {
                tb.Rows.Clear();
              
                if (radioButton2.Checked == true)
                {
                    y = "المصاريف";
                }
                if (radioButton1.Checked == true)
                {
                    y = "المذاخيل";
                }
                tb = ad.readData("SELECT c.idC [رقم الحساب], c.typeCompte [نوع الحساب], c.Anne  السنة, c.Mois  الشهر, c.descrption AS الوصف, c.NomU [اسم المسؤول],c.prix  الثمن from Compte c where c.typeCompte  =N'" + y + "'");
                dataGridView1.DataSource = tb;
                if (comboBoxEdit1.Text == "اطفال الروض")
                {
                    tb = ad.readData("select NumE AS [رقم التلميذ],datedebut AS [تاريخ الانخراط],Nom AS [اسم التلميذ],IdE AS [رقم عقد الازدياد],age AS العمر,Qartie AS الحي,prix AS الثمن from eleve ");
                    dataGridView1.DataSource = tb;
                }
                if (comboBoxEdit1.Text == "الأساتذة")
                {
                    tb = ad.readData("select NumP AS [رقم الأستاذ(ة)],datedebut AS [تاريخ الانخراط],mission AS المهام,salire AS الأجرة,Nom AS [اسم الأستاذ(ة)],Cin AS [رقم بطاقة التعريف],tele AS [رقم الهاتف],Qartie AS الحي from prof");
                    dataGridView1.DataSource = tb;
                }
                if (comboBoxEdit1.Text == "المسؤولين")
                {
                    tb = ad.readData("select  NumR AS [رقم المسؤل],img AS الصورة,datedebut AS [تاريخ الانخراط],mission AS المهام ,salire AS الاجرة ,Nom AS [اسم المسؤول] ,Cin AS [رقم بطاقة التعريف] ,tele AS [رقم الهاتف] ,Qartie AS الحي from resp");
                    dataGridView1.DataSource = tb;
                }
                if (comboBoxEdit1.Text == "المستخدمين")
                {
                    tb = ad.readData("select NumU AS [رقم المستخدم],datedebut AS [تاريخ الانخراط],mission AS المهام,salire AS الاجرة,Nom AS [اسم المستخدم],Cin AS [رقم بطاقة التعريف],tele AS [رقم الهاتف],Qartie AS الحي from USR ");
                    dataGridView1.DataSource = tb;
                }
                if (comboBoxEdit1.Text == "المنخريطين")
                {
                    data = ad.readData("select NumC AS [رقم المنخرط],dateC AS [تاريخ الانخراط],typeC1 AS [نوع الانخراط 1],typeC2 AS [نوع الانخراط 2],Nom AS [اسم المنخرط],cin AS [رقم بطاقة التعريف],age AS العمر,Qartie AS الحي ,prix AS [ثمن الانخرط] from condidtur");
                    dataGridView1.DataSource = data;
                }
            }
            else MessageBox.Show("تاكد من ملأ جميع الخانات المطلوبة ", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
         
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void simpleButton4_Click_1(object sender, EventArgs e)
        {
            if (comboBox1.Text != "" && comboBox2.Text != "" && comboBoxEdit1.Text != "")
            {
                tb.Rows.Clear();
                int x = comboBox2.SelectedIndex + 1;
                int coon = convA();
                if (comboBoxEdit1.Text == "المستخدمين")
                {
                    tb = ad.readData("select NumU AS [رقم المستخدم],datedebut AS [تاريخ الانخراط],mission AS المهام,salire AS الاجرة,Nom AS [اسم المستخدم],Cin AS [رقم بطاقة التعريف],tele AS [رقم الهاتف],Qartie AS الحي from USR where YEAR(datedebut) = '" + coon + "' and MONTH(datedebut) = '" + x + "'");
                    dataGridView1.DataSource = tb;
                }

                if (radioButton2.Checked == true)
                {
                    y = "المصاريف";
                }
                if (radioButton1.Checked == true)
                {
                    y = "المذاخيل";
                }
                if (comboBoxEdit1.Text == "المنخريطين")
                {
                    tb = ad.readData("select NumC AS [رقم المنخرط],dateC AS [تاريخ الانخراط],typeC1 AS [نوع الانخراط 1],typeC2 AS [نوع الانخراط 2],Nom AS [اسم المنخرط],cin AS [رقم بطاقة التعريف],age AS العمر,Qartie AS الحي ,prix AS [ثمن الانخرط] from condidtur where YEAR(dateC) = '" + coon + "' and MONTH(dateC) = '" + x + "'");
                    dataGridView1.DataSource = tb;
                }
                if (comboBoxEdit1.Text == "اطفال الروض")
                {
                    tb = ad.readData("select NumE AS [رقم التلميذ],datedebut AS [تاريخ الانخراط],Nom AS [اسم التلميذ],IdE AS [رقم عقد الازدياد],age AS العمر,Qartie AS الحي,prix AS الثمن from eleve where YEAR(datedebut) = '" + coon + "' and MONTH(datedebut) = '" + x + "'");
                    dataGridView1.DataSource = tb;
                }
                if (comboBoxEdit1.Text == "الأساتذة")
                {
                    tb = ad.readData("select NumP AS [رقم الأستاذ(ة)],datedebut AS [تاريخ الانخراط],mission AS المهام,salire AS الأجرة,Nom AS [اسم الأستاذ(ة)],Cin AS [رقم بطاقة التعريف],tele AS [رقم الهاتف],Qartie AS الحي from prof where YEAR(datedebut) = '" + coon + "' and MONTH(datedebut) = '" + x + "'");
                    dataGridView1.DataSource = tb;
                }
                if (comboBoxEdit1.Text == "الحسابات")
                {

                    tb = ad.readData("SELECT c.idC [رقم الحساب], c.typeCompte [نوع الحساب], c.Anne  السنة, c.Mois  الشهر, c.descrption AS الوصف, c.NomU [اسم المسؤول],c.prix  الثمن from Compte c where c.typeCompte  =N'" + y + "'and c.Anne = '" + comboBox1.Text + "' and c.Mois = N'" + comboBox2.Text + "' ");
                    dataGridView1.DataSource = tb;
                }
                if (comboBoxEdit1.Text == "المسؤولين")
                {
                    tb = ad.readData("select  NumR AS [رقم المسؤل],img AS الصورة,datedebut AS [تاريخ الانخراط],mission AS المهام ,salire AS الاجرة ,Nom AS [اسم المسؤول] ,Cin AS [رقم بطاقة التعريف] ,tele AS [رقم الهاتف] ,Qartie AS الحي from resp where YEAR(datedebut) = '" + coon + "' and MONTH(datedebut) = '" + x + "'");
                    dataGridView1.DataSource = tb;
                }
            }
            else MessageBox.Show("تاكد من ملأ جميع الخانات المطلوبة ", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Error);
           
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxEdit1.Text == "المنخريطين")
                {
                    string st = "المنخريطين";
                    tb = ad.readData("select * from condidtur ");
                    rapport r = new rapport(tb, st);
                    r.ShowDialog();
                }
                if (comboBoxEdit1.Text == "اطفال الروض")
                {
                    string st = "اطفال الروض";
                    tb = ad.readData("select * from eleve ");
                    rapport r = new rapport(tb, st);
                    r.ShowDialog();
                }
                if (comboBoxEdit1.Text == "الأساتذة")
                {
                    string st = "الأساتذة";
                    tb = ad.readData("select * from prof");
                    rapport r = new rapport(tb, st);
                    r.ShowDialog();
                }
                if (radioButton2.Checked == true)
                {
                    y = "المصاريف";
                }
                if (radioButton1.Checked == true)
                {
                    y = "المذاخيل";
                }
                if (comboBoxEdit1.Text == "الحسابات" && comboBox1.Text == "" && comboBox2.Text == "")
                {
                    string st = "الحسابات";
                    tb = ad.readData("SELECT c.idC, c.typeCompte, c.Anne  , c.Mois  , c.descrption  , c.NomU, c.prix   from Compte c where c.typeCompte = N'" + y + "'");
                    rapport r = new rapport(tb, st);
                    r.ShowDialog();
                }
                if (comboBoxEdit1.Text == "المسؤولين" && comboBox1.Text == "" && comboBox2.Text == "")
                {
                    string st = "المسؤولين";
                    tb = ad.readData("select * from resp");
                    rapport r = new rapport(tb, st);
                    r.ShowDialog();
                }
                if (comboBoxEdit1.Text == "المستخدمين")
                {
                    string st = "المستخدمين";
                    tb = ad.readData("select * from USR");
                    rapport r = new rapport(tb, st);
                    r.ShowDialog();
                }
                if (comboBox1.Text != "" && comboBox2.Text != "" && radioButton1.Checked == true || radioButton2.Checked == true)
                {
                    string st = "الحسابات";
                    tb = ad.readData("SELECT * from Compte c where c.typeCompte  =N'" + y + "'and c.Anne = '" + comboBox1.Text + "' and c.Mois = N'" + comboBox2.Text + "' ");
                    rapport r = new rapport(tb, st);
                    r.ShowDialog();
                }
                if (comboBoxEdit1.Text == "المسؤولين" && comboBox1.Text != "" && comboBox2.Text != "")
                {
                    string st = "المسؤولين";
                    int x = comboBox2.SelectedIndex + 1;
                    int coon = convA();
                    tb = ad.readData("select * from resp where YEAR(datedebut) = '" + coon + "' and MONTH(datedebut) = '" + x + "'");
                    rapport r = new rapport(tb, st);
                    r.ShowDialog();
                }
            }
            catch 
            {

                MessageBox.Show("تاكد من ملأ جميع الخانات المطلوبة ", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            comboBox1.Text = "";
            comboBox2.Text = "";
        }
    }
}