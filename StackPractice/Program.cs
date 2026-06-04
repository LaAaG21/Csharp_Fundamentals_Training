namespace StackPractice
{
    internal class Program
    {

        public static string menu()
        {
            Console.WriteLine();
            Console.WriteLine("1.   Problem 1");
            Console.WriteLine("2.   Problem 2");
            Console.WriteLine("3.   Problem 3");
            Console.WriteLine("4.   Problem 4");
            Console.WriteLine("5.   Problem 5");
            Console.WriteLine("6.   Problem 6");
            Console.WriteLine("0.   Exit");

            Console.WriteLine();
            Console.Write("Select An Option: ");
            return Console.ReadLine();
        }

        public static void problem1()
        {

            Stack<string> browserHistory = new Stack<string>();
            browserHistory.Push("https://github.com/LaAaG21/Csharp_Fundamentals_Training");
            browserHistory.Push("https://www.youtube.com/");
            browserHistory.Push("https://hooks.zapier.com/hooks/catch/27227515/ujoqphg/");
            browserHistory.Push("https://drive.google.com/drive/folders/1UKHY_pzG0DAjU6qvFvZcVIZm5U2rXvd_");
            browserHistory.Push("https://git-scm.com/install/windows");

            foreach(string webpage  in browserHistory)
            {
                Console.WriteLine($"Web Page: {webpage}");
            }

            Console.WriteLine();

            browserHistory.Peek();

            Console.WriteLine(browserHistory.Pop());
            Console.WriteLine(browserHistory.Pop());

            Console.WriteLine();

            foreach (string webpage in browserHistory)
            {
                Console.WriteLine($"Web Page: {webpage}");
            }

            Console.WriteLine();

            if (browserHistory.Contains("https://www.youtube.com/") == true)
            {
                Console.WriteLine("The URL Is Avalible.");
            }
            else
            {
                Console.WriteLine("The URL Is Not Avalible.");
            }

            Console.WriteLine();
            Console.WriteLine("The Total URLs Is: " + browserHistory.Count);

        }

        public static void problem2()
        {

            Queue<string> checkInQueue = new Queue<string>();

            checkInQueue.Enqueue("Loay");
            checkInQueue.Enqueue("Aihem");
            checkInQueue.Enqueue("Fahad");
            checkInQueue.Enqueue("Mohammed");
            checkInQueue.Enqueue("Ahmed");

            foreach (string guest in checkInQueue)
            {
                Console.WriteLine($"Guest Name: {guest}");
            }
            Console.WriteLine();

            checkInQueue.Peek();

            Console.WriteLine(checkInQueue.Dequeue());
            Console.WriteLine(checkInQueue.Dequeue());

            Console.WriteLine();

            foreach (string guest in checkInQueue)
            {
                Console.WriteLine($"Guest Name: {guest}");
            }

            Console.WriteLine();

            if (checkInQueue.Contains("Mohammed") == true)
            {
                Console.WriteLine("Mohammed Is Still Witting");
            }
            else
            {
                Console.WriteLine("Mohammed Has Left The Queue");
            }

            Console.WriteLine();

            Console.WriteLine("The Total Number In The Queue Is: " + checkInQueue.Count);

        }

        public static void problem3()
        {
            Stack<string> undoStack = new Stack<string>();
            Stack<string> tempStack = new Stack<string>();

            undoStack.Push("Write ZZZ");
            undoStack.Push("Write AAA");
            undoStack.Push("Write SSS");
            undoStack.Push("Write CCC");
            undoStack.Push("Write VVV");
            undoStack.Push("Write PPP");
            undoStack.Push("Write MMM");

            foreach (string item in undoStack)
            {
                Console.WriteLine("Undo: " + item);
            }

            Console.WriteLine();

            undoStack.Peek();

            Console.WriteLine(undoStack.Pop());
            Console.WriteLine(undoStack.Pop());

            Console.WriteLine();

            foreach (string item in undoStack)
            {
                Console.WriteLine("Undo: " + item);
            }

            Console.WriteLine();

            while (undoStack.Count > 0)
            {
                if(undoStack.Peek() == "Write CCC")
                {
                    undoStack.Pop();
                }
                else
                {
                    tempStack.Push(undoStack.Pop());
                }
            }

            while (tempStack.Count > 0)
            {
                undoStack.Push(tempStack.Pop());
            }

            foreach (string item in undoStack)
            {
                Console.WriteLine("Undo: " + item);
            }

            Console.WriteLine();

            Console.WriteLine("The Total Undo Stack: " + undoStack.Count);

        }

        public static void problem4()
        {
            int i = 1;
            Queue<string> triageQueue = new Queue<string>();
            Queue<string> tempQueue = new Queue<string>();

            triageQueue.Enqueue("Aiham");
            triageQueue.Enqueue("Ahmed");
            triageQueue.Enqueue("Loay");
            triageQueue.Enqueue("Fahad");
            triageQueue.Enqueue("Mohammed");
            triageQueue.Enqueue("Shaheen");
            triageQueue.Enqueue("yarub");
            triageQueue.Enqueue("Khalid");

            foreach (string item in triageQueue)
            {
                Console.WriteLine($"Patient {i} Name: " + item);
                i++;
            }

            triageQueue.Peek();

            Console.WriteLine();

            Console.WriteLine("Has Been Served: " + triageQueue.Dequeue());
            Console.WriteLine("Has Been Served: " + triageQueue.Dequeue());
            Console.WriteLine("Has Been Served: " + triageQueue.Dequeue());

            Console.WriteLine();
            i = 1;

            foreach (string item in triageQueue)
            {
                Console.WriteLine($"Patient {i} Name: " + item);
                i++;
            }

            Console.WriteLine();

            while(triageQueue.Count > 0)
            {
                if (triageQueue.Peek() == "Shaheen")
                {
                    triageQueue.Dequeue();
                }
                else
                {
                    tempQueue.Enqueue(triageQueue.Dequeue());
                }
            }

            while(tempQueue.Count > 0)
            {
                triageQueue.Enqueue(tempQueue.Dequeue());
            }

            i = 1;
            foreach (string item in triageQueue)
            {
                Console.WriteLine($"Patient {i} Name: " + item);
                i++;
            }

            Console.WriteLine();
            Console.WriteLine("The Total Patients are: " + triageQueue.Count);

        }

        public static void problem5()
        {

        }

        public static void problem6()
        {

        }

        static void Main(string[] args)
        {
            bool lop = true;

            do
            {
                switch(menu())
                {

                    case "0":
                        Console.WriteLine("Good Bey Friend..");
                        lop = false;
                        break;

                    case "1":
                        problem1();
                        break;

                    case "2":
                        problem2();
                        break;

                    case "3":
                        problem3();
                        break;

                    case "4":
                        problem4();
                        break;

                    case "5":
                        problem5();
                        break;

                    case "6":
                        problem6();
                        break;

                    default:
                        Console.WriteLine("Error.. Invalid Option.");
                        break;

                }

                Console.WriteLine("Press Any Key To Continue...");
                Console.ReadKey();
                Console.Clear();

            } while (lop == true);

        }
    }
}
