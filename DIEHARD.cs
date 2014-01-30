﻿using System;

namespace AlgoSolution
{
    struct M
    {
        public int Health;
        public int Armour;
        public string current;
    }
    class DIEHARD
    {
        public static void Main()
        {
            Run();
        }

        static void Run()
        {
            int t = int.Parse(Console.ReadLine());
            while (t > 0)
            {
                string[] str = Console.ReadLine().Split();
                int health = int.Parse(str[0]);
                int armour = int.Parse(str[1]);

                M[] r = new M[3];
                for (int i = 0; i < 3; i++)
                {
                    r[i].Armour = armour;
                    r[i].Health = health;
                }
                r[0].current = "air";
                r[1].current = "water";
                r[2].current = "fire";
                int totalTime = 0;
                M air = new M();
                air.Health = 3;
                air.Armour = 2;
                air.current = "air";
                M water = new M();
                water.Armour = -10;
                water.Health = -5;
                water.current = "water";
                M fire = new M();
                fire.Health = -20;
                fire.Armour = 5;
                fire.current = "fire";
                while (true)
                {
                    int missingCounter = 3;
                    if (r[0].Armour > 0 && r[0].Health > 0)
                    {
                        D(ref air, ref water, ref fire, ref r[0]);
                    }
                    else
                    {
                        missingCounter--;
                    }
                    if (r[1].Armour > 0 && r[1].Health > 0)
                    {
                        M myCurrentPlace = r[1];
                        D(ref air, ref water, ref fire, ref r[1]);
                    }
                    else
                    {
                        missingCounter--;
                    }
                    if (r[2].Armour > 0 && r[2].Health > 0)
                    {
                        M myCurrentPlace = r[2];
                        D(ref air, ref water, ref fire, ref r[2]);
                    }
                    else
                    {
                        missingCounter--;
                    }
                    if (missingCounter == 0)
                        break;
                    totalTime++;
                }
                t--;
                Console.WriteLine(totalTime - 1);
            }
            Console.ReadLine();
        }

        private static void D(ref M air, ref M water, ref M fire, ref M myCurrentPlace)
        {
            if (myCurrentPlace.current == "air")
            {
                //We can go either in fire or water
                int healthAfterFire = myCurrentPlace.Health + fire.Health;
                int healthAfterWater = myCurrentPlace.Health + water.Health;

                int armourAfterFire = myCurrentPlace.Armour + fire.Armour;
                int armourAfterWater = myCurrentPlace.Armour + water.Armour;

                int waterMin = Math.Min(healthAfterWater, armourAfterWater);
                int fireMin = Math.Min(healthAfterFire, armourAfterFire);
                if (waterMin >= fireMin)
                {
                    myCurrentPlace.current = "water";
                    myCurrentPlace.Armour = armourAfterWater;
                    myCurrentPlace.Health = healthAfterWater;
                }
                else
                {
                    myCurrentPlace.current = "fire";
                    myCurrentPlace.Armour = armourAfterFire;
                    myCurrentPlace.Health = healthAfterFire;
                }
            }
            else if (myCurrentPlace.current == "water")
            {
                //We can go either in fire or water
                int healthAfterFire = myCurrentPlace.Health + fire.Health;
                int healthAfterair = myCurrentPlace.Health + air.Health;

                int armourAfterFire = myCurrentPlace.Armour + fire.Armour;
                int armourAfterair = myCurrentPlace.Armour + air.Armour;

                int waterMin = Math.Min(healthAfterair, armourAfterair);
                int fireMin = Math.Min(healthAfterFire, armourAfterFire);
                if (waterMin >= fireMin)
                {
                    myCurrentPlace.current = "air";
                    myCurrentPlace.Armour = armourAfterair;
                    myCurrentPlace.Health = healthAfterair;
                }
                else
                {
                    myCurrentPlace.current = "fire";
                    myCurrentPlace.Armour = armourAfterFire;
                    myCurrentPlace.Health = healthAfterFire;
                }
            }
            else if (myCurrentPlace.current == "fire")
            {
                //We can go either in fire or water
                int healthAfterwater = myCurrentPlace.Health + water.Health;
                int healthAfterair = myCurrentPlace.Health + air.Health;

                int armourAfterwater = myCurrentPlace.Armour + water.Armour;
                int armourAfterair = myCurrentPlace.Armour + air.Armour;

                int waterMin = Math.Min(healthAfterair, armourAfterair);
                int fireMin = Math.Min(healthAfterwater, armourAfterwater);
                if (waterMin >= fireMin)
                {
                    myCurrentPlace.current = "air";
                    myCurrentPlace.Armour = armourAfterair;
                    myCurrentPlace.Health = healthAfterair;
                }
                else
                {
                    myCurrentPlace.current = "water";
                    myCurrentPlace.Armour = armourAfterwater;
                    myCurrentPlace.Health = healthAfterwater;
                }
            }
        }
    }
}

