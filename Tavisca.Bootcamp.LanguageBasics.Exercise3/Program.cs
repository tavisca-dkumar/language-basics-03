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
                new[] { "P", "p", "C", "c", "F", "f", "T", "t" },
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
            int[] c = new int[protein.Length];
            int[] x = new int[protein.Length];
            int[] sol = new int[dietPlans.Length];
            int i, l, j, co, b = 99;
            l = protein.Length;
            for (i = 0; i < l; i++)
                c[i] = 5 * protein[i] + 5 * carbs[i] + 9 * fat[i];
            for (i = 0; i < dietPlans.Length; i++)
            {
                for (j = 0; j < l; j++)
                    x[j] = j;
                for (j = 0; j < dietPlans[i].Length; j++)
                {
                    //int b;
                    char v = dietPlans[i][j];
                    if (v == 'P')
                    {
                        co = protein.Max();
                        b = check(co, protein, x);
                    }
                    if (v == 'p')
                    {
                        co = protein.Min();
                        b = check(co, protein, x);
                    }
                    if (v == 'C')
                    {
                        co = carbs.Max();
                        b = check(co, carbs, x);
                    }
                    if (v == 'c')
                    {
                        co = carbs.Min();
                        b = check(co, carbs, x);
                    }
                    if (v == 'F')
                    {
                        co = fat.Max();
                        b = check(co, fat, x);
                    }
                    if (v == 'f')
                    {
                        co = fat.Min();
                        b = check(co, fat, x);
                    }
                    if (v == 'T')
                    {
                        co = c.Max();
                        b = check(co, c, x);
                    }
                    if (v == 't')
                    {
                        co = c.Min();
                        b = check(co, c, x);
                    }
                    if (b == 0)
                        break;
                }
                for (j = 0; j < x.Length; j++)
                    if (x[j] != -1)
                    {
                        sol[i] = x[j];
                        break;
                    }
            }
            return sol;

            throw new NotImplementedException();
        }
    }
}
