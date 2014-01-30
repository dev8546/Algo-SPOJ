using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoSolution
{
    class ALIEN2
    {
        static void Main()
        {
            Run();
        }
        static void Run()
        {
            string[] strFirst = Console.ReadLine().Split();
            int N = int.Parse(strFirst[0]);
            int K = int.Parse(strFirst[1]);
            int[] peopleA = new int[N];
            int[] peopleB = new int[N];
            string[] strPeopleA = Console.ReadLine().Split();
            string[] strPeopleB = Console.ReadLine().Split();

            for (int i = 0; i < N; i++)
            {
                peopleA[i] = int.Parse(strPeopleA[i]);
                peopleB[i] = int.Parse(strPeopleB[i]);
            }

            int prevPeopleA = peopleA[0];
            int prevPeopleB = peopleB[0];
            int prevStationA = 1;
            int preveStationB = 1;
            bool isAOpen = prevPeopleA <= K;
            bool isBOpen = prevPeopleB <= K;
            int finalPeople = -1;
            int finalStation = -1;
            if (prevPeopleA > K && prevPeopleB > K)
            {
                finalStation = 0;
                finalPeople = 0;
            }
            else
            {
                if (prevPeopleA < prevPeopleB)
                {
                    finalPeople = prevPeopleA;
                    finalStation = 1;
                }
                else
                {
                    finalPeople = prevPeopleB;
                    finalStation = 1;
                }
                bool isReached = true;
                for (int i = 1; i < N; i++)
                {
                    //Way to reach on A
                    //direct from prev A
                    if (!isAOpen && !isBOpen)
                    {
                        isReached = false;
                        break;
                    }
                    int peopleADirect = Int32.MaxValue;
                    int peopleAInDirect = Int32.MaxValue;
                    int stationADirect = prevStationA;
                    int stationAInDirect = preveStationB;
                    if (isAOpen)
                    {
                        peopleADirect = prevPeopleA + peopleA[i];
                        stationADirect++;
                    }
                    if (isBOpen)
                    {
                        peopleAInDirect = prevPeopleB + peopleA[i] + peopleB[i];
                        stationAInDirect++;
                    }

                    // For reaching at statio on B

                    int peopleBDirect = Int32.MaxValue;
                    int peopleBInDirect = Int32.MaxValue;
                    int stationBDirect = preveStationB;
                    int stationBInDirect = prevStationA;
                    if (isBOpen)
                    {
                        peopleBDirect = prevPeopleB + peopleB[i];
                        stationBDirect++;
                    }
                    if (isAOpen)
                    {
                        peopleBInDirect = prevPeopleA + peopleA[i] + peopleB[i];
                        stationBInDirect++;
                    }


                    if (Math.Min(peopleADirect, peopleAInDirect) > K)
                    {
                        isAOpen = false;
                    }
                    else
                    {
                        isAOpen = true;
                        if (peopleADirect < peopleAInDirect)
                        {
                            prevPeopleA = peopleADirect;
                            prevStationA = stationADirect;
                        }
                        else
                        {
                            prevPeopleA = peopleAInDirect;
                            prevStationA = stationAInDirect;
                        }
                        finalPeople = prevPeopleA;
                        finalStation = prevStationA;
                    }

                    if (Math.Min(peopleBDirect, peopleBInDirect) > K)
                    {
                        isBOpen = false;
                    }
                    else
                    {
                        isBOpen = true;
                        if (peopleBDirect < peopleBInDirect)
                        {
                            prevPeopleB = peopleBDirect;
                            preveStationB = stationBDirect;
                        }
                        else
                        {
                            prevPeopleB = peopleBInDirect;
                            preveStationB = stationBInDirect;
                        }
                        if (isAOpen)
                        {
                            if (prevPeopleB < prevPeopleA)
                            {
                                finalPeople = prevPeopleB;
                                finalStation = preveStationB;
                            }
                        }
                        else
                        {
                            finalPeople = prevPeopleB;
                            finalStation = preveStationB;
                        }
                    }

                }
            }
            Console.WriteLine(string.Format("{1} {0}", finalPeople, finalStation));
        }
    }
}

