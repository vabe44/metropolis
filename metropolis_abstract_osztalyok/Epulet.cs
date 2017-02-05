using System;

namespace metropolis_abstract_osztalyok
{
    abstract class Epulet
    {
        protected int tipus;
        public int Balkozep { get; set; }
        public int Fentkozep { get; set; }
        public int Vmeret { get; set; }
        public int Fmeret { get; set; }

        public int Tipus
        {
            get { return tipus; }

            set
            {
                if (value != 1 && value != 2 && value != 3) throw new Exception("Érvénytelen típus!");
                tipus = value;
            }
        }

        protected Epulet(int tipus, int balkozep, int fentkozep, int vmeret, int fmeret)
        {
            Tipus = tipus;
            Balkozep = balkozep;
            Fentkozep = fentkozep;
            Vmeret = vmeret;
            Fmeret = fmeret;
        }

        public int Alapterulet()
        {
            return Vmeret * Fmeret;
        }

        public abstract int MunkaHelySzam();

        public abstract int LakoSzam();
    }

    class IpariEpulet : Epulet
    {
        public int OsszMunkaHely { get; set; }

        public IpariEpulet(int tipus, int balkozep, int fentkozep, int vmeret, int fmeret, int osszmunkahely) : base(tipus, balkozep, fentkozep, vmeret, fmeret)
        {
            OsszMunkaHely = osszmunkahely;
        }

        public override int MunkaHelySzam()
        {
            return OsszMunkaHely;
        }

        public override int LakoSzam()
        {
            return 0;
        }
    }

    class UzletiEpulet : Epulet
    {
        public int IrodaSzam { get; set; }
        public int IrodaMhelySzam { get; set; }

        public UzletiEpulet(int tipus, int balkozep, int fentkozep, int vmeret, int fmeret, int irodaszam, int irodamhelyszam) : base(tipus, balkozep, fentkozep, vmeret, fmeret)
        {
            IrodaSzam = irodaszam;
            IrodaMhelySzam = irodamhelyszam;
        }

        public override int LakoSzam()
        {
            return IrodaSzam;
        }

        public override int MunkaHelySzam()
        {
            return IrodaSzam * IrodaMhelySzam + IrodaSzam / 10 + 1;
        }
    }

    class LakoEpulet : Epulet
    {
        public int EmeletSzam { get; set; }
        public int LakasSzam { get; set; }
        public int LakokSzama { get; set; }

        public LakoEpulet(int tipus, int balkozep, int fentkozep, int vmeret, int fmeret, int emeletszam, int lakasszam, int lakoszam) : base(tipus, balkozep, fentkozep, vmeret, fmeret)
        {
            EmeletSzam = emeletszam;
            LakasSzam = lakasszam;
            LakokSzama = lakoszam;
        }

        public override int MunkaHelySzam()
        {
            return LakasSzam / 20;
        }

        public override int LakoSzam()
        {
            return EmeletSzam * LakasSzam * LakokSzama;
        }
    }
}
