namespace ArrayPractice
{
    internal class Program
    {

        public static int Menu()
        {
            Console.WriteLine("1.   Problem 1");
            Console.WriteLine("2.   Problem 2");
            Console.WriteLine("3.   Problem 3");
            Console.WriteLine("4.   Problem 4");
            Console.WriteLine("5.   Problem 5");
            Console.WriteLine("6.   Problem 6");
            Console.WriteLine("7.   Problem 7");
            Console.WriteLine("8.   Problem 8");
            Console.WriteLine("9.   Problem 9");
            Console.WriteLine("10.  Problem 10");
            Console.WriteLine("0.   Exit");

            Console.WriteLine();
            Console.Write("Select an Option: ");

            Console.WriteLine();
            Console.WriteLine("==============================================");
            Console.WriteLine();
            return int.Parse(Console.ReadLine());            
        }

        public static void problem1()
        {
            double[] temperatures = { 30.1, 32.2, 18.0, 12.4, 21.1, 20.1, 40.9 };

            for (int i = 0; i < temperatures.Length; i++)
            {
                Console.WriteLine($"Day {i + 1}: " + temperatures[i]);
            }
            Console.WriteLine();
            Console.WriteLine("The total Temp Stored: " + temperatures.Length);
        }

        public static void problem2()
        {
            int[] scores = { 10, 20, 30, 40, 50, 60 };

            foreach (int score in scores)
            {
                Console.WriteLine($"{score}");
            }

            Array.Reverse(scores);

            foreach (int score in scores)
            {
                Console.WriteLine($"{score}");
            }
        }

        public static void problem3()
        {
            double[] prices = { 200.0, 300.2, 400.9, 100.1, 500.7};

            for (int i = 0; i < prices.Length; i++)
            {
                Console.WriteLine($"Product {i + 1}: " + prices[i] + " OMR");
            }

            if (Array.IndexOf(prices, 100.1) == -1)
            {
                Console.WriteLine("Not found");
            }
            else
            {
                Console.WriteLine(Array.IndexOf(prices, 100.1));
            }
            
        }

        public static void problem4()
        {
            int[] finishTimes = { 10, 20, 60, 30, 40, 70, 50, 80 };

            foreach (int finishTime in finishTimes)
            {
                Console.WriteLine(finishTime);
            }

            Array.Sort(finishTimes);

            foreach (int finishTime in finishTimes)
            {
                Console.WriteLine(finishTime);
            }

            Console.WriteLine(finishTimes.Length);
        }

        public static void problem5()
        {
            int[] grades = { 10, 20, 40, 60, 80, 100, 30, 50, 70, 90};

            Array.Sort(grades);
            Array.Reverse(grades);

            for (int i = 0;i < grades.Length;i++)
            {
                Console.WriteLine($"Rank {i++}" + grades[i]);
            }
        }

        public static void problem6()
        {
            int[] quantities = { 1, 3, 5, 7, 2, 4, 6, 8};
            int total = 0;

            for (int i = 0; i < quantities.Length;i++)
            {
                total += quantities[i];
            }

            Console.WriteLine(total / quantities.Length);

            if (Array.IndexOf(quantities, 4) == -1)
            {
                Console.WriteLine("Not Found");
            }
            else
            {
                Console.WriteLine("Found at " + Array.IndexOf(quantities, 4));
            }
        }

        public static void problem7()
        {
            int[] copies = {1, 3, 5, 7, 9, 2, 4, 6, 8};

            foreach(int copy in copies)
            {
                Console.WriteLine($"{copy}");
            }

            Array.Sort(copies);

            Console.WriteLine(copies[8]);

            foreach (int copy in copies)
            {
                if (copy == 0)
                {
                    Console.WriteLine("Out of Stock");
                }
            }
        }

        public static void problem8()
        {
            double[] revenue = { 90.1, 70.2, 30.3, 40.44, 20.55, 10.23, 50.43, 120.12, 220.32, 400.23, 650.14, 100.0};
            double[] sortedCopy = new double [revenue.Length];

            for (int i = 0; i < revenue.Length; i++)
            {
                Console.WriteLine($"Month {i + 1}: " + revenue[i]);
            }

            for (int i = 0; i < revenue.Length; i++)
            {
                sortedCopy[i] = revenue[i];
            }

            Array.Sort(sortedCopy);

            for (int i = 0;i < sortedCopy.Length; i++)
            {
                Console.WriteLine($"Sorted Copy {i + 1}: " + sortedCopy[i]);
            }

            Console.WriteLine("Best  Revenue Month: " + sortedCopy[11]);
            Console.WriteLine("Worst Revenue Month: " + sortedCopy[0]);

            Console.WriteLine("The Average: " + sortedCopy.Sum() / sortedCopy.Length);
        }

        public static void problem9()
        {

        }

        public static void problem10()
        {

        }

        static void Main(string[] args)
        {
            bool lop = true;
            do
            {
                switch (Menu())
                {
                    case 0:
                        Console.WriteLine("GoodBey Friend.");
                        lop = false;
                        break;
                    
                    case 1:
                        problem1();
                        break;

                    case 2:
                        problem2();
                        break;

                    case 3:
                        problem3();
                        break;

                    case 4:
                        problem4();
                        break;

                    case 5:
                        problem5();
                        break;

                    case 6:
                        problem6();
                        break;

                    case 7:
                        problem7();
                        break;

                    case 8:
                        problem8();
                        break;

                    case 9:
                        problem9();
                        break;

                    case 10:
                        problem10();
                        break;
                }

                Console.WriteLine("Press Any Key To Continue...");
                Console.ReadKey();
                Console.Clear();

            } while (lop == true);
        }
    }
}
