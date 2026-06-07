namespace Mini_Flight_Management_System
{
    internal class Program
    {
        // List Variables
        static List<string> passengerNames = [];
        static List<string> ticketNumbers = [];
        static List<string> availableDates = [];
        static List<string> cancelledTickets = [];

        // Array Variables
        static string[] flightNumbers = { "OA101", "OA102", "OA103", "OA104", "OA105", "OA106" };
        
        // Queue Variables
        static Queue<string> checkedInQueue = new Queue<string>();
        static Queue<string> waitlistQueue = new Queue<string>();

        // Stack Variables
        static Stack<string> boardingStack = new Stack<string>();

        // Dictionary Variables
        static Dictionary<string, string> bookingRecord = new Dictionary<string, string>();
        static Dictionary<string,string> passengerSeatMap = new Dictionary<string,string>();


        public static string menu()
        {
            Console.WriteLine("===========================================");
            Console.WriteLine("SKY WINGS FLIGHT MANAGEMENT SYSTEM");
            Console.WriteLine("===========================================");

            Console.WriteLine();

            Console.WriteLine("1 .   Register New Passenger");
            Console.WriteLine("2 .   View All Passengers");
            Console.WriteLine("3 .   Book a Flight Ticktes");
            Console.WriteLine("4 .   View Booking Details");
            Console.WriteLine("5 .   Update a Booking");
            Console.WriteLine("6 .   Cancel a Ticket");
            Console.WriteLine("7 .   Passenger Check-In");
            Console.WriteLine("8 .   Board Passengers (Bording Stack)");
            Console.WriteLine("9 .   Generate Flight Manifeet");
            Console.WriteLine("10.   Manage Waitlist & Seat Assignment");
            Console.WriteLine("0 .   Exit");

            Console.WriteLine();

            Console.WriteLine("===========================================");
            Console.Write("Enter Your Choice: ");

            return Console.ReadLine();
        }



        static void Main(string[] args)
        {

            bool lop = true;

            do
            {

                switch(menu())
                {

                    case "0":
                        Console.WriteLine("GoodBey..");
                        lop = false;
                        break;

                    case "1":
                        Console.WriteLine("Under Devalopment...");
                        break;

                    case "2":
                        Console.WriteLine("Under Devalopment...");
                        break;

                    case "3":
                        Console.WriteLine("Under Devalopment...");
                        break;

                    case "4":
                        Console.WriteLine("Under Devalopment...");
                        break;

                    case "5":
                        Console.WriteLine("Under Devalopment...");
                        break;

                    case "6":
                        Console.WriteLine("Under Devalopment...");
                        break;

                    case "7":
                        Console.WriteLine("Under Devalopment...");
                        break;

                    case "8":
                        Console.WriteLine("Under Devalopment...");
                        break;

                    case "9":
                        Console.WriteLine("Under Devalopment...");
                        break;

                    case "10":
                        Console.WriteLine("Under Devalopment...");
                        break;

                }
                Console.WriteLine("");
                Console.WriteLine("Press Any Key To Continue...");
                Console.ReadKey();
                Console.Clear();

            } while (lop == true);
        }
    }
}
