using System;
using System.Linq;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    public static class Program
    {
        static void Main(string[] args)
        {
            Test(
                new[] { 3, 4 },
                new[] { 2, 8 },
                new[] { 5, 2 },
                new[] { "P", "p", "C", "calories", "F", "f", "T", "t" },
                new[] { 1, 0, 1, 0, 0, 1, 1, 0 });
            Test(
                new[] { 3, 4, 1, 5 },
                new[] { 2, 8, 5, 1 },
                new[] { 5, 2, 4, 4 },
                new[] { "tFc", "tF", "Ftc" },
                new[] { 3, 2, 0 });
            Test(
                new[] { 18, 86, 76, 0, 34, 30, 95, 12, 21 },
                new[] { 26, 56, 3, 45, 88, 0, 10, 27, 53 },
                new[] { 93, 96, 13, 95, 98, 18, 59, 49, 86 },
                new[] { "f", "Pt", "PT", "fT", "Cp", "C", "t", "", "cCp", "ttp", "PCFt", "P", "pCt", "cP", "Pc" },
                new[] { 2, 6, 6, 2, 4, 4, 5, 0, 5, 5, 6, 6, 3, 5, 6 });
            Console.ReadKey(true);
        }

        private static void Test(int[] protein, int[] carbs, int[] fat, string[] dietPlans, int[] expected)
        {
            var result = SelectMeals(protein, carbs, fat, dietPlans).SequenceEqual(expected) ? "PASS" : "FAIL";
            Console.WriteLine($"Proteins = [{string.Join(", ", protein)}]");
            Console.WriteLine($"Carbs = [{string.Join(", ", carbs)}]");
            Console.WriteLine($"Fats = [{string.Join(", ", fat)}]");
            Console.WriteLine($"Diet plan = [{string.Join(", ", dietPlans)}]");
            Console.WriteLine(result);
        }
        public static int check(int co, int[] a, int[] x)
        {
            int i, count = 0;
            int r = Array.IndexOf(a, co);

            for (i = 0; i < a.Length; i++)
            {
                if (a[i] != co && x[r] != -1)
                    x[i] = -1;
                if (x[i] == -1)
                    count++;
            }
            if (count == a.Length - 1)
                return 0;
            else
                return 1;
        }

        public static int[] SelectMeals(int[] protein, int[] carbs, int[] fat, string[] dietPlans)
        {
            // Add your code here.
            int[] calories = new int[protein.Length];
            int[] checkArray = new int[protein.Length];
            int[] solution = new int[dietPlans.Length];
            int i, arrayLength, j, MinOrMaxValue, flag = 99;
            arrayLength = protein.Length;
            for (i = 0; i < arrayLength; i++)
                calories[i] = 5 * protein[i] + 5 * carbs[i] + 9 * fat[i];
            for (i = 0; i < dietPlans.Length; i++)
            {
                for (j = 0; j < arrayLength; j++)
                    checkArray[j] = j;
                for (j = 0; j < dietPlans[i].Length; j++)
                {
                    //int flag;
                    char v = dietPlans[i][j];
                    if (v == 'P')
                    {
                        MinOrMaxValue = protein.Max();
                        flag = check(MinOrMaxValue, protein, checkArray);
                    }
                    if (v == 'p')
                    {
                        MinOrMaxValue = protein.Min();
                        flag = check(MinOrMaxValue, protein, checkArray);
                    }
                    if (v == 'C')
                    {
                        MinOrMaxValue = carbs.Max();
                        flag = check(MinOrMaxValue, carbs, checkArray);
                    }
                    if (v == 'c')
                    {
                        MinOrMaxValue = carbs.Min();
                        flag = check(MinOrMaxValue, carbs, checkArray);
                    }
                    if (v == 'F')
                    {
                        MinOrMaxValue = fat.Max();
                        flag = check(MinOrMaxValue, fat, checkArray);
                    }
                    if (v == 'f')
                    {
                        MinOrMaxValue = fat.Min();
                        flag = check(MinOrMaxValue, fat, checkArray);
                    }
                    if (v == 'T')
                    {
                        MinOrMaxValue = calories.Max();
                        flag = check(MinOrMaxValue, calories, checkArray);
                    }
                    if (v == 't')
                    {
                        MinOrMaxValue = calories.Min();
                        flag = check(MinOrMaxValue, calories, checkArray);
                    }
                    if (flag == 0)
                        break;
                }
                for (j = 0; j < checkArray.Length; j++)
                    if (checkArray[j] != -1)
                    {
                        solution[i] = checkArray[j];
                        break;
                    }
            }
            return solution;

            throw new NotImplementedException();
        }
    }
}
