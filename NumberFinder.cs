using System;
using System.Collections.Generic;

namespace PadawansTask6
{
    public static class NumberFinder
    {
        public static int? NextBiggerThan(int number)
        {
            if (number <= 0)
                throw new ArgumentException();
            if (BigNumber(number))
                return null;
            bool result = false;
            int[] digits = NumberToArray(number);
            int ind = -1;
            for (int i = digits.Length - 1; i > 0; i--)
            {
                if(digits[i] > digits[i - 1])
                {
                    int temp = digits[i];
                    digits[i] = digits[i - 1];
                    digits[i - 1] = temp;
                    result = true;
                    ind = i;
                    break;
                }
            }
            if (result)
            {
                BubbleSort(digits, ind);
                return DigitsToNumber(digits);
            }
            else
                return null;

        }

        //private static int[] GetMasNumbersFromDigits(int number)
        //{
        //    string s = "" + number;
        //    List<int> listNumbers = new List<int>();
        //    int[] digits = new int[s.Length];
        //    for (int j = 0; j < s.Length; j++)
        //        digits[j] = -2;
        //    PuzzleFromDigits(number, digits, listNumbers,true);
        //    return listNumbers.ToArray();
        //}

        //private static void PuzzleFromDigits(int number, int[] digits, List<int> listNumbers,bool firstElement)
        //{
        //    for (int i = 0; i < digits.Length; i++)
        //    {
        //        if(firstElement)
        //            for (int j = 0; j < digits.Length; j++)
        //                digits[j] = -2;
        //        if (digits[i] != -2)
        //            continue;
        //        digits[i] = number % 10;
        //        bool full = true;
        //        for (int j = 0; j < digits.Length; j++)
        //            if (digits[j] == -2)
        //                full = false;
        //        if (full)
        //            listNumbers.Add(DigitsToNumber(digits));
        //        else
        //            PuzzleFromDigits(number / 10, digits, listNumbers, false);
        //        digits[i] = -2;
        //    }
        //}

        private static int DigitsToNumber(int[] digits)
        {
            string s = "";
            for (int i = 0; i < digits.Length; i++)
            {
                s += "" + digits[i] ;
            }
            return Convert.ToInt32(s);
        }

        private static int[] NumberToArray(int number)
        {
            string s = "" + number;
            int[] digits = new int[s.Length];
            for(int i = s.Length - 1; i >= 0; i--)
            {
                digits[i] = number % 10;
                number /= 10; 
            }
            return digits;
        }

        private static void BubbleSort(int[] A, int start)
        {
            for (int i = start; i < A.Length; i++)
                for (int j = start; j < A.Length - 1; j++)
                {
                    if (A[j] > A[j + 1])
                    {
                        int temp = A[j];
                        A[j] = A[j + 1];
                        A[j + 1] = temp;
                    }
                }
           
        }

        private static bool BigNumber(int number)
        {
            string s = "" + number;
            string s2 = "" + int.MaxValue;
            if (s.Length < s2.Length)
                return false;
            return true;
        }
    }
}
