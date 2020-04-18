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
        public int Lifepoints { get; set; }
        public int Damage { get; set; }

        public string Name { get; set; }

        //Konstruktur
        public Underlyings(int _attackvalue, int _paradevalue, int _lifepoints, int _damage, string _name)
        {
            Attackvalue = _attackvalue;
            Paradevalue = _paradevalue;
            Lifepoints = _lifepoints;
            Damage = _damage;
            Name = _name;
        }


        public Boolean Is_Alive()
        {
            if (Lifepoints > 0)
                return true;

            return false;
        }



        public string getdate()
        {
            return "Attacke: " + Attackvalue + ", Parade: " + Paradevalue + ", Lebenspunkte: " + Lifepoints + ", Schaden: " + Damage + ", Name: " + Name;
        }

        public string getdateRed()
        {
            return "Lebenspunkte: " + Lifepoints + ", Schaden: " + Damage;
        }






    }
}
