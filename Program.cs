using System;
using System.Collections.Generic;

namespace HumanvsOrc
{
    class Program
    {
        static void Main()
        {
            List<Underlyings> Heroes = new List<Underlyings>();
            {
                // --> ( Attackvalue, Paradevalue , Lifepoints, Damage)
                Heroes.Add(new Underlyings(15, 14, 30, 6));
                Heroes.Add(new Underlyings(14, 15, 24, 5));
                Heroes.Add(new Underlyings(16, 12, 33, 7));

            }
            List<Underlyings> Orcs = new List<Underlyings>();
            {
                // --> ( Attackvalue, Paradevalue , Lifepoints, Damage)
                Orcs.Add(new Underlyings(8, 7, 16, 4));
                Orcs.Add(new Underlyings(12, 6, 20, 3));
                Orcs.Add(new Underlyings(8, 7, 15, 3));
                Orcs.Add(new Underlyings(11, 4, 23, 4));
                Orcs.Add(new Underlyings(15, 14, 15, 6));
            }

            Console.WriteLine($"Startwerte: ");

            while (Heroes[0].Lifepoints >= 0) // Falls Held stirbt, wird die Schleife abgebrochen
            {
                Random A_D_rnd = new Random();
                int AttackrndH = A_D_rnd.Next(1, 20); // Attacke Held - Random
                int DefendrndH = A_D_rnd.Next(1, 20); // Parade Held - Random
                int AttackrndO = A_D_rnd.Next(1, 20); // Attacke Orc - Random
                int DefendrndO = A_D_rnd.Next(1, 20); // Parade Orc - Random

                //------------------------------------------------
                if (Orcs[0].Lifepoints <= 0) 
                {
                            if (Orcs[1].Lifepoints <= 0) // Falls Orc stribt -> Schleife wird abgebrochen
                            {
                                break;
                            }
                                //Hero Attack gelungen - Orc1 Parade fehlgeschlagen
                                else if (AttackrndH <= Heroes[0].Attackvalue && DefendrndO > Orcs[1].Paradevalue)
                                {
                                    Orcs[1].Lifepoints = Orcs[1].Lifepoints - Heroes[0].Damage;
                                    Console.WriteLine($"Ork1 hat {Orcs[1].Lifepoints} Lebenspunkte ");
                                }
                                //Hero Attack parrierd
                                else if (AttackrndH < Heroes[0].Attackvalue && DefendrndO <= Orcs[1].Paradevalue)
                                {
                                    Console.WriteLine("Attacke vom Held parriert");
                                }
                                // Hero Attacke misslungen
                                else if (AttackrndH > Heroes[0].Attackvalue)
                                {
                                    Console.WriteLine("Attacke von Held misslungen");
                                }
                }
                    //Hero Attack gelungen - Orc Parade fehlgeschlagen
                    else if (AttackrndH <= Heroes[0].Attackvalue && DefendrndO > Orcs[0].Paradevalue)
                    {
                        Orcs[0].Lifepoints = Orcs[0].Lifepoints - Heroes[0].Damage;
                        Console.WriteLine($"Ork hat {Orcs[0].Lifepoints} Lebenspunkte ");
                    }
                    //Hero Attack parrierd
                    else if (AttackrndH < Heroes[0].Attackvalue && DefendrndO <= Orcs[0].Paradevalue)
                    {
                        Console.WriteLine("Attacke vom Held parriert");
                    }
                    // Hero Attacke misslungen
                    else if (AttackrndH > Heroes[0].Attackvalue)
                    {
                        Console.WriteLine("Attacke von Held misslungen");
                    }


                //------------------------------------------
                if(Orcs[0].Lifepoints <= 0) 
                {
                            if(Orcs[1].Lifepoints <= 0) // Falls Orc stribt -> Schleife wird abgebrochen
                            {
                                break;
                            }
                            //Orc1 Attack gelungen - Held Parade fehlgeschlagen
                            else if (AttackrndO <= Orcs[1].Attackvalue && DefendrndH > Heroes[0].Paradevalue)
                            {
                                Heroes[0].Lifepoints = Heroes[0].Lifepoints - Orcs[1].Damage;
                                Console.WriteLine($"Hero hat {Heroes[0].Lifepoints} Lebenspunkte " + "\n");
                            }
                            //Orc1 Attack parrierd
                            else if (AttackrndO < Orcs[1].Attackvalue && DefendrndH <= Orcs[1].Paradevalue)
                            {
                                Console.WriteLine("Attacke vom Ork 1 parriert" + "\n");
                            }
                            // Orc1 Attacke misslungen
                            else if (AttackrndO > Orcs[1].Attackvalue)
                            {
                                Console.WriteLine("Attacke Ork 1 misslungen" + "\n");
                            }
                }
                    //Orc Attack gelungen - Held Parade fehlgeschlagen
                    else if (AttackrndO <= Orcs[0].Attackvalue && DefendrndH > Heroes[0].Paradevalue)
                    {
                        Heroes[0].Lifepoints = Heroes[0].Lifepoints - Orcs[0].Damage;
                        Console.WriteLine($"Hero hat {Heroes[0].Lifepoints} Lebenspunkte " + "\n");
                    }
                    //Orc Attack parrierd
                    else if (AttackrndO < Orcs[0].Attackvalue && DefendrndH <= Orcs[0].Paradevalue)
                    {
                         Console.WriteLine("Attacke vom Ork parriert" + "\n");
                    }
                    // Orc Attacke misslungen
                    else if (AttackrndO > Orcs[0].Attackvalue)
                    {
                        Console.WriteLine("Attacke Ork misslungen" + "\n");
                    }
            }

            Console.WriteLine($"Daten vom Orc : {Orcs[0].getdateRed()}");
            Console.WriteLine($"Daten vom Orc : {Orcs[1].getdateRed()}");
            Console.WriteLine($"Daten vom Hero : {Heroes[0].getdateRed()}");
            Console.WriteLine($"Daten vom Hero : {Heroes[1].getdateRed()}");

            Console.ReadKey();
        }
     }
}



