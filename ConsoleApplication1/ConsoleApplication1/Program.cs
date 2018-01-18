using System;

public class Hello
{
    public static void Main()
    {

        string input = Console.ReadLine().Trim();
        int n = int.Parse(input);



        string[,] lines = new string[n, 4];
        for (int i = 0; i < n; i++)
        {
            string[] arr = Console.ReadLine().Trim().Split(',');

            Fill2DArray(i, arr, ref lines);
        }


        string x1, x2, y1, y2;
        int count = 0;
        for (int i = 0; i < n; i++)
        {
            x1 = lines[i, 0];
            y1 = lines[i, 1];

            for (int j = 0; j < n; j++)
            {
                x2 = lines[j, 2];
                y2 = lines[j, 3];

                if (x1 == x2 && y1 == y2)
                {
                    count = count + 1;
                }
            }
        }

        Console.WriteLine(count);


    }

    static void Fill2DArray(int lineNumber, string[] line, ref string[,] lines)
    {
        for (int i = 0; i < line.Length; i++)
        {

            lines[lineNumber, i] = line[i].Trim();
        }
    }
}