using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MoonExp2022
{
    class Reteg
    {
        public List<Lencse> Lencsek = new List<Lencse>();
        private Dictionary<int, int> Meresek = new Dictionary<int, int>();

        public bool ElvekonyodottTeljesen => Meresek.Values.Contains(0) ? true : false;
        public int LehetsegesLencsekSzama => Lencsek.Count;
        public int MaxVastagsag => Meresek.Values.Max();
        public int MeresekSzama => Meresek.Count;
        public int MinVastagsag => Meresek.Values.Min();
        public int TenylegesLencsekSzama => Lencsek.Where(r => r.TenylegesLencse).Count();

        private void LehetsegesLencsekKeresese()
        {
            int kezd = 0;
            int veg = 0;
            foreach (var item in Meresek)
            { 
                if (item.Value == 0 && kezd == 0) kezd = item.Key;
                if (item.Value == 0 && kezd < item.Key && kezd+1 != item.Key) veg = item.Key;
                if(veg!= 0 && kezd!= 0)
                {
                    Lencse l = new Lencse(kezd, veg);
                    Lencsek.Add(l);
                    kezd = veg = 0;
                }
            }
           
        }

        public int RetegVastagsaga(int meresSorszama)
        {
            return Meresek[meresSorszama];//egy mérés egy rétegen
        }
        public void TenylegesLencsek()
        {

        }

        public Reteg(string meresek)
        {
            string[] m = meresek.Split(' ');
            foreach (var item in m)
            {
                string[] s = item.Split('-');
                Meresek.Add(int.Parse(s[0]), int.Parse(s[1]));
            }
            LehetsegesLencsekKeresese();
        }
    }
}
