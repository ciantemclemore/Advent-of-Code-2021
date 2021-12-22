// See https://aka.ms/new-console-template for more information

//part 1 input
string[] day1Input = File.ReadAllLines("day1_part1_input.txt");


//part 1 result
int result = CalculateIncreases(day1Input.Select(input => int.Parse(input)).ToArray());
Console.WriteLine(result);

//part 2 result
int[] parsedInput = ParsePart2Input(day1Input).Values.ToArray() ;
int result2 = CalculateIncreases(parsedInput);
Console.WriteLine(result2);




static int CalculateIncreases(int[] input) 
{
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
    return numIncreases;
}

static Dictionary<int, int> ParsePart2Input(string[] input) 
{
    //sample lines
    //199  A      
    //200  A B
    //208  A B C
    //207  E F   D
    Dictionary<int, int> output = new();

    for (int i = 0; i < input.Length; i++)
    {
        if (!output.ContainsKey(i))
        {
            output.Add(i, int.Parse(input[i]));

            if (i == 1)
            {
                output[i - 1] += int.Parse(input[i]);
            } 
            else if (i > 1) 
            {
                output[i - 1] += int.Parse(input[i]);
                output[i - 2] += int.Parse(input[i]);
            }
        }
    }

    return output;
}

