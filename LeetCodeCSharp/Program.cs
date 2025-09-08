public class Solution
{
    //Problem no.3110
    public static int ScoreOfString(string s)
    {
        int l = s.Length;
        int sum = 0;
        for (int i = 0; i < l - 1; i++)
        {
            sum += Math.Abs(s[i] - s[i + 1]);
        }
        return sum;
    }
}

class Program
{
    public static void Main(string[] args)
    {

        //Problem no.3110
        Console.WriteLine("Problem #3110");
        Console.WriteLine();
        Console.WriteLine($"{Solution.ScoreOfString("hello")} == 13");
        Console.WriteLine($"{Solution.ScoreOfString("zaz")} == 50");
        
    }
}