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
                        break;

                    case 5:
                        break;

                    case 6:
                        break;

                    case 7:
                        break;

                    case 8:
                        break;

                    case 9:
                        break;

                    case 10:
                        break;
                }
            } while (lop == true);
        }
    }
}
