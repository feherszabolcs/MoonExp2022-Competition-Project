using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MoonExp2022
{
    class Reteg
    {
        //public List<Lencse> MyProperty;
        private Dictionary<int, int> Meresek = new Dictionary<int, int>();

        public bool ElvekonyodottTeljesen => Meresek.Values.Contains(0) ? true : false;
        public int LehetsegesLencsekSzama { get; private set; }
        public int MaxVastagsag => Meresek.Values.Max();
        public int MeresekSzama => Meresek.Count;
        public int MinVastagsag => Meresek.Values.Min();
        public int TenylegesLencsekSzama { get; private set; }

        private void LehetsegesLencsekKeresese()
        {

        }

        public int RetegVastagsaga(int meresSorszama)
        {
            return 0;
        }

        public Reteg(string meresek)
        {
            string[] m = meresek.Split(' ');
            foreach (var item in m)
            {
                string[] s = item.Split('-');
                Meresek.Add(int.Parse(s[0]), int.Parse(s[1]));
            }
        }
    }
}
