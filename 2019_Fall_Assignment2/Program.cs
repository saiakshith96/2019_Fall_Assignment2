using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _2019_Fall_Assignment2
{
    class Program
    {
        public static void Main(string[] args)
        {
            int target = 5;
            int[] nums = { 1, 3, 5, 6 };
            Console.WriteLine("Position to insert {0} is = {1}\n", target, SearchInsert(nums, target));

            int[] nums1 = { 1, 2, 2, 1 };
            int[] nums2 = { 2, 2 };
            int[] intersect = Intersect(nums1, nums2);
            Console.WriteLine("Intersection of two arrays is: ");
            DisplayArray(intersect);

            Console.WriteLine("\n");

            int[] A = { 5, 7, 3, 9, 4, 9, 8, 3, 1 };
            Console.WriteLine("Largest integer occuring once = {0}\n", LargestUniqueNumber(A));

            string keyboard = "abcdefghijklmnopqrstuvwxyz";
            string word = "cba";
            Console.WriteLine("Time taken to type with one finger = {0}\n", CalculateTime(keyboard, word));

            int[,] image = { { 1, 1, 0 }, { 1, 0, 1 }, { 0, 0, 0 } };
            int[,] flipAndInvertedImage = FlipAndInvertImage(image);
            Console.WriteLine("The resulting flipped and inverted image is:\n");
            Display2DArray(flipAndInvertedImage);
            Console.Write("\n");

            int[,] intervals = { { 0, 30 }, { 5, 10 }, { 15, 20 } };
            int minMeetingRooms = MinMeetingRooms(intervals);
            Console.WriteLine("Minimum meeting rooms needed = {0}\n", minMeetingRooms);

            int[] arr = { -4, -1, 0, 3, 10 };
            int[] sortedSquares = SortedSquares(arr);
            Console.WriteLine("Squares of the array in sorted order is:");
            DisplayArray(sortedSquares);
            Console.Write("\n");

            string s = "abca";
            if(ValidPalindrome(s)) {
                Console.WriteLine("The given string \"{0}\" can be made PALINDROME", s);
            }
            else
            {
                Console.WriteLine("The given string \"{0}\" CANNOT be made PALINDROME", s);
            }
        }

        public static void DisplayArray(int[] a)
        {
            foreach(int n in a)
            {
                Console.Write(n + " ");
            }
        }

        public static void Display2DArray(int[,] a)
        {
            for(int i=0;i<a.GetLength(0);i++)
            {
                for(int j=0;j<a.GetLength(1);j++)
                {
                    Console.Write(a[i, j] + "\t");
                }
                Console.Write("\n");
            }
        }

        public static int SearchInsert(int[] nums, int target)
        {
            try
            {
                // Write your code here
            }
            catch
            {
                Console.WriteLine("Exception occured while computing SearchInsert()");
            }

            return 0;
        }

        public static int[] Intersect(int[] nums1, int[] nums2)
        {
            try
            {
                // Write your code here
            }
            catch
            {
                Console.WriteLine("Exception occured while computing Intersect()");
            }

            return new int[] { };
        }

        public static int LargestUniqueNumber(int[] A)
        {
            try
            {
                // write your code here
            }
            catch
            {
                Console.WriteLine("Exception occured while computing LargestUniqueNumber()");
            }

            return 0;
        }

        public static int CalculateTime(string keyboard, string word)
        {
            try
            {
                var ct = new Dictionary<char, int>();
                int sum = 0;
                for (int i = 0; i < keyboard.Length; i++)
                {
                    ct.Add(keyboard[i], i);
                }
                int ind = 0;
                for (int i = 0; i < word.Length; i++)
                {

                    if (ct.ContainsKey(word[i]))
                    {
                        char c = word[i];
                        int temp = ct[word[i]];
                        sum += Math.Abs(temp - ind);
                        ind = temp;

                    }

                }
                return sum;
            }
            catch
            {
                Console.WriteLine("Exception occured while computing CalculateTime()");
            }

            return 0;
        }

        public static int[,] FlipAndInvertImage(int[,] A)
        {
            try
            {
                // Write your code here
            }
            catch
            {
                Console.WriteLine("Exception occured while computing FlipAndInvertImage()");
            }

            return new int[,] { };
        }

        public static int MinMeetingRooms(int[,] intervals)
        {
            try
            {
                // Write your code here
            }
            catch
            {
                Console.WriteLine("Exception occured while computing MinMeetingRooms()");
            }

            return 0;
        }

        public static int[] SortedSquares(int[] A)
        {
            try
            {
                int[] answer = new int[A.Length];
                int y = A.Length - 1;

                int check = y;
                int x = 0;
                while (x < y)
                {
                    if (Math.Abs(A[y]) > Math.Abs(A[x])) //iterating array from 0 on one side and from last on another side
                    {
                        answer[check] = A[y] * A[y]; //if  absolute value of last element is > than first element's abs value then add the largest element with index in answer array. 
                        y--;
                    }
                    else
                    {
                        answer[check] = A[x] * A[x]; // opposite of above
                        x++;
                    }
                    check--; //decrement index of answer everytime the loop iterartes.

                }
                return answer;

            }
            catch
            {
                Console.WriteLine("Exception occured while computing SortedSquares()");
            }

            return new int[] { };
        }

        public static bool ValidPalindrome(string s)
        {
            try
            {
                char[] check = s.ToCharArray();
                char[] ori = s.ToCharArray();
                Array.Reverse(check);
                char[] rev = check;
                int d = 0;
                List<char> o = new List<char>();
                foreach (var x in ori)
                {
                    o.Add(x);
                }
                List<char> r = new List<char>();
                foreach (var x in check)
                {
                    r.Add(x);
                }
                for (int i = 0; i < s.Length - 1; i++)
                {

                    if (o[i] != r[i])
                    {
                        o.Remove(r[i]); //chechking each element whether equal or not by comparing originl aray and reverse array and if not equal remove that single char from both original and everse and again do the analysis and every time incrementing d hence if value of d is 0 or 1 says that by removing 0 or 1char from string if we retuen true then it may become palindrome
                        r.Remove(r[i]);

                        d++;
                    }

                }
                if (d <= 1) return true;
                else return false;
            }
            catch
            {
                Console.WriteLine("Exception occured while computing ValidPalindrome()");
            }

            return false;
        }
    }
}
