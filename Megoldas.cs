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

        public int LegmelyebbAlsoLeghatar { get; private set; }
        public int LegmelyebbAlsoLeghatarSorszama { get; private set; }
        public int MeresekSzama => Retegek[0].MeresekSzama;
        public int RetegekSzama => Retegek.Count;
        
        public int TeljesenElvekonyodottRetegekSzama => Retegek.Where(r => r.ElvekonyodottTeljesen).Count();


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
        }
    }
}
