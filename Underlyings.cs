using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace HumanvsOrc
{
    class Underlyings
    //Properties
    {

        public static Boolean Is_One_Alive(List<Underlyings> UnderlyingList) 
        {
            foreach(var Underlyings in UnderlyingList)   
            {
                if (Underlyings.Is_Alive())
                    return true;
            }

            return false;
        }

        public int Attackvalue { get; set; }
        public int Paradevalue { get; set; }
        public int Lifepoints { get; set; }
        public int Damage { get; set; }

        public string Name { get; set; }

        public string Race { get; set; }

        //Konstruktur
        public Underlyings(int _attackvalue, int _paradevalue, int _lifepoints, int _damage, string _name, string _race)
        {
            Attackvalue = _attackvalue;
            Paradevalue = _paradevalue;
            Lifepoints = _lifepoints;
            Damage = _damage;
            Name = _name;
            Race = _race;
        }


        public Boolean Is_Alive()
        {
            if (Lifepoints > 0)
                return true;

            return false;
        }

        public Boolean Is_Dead() {
            return !Is_Alive();
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
