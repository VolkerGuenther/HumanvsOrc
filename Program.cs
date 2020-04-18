
using System;
using System.Collections.Generic;


namespace HumanvsOrc
{
    class Program
    {

        public static Boolean OneAttackEachRound = true;

        static void Main()
        {
            List<Underlyings> Heroes = new List<Underlyings>();
            {
                // --> ( Attackvalue, Paradevalue , Lifepoints, Damage, Name)
                Heroes.Add(new Underlyings(15, 7, 5, 6, "Hans"));
                Heroes.Add(new Underlyings(14, 5, 4, 5, "Bertram"));
                Heroes.Add(new Underlyings(16, 8, 33, 7, "Caesar"));

            }
            List<Underlyings> Orcs = new List<Underlyings>();
            {
                // --> ( Attackvalue, Paradevalue , Lifepoints, Damage, Name)
                Orcs.Add(new Underlyings(8, 7, 16, 4, "Fully"));
                Orcs.Add(new Underlyings(12, 6, 5, 3, "Gully"));
                Orcs.Add(new Underlyings(8, 7, 5, 3, "Strully"));
                Orcs.Add(new Underlyings(11, 4, 3, 4, "Pully"));
                Orcs.Add(new Underlyings(15, 14, 5, 6, "Rully"));

            }

            if (OneAttackEachRound) {
                Fight_attack_perRound_start(Heroes,Orcs);
            } else {
                Fight_attack_multi_start(Heroes,Orcs);
            }

           

        }

        static void Fight_attack_perRound_start(List<Underlyings> Heroes, List<Underlyings> Orcs) 
        {

            while(Underlyings.Is_One_Alive(Heroes) && Underlyings.Is_One_Alive(Orcs)) {
                foreach (var Hero in Heroes)
                {
                    if(Hero.is_Dead()) {
                        continue;
                    }
                    foreach (var Orc in Orcs)
                    {
                        if(Orc.is_Dead()) {
                            continue;
                        }

                        Fight_Round_Damage(Hero, Orc);

                        Console.WriteLine($"{Hero.Name}     VS  {Orc.Name}");
                        Console.WriteLine($"Attack-> Orc: {Orc.Lifepoints}");
                    }
                }

                foreach (var Orc in Orcs)
                {
                    if(Orc.is_Dead()) {
                        continue;
                    }

                    foreach (var Hero in Heroes)
                    {
                    }   
                }
                Console.WriteLine("----------------------------------------------");
            }

            // Print fight summary
            // Who is alive, who is dead?
            // How? foreach again
            // Type         
        }

        static void Fight_attack_multi_start(List<Underlyings> Heroes, List<Underlyings> Orcs) {
         foreach (var Hero in Heroes)
            {
                foreach (var Orc in Orcs)
                {
                    if (Hero.is_Dead())
                    {
                        break;
                    }

                    while (Orc.Is_Alive())
                    {
                        Fight_Round_Damage(Hero, Orc);
                        Console.WriteLine($"{Hero.Name}     VS  {Orc.Name}");
                        Console.WriteLine($"Attack-> Orc: {Orc.Lifepoints}");
                        if (Orc.is_Dead())
                        {
                            break;
                        }

                        Fight_Round_Damage(Orc, Hero);
                        Console.WriteLine($"{Hero.Name}     VS  {Orc.Name}");
                        Console.WriteLine($"Attack -> Hero: {Hero.Lifepoints}");
                        if (Hero.is_Dead())
                        {
                            break;
                        }

                        Console.WriteLine("_________________________________________________________________________________________");
                    }
                }
            }
        }
        
        
        
        static Underlyings Fight_Round_Damage(Underlyings Attacker, Underlyings Defender)
        {
            Random Cube = new Random();
            int Attack_Cube = Cube.Next(1, 20); // Attack - Random
            int Defend_Cube = Cube.Next(1, 20); // Defend - Random

            if (Attack_Cube <= Attacker.Attackvalue && Defend_Cube > Defender.Paradevalue)
            {
                Defender.Lifepoints -= Attacker.Damage;
            }

            return Defender;

        }

        static Boolean Action_Done(int SkillValue)
        {
            Random Cube = new Random();
            int Result = Cube.Next(1, 20);
            Console.WriteLine($"Cube: {Result} - SkillValue: {SkillValue}");

            if (Result <= SkillValue)
                return true;

            return false;
        }

        static Underlyings Fight_Round_Damage2(Underlyings Attacker, Underlyings Defender)
        {


            if (Action_Done(Attacker.Attackvalue) && !Action_Done(Defender.Paradevalue))
            {
                Defender.Lifepoints -= Attacker.Damage;
            }

            return Defender;

        }

    }

}

