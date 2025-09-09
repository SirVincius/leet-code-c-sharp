public class Solution
{
    //  Problem no.3110
    /*  Feedback is that

        string.Length is actually a property backed by a field inside the string object.
        Accessing it is O(1) (constant-time), not a loop or a recalculation.
        The JIT compiler often optimizes it away in loops so it doesn’t fetch it repeatedly.
    
    */

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
    //Problem no.2942
    public static IList<int> FindWordsContaining(string[] words, char x)
    {
        List<int> ints = new List<int>();
        for (int i = 0; i < words.Length; i++)
        {
            if (words[i].Contains(x))
                ints.Add(i);
        }
        return ints;
    }
    //Problem no.1108
    public static string DefangIPaddr(string address)
    {
        address.Replace(".", "[.]");
        return address;
    }
    //Problem no.3274
    public static bool CheckTwoChessboards(string coordinate1, string coordinate2) {
        return (coordinate1[0] % 2 == coordinate1[1] % 2) ==
        (coordinate2[0] % 2 == coordinate2[1] % 2);
    }
}

class Program
{
    public static void Main(string[] args)
    {

        //Problem no.3110
        Console.WriteLine("\n\nProblem #3110");
        Console.WriteLine();
        Console.WriteLine($"{Solution.ScoreOfString("hello")} == 13");
        Console.WriteLine($"{Solution.ScoreOfString("zaz")} == 50");

        //Problem no.2942
        Console.WriteLine("\n\nProblem #2942");
        Console.WriteLine();
        IList<int> solution1 = Solution.FindWordsContaining(["leet", "code"], 'e');
        IList<int> solution2 = Solution.FindWordsContaining(["abc", "bcd", "aaaa", "cbc"], 'a');

        Console.WriteLine("[" + string.Join(",", solution1) + "] == [0,1]");
        Console.WriteLine("[" + string.Join(",", solution2) + "] == [0,2]");

        //Problem no.1108
        Console.WriteLine("\n\nProblem #1108");
        Console.WriteLine();
        Console.WriteLine($"{Solution.DefangIPaddr("1.1.1.1")} == 1[.]1[.]1[.]1");
        Console.WriteLine($"{Solution.DefangIPaddr("255.100.50.0")} == 255[.]100[.]50[.]0");

        //Problem no.3274
        Console.WriteLine("\n\nProblem #3274");
        Console.WriteLine();
        Console.WriteLine($"{Solution.CheckTwoChessboards("a1", "c3")} == True");
        Console.WriteLine($"{Solution.CheckTwoChessboards("a1", "h3")} == False");
    
    }
}