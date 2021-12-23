// See https://aka.ms/new-console-template for more information

using System.Numerics;

string[] input = File.ReadAllLines("day6_part1_input.txt");


List<int> laternfish = input[0].Split(",").Select(c => int.Parse(c)).ToList();

BigInteger result = Simulate(256, laternfish);
Console.WriteLine(result);

BigInteger Simulate(int numDays, List<int> laternfish) 
{
    //create an array to represent the total lifespan of a laternfish
    //each element in the array represents the total number of fish
    BigInteger[] laternFishDays = new BigInteger[9];

    //fill the laternfishdays to represent the total count of fish
    for (int i = 0; i < laternfish.Count; i++) 
    {
        laternFishDays[laternfish[i]]++;
    }

    for (int i = 0; i < numDays; i++) 
    {
        BigInteger[] tempLaternFishDays = new BigInteger[9];
        Array.Copy(laternFishDays, tempLaternFishDays, 9);

        //shift the lift span of the fish
        for (int j = 8; j > 0 ; j--) 
        {
            laternFishDays[j - 1] = tempLaternFishDays[j];
        }

        laternFishDays[6] += tempLaternFishDays[0];

        laternFishDays[8] = tempLaternFishDays[0];
    }

    //sum all of the integers
    BigInteger sum = 0;

    for (int i = 0; i < laternFishDays.Count(); i++) 
    {
        sum += laternFishDays[i];    
    }

    return sum;
}