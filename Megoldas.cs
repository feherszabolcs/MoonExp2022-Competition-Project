using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace MoonExp2022
{
    class Megoldas
    {
        private List<Reteg> Retegek = new List<Reteg>();

        public int LegmelyebbAlsoLeghatar
        {
            get
            {
                int s = 0;
                for (int i = 1; i <= MeresekSzama; i++)
                {
                    if (SzummaRetegVastagsag(i) > s) s = SzummaRetegVastagsag(i);
                }
                return s;
            }
        }
        public int LegmelyebbAlsoLeghatarSorszama
        {
            get
            {
                for (int i = 1; i <= MeresekSzama; i++)
                {
                    if (SzummaRetegVastagsag(i) == LegmelyebbAlsoLeghatar) return i;
                }
                return -1;
            }
        }
        public int MeresekSzama => Retegek[0].MeresekSzama;
        public int RetegekSzama => Retegek.Count;
        public int TeljesenElvekonyodottRetegekSzama => Retegek.Where(r => r.ElvekonyodottTeljesen).Count();
        private int RetegvastagsagAlatta(int meresSorszama, int retegIndex)
        {
            if (retegIndex == 0) return -1;
            Reteg r = Retegek[retegIndex - 1];
            return r.RetegVastagsaga(meresSorszama);

        }
        private int RetegVastagsagFelette(int meresSorszama, int retegIndex)
        {
            if (retegIndex == Retegek.Count - 1) return -1;
            return Retegek[retegIndex + 1].RetegVastagsaga(meresSorszama);
        }
        private void TenylegesLencsekKeresese()
        {
            for (int j = 0; j < Retegek.Count; j++)
            {
                for (int i = 0; i < Retegek[j].Lencsek.Count; i++)
                {
                    if (RetegvastagsagAlatta(Retegek[j].Lencsek[i].Kezdete, j) >0 && RetegVastagsagFelette(Retegek[j].Lencsek[i].Vege, j) > 0)
                    {
                        Retegek[j].Lencsek[i].TenylegesLencse = true;
                    }
                }
            }
        }
        public int TenylegesLencsekSzama(int retegSorszama)
        {
            return Retegek[retegSorszama - 1].TenylegesLencsekSzama;
        }

        public int LehetsegesLencsekSzama(int retegSorszam)
        {
            Reteg r = Retegek[retegSorszam-1];
            return r.LehetsegesLencsekSzama;
        }
        private int SzummaRetegVastagsag(int meresSorszam)
        {
            int szum = 0;
            foreach (var item in Retegek)
            {
                szum+=item.RetegVastagsaga(meresSorszam);
            }
            return szum; //pl a 7-es mérésen az összes mélység
        }

        public int MinVastagsag(int retegSorszam)
        {
            Reteg r = Retegek[retegSorszam];
            return r.MinVastagsag;
        }
        public int MaxVastagsag(int retegSorszam)
        {
            Reteg r = Retegek[retegSorszam];
            return r.MaxVastagsag;
        }

        public Megoldas(string forras)
        {
            foreach (var item in File.ReadAllLines(forras))
            {
                Reteg r = new Reteg(item);
                Retegek.Add(r);
            }
            TenylegesLencsekKeresese();
        }
    }
}


