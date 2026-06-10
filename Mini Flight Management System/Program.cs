namespace Mini_Flight_Management_System
{
    internal class Program
    {
        // Files Path
        static string passengerNamesFile = @"..\..\..\\passengerNames.txt";
        static string availableDatesFile = @"..\..\..\\availableDates.txt";
        static string cancelledTicketsFile = @"..\..\..\\cancelledTickets.txt";
        static string ticketNumbersFile = @"..\..\..\\ticketNumbers.txt";

        static string flightNumbersFile = @"..\..\..\\flightNumbers.txt";

        static string checkedInQueueFile = @"..\..\..\\checkedInQueue.txt";
        static string waitlistQueueFile = @"..\..\..\\waitlistQueue.txt";
        static string boardingStackFile = @"..\..\..\\boardingStack.txt";

        static string bookingRecordFile = @"..\..\..\\bookingRecord.txt";
        static string passengerSeatMapFile = @"..\..\..\\passengerSeatMap.txt";

        // List Variables
        static List<string> passengerNames = [];
        static List<string> ticketNumbers = [];
        static List<string> availableDates = [];
        static List<string> cancelledTickets = [];

        // Array Variables
        static string[] flightNumbers = {};
        
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
        static int ticketcounter = 0;
        static string ticketID = "";
        static int flightoption = 0;
        static int bookoption = 0;
        static bool sub_lop = true;
        static int counter = 0;

        static string oldflight = "";
        static string oldbook = "";

        static int row = 10;
        static char seat = 'A';

        static int er = 0;

        
        public static void filehandler()
        {
            // passengerNamesFile

            if (File.Exists(passengerNamesFile))
            {
                using (StreamReader reader = new StreamReader(passengerNamesFile))
                {
                    passengerNames = File.ReadAllLines(passengerNamesFile).ToList();
                }
            }
            else
            {
                Console.WriteLine("passengerNames File not found.");
                er++;
            }


            // availableDatesFile

            if (File.Exists(availableDatesFile))
            {
                using (StreamReader reader = new StreamReader(availableDatesFile))
                {
                    availableDates = File.ReadAllLines(availableDatesFile).ToList();
                }
            }
            else
            {
                Console.WriteLine("availableDates File not found.");
                er++;
            }


            // cancelledTicketsFile

            if (File.Exists(cancelledTicketsFile))
            {
                using (StreamReader reader = new StreamReader(cancelledTicketsFile))
                {
                    cancelledTickets = File.ReadAllLines(cancelledTicketsFile).ToList();
                }
            }
            else
            {
                Console.WriteLine("cancelledTickets File not found.");
                er++;
            }


            // flightNumbersFile

            if (File.Exists(flightNumbersFile))
            {
                using (StreamReader reader = new StreamReader(flightNumbersFile))
                {
                    flightNumbers = File.ReadAllLines(flightNumbersFile).ToArray();
                }
            }
            else
            {
                Console.WriteLine("flightNumbers File not found.");
                er++;
            }


            // ticketNumbersFile

            if (File.Exists(ticketNumbersFile))
            {
                using (StreamReader reader = new StreamReader(ticketNumbersFile))
                {
                    ticketNumbers = File.ReadAllLines(ticketNumbersFile).ToList();
                    ticketcounter = ticketNumbers.Count();
                }
            }
            else
            {
                Console.WriteLine("ticketNumbers File not found.");
                er++;
            }


            // checkedInQueueFile

            if (File.Exists(checkedInQueueFile))
            {
                checkedInQueue = new Queue<string>(File.ReadAllLines(checkedInQueueFile));
            }
            else
            {
                Console.WriteLine("checkedInQueueFile File not found.");
                er++;
            }


            // waitlistQueueFile

            if (File.Exists(waitlistQueueFile))
            {
                waitlistQueue = new Queue<string>(File.ReadAllLines(waitlistQueueFile));
            }
            else
            {
                Console.WriteLine("waitlistQueueFile File not found.");
                er++;
            }


            // boardingStackFile

            if (File.Exists(boardingStackFile))
            {
                boardingStack = new Stack<string>(File.ReadAllLines(boardingStackFile));
            }
            else
            {
                Console.WriteLine("boardingStackFile File not found.");
                er++;
            }


            // bookingRecordFile

            if (File.Exists(bookingRecordFile))
            {
                foreach (string line in File.ReadAllLines(bookingRecordFile))
                {
                    string[] parts = line.Split(',');
                    bookingRecord.Add(parts[0], parts[1]);
                }
            }
            else
            {
                Console.WriteLine("bookingRecordFile File not found.");
                er++;
            }


            // bookingRecordFile

            if (File.Exists(passengerSeatMapFile))
            {
                foreach (string line in File.ReadAllLines(passengerSeatMapFile))
                {
                    string[] parts = line.Split(',');
                    passengerSeatMap.Add(parts[0], parts[1]);
                }
            }
            else
            {
                Console.WriteLine("passengerSeatMapFile File not found.");
                er++;
            }


            if (er == 0)
            {
                Console.WriteLine("All Files Loaded Succefully..");

                Console.WriteLine();
                Console.WriteLine("Press Any Key To Continue...");
                Console.ReadKey();
                Console.Clear();

            }
        }

        public static void writtingfile()
        {
            // passengerNamesFile

            using (StreamWriter writer = new StreamWriter(passengerNamesFile))
            {
                foreach (string name in passengerNames)
                {
                    writer.WriteLine(name);
                }
            }


            // availableDatesFile

            using (StreamWriter writer = new StreamWriter(availableDatesFile))
            {
                foreach (string date in availableDates)
                {
                    writer.WriteLine(date);
                }
            }


            // cancelledTicketsFile

            using (StreamWriter writer = new StreamWriter(cancelledTicketsFile))
            {
                foreach (string cancel in cancelledTickets)
                {
                    writer.WriteLine(cancel);
                }
            }


            // flightNumbersFile

            using (StreamWriter writer = new StreamWriter(flightNumbersFile))
            {
                foreach (string flight in flightNumbers)
                {
                    writer.WriteLine(flight);
                }
            }


            // ticketNumbersFile

            using (StreamWriter writer = new StreamWriter(ticketNumbersFile))
            {
                foreach (string ticket in ticketNumbers)
                {
                    writer.WriteLine(ticket);
                }
            }


            // checkedInQueueFile

            using (StreamWriter writer = new StreamWriter(checkedInQueueFile))
            {
                foreach (string check in checkedInQueue)
                {
                    writer.WriteLine(check);
                }
            }


            // waitlistQueueFile

            using (StreamWriter writer = new StreamWriter(waitlistQueueFile))
            {
                foreach (string wait in waitlistQueue)
                {
                    writer.WriteLine(wait);
                }
            }


            // boardingStackFile

            using (StreamWriter writer = new StreamWriter(boardingStackFile))
            {
                foreach (string board in boardingStack)
                {
                    writer.WriteLine(board);
                }
            }


            // bookingRecordFile

            using (StreamWriter writer = new StreamWriter(bookingRecordFile))
            {
                foreach (var booking in bookingRecord)
                {
                    writer.WriteLine($"{booking.Key},{booking.Value}");
                }
            }


            // passengerSeatMapFile

            using (StreamWriter writer = new StreamWriter(passengerSeatMapFile))
            {
                foreach (var seatmap in passengerSeatMap)
                {
                    writer.WriteLine($"{seatmap.Key},{seatmap.Value}");
                }
            }
        }

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

                ticketcounter++;
                ticketID = "TKT-" + ticketcounter.ToString("D3");                
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
                Console.Write("Invalid Ticket ID Or It Cancelled..");
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

                sub_lop = true;

                do
                {

                    Console.WriteLine("1.   Change Flight Only");
                    Console.WriteLine("2.   Change Date Only");
                    Console.WriteLine("3.   Change Both");
                    Console.WriteLine("0.   Cancel Update");

                    switch (Console.ReadLine())
                    {
                        case "0":
                            sub_lop = false;
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

                } while (sub_lop == true);
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

                if (bookingRecord.ContainsKey(ticketID))
                {
                    Console.WriteLine("The Ticket ID " + bookingRecord.Remove(ticketID) + " Was Removed From Booking Recored..");
                }

                cancelledTickets.Add(ticketID);

                if (checkedInQueue.Contains(name))
                {
                    checkedInQueue = new Queue<string>(checkedInQueue.Where(n => n != name));
                    Console.WriteLine($"{name.ToUpper()} Has Been Removed From Check-In..");
                }

                Console.WriteLine($"Your Ticket ID {ticketID} Has Been Set To Cancelled..");

                if (boardingStack.Contains(name))
                {
                    boardingStack = new Stack<string>(boardingStack.Where(n => n != name).Reverse());
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

            sub_lop = true;

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
                        sub_lop = false;
                        break;

                    case "1":
                        Console.WriteLine();                        

                        if (ticketNumbers.Contains(ticketID) == false || cancelledTickets.Contains(ticketID) == true || checkedInQueue.Contains(name))
                        {
                            Console.Write("Invalid Ticket ID Or Has Been Cancelled Or It Is Already In Check-In..");
                            return;
                        }
                        if(bookingRecord.ContainsKey(ticketID))
                        {
                            Console.Write("You Didn't Book A Flight..");
                            return;
                        }
                        if (checkedInQueue.Count < 10)
                        {
                            checkedInQueue.Enqueue(name);

                            Console.WriteLine($"{name} Has Been Added To Check-In Queue..");

                        }

                        else
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

                        Console.WriteLine("Total in Wait-List Are: " + checkedInQueue.Count);

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

            } while (sub_lop == true);
        }

        public static void BoardPassengers()
        {
            sub_lop = true;

            do
            {
                Console.WriteLine();
                Console.WriteLine("1.   Load Boarding Stack From Check-In Queue");
                Console.WriteLine("2.   Board Next Passenger");
                Console.WriteLine("3.   View Boarding Stack");
                Console.WriteLine("4.   View Boarding Log");
                Console.WriteLine("0.   Back");

                Console.WriteLine();

                Console.Write("Select An Option: ");
                switch(Console.ReadLine())
                {
                    case "0":
                        sub_lop = false;
                        break;

                    case "1":

                        if(checkedInQueue.Count > 0)
                        {
                            while(checkedInQueue.Count > 0)
                            {
                                boardingStack.Push(checkedInQueue.Dequeue());
                            }

                            Console.WriteLine(boardingStack.Count() + " Has Been Loaded");
                        }
                        else
                        {
                            Console.WriteLine("Warning: It Is Already Loaded..");
                        }

                        break;

                    case "2":

                        if(boardingStack.Count > 0)
                        {
                            while (boardingStack.Count > 0)
                            {
                                
                                if(row > 40)
                                {
                                    Console.WriteLine("The Plane Is Full..");
                                    return;
                                }

                                if (seat != 'G')
                                {
                                    Console.WriteLine(boardingStack.Peek() + "Your Seat No Is: " + row + seat);
                                    passengerSeatMap.Add(boardingStack.Pop() , $"{row}{seat}");
                                    seat++;
                                }
                                else
                                {
                                    seat = 'A';
                                    row++;
                                }                                
                            }
                        }
                        else
                        {
                            Console.WriteLine("The Boarding Stack Is Empty..");
                        }

                        break;

                    case "3":
                        counter = 1;

                        foreach(var board in boardingStack)
                        {
                            Console.WriteLine($"{counter}.  {board}");
                        }

                        break;

                    case "4":

                        foreach(var map in passengerSeatMap)
                        {
                            Console.WriteLine($"Passenger Name: {map.Key}   |   {map.Value}");
                        }
                        

                        break;

                    default:
                        Console.WriteLine("Invalid Option.. Please Select Valid Option.");
                        break;
                }

                Console.WriteLine();
                Console.WriteLine("Press Any Key To Continue...");
                Console.ReadKey();
                Console.Clear();

            } while (sub_lop);
        }

        static void Main(string[] args)
        {

            filehandler();

            bool lop = true;

            do
            {

                switch(menu())
                {

                    case "0":
                        Console.ResetColor();

                        writtingfile();

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

                        //Console.WriteLine("Under Devalopment...");

                        BoardPassengers();
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
