using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

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
    //Problem no.3105
    public static int LongestMonotonicSubarray(int[] nums)
    {
        if (nums.Length == 1)
            return 1;
        int longestStreak = 1;
        int longestIncrease = 1;
        int longestDecrease = 1;

        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] > nums[i - 1])
            {
                longestIncrease++;
                longestDecrease = 1;
            }
            if (nums[i] < nums[i - 1])
            {
                longestDecrease++;
                longestIncrease = 1;
            }
            if (nums[i] == nums[i - 1])
            {
                longestIncrease = 1;
                longestDecrease = 1;
            }
            longestStreak = Math.Max(longestStreak, Math.Max(longestIncrease, longestDecrease));
        }
        return longestStreak;
    }
    //Problem no.3046
    public static bool IsPossibleToSplit(int[] nums)
    {
        Array.Sort(nums);
        for (int i = 1; i < nums.Length - 1; i++)
        {
            if ((i + 1) >= nums.Length)
                return true;
            if (nums[i - 1] == nums[i] && nums[i] == nums[i + 1])
                return false;
        }
        return true;
        //TODO
        //Added return true because compiler says that not all path return a value
        //To be verified as I don't see a path where no value is returned
    }
    //Problem no.1769
    public static int[] MinOperations(string boxes)
    {
        int[] answer = new int[boxes.Length];
        int sum = 0;
        for (int i = 0; i < boxes.Length; i++)
        {
            for (int j = 0; j < boxes.Length; j++)
            {
                if (boxes[j] == '1')
                    sum += Math.Abs(j - i);

            }
            answer[i] = sum;
            sum = 0;
        }
        return answer;
    }
    //Problem no.2391
    public static int GarbageCollection(string[] garbage, int[] travel)
    {
        int numberOfUnits(string garbage, char typeOfGarbage)
        {
            int totalUnits = 0;
            foreach (char c in garbage)
            {
                if (c == typeOfGarbage)
                    totalUnits++;
            }
            return totalUnits;
        }

        int totalNumberOfUnits(string[] garbage, char typeOfGarbage)
        {
            int totalUnits = 0;
            foreach (string s in garbage)
            {
                totalUnits += numberOfUnits(s, typeOfGarbage);
            }
            return totalUnits;
        }

        int farthestIndex(string[] garbage, char typeOfGarbage)
        {
            int farthestIndex = 0;
            for (int i = 0; i < garbage.Length; i++)
            {
                if (garbage[i].Contains(typeOfGarbage))
                    farthestIndex = i;
            }
            return farthestIndex;
        }

        int numberOfMinuteNeeded(int[] travel, int unitTotal, int farthestIndex)
        {
            int sum = 0;
            for (int i = 0; i < farthestIndex; i++)
            {
                sum += travel[i];
            }
            sum += unitTotal;
            return sum;
        }


        int totalM = 0, totalP = 0, totalG = 0;
        int farthestM = 0, farthestG = 0, farthestP = 0;
        int numberOfMinuteM = 0, numberOfMinuteG = 0, numberOfMinuteP = 0;

        totalM = totalNumberOfUnits(garbage, 'M');
        totalP = totalNumberOfUnits(garbage, 'P');
        totalG = totalNumberOfUnits(garbage, 'G');

        farthestM = farthestIndex(garbage, 'M');
        farthestP = farthestIndex(garbage, 'P');
        farthestG = farthestIndex(garbage, 'G');
        numberOfMinuteM = numberOfMinuteNeeded(travel, totalM, farthestM);
        numberOfMinuteG = numberOfMinuteNeeded(travel, totalG, farthestG);
        numberOfMinuteP = numberOfMinuteNeeded(travel, totalP, farthestP);



        return numberOfMinuteM + numberOfMinuteG + numberOfMinuteP;
    }
    //Problem no.2023
    public static int NumOfPairs(string[] nums, string target)
    {
        int sum = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = 0; j < nums.Length; j++)
            {
                if (i != j)
                {
                    if ((nums[i] + nums[j]).Equals(target))
                        sum++;
                }
            }
        }
        return sum;
    }
    //problem #2708
    public static long MaxStrength(int[] nums)
    {
        if (nums.Length == 1 && nums[0] < 0)
            return 0;
        long sum = 1;
        foreach (int i in nums)
        {
            sum *= i;
        }
        if (sum < 0)
        {
            Array.Sort(nums);
            Array.Reverse(nums);
            int minAboveZero = -1;
            foreach (int n in nums)
            {
                if (n < 0)
                {
                    minAboveZero = n;
                    break;
                }
            }
            return sum / minAboveZero;
        }
        return sum;
    }
    //Problem #122
    public static int MaxProfit(int[] prices)
    {
        int sum = 0;
        for (int i = 0; i < prices.Length - 1; i++)
        {
            if (prices[i + 1] > prices[i])
                sum += prices[i + 1] - prices[i];
        }
        return sum;
    }
}

public class SolutionMath
{
    //Problem 2894
    public static int DifferenceOfSums(int n, int m)
    {
        int divisible = 0;
        int notDivisible = 0;
        for (int i = 1; i <= n; i++)
        {
            if (i % m != 0)
                notDivisible += i;
            else
                divisible += i;
        }
        return notDivisible - divisible;
    }

