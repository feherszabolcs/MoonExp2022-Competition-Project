using System;
using System.Collections.Generic;
using System.Text;

namespace MoonExp2022
{
    class Lencse
    {
        public int Kezdete { get; private set; }
        public int Vege { get; private set; }
        public bool TenylegesLencse { get; set; }

        public Lencse(int kezdet, int veg)
        {
            Kezdete = kezdet;
            Vege = veg;
        }
    }
}
