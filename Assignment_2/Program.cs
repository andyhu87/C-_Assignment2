using System;
using System.Text;

class Program {
    static void Main() {
        /****** Practice Array ******/

        /*** 1. Copying an Array ***/
        PracticeArray.CopyArray();

        /*** 2. List Management ***/
        PracticeArray.ManagingList();

        /*** 3. Prime Number ***/
        int[] primes = PracticeArray.FindPrimesInRange(1, 20);

        if (primes != null)
        {
            foreach (int prime in primes)
            {
                Console.WriteLine(prime);
            }
        }

        /*** 4. Rotate and sum ***/
        int[] arr4 = { 1, 2, 3, 4, 5 };
        PracticeArray.RotateAndSum(arr4, 3);        // Output: 3 2 5 6

        /*** 5. Find the longest sequence ***/
        int[] arr5 = { 2, 1, 1, 2, 3, 3, 2, 2, 2, 1, 2, 2, 2 };
        PracticeArray.LongestSequence(arr5);        // Output: 2 2 2
        

        /*** 7. Find Most freuqent number ***/
        int[] arr7 = { 4, 11, 11, 11, 11, 12, 14, 14, 13, 2, 2, 4, 4, 11, 2 };
        Console.WriteLine(PracticeArray.MostFrequentNumber(arr7));  // Output: 11
        

        /****** Practice Strings ******/

        /*** 1. Reverse string letter ***/
        Console.WriteLine("String Input: ");
        string str = Console.ReadLine();
        PracticeStrings.ReverseString(str);
        

        /*** 2. Reverse words in sentence ***/
        string sentence1 = "The quick brown fox jumps over the lazy dog /Yes! Really!!!/.";
        string reversed1 = PracticeStrings.ReverseWords(sentence1);
        Console.WriteLine(reversed1);
        

        /*** 3. Extract palindromes ***/
        PracticeStrings.Palindromes("Hi,exe? ABBA! Hog fully a string: ExE. Bob");


        /*** 4. Pharse URL ***/
        string url = "https://www.apple.com/iphone";
        string[] parts = PracticeStrings.ParseUrl(url);
        Console.WriteLine("[protocol] = \"{0}\", [server] = \"{1}\", [resource] = \"{2}\"", parts[0], parts[1], parts[2]);

    }

}


public class PracticeArray {
    // 1. Copying an Array
    public static void CopyArray()
    {
        // Create initial array
        int[] originalArray = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        // Create second array with the same length
        int[] newArray = new int[originalArray.Length];

        // Copy the array
        for (int i = 0; i < originalArray.Length; i++)
        {
            newArray[i] = originalArray[i];
        }

        // Print both arrays
        Console.WriteLine("Original array:");
        foreach (int item in originalArray)
        {
            Console.Write(item + " ");
        }

        Console.WriteLine("\nNew array:");
        foreach (int item in newArray)
        {
            Console.Write(item + " ");
        }
    }

    // 2. List Management
    public static void ManagingList()
    {
        var items = new List<string>();
        while (true)
        {
            Console.WriteLine("Enter command (+ item, - item, or -- to clear):");
            string input = Console.ReadLine().Trim();
            if (input.StartsWith("+"))
            {
                string item = input.Substring(1).Trim();
                items.Add(item);
            }
            else if (input.StartsWith("-"))
            {
                string item = input.Substring(1).Trim();
                items.Remove(item);
            }
            else if (input == "--")
            {
                items.Clear();
            }
            else
            {
                Console.WriteLine("Invalid command.");
            }
            Console.WriteLine("Current list:");
            foreach (string item in items)
            {
                Console.WriteLine(item);
            }
        }
    }

    // 3. Calculate Prime Number
    public static int[] FindPrimesInRange(int startNum, int endNum)
    {
        if (startNum > endNum)
        {
            Console.WriteLine("Invalid input: startNum is greater than endNum");
            return null;
        }

        int[] primes = new int[endNum - startNum + 1];
        int index = 0;

        for (int i = startNum; i <= endNum; i++)
        {
            bool isPrime = true;

            for (int j = 2; j < i; j++)
            {
                if (i % j == 0)
                {
                    isPrime = false;
                    break;
                }
            }

            if (isPrime)
            {
                primes[index] = i;
                index++;
            }
        }

        Array.Resize(ref primes, index);

        return primes;
    }