    //Problem 2769
    public static int TheMaximumAchievableX(int num, int t)
    {
        return num + (t * 2);
    }
    //Problem 2469
    public static double[] ConvertTemperature(double celsius)
    {
        double kelvin = celsius + 273.15;
        double fahrenheit = celsius * 1.80 + 32.00;
        double[] convertedTemperatures = { kelvin, fahrenheit };
        return convertedTemperatures;
    }
}

public class Utilities
{
    public static string printArray<T>(T[] array)
    {
        return "[" + string.Join(",", array) + "]";
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

        //Problem no.1512DistributeCandies
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
        Console.WriteLine("\n\nProblem #575");
        Console.WriteLine();
        Console.WriteLine($"{SolutionArray.DistributeCandies([1, 1, 2, 2, 3, 3])} = 3");
        Console.WriteLine($"{SolutionArray.DistributeCandies([1, 1, 2, 3])} = 2");
        Console.WriteLine($"{SolutionArray.DistributeCandies([6, 6, 6, 6])} = 1");

        //Problem no.3105
        Console.WriteLine("\n\nProblem #3105");
        Console.WriteLine();
        Console.WriteLine($"{SolutionArray.LongestMonotonicSubarray([1, 4, 3, 3, 2])} = 2");
        Console.WriteLine($"{SolutionArray.LongestMonotonicSubarray([3, 3, 3, 3])} = 1");
        Console.WriteLine($"{SolutionArray.LongestMonotonicSubarray([3, 2, 1])} = 3");

        //Problem no.3046
        Console.WriteLine("\n\nProblem #3046");
        Console.WriteLine();
        Console.WriteLine($"{SolutionArray.IsPossibleToSplit([1, 1, 2, 2, 3, 4])} = True");
        Console.WriteLine($"{SolutionArray.IsPossibleToSplit([1, 1, 1, 1])} = False");

        //Problem no.1769
        Console.WriteLine("\n\nProblem #1769");
        Console.WriteLine();
        Console.WriteLine($"[{string.Join(",", SolutionArray.MinOperations("110"))}] = [1,1,3]");
        Console.WriteLine($"[{string.Join(",", SolutionArray.MinOperations("001011"))}] = [11,8,5,4,3,4]");

        //Problem no.2391
        Console.WriteLine("\n\nProblem #2391");
        Console.WriteLine();
        Console.WriteLine($"{SolutionArray.GarbageCollection(["G", "P", "GP", "GG"], [2, 4, 3])} = 21");
        Console.WriteLine($"{SolutionArray.GarbageCollection(["MMM", "PGM", "GP"], [3, 10])} = 37");

        //Problem no.2023
        Console.WriteLine("\n\nProblem #2023");
        Console.WriteLine();
        Console.WriteLine($"{SolutionArray.NumOfPairs(["777", "7", "77", "77"], "7777")} = 4");
        Console.WriteLine($"{SolutionArray.NumOfPairs(["123", "4", "12", "34"], "1234")} = 2");
        Console.WriteLine($"{SolutionArray.NumOfPairs(["1", "1", "1"], "11")} = 6");

        //Problem no.2708
        Console.WriteLine("\n\nProblem #2708");
        Console.WriteLine();
        Console.WriteLine($"{SolutionArray.MaxStrength([3, -1, -5, 2, 5, -9])} = 1350");
        Console.WriteLine($"{SolutionArray.MaxStrength([-4, -5, -4])} = 20");

        //Problem no.122
        Console.WriteLine("\n\nProblem #122");
        Console.WriteLine();
        Console.WriteLine($"{SolutionArray.MaxProfit([7, 1, 5, 3, 6, 4])} = 7");
        Console.WriteLine($"{SolutionArray.MaxProfit([1, 2, 3, 4, 5])} = 4");
        Console.WriteLine($"{SolutionArray.MaxProfit([7, 6, 4, 3, 1])} = 0");

        //Problem no.2894
        Console.WriteLine("\n\nProblem #2894");
        Console.WriteLine();
        Console.WriteLine($"{SolutionMath.DifferenceOfSums(10, 3)} = 19");
        Console.WriteLine($"{SolutionMath.DifferenceOfSums(5, 6)} = 15");
        Console.WriteLine($"{SolutionMath.DifferenceOfSums(5, 1)} = -15");

        //Problem no.2769
        Console.WriteLine("\n\nProblem #2769");
        Console.WriteLine();
        Console.WriteLine($"{SolutionMath.TheMaximumAchievableX(4, 1)} = 6");
        Console.WriteLine($"{SolutionMath.TheMaximumAchievableX(3, 2)} = 7");

        //Problem no.2469
        Console.WriteLine("\n\nProblem #2469");
        Console.WriteLine();
        Console.WriteLine($"{Utilities.printArray(SolutionMath.ConvertTemperature(36.50))} = [309.65000,97.70000]");
        Console.WriteLine($"{Utilities.printArray(SolutionMath.ConvertTemperature(122.11))} = [395.26000,251.79800]");
    }
}