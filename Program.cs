
using System;
using System.Collections.Generic;


namespace HumanvsOrc
{
    class Program
    {

        public static Boolean OneAttackEachRound = true;

        static int tableWidth = 73; // For Text - Output Variable

        static void Main()
        {
            List<Underlyings> Heroes = new List<Underlyings>();
            {
                // --> ( Attackvalue, Paradevalue , Lifepoints, Damage, Name, Race)
                Heroes.Add(new Underlyings(15, 7, 5, 6, "Hans", "Human"));
                Heroes.Add(new Underlyings(14, 5, 4, 5, "Bertram", "Gnom"));
                Heroes.Add(new Underlyings(16, 8, 33, 7, "Caesar", "Drawf"));

            }
            List<Underlyings> Orcs = new List<Underlyings>();
            {
                // --> ( Attackvalue, Paradevalue , Lifepoints, Damage, Name, Race)
                Orcs.Add(new Underlyings(8, 7, 16, 4, "Fully", "Orc"));
                Orcs.Add(new Underlyings(12, 6, 5, 3, "Gully", "Orc"));
                Orcs.Add(new Underlyings(8, 7, 5, 3, "Strully", "Orc"));
                Orcs.Add(new Underlyings(11, 4, 3, 4, "Pully", "Orc"));
                Orcs.Add(new Underlyings(15, 14, 5, 6, "Rully", "Orc"));

            }

            if (OneAttackEachRound)
            {
                Fight_attack_perRound_start(Heroes, Orcs);
            }
            else
            {
                Fight_attack_multi_start(Heroes, Orcs);
            }

        }

        static void Fight_attack_perRound_start(List<Underlyings> Heroes, List<Underlyings> Orcs)
        {

            while (Underlyings.Is_One_Alive(Heroes) && Underlyings.Is_One_Alive(Orcs))
            {
                foreach (var Hero in Heroes)
                {
                    if (Hero.Is_Dead())
                    {
                        continue;
                    }
                    foreach (var Orc in Orcs)
                    {
                        if (Orc.Is_Dead())
                        {
                            continue;
                        }

                        Fight_Round_Damage2(Hero, Orc);

                        Console.WriteLine($"{Hero.Name}     VS  {Orc.Name}");
                        Console.WriteLine($"Attack-> Hero: {Orc.Lifepoints}");

                        break;
                    }
                }

                foreach (var Orc in Orcs)
                {
                    if (Orc.Is_Dead())
                    {
                        continue;
                    }

                    foreach (var Hero in Heroes)
                    {
                        if (Hero.Is_Dead())
                        {
                            continue;
                        }

                        Fight_Round_Damage2(Orc, Hero);

                        Console.WriteLine($"{Orc.Name}     VS  {Hero.Name}");
                        Console.WriteLine($"Attack-> Orc: {Hero.Lifepoints}");

                        break;
                    }
                }
                Console.WriteLine("----------------------------------------------");
            }

            // Text - Output End - Start Program///////////////////////////////////////////////////////////////////////////

            PrintLine();
            PrintRow("Race", "Name", "Lifespoints", "Alife");
            PrintLine();
            foreach (var Table_Orc in Orcs)
            {
                PrintRow(Table_Orc.Race, Table_Orc.Name, Table_Orc.Lifepoints.ToString(), Alife(Table_Orc).ToString());
            }
            foreach (var Table_Hero in Heroes)
            {
                PrintRow(Table_Hero.Race, Table_Hero.Name, Table_Hero.Lifepoints.ToString(), Alife(Table_Hero).ToString());
            }

            PrintRow("", "", "", "");
            PrintLine();
            Console.ReadLine();

            static void PrintLine()
            {
                Console.WriteLine(new string('-', tableWidth));
            }

            static void PrintRow(params string[] columns)
            {
                int width = (tableWidth - columns.Length) / columns.Length;
                string row = "|";

                foreach (string column in columns)
                {
                    row += AlignCentre(column, width) + "|";
                }

                Console.WriteLine(row);
            }

            static string AlignCentre(string text, int width)
            {
                text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;

                if (string.IsNullOrEmpty(text))
                {
                    return new string(' ', width);
                }
                else
                {
                    return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
                }
            }

            // Text - Output End - End Program ///////////////////////////////////////////////////////////////////////////

            // Print fight summary
            // Who is alive, who is dead?
            // How? foreach again
            // Type         
        }

        static void Fight_attack_multi_start(List<Underlyings> Heroes, List<Underlyings> Orcs)
        {
            foreach (var Hero in Heroes)
            {
                foreach (var Orc in Orcs)
                {
                    if (Hero.Is_Dead())
                    {
                        break;
                    }

                    while (Orc.Is_Alive())
                    {
                        Fight_Round_Damage2(Hero, Orc);
                        Console.WriteLine($"{Hero.Name}     VS  {Orc.Name}");
                        Console.WriteLine($"Attack-> Orc: {Orc.Lifepoints}");
                        if (Orc.Is_Dead())
                        {
                            break;
                        }

                        Fight_Round_Damage2(Orc, Hero);
                        Console.WriteLine($"{Hero.Name}     VS  {Orc.Name}");
                        Console.WriteLine($"Attack -> Hero: {Hero.Lifepoints}");
                        if (Hero.Is_Dead())
                        {
                            break;
                        }

                        Console.WriteLine("_________________________________________________________________________________________");
                    }
                }
            }

        }

        static Boolean Alife(Underlyings Table_Lifepoints)
        {
            if (Table_Lifepoints.Lifepoints > 0)
            {
                return true;
            }

            return false;

        }

        static Boolean Action_Done(int SkillValue)
        {
            Random Cube = new Random();
            int Result = Cube.Next(1, 20);
            //onsole.WriteLine($"Cube: {Result} - SkillValue: {SkillValue}");

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

        // - Old Version - //

        //static Underlyings Fight_Round_Damage(Underlyings Attacker, Underlyings Defender)
        //{
        //    Random Cube = new Random();
        //    int Attack_Cube = Cube.Next(1, 20); // Attack - Random
        //    int Defend_Cube = Cube.Next(1, 20); // Defend - Random

        //    if (Attack_Cube <= Attacker.Attackvalue && Defend_Cube > Defender.Paradevalue)
        //    {
        //        Defender.Lifepoints -= Attacker.Damage;
        //    }

        //    return Defender;

        //}

        // - Old Version - //
    }

}

