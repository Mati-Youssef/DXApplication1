using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GestionAssociation
{
    public partial class Form1 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public string nom;
        public Form1()
        {
            InitializeComponent();
           
        }
      
        private void Form1_Load(object sender, EventArgs e)
        {
            barCheckItem6.Caption = DateTime.Now.ToString();
            barButtonItem19.Caption = nom;
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frminkhirat f = new frminkhirat();
            f.ShowDialog();
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmcoran f = new frmcoran();
            f.ShowDialog();
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmUsr u = new frmUsr();
            u.ShowDialog();
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmprof p = new frmprof();
            p.ShowDialog();
        }

        private void barButtonItem13_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            respomsabl r = new respomsabl();
            r.ShowDialog();
        }

        private void barButtonItem14_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmhisabat h = new frmhisabat();
            h.name = barButtonItem19.Caption;
            h.ShowDialog();
        }

        private void tileItem5_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            frmcoran f = new frmcoran();
            f.ShowDialog();
        }

        private void barButtonItem20_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            addmission ad = new addmission();
            ad.ShowDialog();            
        }

        private void barButtonItem21_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            addQartie ad = new addQartie();
            ad.ShowDialog();
        }

        private void tileItem4_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            frminkhirat f = new frminkhirat();
            f.ShowDialog();
        }

        private void tileItem8_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            frmUsr u = new frmUsr();
            u.ShowDialog();
        }

        private void tileItem6_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            frmprof p = new frmprof();
            p.ShowDialog();
        }

        private void tileItem2_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            respomsabl r = new respomsabl();
            r.ShowDialog();
        }

        private void tileItem9_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            frmhisabat h = new frmhisabat();
            h.name = barButtonItem19.Caption;
            h.ShowDialog();
        }

        private void barButtonItem22_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            taqarir f = new taqarir();
            f.ShowDialog();
        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {
        }

        private void barButtonItem24_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Application.Exit();
        }
    }
}
