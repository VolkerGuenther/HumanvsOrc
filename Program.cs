
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


        static Boolean Action_Done(int SkillValue)
        {
            Random Cube = new Random();
            int Result = Cube.Next(1, 20);
            //onsole.WriteLine($"Cube: {Result} - SkillValue: {SkillValue}");

            if (Result <= SkillValue)
                return true;

            return false;
        }

        static Underlyings Fight_Round_Damage(Underlyings Attacker, Underlyings Defender)
        {


            if (Action_Done(Attacker.Attackvalue) && !Action_Done(Defender.Paradevalue))
            {
                Defender.Lifepoints -= Attacker.Damage;
            }

            return Defender;

        }

        private static void Fight_Round(List<Underlyings> Attacker_Li, List<Underlyings> Defender_Li)
        {
            foreach (var Attacker in Attacker_Li)
            {
                if (Attacker.Is_Dead())
                {
                    continue;
                }
                foreach (var Defender in Defender_Li)
                {
                    if (Defender.Is_Dead())
                    {
                        continue;
                    }

                    Fight_Round_Damage(Attacker, Defender);

                    Console.WriteLine($"{Attacker.Name}     VS  {Defender.Name} \n");
                    Console.WriteLine($"Attack-> {Attacker.Race}: {Defender.Lifepoints}");

                    break;
                }
            }
        }

        static void PrintLine()
        {
            Console.WriteLine(new string('-', tableWidth));
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
        static void Loop_PrintRow(List<Underlyings> Races)
        {
            foreach (var Table_Loop in Races)
            {
                PrintRow(Table_Loop.Race, Table_Loop.Name, Table_Loop.Lifepoints.ToString(), Table_Loop.Is_Alive().ToString());   // Alive(Table_Loop).ToString());
            }
        }

        //////////////////////// Case : False  - Start //////////////////////////////////////////////

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
                        Fight_Round_Damage(Hero, Orc);
                        Console.WriteLine($"{Hero.Name}     VS  {Orc.Name}");
                        Console.WriteLine($"Attack-> Orc: {Orc.Lifepoints}");
                        if (Orc.Is_Dead())
                        {
                            break;
                        }

                        Fight_Round_Damage(Orc, Hero);
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

        //////////////////////// Case : False  - End //////////////////////////////////////////////

        //////////////////////// Case : True  - Start //////////////////////////////////////////////

        static void Fight_attack_perRound_start(List<Underlyings> Heroes, List<Underlyings> Orcs)
        {

            while (Underlyings.Is_One_Alive(Heroes) && Underlyings.Is_One_Alive(Orcs))
            {
                Fight_Round(Heroes, Orcs);
                Fight_Round(Orcs, Heroes);

                Console.WriteLine("----------------------------------------------");
            }

            // Text - Output End - Start Program///////////////////////////////////////////////////////////////////////////

            PrintLine();
            PrintRow("Race", "Name", "Lifespoints", "Alife");
            PrintLine();
            Loop_PrintRow(Orcs);
            Loop_PrintRow(Heroes);
            PrintLine();
            Console.ReadLine();


            // Text - Output End - End Program ///////////////////////////////////////////////////////////////////////////    
        }

        //////////////////////// Case : True  - End //////////////////////////////////////////////




        // - Old Version - ////////////////////////////////////////

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

        // - Old Version - //////////////////////////////////////
    }

}