    // 4. Rotate and Sum
    public static void RotateAndSum(int[] arr, int k)
    {
        int[] sum = new int[arr.Length];
        for (int i = 0; i < k; i++)
        {
            int last = arr[arr.Length - 1];
            for (int j = arr.Length - 1; j > 0; j--)
            {
                arr[j] = arr[j - 1];
                sum[j] += arr[j];
            }
            arr[0] = last;
            sum[0] += arr[0];
        }
        // Output the sums
        Console.WriteLine(string.Join(" ", sum));
    }

    // 5. Find the longest sequence
    public static void LongestSequence(int[] arr)
    {
        int maxCount = 0;
        int maxIndex = 0;

        for (int i = 0; i < arr.Length; i++)
        {
            int count = 1;
            while (i + count < arr.Length && arr[i + count] == arr[i])
            {
                count++;
            }
            if (count > maxCount)
            {
                maxCount = count;
                maxIndex = i;
            }
        }

        for (int i = maxIndex; i < maxIndex + maxCount; i++)
        {
            Console.Write(arr[i] + " ");
        }
    }

    // 7. Find Most freuqent number
    public static int MostFrequentNumber(int[] arr)
    {
        int mostFrequentNumber = arr[0];
        int highestFrequency = 1;
        int currentNumber = arr[0];
        int currentFrequency = 1;

        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] == currentNumber)
            {
                currentFrequency++;
            }
            else
            {
                if (currentFrequency > highestFrequency)
                {
                    highestFrequency = currentFrequency;
                    mostFrequentNumber = currentNumber;
                }
                currentNumber = arr[i];
                currentFrequency = 1;
            }
        }

        if (currentFrequency > highestFrequency)
        {
            mostFrequentNumber = currentNumber;
        }

        return mostFrequentNumber;
    }
}


public class PracticeStrings {
    // 1. Reverse string letters
    public static void ReverseString(string input)
    {
        for (int i = input.Length - 1; i >= 0; i--)
        {
            Console.Write(input[i]);
        }
        Console.WriteLine();
    }

    // 2. Reverse words in sentence
    public static string ReverseWords(string sentence)
    {
        char[] separators = new char[] { '.', ',', ':', ';', '=', '(', ')', '&', '[', ']', '"', '\'', '\\', '/', '!', '?', ' ' };

        string[] words = sentence.Split(separators, StringSplitOptions.RemoveEmptyEntries);

        string[] separatorsOnly = sentence.Split(words, StringSplitOptions.RemoveEmptyEntries);

        Array.Reverse(words);

        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < separatorsOnly.Length; i++)
        {
            sb.Append(separatorsOnly[i]);
            if (i < words.Length)
            {
                sb.Append(words[i]);
            }
        }

        return sb.ToString();
    }

    // 3. Extract palindromes
    public static void Palindromes(string text)
    {
        char[] separators = { ' ', '.', ',', ':', ';', '=', '(', ')', '&', '[', ']', '"', '\'', '\\', '/', '!', '?' };
        string[] words = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
        string[] palindromes = new string[words.Length];
        int count = 0;

        for (int i = 0; i < words.Length; i++)
        {
            string word = words[i];
            bool isPalindrome = true;

            for (int j = 0; j < word.Length / 2; j++)
            {
                if (word[j] != word[word.Length - j - 1])
                {
                    isPalindrome = false;
                    break;
                }
            }

            if (isPalindrome)
            {
                bool isDuplicate = false;

                for (int k = 0; k < count; k++)
                {
                    if (word == palindromes[k])
                    {
                        isDuplicate = true;
                        break;
                    }
                }

                if (!isDuplicate)
                {
                    palindromes[count] = word;
                    count++;
                }
            }
        }

        Array.Sort(palindromes, 0, count);

        for (int i = 0; i < count; i++)
        {
            Console.Write(palindromes[i]);

            if (i < count - 1)
            {
                Console.Write(", ");
            }
        }
    }

    // 4. Pharse URL
    public static string[] ParseUrl(string url)
    {
        string[] parts = new string[3];

        int serverStart = url.IndexOf("//") + 2;
        int serverEnd = url.IndexOf("/", serverStart);
        if (serverEnd == -1)
        {
            serverEnd = url.Length;
        }
        parts[1] = url.Substring(serverStart, serverEnd - serverStart);

        int protocolEnd = url.IndexOf(":");
        if (protocolEnd > 0 && protocolEnd < serverStart)
        {
            parts[0] = url.Substring(0, protocolEnd);
        }
        else
        {
            parts[0] = "";
        }

        if (serverEnd < url.Length)
        {
            parts[2] = url.Substring(serverEnd + 1);
        }
        else
        {
            parts[2] = "";
        }

        return parts;
    }

}
