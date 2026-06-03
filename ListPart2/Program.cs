namespace ListPart2
{
    internal class Program
    {

        public static int menu()
        {
            Console.WriteLine();
            Console.WriteLine("1.   Problem 1");
            Console.WriteLine("2.   Problem 2");
            Console.WriteLine("3.   Problem 3");
            Console.WriteLine("4.   Problem 4");
            Console.WriteLine("0.   Exit");

            Console.WriteLine();
            Console.Write("Select An Option: ");

            return int.Parse(Console.ReadLine());
        }

        public static void proble1()
        {
            List<string> menuItems = ["Croissant", "Checken", "Meat", "Fish"];

            for (int i = 0; i < menuItems.Count; i++)
            {
                Console.WriteLine($"Dish No {i + 1}: " + menuItems[i]);
            }

            menuItems.Add("Burgur");
            menuItems.Add("Pizza");

            Console.WriteLine();

            for (int i = 0; i < menuItems.Count; i++)
            {
                Console.WriteLine($"Dish No {i + 1}: " + menuItems[i]);
            }

            menuItems.Remove("Meat");

            Console.WriteLine();

            for (int i = 0; i < menuItems.Count; i++)
            {
                Console.WriteLine($"Dish No {i + 1}: " + menuItems[i]);
            }

            Console.WriteLine();

            if (menuItems.Contains("Croissant") == true)
            {
                Console.WriteLine("The Croissant is Avalible");
            }
            else
            {
                Console.WriteLine("The Croissant is Not Avalible");
            }

            Console.WriteLine();

            Console.WriteLine($"We Have {menuItems.Count} Number of dishs.");

        }

        public static void proble2()
        {
            List<string> checkInQueue = ["Mohammed ", "Ahmed", "Aiham", "Fahad", "Shaheen"];

            for (int i = 0;i < checkInQueue.Count;i++)
            {
                Console.WriteLine($"Guest Name No {i+1}: {checkInQueue[i]}");
            }
            
            Console.WriteLine();

            checkInQueue.RemoveAt(0);
            checkInQueue.RemoveAt(0);

            for (int i = 0; i < checkInQueue.Count; i++)
            {
                Console.WriteLine($"Guest Name No {i + 1}: {checkInQueue[i]}");
            }

            Console.WriteLine();

            checkInQueue.Add("Loay");
            checkInQueue.Add("Yarub");
            checkInQueue.Add("Ahmed");

            for (int i = 0; i < checkInQueue.Count; i++)
            {
                Console.WriteLine($"Guest Name No {i + 1}: {checkInQueue[i]}");
            }

            Console.WriteLine();

            if(checkInQueue.Contains("Aiham") == true)
            {
                Console.WriteLine("The Guest is Still Witting..");
            }
            else
            {
                Console.WriteLine("The Guest Has Completed The Check-in..");
            }

            Console.WriteLine();

            Console.WriteLine($"The Total Number of Witting Guests Are: {checkInQueue.Count}");
        }

        public static void proble3()
        {

        }

        public static void proble4()
        {

        }


        static void Main(string[] args)
        {

            bool lop = true;

            do
            {

                switch(menu())
                {
                    case 0:
                        Console.WriteLine("Good Bey Freind..");
                        lop = false;
                        break;

                    case 1:
                        proble1();
                        break;

                    case 2:
                        proble2();
                        break;

                    case 3:
                        proble3();
                        break;

                    case 4:
                        proble4();
                        break;

                    default:
                        Console.WriteLine("Error.. Wrong Option.");
                        break;
                }

                Console.WriteLine("Press Any Key To Continue...");
                Console.ReadKey();
                Console.Clear();

            } while (lop == true);

        }
    }
}
