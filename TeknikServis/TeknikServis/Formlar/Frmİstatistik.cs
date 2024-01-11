using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeknikServis.Formlar
{
    public partial class Frmİstatistik : Form
    {
        public Frmİstatistik()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void Frmİstatistik_Load(object sender, EventArgs e)
        {
            labelControl2.Text = db.TBLURUN.Count().ToString();
            labelControl3.Text = db.TBLKATEGORİ.Count().ToString();
            labelControl5.Text = db.TBLURUN.Sum(x => x.STOK).ToString();
            labelControl7.Text = "10";
            labelControl19.Text = (from x in db.TBLURUN
                                   orderby x.STOK descending
                                   select x.AD).FirstOrDefault();
            labelControl17.Text=( from x in db.TBLURUN
                                 orderby x.STOK ascending
                                 select x.AD).FirstOrDefault();
            labelControl13.Text= (from x in db.TBLURUN
                                  orderby x.SATISFIYAT descending
                                  select x.AD).FirstOrDefault();
            labelControl11.Text= (from x in db.TBLURUN
                                  orderby x.SATISFIYAT ascending
                                  select x.AD).FirstOrDefault();
            labelControl29.Text = db.TBLURUN.Count(x => x.KATEGORI == 4).ToString();
            labelControl27.Text = db.TBLURUN.Count(x => x.KATEGORI == 1).ToString();
            labelControl25.Text = db.TBLURUN.Count(x => x.KATEGORI == 3).ToString();
            labelControl39.Text = (from x in db.TBLURUN
                                   select x.MARKA).Distinct().Count().ToString();

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
