// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

//keys
const string forward = "forward";
const string up = "up";
const string down = "down";

//part1 input
string[] input = File.ReadAllLines("day2_part1_input.txt");


//part1 result 
var result = CalculatePosition(input);
Console.WriteLine(result);

/// <summary>
/// Calculate the position by multiplying the final horizontal total by the final depth total
/// </summary>
static int CalculatePosition(string[] input) 
{
    //create dictionary to represent data
    /*sample data:
        forward 3 - increases horizontal position and increases depth by your aim multiplied by X (3)
        forward 5 - 
        up 9      - decreases aim by X (9) 
        down 1    - increases aim by X (1)
        forward 5 - 
     */
    
    int aim = 0;
    int horizontalPosition = 0;
    int depth = 0;

    foreach (string line in input) 
    {
        string[] token = line.Split(" ");

        string key = token[0];
        int value = int.Parse(token[1]);

        if (key == forward)
        {
            horizontalPosition += value;
            depth += aim * value;
        }
        else if (key == up)
        {
            aim -= value;
        }
        else if (key == down) 
        {
            aim += value;
        }
    }

    return horizontalPosition * depth;
}
