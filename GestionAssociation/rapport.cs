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
    public partial class rapport : Form
    {
        string st;
        DataTable table = new DataTable();
        public rapport(DataTable tb , string t)
        {
            InitializeComponent();
            table = tb;
            st = t;
        }

        private void rapport_Load(object sender, EventArgs e)
        {
            if(st == "المنخريطين")
            {
                CrystalReport2 r = new CrystalReport2();
                r.SetDataSource(table);
                crystalReportViewer1.ReportSource = r;
            }
            if(st== "اطفال الروض")
            {
                Elevereport r = new Elevereport();
                r.SetDataSource(table);
                crystalReportViewer1.ReportSource = r;
            }
            if (st == "الأساتذة")
            {
                profrepport r = new profrepport();
                r.SetDataSource(table);
                crystalReportViewer1.ReportSource = r;
            }
            if (st == "المستخدمين")
            {
                usrRepport r = new usrRepport();
                r.SetDataSource(table);
                crystalReportViewer1.ReportSource = r;
            }
            if (st == "المسؤولين")
            {
                respoRepport r = new respoRepport();
                r.SetDataSource(table);
                crystalReportViewer1.ReportSource = r;
            }
            if (st == "الحسابات")
            {
                hisabrepport r = new hisabrepport();
                r.SetDataSource(table);
                crystalReportViewer1.ReportSource = r;
            }


        }
    }
}
