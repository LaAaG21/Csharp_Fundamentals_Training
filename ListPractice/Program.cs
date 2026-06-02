namespace ListPractice
{
    internal class Program
    {
        public static int menu()
        {
            Console.WriteLine("1.   problem1");
            Console.WriteLine("2.   problem2");
            Console.WriteLine("3.   problem3");
            Console.WriteLine("4.   problem4");
            Console.WriteLine("5.   problem5");
            Console.WriteLine("6.   problem6");
            Console.WriteLine("7.   problem7");
            Console.WriteLine("0.   Exit");

            Console.WriteLine();
            Console.WriteLine("Select an Option: ");

            return int.Parse(Console.ReadLine());
        }         

        public static void problem1()
        {
            List<double> temp = [30.1, 32.2, 18.0, 12.4, 21.1, 20.1, 40.9];

            for (int i = 0; i < temp.LongCount(); i++)
            {
                Console.WriteLine($"Day {i + 1}: " + temp[i]);
            }
            Console.WriteLine();
            Console.WriteLine("The Total Temp Stored: " + temp.LongCount());
        }

        public static void problem2()
        {
            List<int> scores = [10, 20, 30, 40, 50, 60];

            foreach (int score in scores)
            {
                Console.WriteLine($"Score: {score}");
            }

            scores.Reverse();

            Console.WriteLine();

            foreach (int score in scores)
            {
                Console.WriteLine($"Score: {score}");
            }

        }

        public static void problem3()
        {
            List<double> prices = [200.0, 300.2, 400.9, 100.1, 500.7];

            for (int i = 0; i < prices.LongCount(); i++)
            {
                Console.WriteLine($"Product {i + 1}: " + prices[i]);
            }

            if(prices.Contains(400.9) == true)
            {
                Console.WriteLine("Product Found");
            }
            else
            {
                Console.WriteLine("Product Not Found");
            }
        }

        public static void problem4()
        {
            List<int> finishTimes = [10, 20, 60, 30, 40, 70, 50, 80];

            foreach(int finishTime in finishTimes)
            {
                Console.WriteLine($"Finish Time: {finishTime}");
            }

            finishTimes.Sort();
            Console.WriteLine();

            foreach (int finishTime in finishTimes)
            {
                Console.WriteLine($"Finish Time: {finishTime}");
            }

            Console.WriteLine();
            Console.WriteLine(finishTimes.Count());
        }

        public static void problem5()
        {
            List<int> grades = [10, 20, 40, 60, 80, 100, 30, 50, 70, 90];

            grades.Sort();

            grades.Reverse();

            for(int i = 0; i < grades.Count; i++)
            {
                Console.WriteLine($"Rank {i + 1}: " + grades[i]);
            }
        }

        public static void problem6()
        {
            List<int> quantities = [ 1, 3, 5, 7, 2, 4, 6, 8 ];
            int total = 0;

            for(int i = 0; i < quantities.Count;i++)
            {
                total = total + quantities[i];
            }

            Console.WriteLine();
            Console.WriteLine("Total Sum: " + total);

            Console.WriteLine();
            Console.WriteLine("The Avarage is: " + total / quantities.Count);

            Console.WriteLine();

            if (quantities.IndexOf(7) == -1)
            {
                Console.WriteLine("Not Found");
            }
            else
            {
                Console.WriteLine("The element 7 is in index: " + quantities.IndexOf(7));
            }


        }

        public static void problem7()
        {
            List<int> copies = [ 1, 3, 5, 7, 9, 2, 4, 6, 8 ];

            foreach (int copy in copies)
            {
                Console.WriteLine($"{copy}");
            }

            copies.Sort();

            Console.WriteLine(copies[8]);

            foreach (int copy in copies)
            {
                if (copy == 0)
                {
                    Console.WriteLine("Out of Stock");
                }
            }
        }



        static void Main(string[] args)
        {
            bool lop = true;
            do
            {
                switch (menu())
                {
                    case 0:
                        Console.WriteLine("Good Bey..");
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
                }

                Console.WriteLine("Press Any Key To Continue...");
                Console.ReadKey();
                Console.Clear();

            } while (lop == true);
        }
    }
}
