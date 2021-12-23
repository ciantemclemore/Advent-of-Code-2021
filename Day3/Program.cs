// See https://aka.ms/new-console-template for more information

string[] input = File.ReadAllLines("day3_part1_input.txt");


int result = CalculatePowerConsumption(input);
Console.WriteLine(result);

int result2 = CalculateLifeSupportRating(input);
Console.WriteLine(result2);

static int CalculatePowerConsumption(string[] input) 
{
    int[] result = new int[input[0].Length];

    for (int i = 0; i < input.Length; i++) 
    {
        for (int j = 0; j < input[i].Length; j++) 
        {
            result[j] += input[i][j] - '0';
        }    
    }

    //create the binary string for gamma and epsilon
    string gamma = string.Empty;
    string epsilon = string.Empty;
    int rowLen = input.Length;

    for (int i = 0; i < result.Length; i++) 
    {
        var one = result[i] > (rowLen / 2) ? "1" : "0";
        var zero = result[i] > (rowLen / 2) ? "0" : "1";

        gamma += one;
        epsilon += zero;
    }

    var gammaResult = Convert.ToInt32(gamma, 2);
    var epsilonResult = Convert.ToInt32(epsilon, 2);

    return gammaResult * epsilonResult;
}

static int CalculateLifeSupportRating(string[] input)
{
    List<string> oxygenResults = new List<string>(input);
    List<string> co2Results = new List<string>(input);

    //oxygen majority
    for (int col = 0; col < input[0].Length; col++)
    {
        int result = 0;

        for (int row = 0; row < oxygenResults.Count; row++)
        {
            result += oxygenResults[row][col] - '0';
        }

        char characterToKeep = result >= (oxygenResults.Count - result) ? '1' : '0';
        List<string> newOutput = new List<string>();

        for (int i = 0; i < oxygenResults.Count; i++)
        {
            if (oxygenResults[i][col] == characterToKeep)
            {
                newOutput.Add(oxygenResults[i]);
            }
        }

        oxygenResults = newOutput;

        if (oxygenResults.Count == 1)
            break;
    }

    //co2
    for (int col = 0; col < input[0].Length; col++)
    {
        int result = 0;

        for (int row = 0; row < co2Results.Count; row++)
        {
            result += co2Results[row][col] - '0';
        }

        char characterToKeep = result >= (co2Results.Count - result) ? '0' : '1';
        List<string> newOutput = new List<string>();

        for (int i = 0; i < co2Results.Count; i++)
        {
            if (co2Results[i][col] == characterToKeep)
            {
                newOutput.Add(co2Results[i]);
            }
        }

        co2Results = newOutput;

        if (co2Results.Count == 1)
            break;
    }



    //calculate result
    var oxygenResult = Convert.ToInt32(oxygenResults[0], 2);
    var co2Result = Convert.ToInt32(co2Results[0], 2);

    return oxygenResult * co2Result;
}