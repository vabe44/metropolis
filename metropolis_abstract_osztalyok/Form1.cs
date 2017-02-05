using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace metropolis_abstract_osztalyok
{
    public partial class Form1 : Form
    {
        List<Epulet> epuletek = new List<Epulet>();
        int munkaHelySzam = 0;
        int lakoSzam = 0;
        int alapter = 0;
        int oszzAlapter = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Lerajzol(Epulet ep)
        {
            var l = new Label
            {
                Left = ep.Balkozep - ep.Vmeret/2,
                Top = ep.Fentkozep - ep.Fmeret/2,
                Width = ep.Vmeret,
                Height = ep.Fmeret
            };

            if (ep is IpariEpulet)
            {
                l.BackColor = Color.Yellow;
            } else if (ep is UzletiEpulet)
            {
                l.BackColor = Color.Blue;
            } else if (ep is LakoEpulet)
            {
                l.BackColor = Color.Green;
            }

            panel1.Controls.Add(l);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var sr = new StreamReader("metropolis.txt");
            while (!sr.EndOfStream)
            {
                var sorDb = sr.ReadLine()?.Split(' ');
                switch (sorDb?[0])
                {
                    case "1":
                        var ip = new IpariEpulet(int.Parse(sorDb[0]), int.Parse(sorDb[1]), int.Parse(sorDb[2]), int.Parse(sorDb[3]), int.Parse(sorDb[4]), int.Parse(sorDb[5]));
                        epuletek.Add(ip);
                        Lerajzol(ip);
                        break;
                    case "2":
                        var uz = new UzletiEpulet(int.Parse(sorDb[0]), int.Parse(sorDb[1]), int.Parse(sorDb[2]), int.Parse(sorDb[3]), int.Parse(sorDb[4]), int.Parse(sorDb[5]), int.Parse(sorDb[6]));
                        epuletek.Add(uz);
                        Lerajzol(uz);
                        break;
                    case "3":
                        var la = new LakoEpulet(int.Parse(sorDb[0]), int.Parse(sorDb[1]), int.Parse(sorDb[2]), int.Parse(sorDb[3]), int.Parse(sorDb[4]), int.Parse(sorDb[5]), int.Parse(sorDb[6]), int.Parse(sorDb[7]));
                        epuletek.Add(la);
                        Lerajzol(la);
                        break;
                }

                munkaHelySzam += epuletek.Last().MunkaHelySzam();
                lakoSzam += epuletek.Last().LakoSzam();
                oszzAlapter += epuletek.Last().Alapterulet();
            }

            sr.Close();

            lbMunka.Text = munkaHelySzam.ToString();
            lbLakok.Text = lakoSzam.ToString();
            lbAlapter.Text = (oszzAlapter / epuletek.Count).ToString();
        }
    }
}
