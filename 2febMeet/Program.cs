using System;
using System.Collections.Generic;
using System.Text;

namespace CAP2025.Day_33_Exception_FileHandlingPractice
{
    using System;

    public class Program
    {
        static void Main()
        {
            Console.Write("Enter word1: ");
            string word1 = Console.ReadLine();

            Console.Write("Enter word2: ");
            string word2 = Console.ReadLine();

            int[] freq1 = new int[256];
            int[] freq2 = new int[256];

            // Count frequency of word1
            for (int i = 0; i < word1.Length; i++)
            {
                freq1[word1[i]]++;
            }

            // Count frequency of word2
            for (int i = 0; i < word2.Length; i++)
            {
                freq2[word2[i]]++;
            }

            int deletions = 0;

            // Count deletions from word1
            for (int i = 0; i < 256; i++)
            {
                if (freq1[i] > freq2[i])
                {
                    deletions += freq1[i] - freq2[i];
                }
            }

            Console.WriteLine("Deletions required from word1: " + deletions);
        }
    }
}