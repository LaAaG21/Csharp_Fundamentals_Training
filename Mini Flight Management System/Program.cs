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

        // Temp Variables
        static string name = "";
        static int ticketcounter = 1;
        static string ticketID = "";
        static string option = "";


        public static string menu()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("===========================================");
            Console.WriteLine("SKY WINGS FLIGHT MANAGEMENT SYSTEM");
            Console.WriteLine("===========================================");

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("1 .   Register New Passenger");
            Console.WriteLine("2 .   View All Passengers");
            Console.WriteLine("3 .   Book a Flight Ticktes");
            Console.WriteLine("4 .   View Booking Details");

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("5 .   Update a Booking");
            Console.WriteLine("6 .   Cancel a Ticket");
            Console.WriteLine("7 .   Passenger Check-In");
            Console.WriteLine("8 .   Board Passengers (Bording Stack)");

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("9 .   Generate Flight Manifeet");
            Console.WriteLine("10.   Manage Waitlist & Seat Assignment");

            Console.ResetColor();
            Console.WriteLine("0 .   Exit");

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("===========================================");
            Console.Write("Enter Your Choice: ");

            return Console.ReadLine();
        }

        public static void Register()
        {
            Console.WriteLine();
            Console.Write("Enter Your Full Name: ");
            name = Console.ReadLine().ToLower();

            if (name.IsWhiteSpace() == true || passengerNames.Contains(name) == true)
            {
                Console.WriteLine("Invalid Name Format..");
            }
            else
            {
                passengerNames.Add(name);

                ticketID = "TKT-" + ticketcounter.ToString("D3");
                ticketcounter++;
                ticketNumbers.Add(ticketID);

                Console.WriteLine("The name Was Added Successfully");

                Console.WriteLine();

                Console.WriteLine("Passenger Name:  " + name);
                Console.WriteLine("Ticket ID     :  " + ticketID);
            }
        }

        public static void View_all_Passengers()
        {
            if(passengerNames.Count == 0)
            {
                Console.WriteLine("No Passengers Registered Yet..");
            }
            else
            {
                Console.WriteLine("No.   |   PassName         |   TicketID   |   Status  |");                                

                for (int i = 0; i < passengerNames.Count; i++)
                {
                    if (cancelledTickets.Contains(ticketNumbers[i]) == true)
                    {
                        Console.WriteLine($"{i + 1}       |   {passengerNames[i]}            |   {ticketNumbers[i]}    |   CANCELLED  |");
                    }
                    else
                    {
                        Console.WriteLine($"{i + 1}     |   {passengerNames[i]}            |   {ticketNumbers[i]}    |   ACTIVE  |");
                    }                
                }

                Console.WriteLine();
                Console.WriteLine("Total Passengers: " + passengerNames.Count);
            }
        }

        public static void bookflight()
        {
            Console.Write("Enter Your Ticket ID: ");
            ticketID = Console.ReadLine();

            Console.WriteLine();

            if (ticketNumbers.Contains(ticketID) == false || cancelledTickets.Contains(ticketID) == true)
            {
                Console.Write("Invalid Ticket ID..");
            }

            else if(bookingRecord.ContainsKey(ticketID) == true)
            {
                Console.Write("The Ticket ID Is Already Has a Booking..");
            }

            else
            {
                for(int i = 0; i < flightNumbers.Count(); i++)
                {
                    Console.WriteLine($"Flight No {i+1}: {flightNumbers[i]}");
                }

                Console.WriteLine();

                Console.Write("Select Which Flight No You Want: ");
                option = Console.ReadLine();

                Console.WriteLine();

                if (int.Parse(option) <= flightNumbers.Count() && int.Parse(option) > 0)
                {
                    for(int i = 0;i < availableDates.Count();i++)
                    {
                        Console.WriteLine("");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Option.. Please Select avalible Flight.");
                }
            }
        }
        static void Main(string[] args)
        {

            bool lop = true;

            do
            {

                switch(menu())
                {

                    case "0":
                        Console.ResetColor();
                        Console.WriteLine();
                        Console.WriteLine("GoodBey..");
                        lop = false;
                        break;

                    case "1":
                        Console.WriteLine();
                        Console.ResetColor();

                        //Console.WriteLine("Under Devalopment...");

                        Register();
                        break;

                    case "2":
                        Console.WriteLine();
                        Console.ResetColor();

                        //Console.WriteLine("Under Devalopment...");

                        View_all_Passengers();
                        break;

                    case "3":
                        Console.WriteLine();
                        Console.ResetColor();
                        Console.WriteLine("Under Devalopment...");
                        break;

                    case "4":
                        Console.WriteLine();
                        Console.ResetColor();
                        Console.WriteLine("Under Devalopment...");
                        break;

                    case "5":
                        Console.WriteLine();
                        Console.ResetColor();
                        Console.WriteLine("Under Devalopment...");
                        break;

                    case "6":
                        Console.WriteLine();
                        Console.ResetColor();
                        Console.WriteLine("Under Devalopment...");
                        break;

                    case "7":
                        Console.WriteLine();
                        Console.ResetColor();
                        Console.WriteLine("Under Devalopment...");
                        break;

                    case "8":
                        Console.WriteLine();
                        Console.ResetColor();
                        Console.WriteLine("Under Devalopment...");
                        break;

                    case "9":
                        Console.WriteLine();
                        Console.ResetColor();
                        Console.WriteLine("Under Devalopment...");
                        break;

                    case "10":
                        Console.WriteLine();
                        Console.ResetColor();
                        Console.WriteLine("Under Devalopment...");
                        break;

                    default:
                        Console.ResetColor();
                        Console.WriteLine("Invalid Option.. Please Select From 0 to 10");
                        break;

                }
                Console.WriteLine();
                Console.WriteLine("Press Any Key To Continue...");
                Console.ReadKey();
                Console.Clear();

            } while (lop == true);
        }
    }
}
