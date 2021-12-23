string[] input = File.ReadAllLines("day5_part1_input.txt");

List<Line> lines = ParseLines(input);

// Determine the size of the ocean floor from the vent lines
int maxX = lines.Select(l => Math.Max(l.X1, l.X2)).Max();
int maxY = lines.Select(l => Math.Max(l.Y1, l.Y2)).Max();

// Create the ocean floor
int[,] oceanFloor = new int[maxY + 1, maxX + 1];

// Draw the lines
foreach (Line line in lines)
{
    // Plot the lines
    if (line.X1 == line.X2)
    {
        // Vertical line
        if (line.Y1 > line.Y2)
        {
            for (int i = line.Y2; i <= line.Y1; i++)
            {
                oceanFloor[i, line.X1]++;
            }
        }
        else if (line.Y2 > line.Y1)
        {
            for (int i = line.Y1; i <= line.Y2; i++)
            {
                oceanFloor[i, line.X1]++;
            }
        }
        else
        {
            // Start and end point are the same, just increment the point
            oceanFloor[line.Y1, line.X1]++;
        }
    }
    else if (line.Y1 == line.Y2)
    {
        // Horizontal line
        if (line.X2 > line.X1)
        {
            for (int i = line.X1; i <= line.X2; i++)
            {
                oceanFloor[line.Y1, i]++;
            }
        }
        else if (line.X1 > line.X2)
        {
            for (int i = line.X2; i <= line.X1; i++)
            {
                oceanFloor[line.Y1, i]++;
            }
        }
        else
        {
            // Start and end point are the same, just increment the point
            oceanFloor[line.Y1, line.X1]++;
        }
    }
    else
    {
        if (line.X1 > line.X2 && line.Y1 < line.Y2)
        {
            // X decreasing, Y increasing
            int x = line.X1;
            int y = line.Y1;

            for (; x >= line.X2; x--, y++)
            {
                oceanFloor[y, x]++;
            }
        }
        else if (line.X1 < line.X2 && line.Y1 > line.Y2)
        {
            // X increasing, Y decreasing
            int x = line.X1;
            int y = line.Y1;

            for (; x <= line.X2; x++, y--)
            {
                oceanFloor[y, x]++;
            }
        }
        else if (line.X1 > line.X2 && line.Y1 > line.Y2)
        {
            // Both decreasing
            int x = line.X1;
            int y = line.Y1;

            for (; x >= line.X2; x--, y--)
            {
                oceanFloor[y, x]++;
            }
        }
        else if (line.X1 < line.X2 && line.Y1 < line.Y2)
        {
            // Both increasing
            int x = line.X1;
            int y = line.Y1;

            for (; x <= line.X2; x++, y++)
            {
                oceanFloor[y, x]++;
            }
        }
    }
}

// Find the most dangerous points
int dangerousPoints = 0;

for (int y = 0; y <= maxY; y++)
{
    for (int x = 0; x <= maxX; x++)
    {
        //if (oceanFloor[y, x] == 0)
        //{
        //    Console.Write('.');
        //}
        //else
        //{
        //    Console.Write(oceanFloor[y, x]);
        //}

        if (oceanFloor[y, x] >= 2)
        {
            dangerousPoints++;
        }
    }

    //Console.WriteLine();
}

Console.WriteLine(dangerousPoints);

static List<Line> ParseLines(string[] input)
{
    List<Line> lines = new();

    foreach (string inputLine in input)
    {
        // Parse the coordinate pairs
        List<(int, int)>? coordinates = inputLine.Split(" -> ")
            .Select(l => (int.Parse(l.Split(",")[0]), int.Parse(l.Split(",")[1])))
            .ToList();

        // Create a new line
        Line line = new()
        {
            X1 = coordinates[0].Item1,
            Y1 = coordinates[0].Item2,
            X2 = coordinates[1].Item1,
            Y2 = coordinates[1].Item2
        };

        lines.Add(line);
        /* Part one, ignore diagonal lines
        if (line.X1 == line.X2 || line.Y1 == line.Y2)
        {
            lines.Add(line);
        }
        */
    }

    return lines;
}

internal class Line
{
    // Start point
    public int X1 { get; set; }
    public int Y1 { get; set; }

    // End point
    public int X2 { get; set; }
    public int Y2 { get; set; }

    public override string ToString()
    {
        return $"{X1},{Y1} -> {X2},{Y2}";
    }
}