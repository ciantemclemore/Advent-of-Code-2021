// See https://aka.ms/new-console-template for more information


//sample input
int[] input = File.ReadAllLines("C:\\Users\\e378599\\Desktop\\input.txt").Select(input => int.Parse(input)).ToArray();

int numIncreases = 0;

for (int i = 1; i < input.Length; i++)
{
    int cur = input[i];
    int prev = input[i - 1];

    if (cur > prev)
    {
        numIncreases++;
    }
}

Console.WriteLine(numIncreases);

