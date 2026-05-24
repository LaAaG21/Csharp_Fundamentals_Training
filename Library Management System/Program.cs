using System.Timers;
using System.Xml.Linq;

namespace Library_Management_System
{
    internal class Program
    {

        static string Mid = "";
        static string Mname = "";
        static string Memail = "";
        static string expirydate = "";
        static string Mtier = "";
        static bool isRegistered = false;

        static string bookTitle = "";
        static string bookAuthor = "";
        static string bookgenre = "";
        static int NoOfCopies = 0;
        static bool isAvailable = false;
        static int totalBooksBorrowed = 0;
        static double totalFines = 0;

        static string menuOption = "";
        static string search = "";
        static bool exit = false;

        public static void PrintMenu()
        {
            Console.Clear();
            Console.WriteLine("=========================");
            Console.WriteLine("Library Management System");
            Console.WriteLine("=========================");

            Console.WriteLine();
            Console.WriteLine();
            
            Console.WriteLine("0. Register Member");
            Console.WriteLine("1. Display Member Profile");
            Console.WriteLine("2. Search Book By Title");
            Console.WriteLine("3. Borrow a Book");
            Console.WriteLine("4. Return a Book");
            Console.WriteLine("5. Calculate Late Fine");
            Console.WriteLine("6. Apply Member Discount");
            Console.WriteLine("7. Check Borrowing Eligibility");
            Console.WriteLine("8. Register Book");
            Console.WriteLine("9. Generate Member ID");
            Console.WriteLine("10. Display Book Details");
            Console.WriteLine("11. Calculate Renewal Fee");
            Console.WriteLine("12. Update Member Email");
            Console.WriteLine("13. Session Summary");
            Console.WriteLine("14. Exit");

            Console.WriteLine();
            Console.WriteLine("=====================================");
            Console.WriteLine();

            Console.Write("Select An Option: ");
        }

        public static void RegisterMember()
        {            
            Console.Write("Enter Your Name: ");
            Mname = Console.ReadLine();

            Console.Write("Enter Your Email: ");
            Memail = Console.ReadLine();

            Mtier = "BRONZE";
            expirydate = DateTime.Today.AddDays(30).ToString("yyyy-MM-dd");
            isRegistered = true;
            Mid = "1";
        }

        public static void PrintMembers()
        {
            Console.Write("Member ID: "     + Mid   + "  | "); Console.Write("Member Name: "            + Mname         + "  | "); Console.WriteLine("Member Email: " + Memail);
            Console.Write("Member Tier: "   + Mtier + "  | "); Console.WriteLine("Member Expiry Date: " + expirydate    + "  | ");
        }

