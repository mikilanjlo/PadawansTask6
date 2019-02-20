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
            int[] numbers = GetMasNumbersFromDigits(number);
            int ind = 0;

            numbers = BubbleSort(numbers);

            for (int i = 0; i < numbers.Length; i++)
                if (numbers[i] == number)
                    ind = i;
            
            if (ind == numbers.Length - 1)
                return null;
            else
                return numbers[ind + 1];
        }

        private static int[] GetMasNumbersFromDigits(int number)
        {
            string s = "" + number;
            List<int> listNumbers = new List<int>();
            int[] digits = new int[s.Length];
            for (int j = 0; j < s.Length; j++)
                digits[j] = -2;
            PuzzleFromDigits(number, digits, listNumbers,true);
            return listNumbers.ToArray();
        }

        private static void PuzzleFromDigits(int number, int[] digits, List<int> listNumbers,bool firstElement)
        {
            for (int i = 0; i < digits.Length; i++)
            {
                if(firstElement)
                    for (int j = 0; j < digits.Length; j++)
                        digits[j] = -2;
                if (digits[i] != -2)
                    continue;
                digits[i] = number % 10;
                bool full = true;
                for (int j = 0; j < digits.Length; j++)
                    if (digits[j] == -2)
                        full = false;
                if (full)
                    listNumbers.Add(DigitsToNumber(digits));
                else
                    PuzzleFromDigits(number / 10, digits, listNumbers, false);
                digits[i] = -2;
            }
        }

        private static int DigitsToNumber(int[] digits)
        {
            string s = "";
            for(int i = 0; i < digits.Length; i++)
            {
                s = "" + digits[i] + s;
            }
            return Convert.ToInt32(s);
        }

        private static int[] BubbleSort(int[] A)
        {
            for (int i = 0; i < A.Length; i++)
                for (int j = 0; j < A.Length - 1; j++)
                {
                    if (A[j] > A[j + 1])
                    {
                        int temp = A[j];
                        A[j] = A[j + 1];
                        A[j + 1] = temp;
                    }
                }
            return A;
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
