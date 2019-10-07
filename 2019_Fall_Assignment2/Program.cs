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

            int[,] intervals = { { 29, 30 }, { 5, 10 }, { 15, 20 } };
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
                int len = nums.Length;
                int start = 0;
                int end = len - 1;
                int c = -1;



                while (start <= end)
                {
                    int mid = (start + end) / 2;
                    if (nums[mid] == target)
                    {
                        c = mid; //if mid element is out target then break and dispplay
                        break;
                    }
                    else if (nums[mid] > target) //if target is on right half
                    {
                        end = mid - 1;     //divide again this right half to two parts 
                        if (mid == 0)     //if first elemet is our target then c is equal to mid
                            c = mid;
                        else if ((nums[mid - 1] < target)) 
                            c = mid; //as mid start from 0 c initiated as -1

                    }
                    else if ((nums[mid] < target)) //opposite of above part
                    {
                        start = mid + 1;

                        if (mid == end)
                            c = mid + 1;
                        else if ((nums[mid + 1] > target))
                            c = mid + 1;
                    }


                }
                return c;

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
                List<int> result = new List<int>();
                int a = nums1.Length;
                int b = nums2.Length;
                Array.Sort(nums1);
                Array.Sort(nums2);
                int i = 0;
                int j = 0;

                while (i < a && j < b)
                {
                    if (nums1[i] > nums2[j])

                        j++;

                    else if (nums1[i] < nums2[j])

                        i++;

                    else
                    {
                        result.Add(nums1[i]);
                        i++;
                        j++;
                    }

                }
                return result.ToArray();

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
                int ret = -1;
                ArrayList dummy = new ArrayList();
                
                var m = new System.Collections.Generic.SortedDictionary<int, int>(); //taking a sorted dict
                Array.Sort(A);
                int n = A.Length;
                int[] arr = new int[A.Length];
                for (int i = 0; i < n; i++)
                {
                    if (!m.ContainsKey(A[i]))
                        m.Add(A[i], i); //adding char of string in key and index to value in dict
                    else
                        dummy.Add(A[i]);//if any repeated element hits it will be added to dummy lit
                }
                foreach (int d in dummy) // for each repeated element in dummy loop remove the corresponding element from dict
                {
                    if (m.ContainsKey(d))
                    {
                        m.Remove(d);
                    }
                }
                ret = m.Keys.Last();//returns the max i.e last key as it is sorted dict
                return ret;
            }
            catch
            {
                return -1;
            }
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

        public static int[,] FlipAndInvertImage(int[,] a)
        {
            try
            {
                int[,] b = new int[a.GetLength(0), a.GetLength(1)];

                for (int i = 0; i < a.GetLength(0); i++)
                {
                    int y = a.GetLength(1) - 1;

                    for (int j = 0; j < a.GetLength(1); j++)
                    {

                        b[i, y] = a[i, j];
                        y--;
                    }

                }
                for (int i = 0; i < a.GetLength(0); i++)

                {
                    for (int y = 0; y < a.GetLength(1); y++)
                    {
                        if (b[i, y] == 0)
                        {
                            b[i, y] = 1;
                        }
                        else if (b[i, y] == 1)
                        {
                            b[i, y] = 0;

                        }
                    }
                                                         
                }
                return b;
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
                
                List<int> start = new List<int>();
                List<int> end = new List<int>();
                for (int k = 0; k < intervals.GetLength(0); k++)
                
                    start.Add(intervals[k, 0]); //adding start time  values to start list
                
                for (int k = 0; k < intervals.GetLength(0); k++)
                
                    end.Add(intervals[k, 1]); //adding end time values to end list
                
                start.Sort();
                end.Sort();
                int i = 0, j = 0, rooms = 0;
                while (i < intervals.GetLength(0))
                {

                    if (start[i] < end[j]) //checking if start time of next meeting is less than end time of upcoming meeting

                        i++; //if it is less then we keep track of these meetings in room numbers
                    

                    else if (start[i] > end[j]) //checking if start time of undergoing meeting is > end time of old meeting
                    
                        j++; //if it doesn't satisfy then we keep same meeting room number and doesnot increment j whle if it fails then we need to accomodate this meeting in new room
                    
                    
                    rooms = Math.Max(rooms, i - j); // we need to accomodate all meetings as possible by alloting new room by calculating diff b/w new room(i) and meetings occured in old rooms(or meetings happened in used rooms)(j)
                }
                
                return rooms;
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
                        o.Remove(r[i]); //checking each element whether equal or not by comparing original array and reverse array and if not equal remove that single char from both original and everse and again do the analysis and every time incrementing d hence if value of d is 0 or 1 says that by removing 0 or 1char from string if we retuen true then it may become palindrome
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
