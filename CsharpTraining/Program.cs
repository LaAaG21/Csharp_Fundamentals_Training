using System.ComponentModel.DataAnnotations;

namespace CsharpTraining
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Bank Account Management System!");


            Console.WriteLine("--- Account Profile ---");

            Console.Write("Enter your account number:");
            int accountNumber = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Holder Name:");
            string holderName = Console.ReadLine();

            Console.Write("Enter your balance:");
            double balance = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter 1=active / 0=inactive: ");
            bool isActive = Convert.ToBoolean(Console.ReadLine());

            Console.Write("Enter Account Type ( S / C / F): ");
            char accounttype = Convert.ToChar(Console.ReadLine());
            string accountTypeFull;

            if (accounttype == 'S')
            {
                accountTypeFull = "Savings";
            }
            else if (accounttype == 'C')
            {
                accountTypeFull = "Current";
            }
            else
            {
                accountTypeFull = "Fixed Deposit";
            }

            Console.WriteLine("--- Customer Profile ---");

            Console.Write("Enter 1=Employed / 0=Not Employed: ");
            bool isEmployed = Convert.ToBoolean(Console.ReadLine());

            Console.Write("Enter Your Month Salary: ");
            double salary = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter Credit Score: ");
            int creditScore = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Your Age: ");
            int age = Convert.ToInt32(Console.ReadLine());


            Console.WriteLine("--- Transaction Data ---");

            Console.Write("Enter Last Deposit Amount: ");
            double deposit = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter Last Withdrawal: ");
            double withdrawal = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter Annual Interest Rate: ");
            double annualRate = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter Average Monthly Balance: ");
            double avgBalance = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Setup Complete. Launching Main Menu...");



            Console.WriteLine("=== MAIN MENU ===");

            Console.WriteLine("1) ATM Services ");
            Console.WriteLine("2) Account Management ");
            Console.WriteLine("3) Loan Services ");
            Console.WriteLine("4) Currency Exchange ");
            Console.WriteLine("5) Credit Card Portal ");
            Console.WriteLine("6) Branch Services ");
            Console.WriteLine("7) Reports & Admin ");
            Console.WriteLine("8) [BONUS] Full Terminal ");
            Console.WriteLine("0) Exit ");

            Console.Write("Select: ");

            string main_menu = Console.ReadLine();

            string sub_menu;
            string sub_sub_menu;

            switch (main_menu)
            {
                case "0":
                    Console.WriteLine("Exiting Application. Goodbye!");
                    return;

                case "1":

                    Console.WriteLine("1) Bank Info");
                    Console.WriteLine("2) View Account Data");
                    Console.WriteLine("3) Authenticate");
                    Console.WriteLine("4) Print Receipt");
                    Console.WriteLine("0) Back To Main Menu");

                    Console.Write("Select: ");

                    sub_menu = Console.ReadLine();

                    switch (sub_menu)
                    {
                        case "0":
                            Console.WriteLine("Returning To Main Menu...");
                            break;

                        case "1":
                            
                            Console.WriteLine("=== ATM SERVICES ===");

                            Console.WriteLine("1) Bank Info");
                            Console.WriteLine("2) Branch Info");
                            Console.WriteLine("3) Opening Hours");
                            Console.WriteLine("0) Back To Main Menu");

                            Console.Write("Select: ");

                            sub_sub_menu = Console.ReadLine();

                            switch (sub_sub_menu)
                            {
                                // Return To ATM SERVICES
                                case "0":
                                    Console.WriteLine("Returning To Main Menu...");
                                    break;

                                // Bank Info
                                case "1":
                                    Console.WriteLine(@"Bank Name: National Bank Of Oman
                                        Tagline: Bal Bla
                                        Founding Year: 2000");
                                    break;

                                // Branch Info
                                case "2":
                                    Console.WriteLine(@"Branch Name: Muscat Branch
                                        City: Muscat, Oman
                                        Address: Bla Bla Bla");
                                    break;

                                // Opening Hours
                                case "3":
                                    Console.WriteLine(@"Opening Hours: 8:00 AM - 4:00 PM
                                        Saturday to Thursday
                                        Closed on Fridays and Public Holidays");
                                    break;

                                // Invalid Option
                                default:
                                    Console.WriteLine("Invalid Option. Please Try Again.");
                                    break;
                            }
                            break;

                        case "2":
                            Console.WriteLine("=== VIEW ACCOUNT DATA ===");

                            Console.WriteLine("1) Account Number");
                            Console.WriteLine("2) Holder Name");
                            Console.WriteLine("3) Balance");
                            Console.WriteLine("4) Account Status");
                            Console.WriteLine("5) Account Type");
                            Console.WriteLine("0) Back To Main Menu");

                            Console.Write("Select: ");

                            sub_sub_menu = Console.ReadLine();

                            switch (sub_sub_menu)
                            {
                                // Return To Main Menu
                                case "0":
                                    Console.WriteLine("Returning To Main Menu...");
                                    break;

                                // Account Number
                                case "1":
                                    Console.WriteLine("1) Account Number → " + accountNumber);
                                    break;

                                // Holder Name
                                case "2":
                                    Console.WriteLine("2) Holder Name → " + holderName);
                                    break;

                                // Balance
                                case "3":
                                    Console.WriteLine("3) Balance → " + balance);
                                    break;

                                // Is Account Active
                                case "4":
                                    Console.WriteLine("4) Account Status → " + isActive);
                                    break;

                                // Account Type
                                case "5":
                                    Console.WriteLine("5) Account Type → " + accountTypeFull + "(" + accounttype + ")");
                                    break;

                                // Invalid Option
                                default:
                                    Console.WriteLine("Invalid Option. Please Try Again.");
                                    break;
                            }
                            break;

                        case "3":

                            Console.WriteLine("=== AUTHENTICATION ===");

                            Console.WriteLine("1) Enter PIN");
                            Console.WriteLine("2) Forgot PIN");
                            Console.WriteLine("0) Back");

                            Console.Write("Select: ");

                            sub_sub_menu = Console.ReadLine();

                            const string CORRENT_PIN = "4821";
                            const int MAX_ATTEMPTS = 3;
                            string new_PIN;

                            switch (sub_sub_menu)
                            {
                                // Return To Main Menu
                                case "0":
                                    Console.WriteLine("Returning To Main Menu...");
                                    break;

                                // PIN Check
                                case "1":
                                    Console.Write("Enter PIN: ");
                                    new_PIN = Console.ReadLine();

                                    if (new_PIN == CORRENT_PIN)
                                    {
                                        Console.WriteLine("Access Granted. Welcome, " + holderName + ".");
                                    }
                                    else if (new_PIN.Length != 4)
                                    {
                                        Console.WriteLine("Invalid PIN Format.");

                                    }
                                    else
                                    {
                                        Console.WriteLine("Incorrect PIN.");
                                    }
                                    break;

                                // Forgot PIN
                                case "2":
                                    Console.WriteLine("Please visit the nearest branch with your National ID.");
                                    break;

                                // Invalid Option
                                default:
                                    Console.WriteLine("Invalid Option. Please Try Again.");
                                    break;
                            }
                            break;

                        case "4":
                            Console.WriteLine("=== PRINT RECEIPT ===");

                            Console.WriteLine("1) Short Receipt");
                            Console.WriteLine("2) Detailed Receipt");
                            Console.WriteLine("3) Balance Only");
                            Console.WriteLine("0) Back");

                            Console.Write("Select: ");

                            sub_sub_menu = Console.ReadLine();

                            switch (sub_sub_menu)
                            {
                                // Return To Main Menu
                                case "0":
                                    Console.WriteLine("Returning To ATM Services...");
                                    break;

                                // short Receipt
                                case "1":
                                    Console.WriteLine("Holder Name  :   " + holderName);
                                    Console.WriteLine("Account      :   ****" + accountNumber % 10000);
                                    Console.WriteLine("Balance      :   " + balance);
                                    break;

                                // Detailed Receipt
                                case "2":
                                    Console.WriteLine("Holder Name  :   " + holderName);
                                    Console.WriteLine("Account      :   ****" + accountNumber % 10000);
                                    Console.WriteLine("Balance      :   " + balance);
                                    Console.WriteLine("isActive     :   " + isActive);
                                    Console.WriteLine("Account Type :   " + accounttype);
                                    break;

                                // Balance Only
                                case "3":
                                    Console.WriteLine("Balance      :   " + balance);
                                    break;

                                // Invalid Option
                                default:
                                    Console.WriteLine("Invalid Option. Please Try Again.");
                                    break;
                            }
                            break;

                        default:
                            Console.WriteLine("Invalid Option. Please Try Again.");
                            break;

                    }
                    break;

                case "2":

                    Console.WriteLine("1) Transaction Calculator");
                    Console.WriteLine("2) Account Types");
                    Console.WriteLine("3) Loan Eligibility");
                    Console.WriteLine("0) Back To Main Menu");

                    Console.Write("Select: ");

                    sub_menu = Console.ReadLine();

                    switch (sub_menu)
                    {
                        case "0":
                            Console.WriteLine("Returning To Main Menu...");
                            break;

                        case "1":

                            Console.WriteLine("=== TRANSACTION CALCULATOR ===");

                            Console.WriteLine("Using: balance=" + balance + "   deposit=" + deposit + "rate="+ annualRate +"%");

                            Console.WriteLine("1) Balance After Deposit");
                            Console.WriteLine("2) Balance After Withdrawal");
                            Console.WriteLine("3) Annual Interest Earned");
                            Console.WriteLine("4) Net Balance Change");
                            Console.WriteLine("0) Back");

                            Console.Write("Select calculation: ");

                            sub_sub_menu = Console.ReadLine();

                            switch (sub_sub_menu)
                            {
                                // Return To Main Menu
                                case "0":
                                    Console.WriteLine("Returning To Main Menu...");
                                    break;

                                // Balance After Deposit
                                case "1":
                                    Console.WriteLine("Balance  :   " + balance);
                                    Console.WriteLine("Deposit  :   " + deposit + "OMR");
                                    break;

                                // Balance After Withdrawal
                                case "2":
                                    Console.WriteLine("Balance  :   " + balance);
                                    Console.WriteLine("WithDrawal  :   " + withdrawal + "OMR");
                                    break;

                                // Annual Interest Earned
                                case "3":
                                    double interest = balance * annualRate;
                                    Console.WriteLine("Interest = " + interest);
                                    break;

                                // Invalid Option
                                default:
                                    Console.WriteLine("Invalid Option. Please Try Again.");
                                    break;
                            }
                            break;

                        case "2":
                            Console.WriteLine("=== ACCOUNT TYPES ===");

                            Console.WriteLine("Your Account type: " + accounttype + " (" + accountTypeFull + ")");

                            Console.WriteLine("1) Savings Account");
                            Console.WriteLine("2) Current Account");
                            Console.WriteLine("3) Fixed Deposit");
                            Console.WriteLine("4) Junior Account");
                            Console.WriteLine("0) Back");

                            Console.Write("Select Type: ");

                            sub_sub_menu = Console.ReadLine();

                            switch (sub_sub_menu)
                            {
                                // Return To Transaction Calculator
                                case "0":
                                    Console.WriteLine("Returning To Main Menu...");
                                    break;

                                // Savings Account
                                case "1":
                                    Console.WriteLine("Holder Name: " + holderName);
                                    Console.WriteLine("Balance: " + balance);
                                    Console.WriteLine("Monthly Fee: " + salary);

                                    if (balance > 500)
                                    {
                                        Console.WriteLine("Requires Manager Approval");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Any Branch");
                                    }

                                    if (accounttype == 'S')
                                    {
                                        Console.WriteLine("*** This is your account type *** ");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Account Type Not Offered");
                                    }
                                        break;

                                // Current Account
                                case "2":
                                    Console.WriteLine("Holder Name: " + holderName);
                                    Console.WriteLine("Balance: " + balance);
                                    Console.WriteLine("Monthly Fee: " + salary);

                                    if (balance > 500)
                                    {
                                        Console.WriteLine("Requires Manager Approval");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Any Branch");
                                    }

                                    if (accounttype == 'C')
                                    {
                                        Console.WriteLine("*** This is your account type *** ");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Account Type Not Offered");
                                    }
                                    break;

                                // Fixed Deposit
                                case "3":
                                    Console.WriteLine("Holder Name: " + holderName);
                                    Console.WriteLine("Balance: " + balance);
                                    Console.WriteLine("Monthly Fee: " + salary);

                                    if (balance > 500)
                                    {
                                        Console.WriteLine("Requires Manager Approval");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Any Branch");
                                    }

                                    if (accounttype == 'F')
                                    {
                                        Console.WriteLine("*** This is your account type *** ");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Account Type Not Offered");
                                    }
                                    break;
                                // Junior Account
                                case "4":
                                    Console.WriteLine("Holder Name: " + holderName);
                                    Console.WriteLine("Balance: " + balance);
                                    Console.WriteLine("Monthly Fee: " + salary);

                                    if (balance > 500)
                                    {
                                        Console.WriteLine("Requires Manager Approval");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Any Branch");
                                    }

                                    if (accounttype == 'J')
                                    {
                                        Console.WriteLine("*** This is your account type *** ");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Account Type Not Offered");
                                    }
                                    break;

                                // Invalid Option
                                default:
                                    Console.WriteLine("Invalid Option. Please Try Again.");
                                    break;
                            }
                            break;

                        case "3":

                            Console.WriteLine("=== LOAN ELIGIBILITY ===");

                            Console.WriteLine("Holder : " + holderName + "  |   Salary: " + salary + "OMR   |   Score: " + creditScore +"   |   Age:    " + age);

                            Console.WriteLine("1) Personal Loan");
                            Console.WriteLine("2) Car Loan");
                            Console.WriteLine("3) Home Loan");
                            Console.WriteLine("0) Back");

                            Console.Write("Select Loan Type: ");

                            sub_sub_menu = Console.ReadLine();

                            switch (sub_sub_menu)
                            {
                                // Return To LOAN ELIGIBILITY
                                case "0":
                                    Console.WriteLine("Returning To Main Menu...");
                                    break;

                                // Personal Loan
                                case "1":
                                    if (isEmployed == true && salary >= 400 && creditScore > 650)
                                    {
                                        Console.WriteLine("Eligible — Application Accepted.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Not Eligible.");
                                    }
                                    break;

                                // Car Loan
                                case "2":
                                    if (isEmployed == true && salary >= 600 && age >= 21)
                                    {
                                        Console.WriteLine("Eligible — Application Accepted.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Not Eligible.");
                                    }
                                    break;

                                // Home Loan
                                case "3":
                                    if (isEmployed == true && salary >= 1000 && creditScore > 700 && age >= 25)
                                    {
                                        Console.WriteLine("Eligible — Application Accepted.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Not Eligible.");
                                    }
                                    break;

                                // Invalid Option
                                default:
                                    Console.WriteLine("Loan product not offered.");
                                    break;
                            }
                            break;

                        default:
                            Console.WriteLine("Invalid Option. Please Try Again.");
                            break;

                    }
                    break;

                case "3":
                    Console.WriteLine("Launching Loan Services...");
                    break;

                case "4":
                    Console.WriteLine("Launching Currency Exchange...");
                    break;

                case "5":
                    Console.WriteLine("Launching Credit Card Portal...");
                    break;

                case "6":
                    Console.WriteLine("Launching Branch Services...");
                    break;

                case "7":
                    Console.WriteLine("Launching Reports & Admin...");
                    break;

                case "8":
                    Console.WriteLine("Launching Full Terminal...");
                    break;

                default:
                    Console.WriteLine("Invalid Option. Please Try Again.");
                    return;
            }

            


        }
    }
}