        public static bool SearchBook(string bname)
        {
            if (bname.ToLower() == bookTitle.ToLower())
            {                
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void BorrowBook(ref int avaliblecount)
        {
            if (isRegistered && Mtier == "SELVER" || Mtier == "GOLD" && avaliblecount > 0)
            {
                avaliblecount--;

                Console.WriteLine("The Book " + bookTitle + " Has Been Borrowed.");
            }
            else
            {
                Console.WriteLine("You Can't Borrow A Book..");
            }
            
        }

        public static void ReturnBook(ref int avaliblecount)
        {
            if (isRegistered && Mtier == "SELVER" || Mtier == "GOLD")
            {
                avaliblecount++;

                Console.WriteLine("The Book " + bookTitle + " Has Been Returned.");
            }
            else
            {
                Console.WriteLine("You Need To Register First..");
            }
            
        }

        public static double CalculateFine(int overdue)
        {
            
            return Math.Round(Math.Sqrt(overdue), 0);
        }

        public static double MemberDiscount(double amount)
        {
            return Math.Round(amount + (amount * 0.1), 2);
        }

        public static double MemberDiscount(double amount,string tier)
        {
            if (tier == "BRONZE")
            {
                return Math.Round(amount + (amount * 0.2), 2);
            }
            else if (tier == "SILVER")
            {
                return Math.Round(amount + (amount * 0.3), 2);
            }
            else if (tier == "GOLD")
            {
                return Math.Round(amount + (amount * 0.4), 2);
            }
            else
            {
                return Math.Round(amount + (amount * 0.1), 2);
            }
        }

        public static bool BorrowEligibil(string tier)
        {
            if (tier == "SILVER" || tier == "GOLD")
            {
                return true;
            }           
            else
            {
                return false;
            }
        }

        public static void RegisterBook()
        {
            if (isAvailable == false)
            {
                Console.Write("Enter The Book Title: ");
                bookTitle = Console.ReadLine();
                Console.Write("Enter The Book Author: ");
                bookAuthor = Console.ReadLine();
                Console.Write("Enter The Book Genre: ");
                bookgenre = Console.ReadLine();
                Console.Write("Enter Number of Copies: ");
                NoOfCopies = int.Parse(Console.ReadLine());
                isAvailable = true;
            }
            else
            {
                Console.WriteLine("Failed: The Library Is Full..");
            }
            
        }

        static void Main(string[] args)
        {
            do 
            { 
            PrintMenu();
            menuOption = Console.ReadLine();

            Console.Clear();
                switch (menuOption)
                {
                    case "0":
                        if (isRegistered == false)
                        {
                            RegisterMember();
                        }
                        else
                        {
                            Console.WriteLine("Failed: Can't Register Right Now..");
                        }                        
                        break;

                    case "1":
                        if (isRegistered == true)
                        {
                            PrintMembers();
                        }
                        else
                        {
                            Console.WriteLine("Failed: Please Register First..");
                        }
                        break;

                    case "2":
                        Console.Write("Enter The Book Title: ");
                        if (SearchBook(Console.ReadLine().ToLower()))
                        {
                            Console.WriteLine("The Book Is Avalible.");
                        }
                        else
                        {
                            Console.WriteLine("There Is No Book With This Title.");
                        }

                        break;

                    case "3":
                        if (isRegistered == true)
                        {
                            BorrowBook(ref NoOfCopies);
                            totalBooksBorrowed++;
                        }
                        else
                        {
                            Console.WriteLine("Failed: Please Register First..");
                        }                        
                        break;

                    case "4":
                        if (isRegistered == true)
                        {
                            ReturnBook(ref NoOfCopies);
                            totalBooksBorrowed--;
                        }
                        else
                        {
                            Console.WriteLine("Failed: Please Register First..");
                        }                        
                        break;

                    case "5":
                        if (isRegistered == true)
                        {
                            Console.Write("Enter The Number of Overdue Days: ");
                            totalFines = CalculateFine(Convert.ToInt32(Console.ReadLine()));
                            Console.WriteLine("The Result = " + totalFines);
                        }
                        else
                        {
                            Console.WriteLine("Failed: Please Register First..");
                        }                        
                        break;

                    case "6":
                        if (isRegistered == true)
                        {
                            Console.Write("Enter The Amount " + Mname + " : ");
                            Console.WriteLine("The Total Amount After Discount: " + MemberDiscount(Convert.ToInt32(Console.ReadLine()),Mtier));
                        }
                        else
                        {
                            Console.Write("Enter The Amount: ");
                            Console.WriteLine("The Total Amount After Discount: " + MemberDiscount(Convert.ToInt32(Console.ReadLine())));
                        }
                        break;

                    case "7":
                        if (isRegistered && BorrowEligibil(Mtier) == true)
                        {
                            Console.WriteLine("You Can Borrow A Book");
                        }
                        else
                        {
                            Console.WriteLine("You Can't Borrow A Book");
                        }
                        break;

                    case "8":
                        RegisterBook();
                        break;

                    case "9":
                        break;

                    case "10":
                        break;

                    case "11":
                        break;

                    case "12":
                        break;

                    case "13":
                        break;

                    case "14":
                        Console.WriteLine("Shutting Down...");
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Failed: Invalid Option.");
                        break;

                } 

                Console.WriteLine("Press Any Key To Continue...");
                Console.ReadKey();
                Console.Clear();
            } while (exit != true);
        }
    }
}
