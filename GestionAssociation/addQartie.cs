using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionAssociation
{
    public partial class addQartie : Form
    {
        ado ad = new ado();
        DataTable data = new DataTable();
        public addQartie()
        {
            InitializeComponent();
        }
        public void tam()
        {
            data = ad.readData("select max(id) from addQartie ");
            try
            {
                int x = Int32.Parse(data.Rows[0][0].ToString());

                x = x + 1;
                textBox1.Text = x.ToString();
            }
            catch (Exception)
            {

                textBox1.Text = "1";
            }
        }


        private void simpleButton1_Click(object sender, EventArgs e)
        {
            bool flag = ad.IUDData("Insert into addQartie values ('" + textBox1.Text + "',N'" + textBox2.Text + "')");
            if (flag == true)
            {
                MessageBox.Show("تم الاضافة بنجاح", "مرحبا");
                tam();
                textBox2.Text = "";
            }
            else
                MessageBox.Show("فشلت العملية", "مرحبا");
        }

        private void addQartie_Load(object sender, EventArgs e)
        {
            tam();
        }
    }
}
