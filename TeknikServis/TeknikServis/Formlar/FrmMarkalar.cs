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
    public partial class FrmMarkalar : Form
    {
        public FrmMarkalar()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities db = new DbTeknikServisEntities();
        private void FrmMarkalar_Load(object sender, EventArgs e)
        {
            var degerler = db.TBLURUN.OrderBy(x => x.MARKA).GroupBy(y => y.MARKA).Select(z => new
            {
                Marka = z.Key,
                Toplam = z.Count()
            });

            gridControl1.DataSource = degerler.ToList();
            labelControl2.Text = db.TBLURUN.Count().ToString();
            labelControl3.Text = (from x in db.TBLURUN

                                 select x.MARKA).Distinct().Count().ToString();
            labelControl7.Text = (from x in db.TBLURUN
                                   orderby x.SATISFIYAT descending
                                   select x.MARKA).FirstOrDefault();
            chartControl1.Series["Series 1"].Points.AddPoint("Siemens", 4);
            chartControl1.Series["Series 1"].Points.AddPoint("Arçelik", 6);
            chartControl1.Series["Series 1"].Points.AddPoint("Beko", 2);
            chartControl1.Series["Series 1"].Points.AddPoint("Toshiba", 1);
            chartControl1.Series["Series 1"].Points.AddPoint("Lenovo", 1);

            chartControl2.Series["Series 1"].Points.AddPoint("Beyaz Eşya", 4);
            chartControl2.Series["Series 1"].Points.AddPoint("Bilgisayar", 3);
            chartControl2.Series["Series 1"].Points.AddPoint("Küçük Ev Aletleri", 6);
            chartControl2.Series["Series 1"].Points.AddPoint("TV", 2);
            chartControl2.Series["Series 1"].Points.AddPoint("Telefon", 1);
            chartControl2.Series["Series 1"].Points.AddPoint("Diğer", 2);
        }

        private void pictureEdit2_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}
