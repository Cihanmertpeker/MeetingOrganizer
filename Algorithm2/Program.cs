
internal class Program
{
    private static void Main(string[] args)
    {
        /*

        Problem:
        t and z are strings consist of lowercase English letters.

        Find all substrings for t, and return the maximum value of [ len(substring) x [how many times the substring occurs in z] ]

        Example:
        t = acldm1labcdhsnd
        z = shabcdacasklksjabcdfueuabcdfhsndsabcdmdabcdfa

        Solution:
        abcd is a substring of t, and it occurs 5 times in Z, abcd.Length x 5 = 20 is the solution

        */
        var t = "acldm1labcdhsnd";
        var z = "shabcdacasklksjabcdfueuabcdfhsndsabcdmdabcdfa";

        string FindOccurance(string t, string z)
        {

            int maxValue = 0;
            int n = t.Length;
                        
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j <= n; j++)
                {
                    string substring = t.Substring(i, j - i);
                    int count = CountOccurrences(z, substring);  
                    int value = substring.Length * count;  
                    maxValue = Math.Max(maxValue, value);  
                }
            }

            return Convert.ToString(maxValue);
        }
               
        static int CountOccurrences(string z, string substring)
        {
            int count = 0;
            int index = 0;

            while ((index = z.IndexOf(substring, index)) != -1)
            {
                count++;
                index += substring.Length;
            }

            return count;
        }

        Console.WriteLine(FindOccurance(t, z));

    }
}
