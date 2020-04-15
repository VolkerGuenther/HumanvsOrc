using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace HumanvsOrc
{
    class Underlyings
        //Properties
    {
        public int Attackvalue { get; set; }
        public int Paradevalue { get; set; }
        public int Lifepoints { get; set;  }
        public int Damage { get; set; }
        // Konstruktur
        public Underlyings(int _attackvalue, int _paradevalue, int _lifepoints, int _damage)
        {
            Attackvalue = _attackvalue;
            Paradevalue = _paradevalue;
            Lifepoints = _lifepoints;
            Damage = _damage;
        }

        //public string getdate()
        //{
        //    return "Attacke: " + Attackvalue + ", Parade: " + Paradevalue + ", Lebenspunkte: " + Lifepoints + ", Schaden: " + Damage;
        //}

        public string getdateRed()
        {
            return "Lebenspunkte: " + Lifepoints + ", Schaden: " + Damage;
        }
    }
}
