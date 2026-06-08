namespace Mini_Flight_Management_System
{
    internal class Program
    {
        // List Variables
        static List<string> passengerNames = ["aiham","ahmed","fahad", "mohammed"];
        static List<string> ticketNumbers = ["TKT-001", "TKT-002", "TKT-003", "TKT-004",];
        static List<string> availableDates = ["12/2/2026", "20/2/2026", "12/5/2026", "12/6/2026", "12/8/2026"];
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
        static int ticketcounter = 5;
        static string ticketID = "";
        static int flightoption = 0;
        static int bookoption = 0;
        static bool updatelop = true;
        static int counter = 0;

        static string oldflight = "";
        static string oldbook = "";

        static Queue<string> tempcheck = new Queue<string>();
        static Stack<string> tempstack = new Stack<string>();


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

        public static void updatemenu()
        {
            updatelop = true;

            do
            {

                Console.WriteLine("1.   Change Flight Only");
                Console.WriteLine("2.   Change Date Only");
                Console.WriteLine("3.   Change Both");
                Console.WriteLine("0.   Cancel Update");

                switch (Console.ReadLine())
                {
                    case "0":
                        updatelop = false;
                        break;

                    case "1":

                        for (int i = 0; i < flightNumbers.Count(); i++)
                        {
                            Console.WriteLine($"Flight No {i + 1}: {flightNumbers[i]}");
                        }

                        Console.WriteLine();

                        Console.Write("Select Which Flight No You Want: ");
                        oldflight = flightNumbers[flightoption - 1];
                        flightoption = int.Parse(Console.ReadLine());

                        Console.WriteLine();

                        if (flightoption <= flightNumbers.Count() && flightoption > 0)
                        {
                            bookingRecord[ticketID] = $"{flightNumbers[flightoption - 1]}   |   {availableDates[bookoption - 1]}";

                            Console.WriteLine("Successful Book The Flight..");
                            Console.WriteLine();
                            Console.WriteLine($"Ticket ID       : {ticketID}");
                            Console.WriteLine($"Paasenger Name  : {passengerNames[ticketNumbers.IndexOf(ticketID)]}");
                            Console.WriteLine($"Flight Number   : {oldflight} ===> {flightNumbers[flightoption - 1]}");
                            Console.WriteLine($"Flight Date     : {availableDates[bookoption - 1]}");
                        }
                        else
                        {
                            Console.WriteLine("Invalid Option..Please Select avalible Flight.");
                        }

                        break;

                    case "2":

                        for (int i = 0; i < availableDates.Count(); i++)
                        {
                            Console.WriteLine($"Date No {i + 1}: {availableDates[i]}");
                        }

                        Console.WriteLine();

                        Console.Write("Select Which Date No You Want: ");
                        oldbook = availableDates[bookoption - 1];
                        bookoption = int.Parse(Console.ReadLine());

                        Console.WriteLine();

                        if (bookoption <= availableDates.Count() && bookoption > 0)
                        {

                            bookingRecord[ticketID] = $"{flightNumbers[flightoption - 1]} | {availableDates[bookoption - 1]}";



                            Console.WriteLine("Successful Book The Flight..");
                            Console.WriteLine();
                            Console.WriteLine($"Ticket ID       : {ticketID}");
                            Console.WriteLine($"Paasenger Name  : {passengerNames[ticketNumbers.IndexOf(ticketID)]}");
                            Console.WriteLine($"Flight Number   : {flightNumbers[flightoption - 1]}");
                            Console.WriteLine($"Flight Date     : {oldbook} ===> {availableDates[bookoption - 1]}");

                        }
                        else
                        {
                            Console.WriteLine("Invalid Option.. Please Select avalible Date.");
                        }

                        break;

                    case "3":

                        for (int i = 0; i < flightNumbers.Count(); i++)
                        {
                            Console.WriteLine($"Flight No {i + 1}: {flightNumbers[i]}");
                        }

                        Console.WriteLine();

                        Console.Write("Select Which Flight No You Want: ");
                        oldflight = flightNumbers[flightoption - 1];
                        flightoption = int.Parse(Console.ReadLine());

                        Console.WriteLine();

                        if (flightoption <= flightNumbers.Count() && flightoption > 0)
                        {
                            for (int i = 0; i < availableDates.Count(); i++)
                            {
                                Console.WriteLine($"Date No {i + 1}: {availableDates[i]}");
                            }

                            Console.WriteLine();

                            Console.Write("Select Which Date No You Want: ");
                            oldbook = availableDates[bookoption - 1];
                            bookoption = int.Parse(Console.ReadLine());

                            Console.WriteLine();

                            if (bookoption <= availableDates.Count() && bookoption > 0)
                            {

                                bookingRecord.Add($"{ticketID}", $"{flightNumbers[flightoption - 1]} | {availableDates[bookoption - 1]}");



                                Console.WriteLine("Successful Book The Flight..");
                                Console.WriteLine();
                                Console.WriteLine($"Ticket ID       : {ticketID}");
                                Console.WriteLine($"Paasenger Name  : {passengerNames[ticketNumbers.IndexOf(ticketID)]}");
                                Console.WriteLine($"Flight Number   : {oldflight} ===> {flightNumbers[flightoption - 1]}");
                                Console.WriteLine($"Flight Date     : {oldbook} ===> {availableDates[bookoption - 1]}");

                            }
                            else
                            {
                                Console.WriteLine("Invalid Option.. Please Select avalible Date.");
                            }

                        }
                        else
                        {
                            Console.WriteLine("Invalid Option.. Please Select avalible Flight.");
                        }

                        break;

                    default:
                        Console.WriteLine("Invalid Option..");
                        break;
                }

                Console.WriteLine();
                Console.WriteLine("Press Any Key To Continue...");
                Console.ReadKey();
                Console.Clear();

            } while (updatelop == true);
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
                flightoption = int.Parse(Console.ReadLine());

                Console.WriteLine();

                if (flightoption <= flightNumbers.Count() && flightoption > 0)
                {
                    for(int i = 0;i < availableDates.Count();i++)
                    {
                        Console.WriteLine($"Date No {i+1}: {availableDates[i]}");
                    }

                    Console.WriteLine();

                    Console.Write("Select Which Date No You Want: ");
                    bookoption = int.Parse(Console.ReadLine());

                    Console.WriteLine();

                    if (bookoption <= availableDates.Count() && bookoption > 0)
                    {

                        bookingRecord.Add($"{ticketID}", $"{flightNumbers[flightoption - 1]} | {availableDates[bookoption - 1]}");

                        
                        
                        Console.WriteLine("Successful Book The Flight..");
                        Console.WriteLine();
                        Console.WriteLine($"Ticket ID       : {ticketID}");
                        Console.WriteLine($"Paasenger Name  : {passengerNames[ticketNumbers.IndexOf(ticketID)]}");
                        Console.WriteLine($"Flight Number   : {flightNumbers[flightoption - 1]}");
                        Console.WriteLine($"Flight Date     : {availableDates[bookoption - 1]}");

                    }
                    else
                    {
                        Console.WriteLine("Invalid Option.. Please Select avalible Date.");
                    }

                }
                else
                {
                    Console.WriteLine("Invalid Option.. Please Select avalible Flight.");
                }
            }
        }

        public static void BookingDetails()
        {
            Console.WriteLine();

            Console.Write("Enter Your Ticket ID:");
            ticketID = Console.ReadLine();

            Console.WriteLine();

            if (ticketNumbers.Contains(ticketID) == false)
            {
                Console.Write("Invalid Ticket ID..");
            }
            if (cancelledTickets.Contains(ticketID) == true)
            {
                Console.WriteLine("This Ticket ID Is Cancelled..");
            }
            if (bookingRecord.ContainsKey(ticketID) == false)
            {
                Console.WriteLine("No Booking Found For This Ticket ID..");
            }
            else
            {
                Console.WriteLine($"Passenger Name: {passengerNames[ticketNumbers.IndexOf(ticketID)]}");
                Console.WriteLine($"Ticket ID: {ticketID}");
                Console.WriteLine($"Flight Number & Date: {bookingRecord[ticketID]}");
            }
        }

        public static void updatebooking()
        {

            Console.WriteLine();

            Console.Write("Enter Your Ticket ID:");
            ticketID = Console.ReadLine();

            Console.WriteLine();

            if (ticketNumbers.Contains(ticketID) == false || cancelledTickets.Contains(ticketID) == true || bookingRecord.ContainsKey(ticketID) == false)
            {
                Console.Write("Invalid Ticket ID..");
            }
            else
            {
                Console.WriteLine($"Flight & Date: {bookingRecord[ticketID]}");

                Console.WriteLine();

                updatemenu();
            }
        }

        public static void cancelticket()
        {
            Console.WriteLine();

            Console.Write("Enter Your Ticket ID:");
            ticketID = Console.ReadLine();

            Console.WriteLine();

            if (ticketNumbers.Contains(ticketID) == true && cancelledTickets.Contains(ticketID) == false)
            {             

                name = passengerNames[ticketNumbers.IndexOf(ticketID)];
                Console.WriteLine($"Welcome: {name.ToUpper()}");

                Console.WriteLine();

                if (bookingRecord.ContainsKey(ticketID) == true)
                {
                    Console.WriteLine("The Ticket ID " + bookingRecord.Remove(ticketID) + " Was Removed From Booking Recored..");
                }

                cancelledTickets.Add(ticketID);

                if (checkedInQueue.Contains(name) == true)
                {
                    foreach (string item in checkedInQueue)
                    {
                        if (item != name)
                        {
                            tempcheck.Enqueue(item);
                        }
                    }

                    foreach (string item in tempcheck)
                    {
                        checkedInQueue.Enqueue(item);
                    }

                    Console.WriteLine($"{name.ToUpper()} Has Been Removed From Check-In..");
                }

                Console.WriteLine($"Your Ticket ID {ticketID} Has Been Set To Cancelled..");

                if (boardingStack.Contains(name) == true)
                {
                    foreach (string item in boardingStack)
                    {
                        if (item != name)
                        {
                            tempstack.Push(item);
                        }
                    }

                    foreach (string item in tempstack)
                    {
                        boardingStack.Push(item);
                    }

                    Console.WriteLine($"{name.ToUpper()} Has Been Removed From Boarding Stack..");
                }
            }
            else
            {
                Console.Write("Invalid Ticket ID or It is Already Cancelled..");
            }
        }

        public static void checkin()
        {

            Console.Write("Enter Your Ticket ID:");
            ticketID = Console.ReadLine();
            Console.WriteLine();

            name = passengerNames[ticketNumbers.IndexOf(ticketID)];

            updatelop = true;

            do
            {

                Console.WriteLine("1.   Check In a Passenger");
                Console.WriteLine("2.   View Check-In Queue");
                Console.WriteLine("3.   Process Next Passenger");
                Console.WriteLine("0.   Back");

                Console.WriteLine();

                Console.Write("Select An Option: ");


                switch (Console.ReadLine())
                {
                    case "0":
                        updatelop = false;
                        break;

                    case "1":
                        Console.WriteLine();                        

                        if (ticketNumbers.Contains(ticketID) == false || cancelledTickets.Contains(ticketID) == true || bookingRecord.ContainsKey(ticketID) == false || checkedInQueue.Contains(name))
                        {
                            Console.Write("Invalid Ticket ID..");
                        }
                        
                        if (checkedInQueue.Count < 10)
                        {
                            checkedInQueue.Enqueue(name);

                            Console.WriteLine($"{name} Has Been Added To Check-In Queue..");
                        }
                        
                        if (checkedInQueue.Count == 10)
                        {
                            waitlistQueue.Enqueue(name);

                            Console.WriteLine($"{name} Has Been Added To Wait-List Queue..");
                        }               
                        
                        break;

                    case "2":

                        counter = 1;
                        foreach (string item in checkedInQueue)
                        {
                            Console.WriteLine($"{counter}: {item}");
                            counter++;
                        }

                        Console.WriteLine();

                        Console.WriteLine("Total in Wait-List Are: " + waitlistQueue.Count);

                        break;

                    case "3":

                        Console.WriteLine("");

                        if (checkedInQueue.Count > 0)
                        {
                            checkedInQueue.Dequeue();

                            Console.WriteLine($"{name.ToUpper()} Has Been Processed..");
                        }

                        Console.WriteLine();

                        if (waitlistQueue.Count > 0)
                        {
                            checkedInQueue.Enqueue(waitlistQueue.Dequeue());
                            Console.WriteLine("Check-In Queue Has Been Updated..");
                        }

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

            } while (updatelop == true);
        }

        public static void BoardPassengers()
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

                        //Console.WriteLine("Under Devalopment...");

                        bookflight();
                        break;

                    case "4":
                        Console.WriteLine();
                        Console.ResetColor();

                        //Console.WriteLine("Under Devalopment...");

                        BookingDetails();
                        break;

                    case "5":
                        Console.WriteLine();
                        Console.ResetColor();

                        //Console.WriteLine("Under Devalopment...");

                        updatebooking();
                        break;

                    case "6":
                        Console.WriteLine();
                        Console.ResetColor();

                        //Console.WriteLine("Under Devalopment...");

                        cancelticket();
                        break;

                    case "7":
                        Console.WriteLine();
                        Console.ResetColor();

                        //Console.WriteLine("Under Devalopment...");

                        checkin();
                        break;

                    case "8":
                        Console.WriteLine();
                        Console.ResetColor();

                        Console.WriteLine("Under Devalopment...");

                        //BoardPassengers();
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
