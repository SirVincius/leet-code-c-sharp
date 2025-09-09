using System.Runtime.CompilerServices;

public class SolutionString
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
    public static bool CheckTwoChessboards(string coordinate1, string coordinate2)
    {
        return (coordinate1[0] % 2 == coordinate1[1] % 2) ==
        (coordinate2[0] % 2 == coordinate2[1] % 2);
    }



}

public class SolutionArray
{
    //Problem no.1512
    public static int NumIdenticalPairs(int[] nums)
    {
        int numbreOfGoodPairs = 0;
        for (int i = 0; i < nums.Length - 1; i++)
        {
            for (int j = i + 1; j < nums.Length; j++)
            {
                if (nums[i] == nums[j])
                    numbreOfGoodPairs++;
            }
        }
        return numbreOfGoodPairs;
    }
    //Problem no.3467
    public static int[] TransformArray(int[] nums)
    {
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] % 2 == 0)
                nums[i] = 0;
            if (nums[i] % 2 == 1)
                nums[i] = 1;
        }
        Array.Sort(nums);
        return nums;
    }
    //Problem no.2656
    public static int MaximizeSum(int[] nums, int k)
    {
        int max;
        int sum = 0;
        int index;
        for (int i = 0; i < k; i++)
        {
            max = nums.Max();
            sum += max;
            index = Array.IndexOf(nums, max);
            nums[index] = max + 1;
        }
        return sum;
    }
    //Problem no.2558
    public static long PickGifts(int[] gifts, int k)
    {
        int max;
        int index;
        for (int i = 0; i < k; i++)
        {
            max = gifts.Max();
            index = Array.IndexOf(gifts, max);
            gifts[index] = (int)Math.Floor(Math.Sqrt(max));
        }
        return gifts.Sum();
    }
    //Problem no.575
    public static int DistributeCandies(int[] candyType)
    {
        int numberToEat = candyType.Length / 2;
        int differentTypeOfCandies = 1;
        Array.Sort(candyType);
        for (int i = 0; i < candyType.Length - 1; i++)
        {
            if (candyType[i] != candyType[i + 1])
                differentTypeOfCandies++;
        }
        return numberToEat <= differentTypeOfCandies ? numberToEat : differentTypeOfCandies;
    }
}

class Program
{
    public static void Main(string[] args)
    {

        //Problem no.3110
        Console.WriteLine("\n\nProblem #3110");
        Console.WriteLine();
        Console.WriteLine($"{SolutionString.ScoreOfString("hello")} == 13");
        Console.WriteLine($"{SolutionString.ScoreOfString("zaz")} == 50");

        //Problem no.2942
        Console.WriteLine("\n\nProblem #2942");
        Console.WriteLine();
        IList<int> solution1 = SolutionString.FindWordsContaining(["leet", "code"], 'e');
        IList<int> solution2 = SolutionString.FindWordsContaining(["abc", "bcd", "aaaa", "cbc"], 'a');

        Console.WriteLine("[" + string.Join(",", solution1) + "] == [0,1]");
        Console.WriteLine("[" + string.Join(",", solution2) + "] == [0,2]");

        //Problem no.1108
        Console.WriteLine("\n\nProblem #1108");
        Console.WriteLine();
        Console.WriteLine($"{SolutionString.DefangIPaddr("1.1.1.1")} == 1[.]1[.]1[.]1");
        Console.WriteLine($"{SolutionString.DefangIPaddr("255.100.50.0")} == 255[.]100[.]50[.]0");

        //Problem no.3274
        Console.WriteLine("\n\nProblem #3274");
        Console.WriteLine();
        Console.WriteLine($"{SolutionString.CheckTwoChessboards("a1", "c3")} == True");
        Console.WriteLine($"{SolutionString.CheckTwoChessboards("a1", "h3")} == False");

        //Problem no.1512
        Console.WriteLine("\n\nProblem #1512");
        Console.WriteLine();
        Console.WriteLine($"{SolutionArray.NumIdenticalPairs([1, 2, 3, 1, 1, 3])} = 4");
        Console.WriteLine($"{SolutionArray.NumIdenticalPairs([1, 1, 1, 1])} = 6");
        Console.WriteLine($"{SolutionArray.NumIdenticalPairs([1, 2, 3])} = 0");

        //Problem no.3467
        Console.WriteLine("\n\nProblem #3467");
        Console.WriteLine();
        Console.WriteLine($"{SolutionArray.TransformArray([4, 3, 2, 1])} = [0,0,1,1]");
        Console.WriteLine($"{SolutionArray.TransformArray([1, 5, 1, 4, 2])} = [0,0,1,1,1]");

        //Problem no.2656
        Console.WriteLine("\n\nProblem #2656");
        Console.WriteLine();
        Console.WriteLine($"{SolutionArray.MaximizeSum([1, 2, 3, 4, 5], 3)} = 18");
        Console.WriteLine($"{SolutionArray.MaximizeSum([5, 5, 5], 2)} = 11");

        //Problem no.2558
        Console.WriteLine("\n\nProblem #2558");
        Console.WriteLine();
        Console.WriteLine($"{SolutionArray.PickGifts([25, 64, 9, 4, 100], 4)} = 29");
        Console.WriteLine($"{SolutionArray.PickGifts([1, 1, 1, 1], 4)} = 4");

        //Problem no.575
        Console.WriteLine("\n\nProblem #2558");
        Console.WriteLine();
        Console.WriteLine($"{SolutionArray.DistributeCandies([1, 1, 2, 2, 3, 3])} = 3");
        Console.WriteLine($"{SolutionArray.DistributeCandies([1, 1, 2, 3])} = 2");
        Console.WriteLine($"{SolutionArray.DistributeCandies([6,6,6,6])} = 1");
    }
}